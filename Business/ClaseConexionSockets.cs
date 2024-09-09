using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace Business
{
    public class ClaseConexionSocketsBF
    {
        public void  ConectarSocketAvigilonBF(string IP , int socket)
        {
            ClaseClienteSocket socketCliente = new ClaseClienteSocket();
            ClaseServidorSocket socketServidor = new ClaseServidorSocket();
            socketServidor.Puerto = 5020;
            socketServidor.IniciarEscucha();
            socketCliente.IP = IP;
            socketCliente.Puerto = socket;
            socketCliente.Conectar();
        }

        public void ConectarSocketAvigilonAutoBF()
        {
            // se debe crear entidad donde se guarden estos parametros
            ClaseClienteSocket socketCliente = new ClaseClienteSocket();
            ClaseServidorSocket socketServidor = new ClaseServidorSocket();
            socketServidor.Puerto = 5020;
            socketServidor.IniciarEscucha();
            socketCliente.IP = "192.168.10.104"; 
            socketCliente.Puerto = 5020;
            socketCliente.Conectar();
        }
    }
}
