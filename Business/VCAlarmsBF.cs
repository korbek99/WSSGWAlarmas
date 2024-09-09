using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using Entities;

namespace Business
{
    public class VCAlarmsBF
    {
        public VCAlarms GetAllObjetoAlarmsBF()
        {
            VCAlarms objeto = new VCAlarms();

            objeto.VCAlarmsCHANNEL = 0; //VCA Channel Number and Enable 
            objeto.VVCAlarmsVIDEOSIZE = 1; //VCA Channel of video size 
            objeto.VCAlarmsADVANCE_PARAM = 2;//VCA advanced parameter 
            objeto.VCAlarmsTARGET_PARAM = 3; //VCA superimpose paramenter and colour setting 
            objeto.VCAlarmsALARM_STATISTIC = 4; //VCA alarm count is zero 
            objeto.VCAlarmsRULE_COMMON = 5; //rule of VCA convention parameter 
            objeto.VCAlarmsRULE0_TRIPWIRE = 6; //rule of VCA(single tripwire) 
            objeto.VCAlarmsRULE1_DBTRIPWIRE = 7; // rule of VCA(double tripwire) 
            objeto.VCAlarmsRULE2_PERIMETER = 8; // rule of VCA(perimeter) 
            objeto.VCAlarmsALARM_SCHEDULE = 9; // VCA alarm module 
            objeto.VCAlarmsALARM_LINK = 10; // VCA input port 
            objeto.VCAlarmsSCHEDULE_ENABLE = 11; //enable of VCA 
            objeto.VCAlarmsRULE9_FACEREC = 12; //rule of VCA(face recognition) 
            objeto.VCAlarmsRULE10_VIDEODETECT = 13; // rule of VCA(video diagnose) 
            objeto.VCAlarmsRULE8_ABANDUM = 14; //rule of VCA(abandon) 
            objeto.VCAlarmsRULE7_OBJSTOLEN = 15; //rule of VCA(stolen) 
            objeto.VCAlarmsRULE11_TRACK = 16; //rule of VCA(follow) 


            return objeto;
        }

        public List<VCAlarmEntity> ListAllObjetoAlarmsBF()
        {
            List<VCAlarmEntity> lista = new List<VCAlarmEntity>();

            lista.Add(new VCAlarmEntity() { VCAlarmEntityID = 0, VCAlarmEntityDescripcion = "VCA Channel Number and Enable" });
            lista.Add(new VCAlarmEntity() { VCAlarmEntityID = 1, VCAlarmEntityDescripcion = "VCA Channel of video size" });
            lista.Add(new VCAlarmEntity() { VCAlarmEntityID = 2, VCAlarmEntityDescripcion = "VCA advanced parameter" });
            lista.Add(new VCAlarmEntity() { VCAlarmEntityID = 3, VCAlarmEntityDescripcion = "VCA superimpose paramenter and colour setting" });
            lista.Add(new VCAlarmEntity() { VCAlarmEntityID = 4, VCAlarmEntityDescripcion = "VCA alarm count is zero" });
            lista.Add(new VCAlarmEntity() { VCAlarmEntityID = 5, VCAlarmEntityDescripcion = "rule of VCA convention parameter" });
            lista.Add(new VCAlarmEntity() { VCAlarmEntityID = 6, VCAlarmEntityDescripcion = "rule of VCA(single tripwire) " });
            lista.Add(new VCAlarmEntity() { VCAlarmEntityID = 7, VCAlarmEntityDescripcion = "rule of VCA(double tripwire)" });
            lista.Add(new VCAlarmEntity() { VCAlarmEntityID = 8, VCAlarmEntityDescripcion = "rule of VCA(perimeter)" });
            lista.Add(new VCAlarmEntity() { VCAlarmEntityID = 9, VCAlarmEntityDescripcion = "VCA alarm module " });
            lista.Add(new VCAlarmEntity() { VCAlarmEntityID = 10, VCAlarmEntityDescripcion = "VCA input port " });
            lista.Add(new VCAlarmEntity() { VCAlarmEntityID = 11, VCAlarmEntityDescripcion = "enable of VCA" });
            lista.Add(new VCAlarmEntity() { VCAlarmEntityID = 12, VCAlarmEntityDescripcion = "rule of VCA(face recognition)" });
            lista.Add(new VCAlarmEntity() { VCAlarmEntityID = 13, VCAlarmEntityDescripcion = "rule of VCA(video diagnose)" });
            lista.Add(new VCAlarmEntity() { VCAlarmEntityID = 14, VCAlarmEntityDescripcion = "rule of VCA(abandon) " });
            lista.Add(new VCAlarmEntity() { VCAlarmEntityID = 15, VCAlarmEntityDescripcion = "rule of VCA(stolen) " });
            lista.Add(new VCAlarmEntity() { VCAlarmEntityID = 16, VCAlarmEntityDescripcion = "rule of VCA(follow" });

            return lista;
        }
    }
}
