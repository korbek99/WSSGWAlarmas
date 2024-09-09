using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class AlertasCapture
    {
        public int AlertasCapID { get; set; }
        public string AlertasCapIDLogon { get; set; }
        public string AlertasCapIP { get; set; }
        public string AlertasCapUser { get; set; }
        public string AlertasCapPass { get; set; }
        public string AlertasCapChannel { get; set; }
        public string AlertasCapTCPUDP { get; set; }
        public string AlertasCapMainSub { get; set; }
        public string AlertasCapAlert { get; set; }
        public int AlertasCapEstado { get; set; }
    }
}
