using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entities;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Collections;
using System.IO;


namespace DataAccess
{
    public class DataNextivaDAL
    {
        BaseDatos dbm = new BaseDatos();
        public ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();

        //Para realizar la escuchas de conexiones de clientes
        private TcpListener tcpLsn;
        //Datos de los clientes conectados
        private Hashtable Clientes = new Hashtable();
        private Thread tcpThd;
        //Último cliente conectado
        private System.Net.IPEndPoint IDClienteActual;
        private string m_PuertoDeEscucha;

        public event NuevaConexionEventHandler NuevaConexion;
        public delegate void NuevaConexionEventHandler(System.Net.IPEndPoint IDTerminal);
        public event DatosRecibidosEventHandler DatosRecibidos;
        public delegate void DatosRecibidosEventHandler(System.Net.IPEndPoint IDTerminal);
        public event ConexionTerminadaEventHandler ConexionTerminada;
        public delegate void ConexionTerminadaEventHandler(System.Net.IPEndPoint IDTerminal);

        public NextivaXMLConfig objXMl = new NextivaXMLConfig();
        public string AlarmSystem = "";
        public string AlarmType = "";
        public string AlarmMensage = "";
        public string AlarmTime = "";
        public string AlarmIP = "";

        public int OpcionSistema = 0;

        public int OpcionProcesoAlarmas = 0;
        public string OpcionRutaProcesoAlarmas = "";

        public ClaseClienteSocket socketCliente = new ClaseClienteSocket();

        public int ConvertToASCIIString(string var)
        {
            int int_ASCII = 0;

            string s = var;
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            int_ASCII = BitConverter.ToInt32(bytes, 0);

            return int_ASCII;

        }
        private void EsperarConexionCliente()
        {
            datosClienteConectado datosClienteActual = new datosClienteConectado();

            while (true)
            {
                try
                {
                    //Se guarda la información del cliente cuando se recibe la conexión
                    //Quedará esperando la conexión de un nuevo cliente
                   // datosClienteActual.socketConexion = tcpLsn.AcceptSocket();

                    //Con el IDClienteActual se identificará al cliente conectado
                    // IDClienteActual = datosClienteActual.socketConexion.RemoteEndPoint;

                    //Crear un hilo para que quede escuchando los mensajes del cliente
                    datosClienteActual.Thread = new Thread(LeerSocket);

                    //Agregar la información del cliente conectado al array
                    lock (this)
                    {
                        Clientes.Add(1, datosClienteActual);
                    }

                    //Generar evento NuevaConexion
                    if (NuevaConexion != null)
                    {
                        NuevaConexion(IDClienteActual);
                    }

                    //Iniciar el hilo que escuchará los mensajes del cliente
                    datosClienteActual.Thread.Start();

                }
                catch (Exception ex)
                {

                }

            }
        }

        private void LeerSocket()
        {
            System.Net.IPEndPoint IDReal = default(System.Net.IPEndPoint);
            //ID del cliente que se va a escuchar
            byte[] Recibir = null;
            //Array donde se guardarán los datos que lleguen
            datosClienteConectado InfoClienteActual = default(datosClienteConectado);
            //Datos del cliente conectado
            int Ret = 0;

            IDReal = IDClienteActual;
            //InfoClienteActual = Clientes(IDReal);


            while (true)
            {
                if (InfoClienteActual.socketConexion.Connected)
                {
                    Recibir = new byte[101];
                    try
                    {
                        //Esperar a que lleguen un mensaje desde el cliente
                        Ret = InfoClienteActual.socketConexion.Receive(Recibir, Recibir.Length, SocketFlags.None);
                        if (Ret > 0)
                        {
                            //Guardar mensaje recibido
                            InfoClienteActual.UltimosDatosRecibidos = Encoding.ASCII.GetString(Recibir);
                           // Clientes(IDReal) = InfoClienteActual;

                            //Generar el evento DatosRecibidos 
                            //para los datos recibidos
                            if (DatosRecibidos != null)
                            {
                                DatosRecibidos(IDReal);
                            }
                        }
                        else
                        {
                            //Generar el evento ConexionTerminada 
                            //de finalización de la conexión
                            if (ConexionTerminada != null)
                            {
                                ConexionTerminada(IDReal);
                            }
                            break; // TODO: might not be correct. Was : Exit While
                        }
                    }
                    catch (Exception e)
                    {
                        if (!InfoClienteActual.socketConexion.Connected)
                        {
                            //Generar el evento ConexionTerminada 
                            //de finalización de la conexión
                            if (ConexionTerminada != null)
                            {
                                ConexionTerminada(IDReal);
                            }
                            break; // TODO: might not be correct. Was : Exit While
                        }
                    }
                }
            }
            CerrarThread(IDReal);
        }
        private void CerrarThread(System.Net.IPEndPoint IDCliente)
        {
            datosClienteConectado InfoClienteActual = default(datosClienteConectado);

            //Finalizar el hilo (thread) iniciado 
            // encargado de escuchar al cliente
           // InfoClienteActual = Clientes(IDCliente);

            try
            {
                InfoClienteActual.Thread.Abort();
            }
            catch (Exception e)
            {
                lock (this)
                {
                    //Eliminar el cliente del array
                    Clientes.Remove(IDCliente);
                }
            }
        }
        private Boolean SendDataWithComunicationNextivaDAL(List<AlarmNextiva> ObjetoLista)
        {
            Boolean res = false;
            string pathString = "";
            string stringAscii = "";
            string fileName = "";
            string CameraName = "";
            int cantidad = 1;
            int cantidad2 = 1;
            int Numerocantidad = 1;
            string str_match = "";

          //  NextivaXMLConfig objXMl = new NextivaXMLConfig();

            SWGParams objParams = new SWGParams();
            int paramCustCompanyID =0;
            CustomerCompanyDataComuniDAL ObjCusData = new CustomerCompanyDataComuniDAL();
            DataSet DsCusData = new DataSet();
            DataSet DSDevice = new DataSet();
            DeviceDAL ObjDevice = new DeviceDAL();
            SWGParams ObjParam = new SWGParams();


            DateTime moment;
            moment = DateTime.Now;
            // Year gets 1999.
            int year = moment.Year;

            // Month gets 1 (January).
            int month = moment.Month;

            // Day gets 13.
            int day = moment.Day;

            // Hour gets 3.
            int hour = moment.Hour;

            // Minute gets 57.
            int minute = moment.Minute;

            // Second gets 32.
            int second = moment.Second;

            // Millisecond gets 11.
            int millisecond = moment.Millisecond;

            string DateTemp = Convert.ToString(moment.Year + "-" + moment.Month + "-" + moment.Day + "  " + moment.Hour + ":" + moment.Minute + ":" + moment.Second);


            foreach (AlarmNextiva objlista in ObjetoLista)
            {
                paramCustCompanyID = Convert.ToInt32(objlista.AlarmSentCustCompanyID);
                DsCusData = ObjCusData.CustomerCompanyDataComuniByCompanyIDDAL(paramCustCompanyID);
                DSDevice = ObjDevice.DeviceByIPDeviceDAL(objlista.AlarmSentIDE);
            }

            if (DSDevice.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dataRow in DSDevice.Tables[0].Rows)
                {
                    OpcionSistema = Convert.ToInt32(dataRow["SystemDeviceID"].ToString());
                }
            }

