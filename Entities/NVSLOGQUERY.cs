using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class NVSLOGQUERY
    {

        public int m_iChannelNo { get; set; }
        public int m_iLogType { get; set; }
        public int m_iLanguage { get; set; }
        public List<NVSFILETIME> m_struStartTime { get; set; }
        public List<NVSFILETIME> m_struStopTime { get; set; }
        public int m_iPageSize { get; set; }
        public int m_iPageNo { get; set; }

    }
}
