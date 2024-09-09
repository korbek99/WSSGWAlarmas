using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using Entities;
using System.Data.SqlClient;

namespace Business
{
   public class NextivaStatisticsBF
    {

       
        public DataSet AllNextivaStatisticsBF(int CustomerCompanyID, int AlarmSentRuleID, DateTime FechaInicio, DateTime FechaFin)
        {
            
            DataSet ds = new DataSet();
            try
            {
                NextivaStatisticsDAL Obj = new NextivaStatisticsDAL();
                 ds =Obj.AllNextivaStatisticsDAL( CustomerCompanyID,  AlarmSentRuleID,  FechaInicio,  FechaFin);
                return ds;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error de SQL :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "TypeRulesDAL/AllNextivaStatisticsBF");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "TypeRulesDAL/AllNextivaStatisticsBF");
            }
            return null;
        }

        public DataSet AllCostumersAndTypeRulesNextivaStatisticsBF(int AlarmSentRuleID)
        {
            DataSet ds = new DataSet();
            try
            {
                 NextivaStatisticsDAL Obj = new NextivaStatisticsDAL();
                 ds = Obj.AllCostumersAndTypeRulesNextivaStatisticsDAL(AlarmSentRuleID);
                return ds;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error de SQL :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "TypeRulesDAL/AllCostumersAndTypeRulesNextivaStatisticsBF");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "TypeRulesDAL/AllCostumersAndTypeRulesNextivaStatisticsBF");
            }
            return null;
        }

        public DataSet AllCostumersByTypeRulesNextivaStatisticsBF()
        {
            
            DataSet ds = new DataSet();
            try
            {
                NextivaStatisticsDAL Obj = new NextivaStatisticsDAL();
                ds = Obj.AllCostumersByTypeRulesNextivaStatisticsDAL();
                return ds;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error de SQL :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "TypeRulesDAL/AllCostumersByTypeRulesNextivaStatisticsBF");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "TypeRulesDAL/AllCostumersByTypeRulesNextivaStatisticsBF");
            }
            return null;
        }
    }
}
