﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using Entities;
using System.Data.SqlClient;


namespace Business
{
    public class SystemDeviceBF
    {
        SystemDeviceDAL ObjSys = new SystemDeviceDAL();
        public DataSet GetAllSystemDeviceBF()
        {
           
            DataSet ds = new DataSet();
            try
            {
                ds = ObjSys.GetAllSystemDeviceDAL();
                return ds;
            }
            
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "SystemDeviceBF/GetAllSystemDeviceBF");

            }
            return null;
        }

        public DataSet GetAllSystemDeviceListBF()
        {
           
            DataSet ds = new DataSet();
            try
            {
                ds = ObjSys.GetAllSystemDeviceListDAL();
                return ds;
            }
            
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "SystemDeviceBF/GetAllSystemDeviceListBF");

            }
            return null;
        }
        public DataSet GetSystemDeviceByIDBF(int SystemDeviceID)
        {
           
            DataSet ds = new DataSet();
            
            try
            {
                ds = ObjSys.GetSystemDeviceByIDDAL(SystemDeviceID);
                return ds;
            }
           
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "SystemDeviceBF/GetSystemDeviceByIDBF");

            }
            return null;
        }
        public Boolean IngrSystemDeviceBF(string SystemDeviceDescrip
                                         , string SystemDeviceUser
                                         , string SystemDevicePass
                                         , DateTime SystemDeviceDateIng
                                         , int SystemDeviceEstado)
        {
           
            Boolean esExito = false;
            
            try
            {


                esExito = ObjSys.IngrSystemDeviceDAL( SystemDeviceDescrip
                                         ,  SystemDeviceUser
                                         ,  SystemDevicePass
                                         ,  SystemDeviceDateIng
                                         ,  SystemDeviceEstado);
              
            }
            
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "SystemDeviceBF/IngrSystemDeviceBF");
                esExito = false;
            }

            return esExito;
        }

        public Boolean UpdateSystemDeviceBF(int SystemDeviceID
                                           , string SystemDeviceDescrip
                                          , string SystemDeviceUser
                                          , string SystemDevicePass
                                          , DateTime SystemDeviceDateIng
                                          , int SystemDeviceEstado)
        {
           
            Boolean esExito = false;
           
            try
            {


                esExito = ObjSys.UpdateSystemDeviceDAL(SystemDeviceID,SystemDeviceDescrip
                                     , SystemDeviceUser
                                     , SystemDevicePass
                                     , SystemDeviceDateIng
                                     , SystemDeviceEstado);
              
            }
           
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "SystemDeviceBF/UpdateSystemDeviceBF");
                esExito = false;
            }

            return esExito;
        }

        public Boolean DeleteSystemDeviceBF(int SystemDeviceID)
        {
           
            Boolean esExito = false;
            
            try
            {

                esExito = ObjSys.DeleteSystemDeviceDAL(SystemDeviceID);
           
            }
           
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "SystemDeviceBF/DeleteSystemDeviceBF");
                esExito = false;
            }

            return esExito;
        }
    }
}
