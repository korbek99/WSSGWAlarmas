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
  public  class DeviceBF
    {
      
        public DataSet AllDeviceBF()
        {
           
            DataSet ds = new DataSet();
            DeviceDAL Obj = new DeviceDAL();
            try
            {
                ds = Obj.AllDeviceDAL();
                return ds;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error de SQL :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceBF/AllTypeRulesListDropBF");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceBF/AllTypeRulesListDropBF");
            }
            return null;
        }
        public DataSet DeviceByIDBF(int DeviceID)
        {
           
            DataSet ds = new DataSet();
            DeviceDAL Obj = new DeviceDAL();
            try
            {
                ds = Obj.DeviceByIDDAL(DeviceID);
                return ds;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error de SQL :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceBF/DeviceByIDDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceBF/DeviceByIDDAL");
            }
            return null;
        }


        public DataSet DeviceByIPDeviceBF(string DeviceIP)
        {
            
            DataSet ds = new DataSet();
            DeviceDAL Obj = new DeviceDAL();
            try
            {
                ds = Obj.DeviceByIPDeviceDAL(DeviceIP);
                return ds;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceBF/DeviceByIPDeviceBF");
            }
            return null;
        }
        public DataSet AllDeviceByCompanyIDBF(int CustomerCompanyID)
        {
           
            DataSet ds = new DataSet();
            DeviceDAL Obj = new DeviceDAL();
            try
            {
                ds = Obj.AllDeviceByCompanyIDDAL(CustomerCompanyID);
                return ds;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error de SQL :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceBF/AllDeviceByCompanyIDBF");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceBF/AllDeviceByCompanyIDBF");
            }
            return null;
        }
        public DataSet ListDeviceByCompanyIDBF(int CustomerCompanyID)
        {
            
            DataSet ds = new DataSet();
            DeviceDAL Obj = new DeviceDAL();
            try
            {
                ds = Obj.ListDeviceByCompanyIDDAL(CustomerCompanyID);
                return ds;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceBF/ListDeviceByCompanyIDBF");
            }
            return null;
        }
        public Boolean IngrDeviceBF(string DeviceIDE
                                     , string DeviceNameDescrip
                                     , int TypeDeviceID
                                     , int CustomerCompanyID
                                     , int DeviceChannel
                                     , string DeviceIDLogon
                                     , string DeviceIP
                                     , string DeviceUser
                                     , string DevicePass
                                     , string DevicePort
                                     , DateTime DeviceDateIng
                                     , int DeviceEstado
                                     ,int SystemDeviceID)
        {

           
            Boolean esExito = false;
            DeviceDAL Obj = new DeviceDAL();
            try
            {

                    esExito = Obj.IngrDeviceDAL( DeviceIDE
                                     ,  DeviceNameDescrip
                                     ,  TypeDeviceID
                                     ,  CustomerCompanyID
                                     ,  DeviceChannel
                                     ,  DeviceIDLogon
                                     ,  DeviceIP
                                     ,  DeviceUser
                                     ,  DevicePass
                                     ,  DevicePort
                                     ,  DeviceDateIng
                                     ,  DeviceEstado
                                     , SystemDeviceID);
               
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DeviceBF/IngrDeviceBF");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DeviceBF/IngrDeviceBF");
                esExito = false;
            }
            return esExito;
        }

        public Boolean UpdateDeviceBF(int DeviceID, string DeviceIDE
                                      , string DeviceNameDescrip
                                      , int TypeDeviceID
                                      , int CustomerCompanyID
                                      , int DeviceChannel
                                      , string DeviceIDLogon
                                      , string DeviceIP
                                      , string DeviceUser
                                      , string DevicePass
                                      , string DevicePort
                                      , DateTime DeviceDateIng
                                      , int DeviceEstado
                                      ,int SystemDeviceID)
        {

           
            Boolean esExito = false;
            DeviceDAL Obj = new DeviceDAL();
            try
            {
                esExito = Obj.UpdateDeviceDAL(DeviceID
                                ,DeviceIDE
                                , DeviceNameDescrip
                                , TypeDeviceID
                                , CustomerCompanyID
                                , DeviceChannel
                                , DeviceIDLogon
                                , DeviceIP
                                , DeviceUser
                                , DevicePass
                                , DevicePort
                                , DeviceDateIng
                                , DeviceEstado
                                , SystemDeviceID);
               
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DeviceBF/UpdateDeviceBF");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DeviceBF/UpdateDeviceBF");
                esExito = false;
            }
            return esExito;
        }

        public Boolean DeleteDeviceBF(int DeviceID)
        {

           
            Boolean esExito = false;
            DeviceDAL Obj = new DeviceDAL();
            try
            {
                esExito = Obj.DeleteDeviceDAL(DeviceID);
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DeviceBF/DeleteDeviceBF");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DeviceBF/DeleteDeviceBF");
                esExito = false;
            }
            return esExito;
        }


        public DataSet DeviceByIDEBF(string DeviceIDE)
        {
            
            DataSet ds = new DataSet();
            DeviceDAL Obj = new DeviceDAL();
            try
            {

                ds = Obj.DeviceByIDEDAL(DeviceIDE);
                return ds;
            }
           
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceBF/DeviceByIDEBF");
            }
            return null;
        }
    }
}
