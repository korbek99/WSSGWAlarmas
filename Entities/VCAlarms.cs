using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class VCAlarms
    {
        public int VCAlarmsCHANNEL { get; set; } // 0; VCA Channel Number and Enable 
        public int VVCAlarmsVIDEOSIZE { get; set; } //  1; //VCA Channel of video size 
        public int VCAlarmsADVANCE_PARAM { get; set; } //  2;//VCA advanced parameter 
        public int VCAlarmsTARGET_PARAM { get; set; } //  3; //VCA superimpose paramenter and colour setting 
        public int VCAlarmsALARM_STATISTIC { get; set; } //  4; //VCA alarm count is zero 
        public int VCAlarmsRULE_COMMON { get; set; } //  5; //rule of VCA convention parameter 
        public int VCAlarmsRULE0_TRIPWIRE { get; set; } //  6; //rule of VCA(single tripwire) 
        public int VCAlarmsRULE1_DBTRIPWIRE { get; set; } //  7; // rule of VCA(double tripwire) 
        public int VCAlarmsRULE2_PERIMETER { get; set; } //  8; // rule of VCA(perimeter) 
        public int VCAlarmsALARM_SCHEDULE { get; set; } //  9; // VCA alarm module 
        public int VCAlarmsALARM_LINK { get; set; } //  10; // VCA input port 
        public int VCAlarmsSCHEDULE_ENABLE { get; set; } //  11; //enable of VCA 
        public int VCAlarmsRULE9_FACEREC { get; set; } //  12; //rule of VCA(face recognition) 
        public int VCAlarmsRULE10_VIDEODETECT { get; set; } //  13; // rule of VCA(video diagnose) 
        public int VCAlarmsRULE8_ABANDUM { get; set; } //  14; //rule of VCA(abandon) 
        public int VCAlarmsRULE7_OBJSTOLEN { get; set; } // 15; //rule of VCA(stolen) 
        public int VCAlarmsRULE11_TRACK { get; set; } //  16; //rule of VCA(follow) 
    }
}