            if (DsCusData.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dataRow in DsCusData.Tables[0].Rows)
                {
                    // CustomerID = Convert.ToInt32(dataRow["CustomerCompanyID"].ToString());
                    CameraName = dataRow["CusCompanyDataCameraName"].ToString();
                    objXMl.XMLNextID = Convert.ToInt32(dataRow["CusCompanyDataIDE"].ToString());
                    objXMl.XMLNextNiveles = dataRow["CusCompanyDataNextNiveles"].ToString();
                    objXMl.XMLNextSiteName = dataRow["CusCompanyDataSiteName"].ToString();
                    objXMl.XMLNextSiteNameUrl = dataRow["CusCompanyDataNameUrl"].ToString();
                    objXMl.XMLNextSiteUser = dataRow["CusCompanyDataSiteUser"].ToString();
                    objXMl.XMLNextSitePass = dataRow["CusCompanyDataSitePass"].ToString();
                    objXMl.XMLNextAlarmSite = dataRow["CusCompanyDataAlarmSite"].ToString();
                    objXMl.XMLNextListenResponse = dataRow["CusCompanyDataListenResponse"].ToString();
                    objXMl.XMLNextListenError = dataRow["CusCompanyDataListenError"].ToString();
                    objXMl.XMLNextPathString = dataRow["CusCompanyDataPathString"].ToString();
                    objXMl.XMLNextFileName = dataRow["CusCompanyDataFileName"].ToString();
                }
            }
            //CameraName = "Domo PTZ";
            //objXMl.XMLNextID = 1;
            //objXMl.XMLNextNiveles = "DEBUG"; // "INFO";
            //objXMl.XMLNextSiteName = "VM-33-S12-N75";
            //objXMl.XMLNextSiteNameUrl = "tcp://192.168.10.33:5005";
            //objXMl.XMLNextSiteUser = "Administrator";
            //objXMl.XMLNextSitePass = "cctvware";
            //objXMl.XMLNextAlarmSite = "VM-33-S12-N75";
            //objXMl.XMLNextListenResponse = "OK10;";
            //objXMl.XMLNextListenError = "ERROR10;";
            //objXMl.XMLNextPathString = @"\\VM-33-S12-N75\Verint\AlarmInterface\";
            //objXMl.XMLNextFileName = "config.xml";


            //public int OptionSysNextiva64 = 1;
            //public int OptionSysNextiva75 = 5;
            //public int OptionSysAvigilon5 = 6;
            //public int OptionSysAvigilon6 = 8;
            //public int OptionSysGanz = 10;

            OpcionSistema = 8;

            if (OpcionSistema == SWGParams.OptionSysNextiva64 || OpcionSistema == SWGParams.OptionSysNextiva75)
            {
                if (OpcionSistema == SWGParams.OptionSysNextiva64)
                {
                    OpcionRutaProcesoAlarmas = SWGParams.OptionPathNextiva64;
                }

                if (OpcionSistema == SWGParams.OptionSysNextiva75)
                {
                    OpcionRutaProcesoAlarmas = SWGParams.OptionPathNextiva75;
                }
                OpcionProcesoAlarmas = 1;
            }

            if (OpcionSistema == SWGParams.OptionSysAvigilon5 || OpcionSistema == SWGParams.OptionSysAvigilon6)
            {

                if (OpcionSistema == SWGParams.OptionSysAvigilon5)
                {
                    OpcionRutaProcesoAlarmas = SWGParams.OptionPathAvigilon5;

                }

                if (OpcionSistema == SWGParams.OptionSysAvigilon6)
                {
                    OpcionRutaProcesoAlarmas = SWGParams.OptionPathAvigilon6;
                }

                OpcionProcesoAlarmas = 2;
            }

            if (OpcionSistema == SWGParams.OptionSysGanz)
            {

                if (OpcionSistema == SWGParams.OptionSysGanz)
                {
                    OpcionRutaProcesoAlarmas = SWGParams.OptionPathGanz;

                }
                OpcionProcesoAlarmas = 3;
            }

            pathString = OpcionRutaProcesoAlarmas;
            // pathString = objXMl.XMLNextPathString;
            fileName = objXMl.XMLNextFileName;
           
