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
    public class UsuarioTipoBF
    {
        public DataSet AllUsuarioTipoBF()
        {
            DataSet ds = new DataSet();
            try
            {
                UsuarioTipoDAL Obj = new UsuarioTipoDAL();
                ds = Obj.AllUsuarioTipoDAL();
                return ds;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error de SQL :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioTipoBF/AllUsuarioTipoBF");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioTipoBF/AllUsuarioTipoBF");
            }
            return null;
        }
    }
}
