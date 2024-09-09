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
   public class TypeDeviceBF
    {
       
        public DataSet GetAllTypeDeviceBF()
        {
            DataSet ds = new DataSet();
            TypeDeviceDAL Obj = new TypeDeviceDAL();
            try
            {
                ds = Obj.GetAllTypeDeviceDAL();  
                return ds;
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "TypeDeviceBF/GetAllTypeDeviceBF");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "TypeDeviceBF/GetAllTypeDeviceBF");
            }
            return null;
        }
        public DataSet GetTypeDeviceByIDBF(int TypeDeviceID)
        {
            
            DataSet ds = new DataSet();

            TypeDeviceDAL Obj = new TypeDeviceDAL();
            try
            {
                ds = Obj.GetTypeDeviceByIDDAL(TypeDeviceID);
                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "TypeDeviceBF/GetTypeDeviceByIDBF");

            }
            return null;
        }
        public Boolean IngrTypeDeviceBF(string TypeDeviceDescrip)
        {
            Boolean esExito = false;
            TypeDeviceDAL Obj = new TypeDeviceDAL();
            try
            {
                    esExito = Obj.IngrTypeDeviceDAL(TypeDeviceDescrip);
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "TypeDeviceBF/IngrTypeDeviceBF");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "UsuarioDAL/IngrTypeDeviceBF");
                esExito = false;
            }
            return esExito;
        }

        public Boolean UpdateTypeDeviceBF(int TypeDeviceID, string TypeDeviceDescrip)
        {
            Boolean esExito = false;
            TypeDeviceDAL Obj = new TypeDeviceDAL();
            try
            {
                esExito = Obj.UpdateTypeDeviceDAL(TypeDeviceID, TypeDeviceDescrip);
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "TypeDeviceBF/UpdateTypeDeviceBF");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "UsuarioDAL/UpdateTypeDeviceBF");
                esExito = false;
            }
            return esExito;
        }

        public Boolean DeleteTypeDeviceBF(int @TypeDeviceID)
        {
            Boolean esExito = false;
            TypeDeviceDAL Obj = new TypeDeviceDAL();
            try
            {
                esExito = Obj.DeleteTypeDeviceDAL(TypeDeviceID);
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "TypeDeviceBF/DeleteTypeDeviceBF");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "UsuarioDAL/DeleteTypeDeviceBF");
                esExito = false;
            }
            return esExito;
        }
    }
}