           // string strTest = "";
            if (!String.IsNullOrEmpty(pathString) && !String.IsNullOrEmpty(fileName))
            {
                try
                {
                    string str = "";
                    str += "<config>";
                    str += "<!-- Sample configuration file -->" ;
                    str += "<Logging filename='Logging/NextivaAlarmServer.log' level='" + objXMl.XMLNextNiveles + "' daysToLive='7'/>";
                    str += "<tcpPort name='tcp' port='8081'/>";
                    str += "<comPort name='com' port='COM1' baud='9600' dataBits='8' parity='none' stopBits='1' handshake='none'/>";
                    str += "<site name='" + objXMl.XMLNextSiteName + "' url='" + objXMl.XMLNextSiteNameUrl + "' username='" + objXMl.XMLNextSiteUser + "' password='" + objXMl.XMLNextSitePass + "'/>";
                    str += "<alarm site='" + objXMl.XMLNextAlarmSite + "'/>";
                    str += "<listener input='tcp' separator='!' response='" + objXMl.XMLNextListenResponse + "' error='" + objXMl.XMLNextListenError + "'>";

                    foreach (AlarmNextiva objlista in ObjetoLista)
                    {
                        AlarmType = objlista.AlarmSentRuleID.ToString();
                        AlarmMensage = objlista.AlarmSentRuleDescrip.ToString();
                        AlarmTime = DateTemp.ToString();
                        AlarmIP = objlista.AlarmSentIDE;

                        str += "<rule response='" + objXMl.XMLNextListenResponse + "'>" ;
                        str += "<match contains='AlarmMsg'/>" ;
                        str += "<event site='" + objXMl.XMLNextAlarmSite + "' id='1' argument='prueba de analitica  " + objlista.AlarmSentRuleDescrip + "'>" ;
                        str += "<camera number='" + CameraName + "' preset='" + VerifyVCAAlarmasRules(objlista.AlarmSentRuleID) + "'/>";
                        str += "</event>" ;
                        str += "</rule>";
                        cantidad2++;
                    }
                    str += "</listener>" ;
                    str += "</config>";

                    string mensaje = str; // "prueba de analitica";

                    OpcionProcesoAlarmas = 1;

                    if (!String.IsNullOrEmpty(mensaje))
                    {
                        switch (OpcionProcesoAlarmas)
                        {
                            case 1:
                                        string pathStringFinal = System.IO.Path.Combine(pathString, fileName);
                                        using (System.IO.FileStream fs = System.IO.File.Create(pathStringFinal))
                                        {
                                            for (byte i = 0; i < 100; i++)
                                            {
                                                fs.WriteByte(i);
                                            }
                                        }

                                        System.IO.File.WriteAllText(pathString + fileName, str);
                                        using (TcpClient clientSocket = new TcpClient())
                                        {
                                            clientSocket.Connect(ObjParam.IpSystemaDestino, ObjParam.PuertoSystemaDestino);
                                            //clientSocket.Connect("192.168.10.33", 8081);
                                            NetworkStream serverStream = clientSocket.GetStream();
                                            byte[] arrayMsg = Encoding.ASCII.GetBytes(mensaje);
                                            byte[] mensajeFinal = arrayMsg, enviarServidor;
                                            serverStream.WriteTimeout = 2000;
                                            serverStream.Write(mensajeFinal, 0, mensajeFinal.Length);
                                            serverStream.Flush();
                                            byte[] inStream = new byte[10025];
                                            serverStream.ReadTimeout = 2000;
                                            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                                            string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                                            int respuesta = int.Parse(returndata);
                                        }

                                    break;

                            case 2:
                                      
                               
                                        ClaseServidorSocket socketServidor = new ClaseServidorSocket();
                                        string strtempAvi6 = "";
                                        AlarmSystem = "AVIGILON";

                                        strtempAvi6 += "<config>";
                                            strtempAvi6 += "<!-- Sample configuration AVIGILON file -->";
                                            strtempAvi6 += "<AlarmSystem>" + AlarmSystem + "</AlarmSystem>";
                                            strtempAvi6 += "<AlarmType>" + AlarmType + "</AlarmType>";
                                            strtempAvi6 += "<AlarmMensage>" + AlarmMensage + "</AlarmMensage>";
                                            strtempAvi6 += "<AlarmTime>" + AlarmTime + "</AlarmTime>";
                                            strtempAvi6 += "<AlarmIP>" + AlarmIP + "</AlarmIP>";
                                            strtempAvi6 += "</config>";
                                        mensaje = strtempAvi6;
                                        //socketCliente.EnviarDatos(mensaje);
                                        socketServidor.enviarMensajeTodosClientes(mensaje);



                                        //socketCliente.Desconectar();
                                        //socketServidor.DetenerEscucha();

                                       //  datosClienteConectado Cliente = default(datosClienteConectado);
                                       //// enviarMensajeCliente(Cliente.socketConexion.RemoteEndPoint, Datos);
                                       //  Cliente.socketConexion.Send(Encoding.ASCII.GetBytes(mensaje));
                                        //using (TcpClient clientSocket = new TcpClient())
                                        //{
                                        //    //if (OpcionSistema == SWGParams.OptionSysAvigilon5)
                                        //    //{
                                        //    //    clientSocket.Connect(ObjParam.IpSystemaDestAvigilon5, ObjParam.PuertoSystemaDestAvigilon5);
                                        //    //}

                                        //    //if (OpcionSistema == SWGParams.OptionSysAvigilon6)
                                        //    //{
                                        //    //    clientSocket.Connect(ObjParam.IpSystemaDestAvigilon6, ObjParam.PuertoSystemaDestAvigilon6);
                                        //    //}
                                        //    // Aca Faltaria el puerto que avigilon reciva

                                        //    //clientSocket.Connect("192.168.10.104", 5020);
                                        //    //NetworkStream serverStream = clientSocket.GetStream();
                                        //    //byte[] arrayMsg = Encoding.ASCII.GetBytes(mensaje);
                                        //    //byte[] mensajeFinal = arrayMsg, enviarServidor;
                                        //    //serverStream.WriteTimeout = 10000;
                                        //    //serverStream.Write(mensajeFinal, 0, mensajeFinal.Length);
                                        //    //serverStream.Flush();
                                        //    //byte[] inStream = new byte[10025];
                                        //    //serverStream.ReadTimeout = 10000;
                                        //    //serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                                        //    //string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                                        //    //int respuesta = int.Parse(returndata);   
                                        //}

                                    break;
                            case 3:
                                             string strtempGanz = "";
                                             AlarmSystem = "GANZ";
                                             strtempGanz += "<AlarmSystem>" + AlarmSystem + "</AlarmSystem>";
                                             strtempGanz += "<AlarmType>" + AlarmType + "</AlarmType>";
                                             strtempGanz += "<AlarmMensage>" + AlarmMensage + "</AlarmMensage>";
                                             strtempGanz += "<AlarmTime>" + AlarmTime + "</AlarmTime>";
                                             strtempGanz += "<AlarmIP>" + AlarmIP + "</AlarmIP>";
                                             mensaje = strtempGanz;

                                                using (TcpClient clientSocket = new TcpClient())
                                                {
                                                    clientSocket.Connect("192.168.10.32", 38880);
                                                    NetworkStream serverStream = clientSocket.GetStream();
                                                    byte[] arrayMsg = Encoding.ASCII.GetBytes(mensaje);
                                                    byte[] mensajeFinal = arrayMsg, enviarServidor;
                                                    serverStream.WriteTimeout = 2000;
                                                    serverStream.Write(mensajeFinal, 0, mensajeFinal.Length);
                                                    serverStream.Flush();
                                                    byte[] inStream = new byte[10025];
                                                    serverStream.ReadTimeout = 2000;
                                                    serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                                                    string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                                                    int respuesta = int.Parse(returndata);
                                                }

                                    break;
                        }
                    }
                    
                    
                    //if (!String.IsNullOrEmpty(mensaje))
                    //{

                    //    switch (OpcionSistema)
                    //    {
                    //        case 10:
                    //             string strtempGanz = "";
                    //             strtempGanz += "<AlarmType>" + AlarmType + "</AlarmType>";
                    //             strtempGanz += "<AlarmMensage>" + AlarmMensage + "</AlarmMensage>";
                    //             strtempGanz += "<AlarmTime>" + AlarmTime + "</AlarmTime>";
                    //             strtempGanz += "<AlarmIP>" + AlarmIP + "</AlarmIP>";
                    //             mensaje = strtempGanz;

                    //                using (TcpClient clientSocket = new TcpClient())
                    //                {
                    //                    clientSocket.Connect("192.168.10.32", 38880);
                    //                    NetworkStream serverStream = clientSocket.GetStream();
                    //                    byte[] arrayMsg = Encoding.ASCII.GetBytes(mensaje);
                    //                    byte[] mensajeFinal = arrayMsg, enviarServidor;
                    //                    serverStream.WriteTimeout = 2000;
                    //                    serverStream.Write(mensajeFinal, 0, mensajeFinal.Length);
                    //                    serverStream.Flush();
                    //                    byte[] inStream = new byte[10025];
                    //                    serverStream.ReadTimeout = 2000;
                    //                    serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                    //                    string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                    //                    int respuesta = int.Parse(returndata);
                    //                }
                    //            break;
                    //        case 1:

                    //            System.IO.File.WriteAllText(pathString + fileName, str);

                    //            using (TcpClient clientSocket = new TcpClient())
                    //            {
                    //                clientSocket.Connect(ObjParam.IpSystemaDestino, ObjParam.PuertoSystemaDestino);
                    //                //clientSocket.Connect("192.168.10.33", 8081);
                    //                NetworkStream serverStream = clientSocket.GetStream();
                    //                byte[] arrayMsg = Encoding.ASCII.GetBytes(mensaje);
                    //                byte[] mensajeFinal = arrayMsg, enviarServidor;
                    //                serverStream.WriteTimeout = 2000;
                    //                serverStream.Write(mensajeFinal, 0, mensajeFinal.Length);
                    //                serverStream.Flush();
                    //                byte[] inStream = new byte[10025];
                    //                serverStream.ReadTimeout = 2000;
                    //                serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                    //                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                    //                int respuesta = int.Parse(returndata);
                    //            }
                    //            break;
                    //        case 2:
                    //            Console.WriteLine(1);
                    //            break;
                    //        case 3:
                    //            Console.WriteLine(1);
                    //            break;
                    //        case 4:
                    //            Console.WriteLine(1);
                    //            break;
                    //        case 5:

                    //            System.IO.File.WriteAllText(pathString + fileName, str);

                    //            using (TcpClient clientSocket = new TcpClient())
                    //            {
                    //                clientSocket.Connect(ObjParam.IpSystemaDestino, ObjParam.PuertoSystemaDestino);
                    //                //clientSocket.Connect("192.168.10.33", 8081);
                    //                NetworkStream serverStream = clientSocket.GetStream();
                    //                byte[] arrayMsg = Encoding.ASCII.GetBytes(mensaje);
                    //                byte[] mensajeFinal = arrayMsg, enviarServidor;
                    //                serverStream.WriteTimeout = 2000;
                    //                serverStream.Write(mensajeFinal, 0, mensajeFinal.Length);
                    //                serverStream.Flush();
                    //                byte[] inStream = new byte[10025];
                    //                serverStream.ReadTimeout = 2000;
                    //                serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                    //                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                    //                int respuesta = int.Parse(returndata);
                    //            }
                    //            break;
                    //        case 6:

                    //            string pathStringTemp = @"\\VM-32-S12-Avigilon 6.x\Avigilon\";
                    //            string  fileNameTemp = "config.xml";

                    //          //  CreateFilePathRemote(pathStringTemp, fileNameTemp, ObjetoLista);
                    //            // enviarMensajeTodosClientes(str);

                    //            string strtempAvi6 = "";
                    //            strtempAvi6 += "<AlarmType>" + AlarmType + "</AlarmType>";
                    //            strtempAvi6 += "<AlarmMensage>" + AlarmMensage + "</AlarmMensage>";
                    //            strtempAvi6 += "<AlarmTime>" + AlarmTime + "</AlarmTime>";
                    //            strtempAvi6 += "<AlarmIP>" + AlarmIP + "</AlarmIP>";
                    //            mensaje = strtempAvi6;

                    //            using (TcpClient clientSocket = new TcpClient())
                    //            {
                    //                clientSocket.Connect("192.168.10.32", 38880);
                    //                NetworkStream serverStream = clientSocket.GetStream();
                    //                byte[] arrayMsg = Encoding.ASCII.GetBytes(mensaje);
                    //                byte[] mensajeFinal = arrayMsg, enviarServidor;
                    //                serverStream.WriteTimeout = 2000;
                    //                serverStream.Write(mensajeFinal, 0, mensajeFinal.Length);
                    //                serverStream.Flush();
                    //                byte[] inStream = new byte[10025];
                    //                serverStream.ReadTimeout = 2000;
                    //                serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                    //                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                    //                int respuesta = int.Parse(returndata);
                    //            }

                    //             break;
                    //        case 8:
                    //             string pathStringTemp2 = @"\\VM-32-S12-Avigilon 6.x\Avigilon\";
                    //            string  fileNameTemp2 = "config.xml";

                    //          //  CreateFilePathRemote(pathStringTemp2, fileNameTemp2, ObjetoLista);
                    //            // enviarMensajeTodosClientes(str);

                    //            string strtempAvi5 = "";
                    //            strtempAvi5 += "<AlarmType>" + AlarmType + "</AlarmType>";
                    //            strtempAvi5 += "<AlarmMensage>" + AlarmMensage + "</AlarmMensage>";
                    //            strtempAvi5 += "<AlarmTime>" + AlarmTime + "</AlarmTime>";
                    //            strtempAvi5 += "<AlarmIP>" + AlarmIP + "</AlarmIP>";
                    //            mensaje = strtempAvi5;

                    //            using (TcpClient clientSocket = new TcpClient())
                    //            {
                    //                clientSocket.Connect("192.168.10.32", 38880);
                    //                NetworkStream serverStream = clientSocket.GetStream();
                    //                byte[] arrayMsg = Encoding.ASCII.GetBytes(mensaje);
                    //                byte[] mensajeFinal = arrayMsg, enviarServidor;
                    //                serverStream.WriteTimeout = 2000;
                    //                serverStream.Write(mensajeFinal, 0, mensajeFinal.Length);
                    //                serverStream.Flush();
                    //                byte[] inStream = new byte[10025];
                    //                serverStream.ReadTimeout = 2000;
                    //                serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                    //                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                    //                int respuesta = int.Parse(returndata);
                    //            }

                    //            break;
                    //    }
                    //    res = true;
                    //}
                    //else {
                    //    res = false;
                    //}  
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error de SQL :" + e.Message);
                    ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                    objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DataNextivaDAL/SendDataWithComunicationNextivaDAL");
                }
                catch (SocketException ex)
                {
                    Console.WriteLine("Error :" + ex.Message);
                    ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                    objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/SendDataWithComunicationNextivaDAL");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error :" + e.Message);
                    ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                    objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DataNextivaDAL/SendDataWithComunicationNextivaDAL");
                }
            }
            return res;
        }

        public void enviarMensajeTodosClientes(string Datos)
        {
	            datosClienteConectado Cliente = default(datosClienteConectado);

	       // foreach ( Cliente in Clientes.Values) {
		       // enviarMensajeCliente(Cliente.socketConexion.RemoteEndPoint, Datos);
                Cliente.socketConexion.Send(Encoding.ASCII.GetBytes(Datos));
	       // }
        }

        private void enviarMensajeCliente(EndPoint endPoint, string Datos)
        {
         //   throw new NotImplementedException();

            datosClienteConectado Cliente = default(datosClienteConectado);

            //Obtener información del cliente al que se enviará el mensaje
            // Cliente = Clientes(IDCliente);

            //Enviar mensaje a cliente
            Cliente.socketConexion.Send(Encoding.ASCII.GetBytes(Datos));
        }
        public void IniciarEscucha(int Puerto)
        {
            tcpLsn = new TcpListener(Puerto);

            //Iniciar escucha
            tcpLsn.Start();
            //EsperarConexionCliente()

            //Crear hilo para dejar escuchando la conexión de clientes
            tcpThd = new Thread(EsperarConexionCliente);
            tcpThd.Start();
        }

        private Stream mensajesEnviarRecibir;
        private Thread hiloMensajeServidor;

        public void Conectar(string IP, int Puerto)
        {
            TcpClient clienteTCP = new TcpClient();

             try {
                    //Conectar con el servidor
                    clienteTCP.Connect(IP, Puerto);
                    mensajesEnviarRecibir = clienteTCP.GetStream();
                    //Crear hilo para establecer escucha de posibles mensajes
                    //enviados por el servidor al cliente
                    hiloMensajeServidor = new Thread(LeerSocket);
                    hiloMensajeServidor.Start();

             }catch (SocketException ex){
                 Console.WriteLine("Error :" + ex.Message);
                 ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                 objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/Conectar");
             }catch (Exception e){
                 Console.WriteLine("Error :" + e.Message);
                 ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                 objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DataNextivaDAL/Conectar");
             }
        }
        private void CreateFilePathRemote(string paths, string fileName, List<AlarmNextiva> ObjetoLista)
        {
            try {
                
                string CameraName = "Avigilon";
                objXMl.XMLNextID = 1;
                objXMl.XMLNextNiveles = "DEBUG"; // "INFO";
                objXMl.XMLNextSiteName = "VM-32-S12-Avigilon 6.x";
                objXMl.XMLNextSiteNameUrl = "tcp://192.168.10.32:80";
                objXMl.XMLNextSiteUser = "Administrator";
                objXMl.XMLNextSitePass = "cctvware";
                objXMl.XMLNextAlarmSite = "VM-32-S12-Avigilon 6.x";
                objXMl.XMLNextListenResponse = "OK10;";
                objXMl.XMLNextListenError = "ERROR10;";
                objXMl.XMLNextPathString = @"\\VM-32-S12-Avigilon 6.x\Avigilon"; ;
                objXMl.XMLNextFileName = "config.xml";

                string pathStringFinal = System.IO.Path.Combine(paths, fileName);
                using (System.IO.FileStream fs = System.IO.File.Create(pathStringFinal))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }

                if (!String.IsNullOrEmpty(paths) && !String.IsNullOrEmpty(fileName))
                {
                    string str = "";
                    str += "<config>";
                    str += "<!-- Sample configuration file -->";
                    str += "<Logging filename='Logging/NextivaAlarmServer.log' level='" + objXMl.XMLNextNiveles + "' daysToLive='7'/>";
                    str += "<tcpPort name='tcp' port='8081'/>";
                    str += "<comPort name='com' port='COM1' baud='9600' dataBits='8' parity='none' stopBits='1' handshake='none'/>";
                    str += "<site name='" + objXMl.XMLNextSiteName + "' url='" + objXMl.XMLNextSiteNameUrl + "' username='" + objXMl.XMLNextSiteUser + "' password='" + objXMl.XMLNextSitePass + "'/>";
                    str += "<alarm site='" + objXMl.XMLNextAlarmSite + "'/>";
                    str += "<listener input='tcp' separator='!' response='" + objXMl.XMLNextListenResponse + "' error='" + objXMl.XMLNextListenError + "'>";
                   
                    foreach (AlarmNextiva objlista in ObjetoLista)
                    {
                        str += "<rule response='" + objXMl.XMLNextListenResponse + "'>";
                        str += "<match contains='AlarmMsg'/>";
                        str += "<event site='" + objXMl.XMLNextAlarmSite + "' id='1' argument='Alarma Avigilon  " + objlista.AlarmSentRuleDescrip + "'>";
                        str += "<camera number='" + CameraName + "' preset='" + VerifyVCAAlarmasRules(objlista.AlarmSentRuleID) + "'/>";
                        str += "</event>";
                        str += "</rule>";
                    }

                    str += "</listener>";
                    str += "</config>";
                    System.IO.File.WriteAllText(paths + fileName, str);
                }
            
            }catch (SocketException ex){

                    Console.WriteLine("Error :" + ex.Message);
                    ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                    objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/CreateFilePathRemote");
            }

            catch (Exception e){

                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DataNextivaDAL/CreateFilePathRemote");
            }
        }

        //Procedimiento para establecer el servidor en modo escucha
        //public void IniciarEscucha()
        //{
        //    SWGParams ObjParam = new SWGParams();
        //    int Puerto = 7788; // ObjParam.PuertoCallOpenSocket;
        //    tcpLsn = new TcpListener(Puerto);
        //     try {
        //        //Iniciar escucha
        //        tcpLsn.Start();
        //        //Crear hilo para dejar escuchando la conexión de clientes
        //        EsperarConexionCliente();
        //        tcpThd = new Thread(EsperarConexionCliente);
        //        //tcpThd =
        //        tcpThd.Start();
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine("Error :" + ex.Message);
        //         ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
        //         objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/IniciarEscucha");
        //     }
        //}

        public void enviarMensajeTodosClientesDemo(string Datos)
        {
	        datosClienteConectado Clientes = default(datosClienteConectado);

	       // foreach ( Clientes in Client.Values) {
          //  enviarMensajeClientes(Clientes.socketConexion.RemoteEndPoint, Datos);
	       // }
        }
        public void enviarMensajeClientes(System.Net.IPEndPoint IDCliente, string Datos)
        {
            datosClienteConectado Cliente = default(datosClienteConectado);

            //Obtener información del cliente al que se enviará el mensaje
           // Cliente = Clientes(IDCliente);

            //Enviar mensaje a cliente
            Cliente.socketConexion.Send(Encoding.ASCII.GetBytes(Datos));
        }
        //public  void enviarMensajeTodosClientes(string Datos){

        //    IniciarEscucha();

        //    datosClienteConectado Cliente = new datosClienteConectado();
        //   // enviarMensajeCliente(Cliente.socketConexion.RemoteEndPoint, Datos);
        //   // Cliente.socketConexion = 
        //    try
        //    {
        //        Cliente.socketConexion.Send(Encoding.ASCII.GetBytes(Datos));

        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        Console.WriteLine("Error :" + ex.Message);
        //        ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
        //        objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/enviarMensajeTodosClientes");
        //    }
        //    catch (ObjectDisposedException ex)
        //    {
        //        Console.WriteLine("Error :" + ex.Message);
        //        ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
        //        objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/enviarMensajeTodosClientes");
        //    }
        //    catch (SocketException ex)
        //    {
        //        Console.WriteLine("Error :" + ex.Message);
        //        ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
        //        objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/enviarMensajeTodosClientes");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error :" + ex.Message);
        //        ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
        //        objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/enviarMensajeTodosClientes");
        //    }

        //   DetenerEscucha();
        //}
        //Procedimiento para detener la escucha del servidor
        public void DetenerEscucha()
        {
           // CerrarTodosClientes();
            tcpThd.Abort();
            tcpLsn.Stop();
        }
        //Cerrar todas la conexión de todos los clientes conectados
        public void CerrarTodosClientes()
        {
            datosClienteConectado InfoClienteActual = new datosClienteConectado();
            //List<datosClienteConectado> list = new List<datosClienteConectado>();
            ////Cerrar conexión de todos los clientes
            //foreach ( list in Clientes.Values) {
              //  cerrarConexionCliente(InfoClienteActual.socketConexion.RemoteEndPoint);
            //}
        }

        public void cerrarConexionCliente(System.Net.IPEndPoint IDCliente)
        {
            datosClienteConectado InfoClienteActual = default(datosClienteConectado);

            //Obtener información del cliente indicado
          //  InfoClienteActual = Clientes(IDCliente);

            //Cerrar conexión con cliente
            InfoClienteActual.socketConexion.Close();
        }
      public void enviarMensajeCliente(System.Net.IPEndPoint IDCliente, string Datos)
      {
         datosClienteConectado Cliente = new datosClienteConectado();

        //'Obtener información del cliente al que se enviará el mensaje
        //Cliente.  (IDCliente);
       // 'Enviar mensaje a cliente
         Cliente.socketConexion.Send(Encoding.ASCII.GetBytes(Datos));
    
      }
        public int GetLastIDE(int idchannel)
        {
            SqlConnection con = new SqlConnection();
		    SqlParameter parametros;
            int    int_lastID =0;
		    try
		    {
			    con = dbm.getConexion();
			    con.Open();
                SqlCommand cmd = new SqlCommand("SWG_select_LastAlarmSentNextiva_by_ID", con);
			    parametros = cmd.Parameters.Add("@AlarmSentChannel", SqlDbType.Int);
			    parametros.Value = idchannel;
			    cmd.CommandType = CommandType.StoredProcedure;
			    SqlDataReader dr = cmd.ExecuteReader();
			    while (dr.Read())
			    {
                    int_lastID = dr.GetInt32(0);
			    }
			    con.Close();
		    }
		    catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
		    catch (Exception e) { Console.WriteLine("Error :" + e.Message); }

		    return int_lastID;
        }

        private string FormarCameraIde(int idchannel)
        {
            string resp = "";
            string idchannels = Convert.ToString(idchannel);
            if (idchannels.Length > 0)
            {
                resp = "000" + idchannels;
            }
            if (idchannels.Length > 1 && idchannels.Length < 3)
            {
                resp = "00" + idchannel;
            }
            if (idchannels.Length > 2 && idchannels.Length < 4)
            {
                resp = "0" + idchannels;
            }
            if (idchannels.Length > 3 && idchannels.Length == 4)
            {
                resp = idchannels;
            }
            return resp;

        }
        public Boolean SendDataCameraToNextivaDAL(List<AlarmNextiva> Objeto)
        {
            Boolean res = false;
            try
            {
                //VA A FUNCION QUE CREA XML
                res = SendDataWithComunicationNextivaDAL(Objeto);

                //if (res == true)
                //{
                    //RECORRE LISTA , LLENA ENTIDAD Y GRABA EN BASE DATOS
                    foreach (AlarmNextiva objlista in Objeto)
                    {
                        AlarmNextiva enti = new AlarmNextiva();
                        enti.AlarmSentIDE = objlista.AlarmSentIDE;
                        enti.AlarmSentChannel = objlista.AlarmSentChannel;
                        enti.AlarmSentState = objlista.AlarmSentState;
                        enti.AlarmSentventType = objlista.AlarmSentventType;
                        enti.AlarmSentRuleID = objlista.AlarmSentRuleID;
                        enti.AlarmSentTargetID = objlista.AlarmSentTargetID;
                        enti.AlarmSentTargetType = objlista.AlarmSentTargetType;
                        enti.AlarmSentrctTarget = objlista.AlarmSentrctTarget;
                        enti.AlarmSentTargetSpeed = objlista.AlarmSentTargetSpeed;
                        enti.AlarmSentTargetDirection = objlista.AlarmSentTargetDirection;
                        enti.AlarmSentDescription =  objlista.AlarmSentDescription;
                        enti.AlarmSentEstado = objlista.AlarmSentEstado;
                        enti.AlarmSentCustCompanyID = objlista.AlarmSentCustCompanyID;

                        if (IngrDataCameraToNextivaSQLDAL(enti) == true)
                        {

                        }else{
                            Console.WriteLine("Occurio un Error de Ingreso SQL");
                            ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                            objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :Occurio un Error de Ingreso SQL", 1, 1, "DataNextivaDAL/SendDataCameraToNextivaDAL");
                        }
                    }
                    res = true;
                //}else{
                //    res = false;
                //}
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error de SQL :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DataNextivaDAL/SendDataCameraToNextivaDAL");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DataNextivaDAL/SendDataCameraToNextivaDAL");
            }
            return res;
        }

        public Boolean UpdateStateDataCameraToNextivaSQLDAL(int AlarmSentID, int AlarmSentEstado)
        {

            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {
                con = dbm.getConexion();
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_UpdateState_AlarmSentNextiva", con);
                parametros = cmd.Parameters.Add("@AlarmSentID", SqlDbType.Int);
                parametros.Value = AlarmSentID;
                parametros = cmd.Parameters.Add("@AlarmSentEstado", SqlDbType.Int);
                parametros.Value = AlarmSentEstado;

                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    esExito = true;
                }

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/UpdateStateDataCameraToNextivaSQLDAL");
                esExito = false;
            }
            return esExito;
        }
        public Boolean IngrDataCameraToNextivaSQLDAL(AlarmNextiva ObjAlarm)
        {

            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {

                con = dbm.getConexion();
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Insert_AlarmSentNextiva", con);
                parametros = cmd.Parameters.Add("@AlarmSentIDE", SqlDbType.VarChar);
                parametros.Value = ObjAlarm.AlarmSentIDE;
                parametros = cmd.Parameters.Add("@AlarmSentChannel", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentChannel;
                parametros = cmd.Parameters.Add("@AlarmSentState", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentState;
                parametros = cmd.Parameters.Add("@AlarmSentventType", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentventType;
                parametros = cmd.Parameters.Add("@AlarmSentRuleID", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentRuleID;
                parametros = cmd.Parameters.Add("@AlarmSentTargetID", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentTargetID;
                parametros = cmd.Parameters.Add("@AlarmSentTargetType", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentTargetType;
                parametros = cmd.Parameters.Add("@AlarmSentrctTarget", SqlDbType.VarChar);
                parametros.Value = ObjAlarm.AlarmSentrctTarget;
                parametros = cmd.Parameters.Add("@AlarmSentTargetSpeed", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentTargetSpeed;
                parametros = cmd.Parameters.Add("@AlarmSentTargetDirection", SqlDbType.VarChar);
                parametros.Value = ObjAlarm.AlarmSentTargetDirection;
                parametros = cmd.Parameters.Add("@AlarmSentDescription", SqlDbType.VarChar);
                parametros.Value = ObjAlarm.AlarmSentDescription;
                parametros = cmd.Parameters.Add("@AlarmSentEstado", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentEstado;
                parametros = cmd.Parameters.Add("@CustomerCompanyID", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentCustCompanyID;

                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    esExito = true;
                }

                con.Close();
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/IngrDataCameraToNextivaSQLDAL");
            
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/IngrDataCameraToNextivaSQLDAL");
                esExito = false;
            }
            return esExito;
        }
        public DataSet GetDataProcessedNextivaByParametersDAL(int AlarmSentRuleID ,int CustomerCompanyID ,DateTime FechaInicio ,DateTime FechaFin )
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            SqlParameter parametros;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_select_DataNextiva_by_Parameters", con);
                parametros = cmd.Parameters.Add("@AlarmSentRuleID", SqlDbType.Int);
                parametros.Value = AlarmSentRuleID;
                parametros = cmd.Parameters.Add("@CustomerCompanyID", SqlDbType.Int);
                parametros.Value = CustomerCompanyID;
                parametros = cmd.Parameters.Add("@FechaInicio", SqlDbType.DateTime);
                parametros.Value = FechaInicio;
                parametros = cmd.Parameters.Add("@FechaFin", SqlDbType.DateTime);
                parametros.Value = FechaFin;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                con.Close();
                return ds;
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/GetDataProcessedNextivaByParametersDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/GetDataProcessedNextivaByParametersDAL");

            }
            return null;
        }
        public DataSet GetDataProcessedNextivaByDatesDAL(DateTime FechaInicio, DateTime FechaFin)
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            SqlParameter parametros;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("[SWG_select_DataNextiva_By_Dates]", con);
                parametros = cmd.Parameters.Add("@fechaIni", SqlDbType.DateTime);
                parametros.Value = FechaInicio;
                parametros = cmd.Parameters.Add("@fechaFin", SqlDbType.DateTime);
                parametros.Value = FechaFin;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/GetDataProcessedNextivaByDatesDAL");

            }
            return null;
        }
        public DataSet GetAllDataProcessedNextivaDAL()
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_select_DataNextiva", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                con.Close();
                return ds;
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/GetAllDataProcessedNextivaDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/GetAllDataProcessedNextivaDAL");
               
            }
            return null;
        }

        public DataSet SearchDataNextivaByID_DAL(string IDECamera)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            try
            {
                ////cmd.Connection = new SqlConnection("Data Source=MOVTOSHIPAPA\\SQLSERVER2005;Initial Catalog=DB_DAWPECEI;User Id=sa;Password=lcdp");
                ////temporal conexion , se quita despues
                //string StrConn = "Data Source=MOVTOSHIPAPA\\SQLSERVER2005;Initial Catalog=DB_DAWPECEI;User Id=sa;Password=lcdp";

                //cmd.Connection = new SqlConnection(StrConn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "SWG_select_DataNextiva_by_ID";

                //cmd.Parameters.Add("@IDECamera", SqlDbType.VarChar, 15).Value = IDECamera;

                //cmd.Connection.Open();
                //cmd.ExecuteNonQuery();
                //sda.Fill(ds);
                //cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
            }
            return ds;
        }

        private int VerifyVCAAlarmasRules(int codigo)
        {
            int presentEvent = 0;
            int caseSwitch = codigo;
            switch (caseSwitch)
            {
                case 6:
                    presentEvent = 1;
                    break;
                case 7:
                    presentEvent = 1;
                    break;
                case 8:
                    presentEvent = 2;
                    break;
                case 12:
                    presentEvent = 3;
                    break;
                case 13:
                    presentEvent = 1;
                    break;
                case 14:
                    presentEvent = 2;
                    break;
                case 15:
                    presentEvent = 3;
                    break;
                case 16:
                    presentEvent = 1;
                    break;
                default:
                    presentEvent = 1;
                    break;
            }


            return presentEvent;
        }

    }
}
