using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class AlarmNextiva
    {
        public string AlarmSentIDE { get; set; }
        public int AlarmSentChannel { get; set; }
        public int AlarmSentState { get; set; }
        public int AlarmSentventType { get; set; }
        public int AlarmSentRuleID { get; set; }
        public string AlarmSentRuleDescrip { get; set; }
        public int AlarmSentTargetID { get; set; }
        public int AlarmSentTargetType { get; set; }
        public string AlarmSentrctTarget { get; set; }
        public int AlarmSentTargetSpeed { get; set; }
        public int AlarmSentTargetDirection { get; set; }
        public DateTime AlarmSentDateIng { get; set; }
        public string AlarmSentDescription { get; set; }
        public int AlarmSentEstado { get; set; }
        public int AlarmSentCustCompanyID { get; set; }
        public DateTime AlarmSentDateEvent { get; set; }
    }
}
