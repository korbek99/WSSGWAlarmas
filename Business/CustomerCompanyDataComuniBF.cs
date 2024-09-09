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
    public class CustomerCompanyDataComuniBF
    {
        CustomerCompanyDataComuniDAL Obj = new CustomerCompanyDataComuniDAL();
        public Boolean DeleteCustomerCompanyDataComuniBF(int CusCompanyDataID)
        {
            Boolean esExito = false;
            try
            {
                esExito = Obj.DeleteCustomerCompanyDataComuniDAL(CusCompanyDataID); ;
            }
            
            catch (Exception ex)
            {
                
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyDataComuniBF/DeleteCustomerCompanyDataComuniBF");
                esExito = false;
            }
            return esExito;

        }
        public Boolean UpdateCustomerCompanyDataComuniBF(int CusCompanyDataID
                                                          , int CustomerCompanyID
                                                         , string CusCompanyDataCameraName
                                                         , int CusCompanyDataIDE
                                                         , string CusCompanyDataNextNiveles
                                                         , string CusCompanyDataSiteName
                                                         , string CusCompanyDataNameUrl
                                                         , string CusCompanyDataSiteUser
                                                         , string CusCompanyDataSitePass
                                                         , string CusCompanyDataAlarmSite
                                                         , string CusCompanyDataListenResponse
                                                         , string CusCompanyDataListenError
                                                         , string CusCompanyDataPathString
                                                         , string CusCompanyDataFileName
                                                         , int CusCompanyDataActivo)
        {

            
            Boolean esExito = false;
            
            try
            {


                esExito = Obj.UpdateCustomerCompanyDataComuniDAL( CusCompanyDataID
                                                          ,  CustomerCompanyID
                                                         ,  CusCompanyDataCameraName
                                                         ,  CusCompanyDataIDE
                                                         ,  CusCompanyDataNextNiveles
                                                         ,  CusCompanyDataSiteName
                                                         ,  CusCompanyDataNameUrl
                                                         ,  CusCompanyDataSiteUser
                                                         ,  CusCompanyDataSitePass
                                                         ,  CusCompanyDataAlarmSite
                                                         ,  CusCompanyDataListenResponse
                                                         ,  CusCompanyDataListenError
                                                         ,  CusCompanyDataPathString
                                                         ,  CusCompanyDataFileName
                                                         ,  CusCompanyDataActivo);
                
            }
            
            catch (Exception ex)
            {
                
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyDataComuniBF/UpdateCustomerCompanyDataComuniBF");
                esExito = false;
            }
            return esExito;

        }
        public Boolean IngrCustomerCompanyDataComuniBF(int CustomerCompanyID
                                                         , string CusCompanyDataCameraName
                                                         , int CusCompanyDataIDE
                                                         , string CusCompanyDataNextNiveles
                                                         , string CusCompanyDataSiteName
                                                         , string CusCompanyDataNameUrl
                                                         , string CusCompanyDataSiteUser
                                                         , string CusCompanyDataSitePass
                                                         , string CusCompanyDataAlarmSite
                                                         , string CusCompanyDataListenResponse
                                                         , string CusCompanyDataListenError
                                                         , string CusCompanyDataPathString
                                                         , string CusCompanyDataFileName
                                                         , int CusCompanyDataActivo)
        {

            
            Boolean esExito = false;
            
            try
            {



                esExito = Obj.IngrCustomerCompanyDataComuniDAL(CustomerCompanyID
                                                     , CusCompanyDataCameraName
                                                     , CusCompanyDataIDE
                                                     , CusCompanyDataNextNiveles
                                                     , CusCompanyDataSiteName
                                                     , CusCompanyDataNameUrl
                                                     , CusCompanyDataSiteUser
                                                     , CusCompanyDataSitePass
                                                     , CusCompanyDataAlarmSite
                                                     , CusCompanyDataListenResponse
                                                     , CusCompanyDataListenError
                                                     , CusCompanyDataPathString
                                                     , CusCompanyDataFileName
                                                     , CusCompanyDataActivo);
            }
            
            catch (Exception ex)
            {
                
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyDataComuniBF/IngrCustomerCompanyDataComuniBF");
                esExito = false;
            }
            return esExito;

        }


        public DataSet CustomerCompanyDataComuniByCompanyIDBF(int CustomerCompanyID)
        {
            
            
            DataSet ds = new DataSet();
            try
            {
                ds = Obj.CustomerCompanyDataComuniByCompanyIDDAL(CustomerCompanyID);
                return ds;
            }
           
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDataComuniBF/CustomerCompanyDataComuniByCompanyIDBF");
            }
            return null;
        }

        public DataSet CustomerCompanyDataComuniByIDBF(int CusCompanyDataID)
        {
            
            
            DataSet ds = new DataSet();
            try
            {
                ds = Obj.CustomerCompanyDataComuniByIDDAL(CusCompanyDataID);
                return ds;
            }
            
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDataComuniBF/CustomerCompanyDataComuniByIDBF");
            }
            return null;
        }
    }
}
