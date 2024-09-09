using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using System.Data.SqlClient;

namespace Business
{
   public class CiudadBF
    {
        public DataSet GetAllCityBF()
        {
            
            DataSet ds = new DataSet();
            CiudadDAL Obj = new CiudadDAL();
            try
            {
                ds = Obj.GetAllCityDAL();
                
                return ds;
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CiudadBF/GetAllCityBF");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CiudadBF/GetAllCityBF");

            }
            return null;
        }
    }
}
