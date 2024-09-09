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
   public class TypeRulesBF
   {
       public DataSet AllTypeRulesListDropBF()
       {
           
           DataSet ds = new DataSet();
           try
           {
               TypeRulesDAL Obj =new TypeRulesDAL();
               ds = Obj.AllTypeRulesListDropDAL();

               return ds;
           }
           catch (SqlException e)
           {
               Console.WriteLine("Error de SQL :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "TypeRulesBF/AllTypeRulesListDropDAL");

           }
           catch (Exception e)
           {
               Console.WriteLine("Error :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "TypeRulesBF/AllTypeRulesListDropDAL");
           }
           return null;
       }

       public DataSet GetTypeRulesByIDBF(int ParamID)
       {
           
           DataSet ds = new DataSet();
           try
           {
               TypeRulesDAL Obj = new TypeRulesDAL();
               ds = Obj.GetTypeRulesByIDDAL(ParamID);
               return ds;
           }
           catch (SqlException e)
           {
               Console.WriteLine("Error de SQL :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "TypeRulesBF/GetTypeRulesByIDBF");

           }
           catch (Exception e)
           {
               Console.WriteLine("Error :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "TypeRulesBF/GetTypeRulesByIDBF");
           }
           return null;
       }
    }
}
