using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class AlertasProcessed
    {
        public int AlertasProcID { get; set; }
        public string AlertasProcIDLogon { get; set; }
        public string AlertasProcIP { get; set; }
        public string AlertasProcUser { get; set; }
        public string AlertasProcPass { get; set; }
        public string AlertasProcChannel { get; set; }
        public string AlertasProcTCPUDP { get; set; }
        public string AlertasProcMainSub { get; set; }
        public string AlertasProcAlert { get; set; }
        public int AlertasProcEstado { get; set; }
    }
}
