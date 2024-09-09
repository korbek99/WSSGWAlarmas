using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class VCAConfiguration
    {
        public static int VCA_CHANNEL = 0; //VCA Channel Number and Enable 
        public static int VCA_VIDEOSIZE = 1; //VCA Channel of video size 
        public static int VCA_ADVANCE_PARAM = 2;//VCA advanced parameter 
        public static int VCA_TARGET_PARAM = 3; //VCA superimpose paramenter and colour setting 
        public static int VCA_ALARM_STATISTIC = 4; //VCA alarm count is zero 
        public static int VCA_RULE_COMMON = 5; //rule of VCA convention parameter 
        public static int VCA_RULE0_TRIPWIRE = 6; //rule of VCA(single tripwire) 
        public static int VCA_RULE1_DBTRIPWIRE = 7; // rule of VCA(double tripwire) 
        public static int VCA_RULE2_PERIMETER = 8; // rule of VCA(perimeter) 
        public static int VCA_ALARM_SCHEDULE = 9; // VCA alarm module 
        public static int VCA_ALARM_LINK = 10; // VCA input port 
        public static int VCA_SCHEDULE_ENABLE = 11; //enable of VCA 
        public static int VCA_RULE9_FACEREC = 12; //rule of VCA(face recognition) 
        public static int VCA_RULE10_VIDEODETECT = 13; // rule of VCA(video diagnose) 
        public static int VCA_RULE8_ABANDUM = 14; //rule of VCA(abandon) 
        public static int VCA_RULE7_OBJSTOLEN = 15; //rule of VCA(stolen) 
        public static int VCA_RULE11_TRACK = 16; //rule of VCA(follow) 

        public static string VCA_CHANNEL_DESCRIP = "VCA Channel Number and Enable";
        public static string VCA_VIDEOSIZE_DESCRIP = "VCA Channel of video size ";
        public static string VCA_ADVANCE_PARAM_DESCRIP = "VCA advanced parameter ";
        public static string VCA_TARGET_PARAM_DESCRIP = "VCA superimpose paramenter and colour setting";
        public static string VCA_ALARM_STATISTIC_DESCRIP = "VCA alarm count is zero ";
        public static string VCA_RULE_COMMON_DESCRIP = "rule of VCA convention parameter ";
        public static string VCA_RULE0_TRIPWIRE_DESCRIP = "rule of VCA(single tripwire)";
        public static string VCA_RULE1_DBTRIPWIRE_DESCRIP = " rule of VCA(double tripwire)";
        public static string VCA_RULE2_PERIMETER_DESCRIP = " rule of VCA(perimeter) ";
        public static string VCA_ALARM_SCHEDULE_DESCRIP = " VCA alarm module ";
        public static string VCA_ALARM_LINK_DESCRIP = " VCA input port ";
        public static string VCA_SCHEDULE_ENABLE_DESCRIP = "enable of VCA ";
        public static string VCA_RULE9_FACEREC_DESCRIP = "rule of VCA(face recognition)";
        public static string VCA_RULE10_VIDEODETECT_DESCRIP = "rule of VCA(video diagnose) ";
        public static string VCA_RULE8_ABANDUM_DESCRIP = "rule of VCA(abandon) ";
        public static string VCA_RULE7_OBJSTOLEN_DESCRIP = "rule of VCA(stolen) ";
        public static string VCA_RULE11_TRACK_DESCRIP = "rule of VCA(follow) ";
    }
}
