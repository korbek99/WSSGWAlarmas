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
    public class datosClienteConectado
    {
         //public Socket socketConexion { get; set; }
         //public Thread Thread  {get; set;}
         //public string UltimosDatosRecibidos { get; set; }


            //Socket para mantener la conexión con cliente
            public Socket socketConexion;
            //Hilo para mantener escucha con el cliente
            public Thread Thread;
            //Últimos datos enviados por el cliente
            public string UltimosDatosRecibidos;
        
    }
}
