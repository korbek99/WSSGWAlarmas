using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Net.Sockets;
using System.Text;


namespace DataAccess
{
   public class ClaseServidorSocket
    {
        //Esta estructura permite guardar la información sobre un cliente
        private struct datosClienteConectado
        {
            //Socket para mantener la conexión con cliente
            public Socket socketConexion;
            //Hilo para mantener escucha con el cliente
            public Thread Thread;
            //Últimos datos enviados por el cliente
            public string UltimosDatosRecibidos;
        }

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

        //Propiedad para establecer el puerto por el que se realizará la escucha
        public int Puerto
        {
            get ; 

            set ; 
        }

        //Procedimiento para establecer el servidor en modo escucha
        public void IniciarEscucha()
        {
            tcpLsn = new TcpListener(Puerto);

            //Iniciar escucha
            tcpLsn.Start();
            //EsperarConexionCliente()

            //Crear hilo para dejar escuchando la conexión de clientes
            tcpThd = new Thread(EsperarConexionCliente);
            tcpThd.Start();
        }


        //Procedimiento para detener la escucha del servidor
        public void DetenerEscucha()
        {
            CerrarTodosClientes();
            tcpThd.Abort();
            tcpLsn.Stop();
        }


        public string ObtenerDatos(System.Net.IPEndPoint IDCliente)
        {
            datosClienteConectado InfoClienteSolicitado = default(datosClienteConectado);

            //Obtengo la informacion del cliente solicitado
         //   InfoClienteSolicitado = Clientes(IDCliente);
            return InfoClienteSolicitado.UltimosDatosRecibidos;
        }

        //Cierra la conexión de un cliente conectado
        public void cerrarConexionCliente(System.Net.IPEndPoint IDCliente)
        {
            datosClienteConectado InfoClienteActual = default(datosClienteConectado);

            //Obtener información del cliente indicado
           // InfoClienteActual = Clientes(IDCliente);

            //Cerrar conexión con cliente
            InfoClienteActual.socketConexion.Close();
        }


        //Cerrar todas la conexión de todos los clientes conectados
        public void CerrarTodosClientes()
        {
            datosClienteConectado InfoClienteActual = default(datosClienteConectado);

            //Cerrar conexión de todos los clientes
            //foreach (DummyTypeForConversion.datosClienteConectado InfoClienteActual_loopVariable in Clientes.Values)
            //{
               // InfoClienteActual = InfoClienteActual_loopVariable;
               // cerrarConexionCliente(InfoClienteActual.socketConexion.RemoteEndPoint);
            //}
        }

        //Enviar mensaje a cliente indicado
        public void enviarMensajeCliente(System.Net.IPEndPoint IDCliente, string Datos)
        {
            datosClienteConectado Cliente = default(datosClienteConectado);

            //Obtener información del cliente al que se enviará el mensaje
          //  Cliente = Clientes(IDCliente);

            //Enviar mensaje a cliente
            Cliente.socketConexion.Send(Encoding.ASCII.GetBytes(Datos));
        }

        //Enviar mensaje a todos los clientes conectados al servidor
        public void enviarMensajeTodosClientes(string Datos)
        {
            datosClienteConectado Cliente = default(datosClienteConectado);

           // foreach ( Cliente in Clientes.Values) {
		       // enviarMensajeCliente(Cliente.socketConexion.RemoteEndPoint, Datos);
                enviarMensajeCliente(null, Datos);
	       // }
        }

        //Procedimiento que inicia la espera de la conexión de un cliente
        //para ello inicia un hilo (thread)
        private void EsperarConexionCliente()
        {
            datosClienteConectado datosClienteActual = default(datosClienteConectado);

            while (true)
            {
                //Se guarda la información del cliente cuando se recibe la conexión
                //Quedará esperando la conexión de un nuevo cliente
                datosClienteActual.socketConexion = tcpLsn.AcceptSocket();

                //Con el IDClienteActual se identificará al cliente conectado
               // IDClienteActual = datosClienteActual.socketConexion.RemoteEndPoint;

                //Crear un hilo para que quede escuchando los mensajes del cliente
                datosClienteActual.Thread = new Thread(LeerSocket);

                //Agregar la información del cliente conectado al array
                lock (this)
                {
                  //  Clientes.Add(IDClienteActual, datosClienteActual);
                }

                //Generar evento NuevaConexion
                if (NuevaConexion != null)
                {
                   // NuevaConexion(IDClienteActual);
                }

                //Iniciar el hilo que escuchará los mensajes del cliente
                datosClienteActual.Thread.Start();
            }
        }

        //Procedimiento para leer datos enviados por el cliente
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
           // InfoClienteActual = Clientes(IDReal);
            while (true)
            {
                //if (InfoClienteActual.socketConexion.Connected == null)
                //{

                //}else{
                        //if (InfoClienteActual.socketConexion.Connected)
                        //{
                            Recibir = new byte[101];
                            try
                            {
                                //Esperar a que lleguen un mensaje desde el cliente
                                Ret = InfoClienteActual.socketConexion.Receive(Recibir, Recibir.Length, SocketFlags.None);
                                if (Ret > 0)
                                {
                                    //Guardar mensaje recibido
                                    InfoClienteActual.UltimosDatosRecibidos = Encoding.ASCII.GetString(Recibir);
                                //    Clientes(IDReal) = InfoClienteActual;

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
                                //if (!InfoClienteActual.socketConexion.Connected)
                                //{
                                    //Generar el evento ConexionTerminada 
                                    //de finalización de la conexión
                                    if (ConexionTerminada != null)
                                    {
                                        ConexionTerminada(IDReal);
                                    }
                                    break; // TODO: might not be correct. Was : Exit While
                               // }
                            }
                       // }
                //}
               
            }
            CerrarThread(IDReal);
        }

        //Procedimiento para cerrar el hilo (thread)
        private void CerrarThread(System.Net.IPEndPoint IDCliente)
        {
            datosClienteConectado InfoClienteActual = default(datosClienteConectado);

            //Finalizar el hilo (thread) iniciado 
            // encargado de escuchar al cliente
          //  InfoClienteActual = Clientes(IDCliente);

            try
            {
                InfoClienteActual.Thread.Abort();
            }
            catch (Exception e)
            {
                lock (this)
                {
                    //Eliminar el cliente del array
                   // Clientes.Remove(IDCliente);
                }
            }
        }


    }
}
