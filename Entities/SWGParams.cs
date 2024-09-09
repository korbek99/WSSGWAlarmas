using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class SWGParams
    {
        public static int IdSistema = 1; 
        public string  Modulo = "SWG Demo Sample" ;
        public string IpSystemaDestino = "192.168.10.33";
        public int PuertoSystemaDestino = 8081;

        public string IpSystemaDestAvigilon6 = "192.168.10.32";
        public int PuertoSystemaDestAvigilon6 = 38880;

        public string IpSystemaDestAvigilon5 = "192.168.10.31";
        public int PuertoSystemaDestAvigilon5 = 38880;

        public static int OptionSysNextiva64 = 1;
        public static int OptionSysNextiva75 = 5;
        public static int OptionSysAvigilon5 = 6;
        public static int OptionSysAvigilon6 = 8;
        public static int OptionSysGanz = 10;
        public int PuertoCallOpenSocket = 8080;

        public static string OptionPathNextiva64 = @"\\VM-33-S12-N75\Verint\AlarmInterface\";
        public static string OptionPathNextiva75 = @"\\VM-33-S12-N75\Verint\AlarmInterface\";
        public static string OptionPathAvigilon5 = @"\\VM-31-S12-Avigilon 5.x\Avigilon";
        public static string OptionPathAvigilon6 = @"\\VM-32-S12-Avigilon 6.x\Avigilon";
        public static string OptionPathGanz = @"\\VM-27-S12-Ganz\";

        //@Fecha datetime { get; set; }  
        //@MachineName varchar(50) { get; set; } 
        //@UserName varchar(50) { get; set; }  
        //@IdSistema int { get; set; }  
        //@Mensaje varchar(8000) { get; set; }  
        //@Resuelto bit { get; set; }  
        //@NumeroError int { get; set; }
        //@Modulo varchar(50)  { get; set; }
    }
}
