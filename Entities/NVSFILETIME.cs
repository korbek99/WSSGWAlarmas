using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class NVSFILETIME
    {
        public UInt16 m_iYear { get; set; }   /* Year */
        public UInt16 m_iMonth { get; set; }  /* Month */
        public UInt16 m_iDay { get; set; }    /* Day */
        public UInt16 m_iHour { get; set; }   /* Hour */
        public UInt16 m_iMinute { get; set; } /* Minute */
        public UInt16 m_iSecond { get; set; } /* Second */
    }
}
