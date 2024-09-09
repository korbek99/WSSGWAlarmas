using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace DataAccess
{
   public class ClaseClienteSocket
    {
        //Para enviar y recibir datos del servidor
        private Stream mensajesEnviarRecibir;
        //Dirección IP
        private string ipServidor;
        //Puerto de escucha
        private string puertoServidor;

        private TcpClient clienteTCP;
        //Escuchar mensajes enviados desde el servidor
        private Thread hiloMensajeServidor;


        public event ConexionTerminadaEventHandler ConexionTerminada;
        public delegate void ConexionTerminadaEventHandler();
        public event DatosRecibidosEventHandler DatosRecibidos;
        public delegate void DatosRecibidosEventHandler(string datos);

        //Dirección IP del servidor al que nos conectaremos
        public string IP
        {
            get { return ipServidor; }

            set { ipServidor = value; }
        }

        //Puerto por el que realizar la conexión al servidor
        public int Puerto
        {
            get ; 

            set ; 
        }

        //Procedimiento para realizar la conexión con el servidor
        public void Conectar()
        {
            try {

                clienteTCP = new TcpClient();

                //Conectar con el servidor
                clienteTCP.Connect(IP, Puerto);
                mensajesEnviarRecibir = clienteTCP.GetStream();

                //Crear hilo para establecer escucha de posibles mensajes
                //enviados por el servidor al cliente
                hiloMensajeServidor = new Thread(LeerSocket);
                hiloMensajeServidor.Start();
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

        //Procedimiento para cerrar la conexión con el servidor
        public void Desconectar()
        {
            //desconectamos del servidor
            clienteTCP.Close();
            //abortamos el hilo (thread)
            hiloMensajeServidor.Abort();
        }


        //Enviar mensaje al servidor
        public void EnviarDatos(string Datos)
        {
            byte[] BufferDeEscritura = null;

            BufferDeEscritura = Encoding.ASCII.GetBytes(Datos);
            if ((mensajesEnviarRecibir != null))
            {
                mensajesEnviarRecibir.Write(BufferDeEscritura, 0, BufferDeEscritura.Length);
            }
        }


        private void LeerSocket()
        {
            byte[] BufferDeLectura = null;

            while (true)
            {
                try
                {
                    BufferDeLectura = new byte[101];

                    //Esperar a que llegue algún mensaje
                    mensajesEnviarRecibir.Read(BufferDeLectura, 0, BufferDeLectura.Length);

                    //Generar evento DatosRecibidos cuando se recibien datos desde el servidor
                    if (DatosRecibidos != null)
                    {
                        DatosRecibidos(Encoding.ASCII.GetString(BufferDeLectura));
                    }
                }
                catch (Exception e)
                {
                    break; // TODO: might not be correct. Was : Exit While
                }
            }

            //Finalizar conexión y generar evento ConexionTerminada
            if (ConexionTerminada != null)
            {
                ConexionTerminada();
            }
        }


    }
}
