
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
    public class DataNextivaBF
    {
        public int GetLastIDBF(int idchannel)
        {
            int res = 0;
             DataNextivaDAL ObjData = new DataNextivaDAL();

             res = ObjData.GetLastIDE(idchannel);

            return res;
        }
        public Boolean UpdateStateDataCameraToNextivaSQLBF(int AlarmSentID, int AlarmSentEstado)
        {
            Boolean esExito = false;
            DataNextivaDAL ObjData = new DataNextivaDAL();
            try
            {
                esExito = ObjData.UpdateStateDataCameraToNextivaSQLDAL(AlarmSentID, AlarmSentEstado);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaBF/UpdateStateDataCameraToNextivaSQLBF");
                esExito = false;
            }
            return esExito;
        }
        public Boolean SendDataCameraToNextivaBF(List<AlarmNextiva> Objeto)
        {
            Boolean res = false;
            try
            {
                DataNextivaDAL ObjData = new DataNextivaDAL();
                if (ObjData.SendDataCameraToNextivaDAL(Objeto) == true)
                {
                    res = true;
                }
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaBF/SendDataCameraToNextivaBF");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaBF/SendDataCameraToNextivaBF");
               
            }
            return res;
        }

        public DataSet GetAllDataProcessedNextivaBF()
        {
            DataSet ds = new DataSet();

            try
            {
                DataNextivaDAL ObjData = new DataNextivaDAL();

                ds = ObjData.GetAllDataProcessedNextivaDAL();
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaBF/GetAllDataProcessedNextivaBF");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaBF/GetAllDataProcessedNextivaBF");

            }
            return ds;

        }

        public DataSet GetDataProcessedNextivaByDatesBF(DateTime FechaInicio, DateTime FechaFin)
        {
            DataSet ds = new DataSet();
            try
            {
                DataNextivaDAL ObjData = new DataNextivaDAL();
                ds = ObjData.GetDataProcessedNextivaByDatesDAL(FechaInicio,FechaFin);
                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaBF/GetDataProcessedNextivaByDatesBF");
            }
            return null;
        }

        public DataSet GetDataProcessedNextivaByParametersBF(int AlarmSentRuleID, int CustomerCompanyID, DateTime FechaInicio, DateTime FechaFin)
        {
           
            DataSet ds = new DataSet();
            try
            {
                DataNextivaDAL ObjData = new DataNextivaDAL();

                ds = ObjData.GetDataProcessedNextivaByParametersDAL( AlarmSentRuleID,  CustomerCompanyID,  FechaInicio,  FechaFin);
                return ds;
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaBF/GetDataProcessedNextivaByParametersBF");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaBF/GetDataProcessedNextivaByParametersBF");

            }
            return null;
        }
    }
}
