using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class AlarmInfomation
    {
        public int AlarmInfID { get; set; }
        public string AlarmInfIDE { get; set; }
        public int AlarmInfChannel { get; set; }
        public int AlarmInfState { get; set; }
        public int AlarmInfEventType { get; set; }
        public int AlarmInfRuleID { get; set; }
        public string AlarmInfRuleDescrip { get; set; }
        public int AlarmInTargetID { get; set; }
        public int AlarmInfTargetType { get; set; }
        public string AlarmInfrctTarget { get; set; }
        public int AlarmInfTargetSpeed { get; set; }
        public int AlarmInfTargetDirection { get; set; }
        public string AlarmInfDescription { get; set; }
        public int AlarmInfCostuCompany { get; set; }
        public DateTime AlarmInfDateEvent { get; set; }
    }
}
