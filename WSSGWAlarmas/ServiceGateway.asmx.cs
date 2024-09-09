using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Business;
using System.Data;
using Entities;
namespace WSSGWAlarmas
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hello World";
        //}

        [WebMethod]
        public Boolean ServiceSendDataCameraToNextiva(int AlarmSentChannel,
                                                     int AlarmSentCustCompanyID,
                                                    string AlarmSentDateIng,
                                                    string AlarmSentDescription,
                                                    int AlarmSentEstado,
                                                    string AlarmSentIDE,
                                                    string AlarmSentrctTarget,
                                                    string AlarmSentRuleDescrip,
                                                    int AlarmSentRuleID,
                                                    int AlarmSentState,
                                                    int AlarmSentTargetDirection,
                                                    int AlarmSentTargetID,
                                                    int AlarmSentTargetSpeed,
                                                    int AlarmSentTargetType,
                                                    int AlarmSentventType)
        {
            DataNextivaBF ObjDataNext = new DataNextivaBF();
            Boolean EsExito = false;
            try
            {

                List<AlarmNextiva> lista = new List<AlarmNextiva>();
                lista.Add(new AlarmNextiva()
                {
                    AlarmSentChannel = AlarmSentChannel,
                    AlarmSentventType = AlarmSentRuleID,
                    AlarmSentIDE = AlarmSentIDE,
                    AlarmSentrctTarget = "",
                    AlarmSentRuleID = AlarmSentRuleID,
                    AlarmSentRuleDescrip = AlarmSentDescription,
                    AlarmSentState = AlarmSentState,
                    AlarmSentTargetDirection = AlarmSentTargetDirection,
                    AlarmSentTargetSpeed = AlarmSentTargetSpeed,
                    AlarmSentTargetType = AlarmSentTargetType,
                    AlarmSentTargetID = AlarmSentTargetType,
                    AlarmSentDescription = AlarmSentDescription,
                    AlarmSentCustCompanyID = AlarmSentCustCompanyID
                });


                EsExito = ObjDataNext.SendDataCameraToNextivaBF(lista);

                if (EsExito == true)
                {
                    EsExito = true;
                }
                else
                {
                    EsExito = false;

                    ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                    SWGParams ObjParam = new SWGParams();
                    objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "WebServiceSWGateway", 1, "No fue Realizado Proceso", 1, 1, "WebServiceSWGateway/ServiceSendDataCameraToNextiva");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error :" + ex.Message);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                SWGParams ObjParam = new SWGParams();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "WebServiceSWGateway", 1, "Error :" + ex.Message, 1, 1, "WebServiceSWGateway/ServiceSendDataCameraToNextiva");
            }



            return EsExito;
        }

        [WebMethod]
        public Boolean ServiceTrackingErrorSWG(DateTime Fecha,
                 string MachineName,
                 string UserName,
                 int IdSistema,
                 string Mensaje,
                 int Resuelto,
                 int NumeroError,
                 string Modulo)
        {
            Boolean esExito = false;

            try
            {
                ErrorSWGNextivaBF objError = new ErrorSWGNextivaBF();
                if (objError.TrackingErrorSWGNextivaBF(Fecha, MachineName, UserName, IdSistema, Mensaje, Resuelto, NumeroError, Modulo) == true)
                {
                    esExito = true;
                }
                else
                {

                    esExito = false;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Excepcion Capturada : {0}", ex);
                esExito = false;
            }
            return esExito;
        }

        [WebMethod]
        public DataSet ServiceDeviceByCompanyID(int CustomerCompanyID)
        {
            DataSet ds = new DataSet();
            DeviceBF Obj = new DeviceBF();
            try
            {
                ds = Obj.AllDeviceByCompanyIDBF(CustomerCompanyID);
                return ds;
            }
            catch (Exception ex)
            {
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                SWGParams ObjParam = new SWGParams();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "WebServiceSWGateway", 1, "Error :" + ex.Message, 1, 1, "WebServiceSWGateway/ServiceDeviceByCompanyID");
            }
            return null;
        }
        [WebMethod]
        public Boolean ServiceIngrDevice(string DeviceIDE
                                    , string DeviceNameDescrip
                                    , int TypeDeviceID
                                    , int CustomerCompanyID
                                    , int DeviceChannel
                                    , string DeviceIDLogon
                                    , string DeviceIP
                                    , string DeviceUser
                                    , string DevicePass
                                    , string DevicePort
                                    , string DeviceDateIng
                                    , int DeviceEstado
                                    , int SystemDeviceID)
        {


            Boolean esExito = false;
            DeviceBF Obj = new DeviceBF();
            try
            {
                esExito = Obj.IngrDeviceBF(DeviceIDE
                                 , DeviceNameDescrip
                                 , TypeDeviceID
                                 , CustomerCompanyID
                                 , DeviceChannel
                                 , DeviceIDLogon
                                 , DeviceIP
                                 , DeviceUser
                                 , DevicePass
                                 , DevicePort
                                 , Convert.ToDateTime(DeviceDateIng)
                                 , DeviceEstado,
                                 SystemDeviceID);

            }
            catch (Exception ex)
            {
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                SWGParams ObjParam = new SWGParams();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "WebServiceSWGateway", 1, "Error :" + ex.Message, 1, 1, "WebServiceSWGateway/ServiceIngrDevice");
            }
            return esExito;
        }

        [WebMethod]
        public Boolean ServiceIngresoCustomerCompany(
             string CustomerCompanyIDE,
             string CustomerCompanyName,
             string CustomerCompanyDir,
             string CustomerCompanyPhone,
             string CustomerCompanyCelPhone,
             string CustomerCompanyEmail,
             string CustomerCompanyFax,
             string CustomerCompanyWebSite,
             int CiudadID,
             string CustomerCompanyDateIng,
             int CustomerCompanyState,
             string CustomerCompanyShortName)
        {


            Boolean esExito = false;
            CustomerCompanyBF Obj = new CustomerCompanyBF();
            try
            {
                esExito = Obj.IngrCustomerCompanyBF(CustomerCompanyIDE,
                                                      CustomerCompanyName,
                                                      CustomerCompanyDir,
                                                      CustomerCompanyPhone,
                                                      CustomerCompanyCelPhone,
                                                      CustomerCompanyEmail,
                                                      CustomerCompanyFax,
                                                      CustomerCompanyWebSite,
                                                      CiudadID,
                                                     Convert.ToDateTime(CustomerCompanyDateIng),
                                                      CustomerCompanyState,
                                                      CustomerCompanyShortName);
            }
            catch (Exception ex)
            {
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                SWGParams ObjParam = new SWGParams();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "WebServiceSWGateway", 1, "Error :" + ex.Message, 1, 1, "WebServiceSWGateway/ServiceIngresoCustomerCompany");
            }
            return esExito;
        }


        [WebMethod]
        public Boolean ServiceDeleteCustomerCompanyDataComuni(int CusCompanyDataID)
        {
            Boolean esExito = false;
            CustomerCompanyDataComuniBF Obj = new CustomerCompanyDataComuniBF();
            try
            {
                esExito = Obj.DeleteCustomerCompanyDataComuniBF(CusCompanyDataID); ;
            }

            catch (Exception ex)
            {

                Console.WriteLine("Error :" + ex.Message);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Web Service SWGateway", 1, "Error :" + ex.Message, 1, 1, "WebServiceSWGateway/ServiceDeleteCustomerCompanyDataComuni");
            }
            return esExito;

        }
        [WebMethod]
        public Boolean ServiceUpdateCustomerCompanyDataComuni(int CusCompanyDataID
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
            CustomerCompanyDataComuniBF Obj = new CustomerCompanyDataComuniBF();
            try
            {


                esExito = Obj.UpdateCustomerCompanyDataComuniBF(CusCompanyDataID
                                                          , CustomerCompanyID
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

                Console.WriteLine("Error :" + ex.Message);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Web Service SWGateway", 1, "Error :" + ex.Message, 1, 1, "WebServiceSWGateway/ServiceUpdateCustomerCompanyDataComuni");
            }
            return esExito;

        }
        [WebMethod]
        public Boolean ServiceIngrCustomerCompanyDataComuni(int CustomerCompanyID
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

            CustomerCompanyDataComuniBF Obj = new CustomerCompanyDataComuniBF();
            Boolean esExito = false;

            try
            {



                esExito = Obj.IngrCustomerCompanyDataComuniBF(CustomerCompanyID
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

                Console.WriteLine("Error :" + ex.Message);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Web Service SWGateway", 1, "Error :" + ex.Message, 1, 1, "WebServiceSWGateway/ServiceIngrCustomerCompanyDataComuni");
            }
            return esExito;

        }

        [WebMethod]
        public DataSet ServiceCustomerCompanyDataComuniByCompanyID(int CustomerCompanyID)
        {

            CustomerCompanyDataComuniBF Obj = new CustomerCompanyDataComuniBF();
            DataSet ds = new DataSet();
            try
            {
                ds = Obj.CustomerCompanyDataComuniByCompanyIDBF(CustomerCompanyID);
                return ds;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Web Service SWGateway", 1, "Error :" + e.Message, 1, 1, "WebServiceSWGateway/ServiceCustomerCompanyDataComuniByCompanyID");
            }
            return null;
        }
        [WebMethod]
        public DataSet ServiceCustomerCompanyDataComuniByID(int CusCompanyDataID)
        {

            CustomerCompanyDataComuniBF Obj = new CustomerCompanyDataComuniBF();
            DataSet ds = new DataSet();
            try
            {
                ds = Obj.CustomerCompanyDataComuniByIDBF(CusCompanyDataID);
                return ds;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Web Service SWGateway", 1, "Error :" + e.Message, 1, 1, "WebServiceSWGateway/ServiceCustomerCompanyDataComuniByID");
            }
            return null;
        }

        [WebMethod]
        public Boolean ServicioCustomerCompany_Ingreso(
            string CustomerCompanyIDE,
            string CustomerCompanyName,
            string CustomerCompanyDir,
            string CustomerCompanyPhone,
            string CustomerCompanyCelPhone,
            string CustomerCompanyEmail,
            string CustomerCompanyFax,
            string CustomerCompanyWebSite,
            int CiudadID,
            string CustomerCompanyDateIng,
            int CustomerCompanyState,
            string CustomerCompanyShortName)
        {


            Boolean esExito = false;

            try
            {
                CustomerCompanyBF Obj = new CustomerCompanyBF();
                esExito = Obj.IngrCustomerCompanyBF(CustomerCompanyIDE,
                                                      CustomerCompanyName,
                                                      CustomerCompanyDir,
                                                      CustomerCompanyPhone,
                                                      CustomerCompanyCelPhone,
                                                      CustomerCompanyEmail,
                                                      CustomerCompanyFax,
                                                      CustomerCompanyWebSite,
                                                      CiudadID,
                                                      Convert.ToDateTime(CustomerCompanyDateIng),
                                                      CustomerCompanyState,
                                                      CustomerCompanyShortName);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Web Service SWGateway", 1, "Error :" + ex.Message, 1, 1, "WebServiceSWGateway/ServicioCustomerCompany_Ingreso");
                esExito = false;
            }
            return esExito;
        }
        [WebMethod]
        public Boolean ServicioCustomerCompany_Update(
            int CustomerCompanyID,
            string CustomerCompanyIDE,
            string CustomerCompanyName,
            string CustomerCompanyDir,
            string CustomerCompanyPhone,
            string CustomerCompanyCelPhone,
            string CustomerCompanyEmail,
            string CustomerCompanyFax,
            string CustomerCompanyWebSite,
            int CiudadID,
            string CustomerCompanyDateIng,
            int CustomerCompanyState,
            string CustomerCompanyShortName)
        {


            Boolean esExito = false;
            CustomerCompanyBF Obj = new CustomerCompanyBF();
            try
            {


                esExito = Obj.UpdateCustomerCompanyBF(CustomerCompanyID,
                                                    CustomerCompanyIDE,
                                                   CustomerCompanyName,
                                                   CustomerCompanyDir,
                                                   CustomerCompanyPhone,
                                                   CustomerCompanyCelPhone,
                                                   CustomerCompanyEmail,
                                                   CustomerCompanyFax,
                                                   CustomerCompanyWebSite,
                                                   CiudadID,
                                                   Convert.ToDateTime(CustomerCompanyDateIng),
                                                   CustomerCompanyState,
                                                   CustomerCompanyShortName);

            }

            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Web Service SWGateway", 1, "Error :" + ex.Message, 1, 1, "WebServiceSWGateway/ServicioCustomerCompany_Update");
                esExito = false;
            }
            return esExito;
        }
        [WebMethod]
        public Boolean ServiceCustomerCompany_Delete(
            int CustomerCompanyID)
        {


            Boolean esExito = false;

            try
            {
                CustomerCompanyBF Obj = new CustomerCompanyBF();
                esExito = Obj.DeleteCustomerCompanyBF(CustomerCompanyID);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Web Service SWGateway", 1, "Error :" + ex.Message, 1, 1, "WebServiceSWGateway/ServiceCustomerCompany_Delete");
                esExito = false;
            }
            return esExito;
        }
        [WebMethod]
        public DataSet ServiceCustomerCompanyByCustomerIP(string IP)
        {
            CustomerCompanyBF Obj = new CustomerCompanyBF();

            DataSet ds = new DataSet();
            try
            {
                ds = Obj.CustomerCompanyByCustomerIPBF(IP);
                return ds;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Web Service SWGateway", 1, "Error :" + e.Message, 1, 1, "WebServiceSWGateway/ServiceCustomerCompanyByCustomerIP");
            }
            return null;
        }
        [WebMethod]
        public DataSet ServiceCustomerCompanyByCustomerID(int ID)
        {
            CustomerCompanyBF Obj = new CustomerCompanyBF();

            DataSet ds = new DataSet();
            try
            {
                ds = Obj.CustomerCompanyByCustomerIDBF(ID);
                return ds;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Web Service SWGateway", 1, "Error :" + e.Message, 1, 1, "WebServiceSWGateway/ServiceCustomerCompanyByCustomerID");
            }
            return null;
        }
        [WebMethod]
        public DataSet ServiceCustomerCompanyAllByCustomer()
        {
            CustomerCompanyBF Obj = new CustomerCompanyBF();

            DataSet ds = new DataSet();
            try
            {
                ds = Obj.AllCustomerCompanyByCustomerBF();

                return ds;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Web Service SWGateway", 1, "Error :" + e.Message, 1, 1, "WebServiceSWGateway/ServiceCustomerCompanyAllByCustomer");
            }
            return null;


        }
        [WebMethod]
        public DataSet ServiceCustomerCompanyAllListDrop()
        {
            CustomerCompanyBF Obj = new CustomerCompanyBF();
            DataSet ds = new DataSet();
            try
            {

                ds = Obj.AllCustomerCompanyListDropBF();

                return ds;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Web Service SWGateway", 1, "Error :" + e.Message, 1, 1, "WebServiceSWGateway/ServiceCustomerCompanyAllListDrop");
            }
            return null;
        }
        [WebMethod]
        public DataSet ServiceCustomerCompanySearchByNameCustomer(string str_name)
        {
            CustomerCompanyBF Obj = new CustomerCompanyBF();
            DataSet ds = new DataSet();
            try
            {
                ds = Obj.SearchCustomerCompanyByNameCustomerBF(str_name);

                return ds;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Web Service SWGateway", 1, "Error :" + e.Message, 1, 1, "WebServiceSWGateway/ServiceCustomerCompanySearchByNameCustomer");
            }
            return null;
        }
        [WebMethod]
        public DataSet ServiceCustomerCompanyByCiudadID(int CiudadID)
        {
            CustomerCompanyBF Obj = new CustomerCompanyBF();
            DataSet ds = new DataSet();
            try
            {
                ds = Obj.CustomerCompanyByCiudadIDBF(CiudadID);

                return ds;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Web Service SWGateway", 1, "Error :" + e.Message, 1, 1, "WebServiceSWGateway/ServiceCustomerCompanyByCiudadID");
            }
            return null;
        }

        [WebMethod]
        public DataSet ServiceDeviceAll()
        {

            DataSet ds = new DataSet();
            DeviceBF Obj = new DeviceBF();
            try
            {
                ds = Obj.AllDeviceBF();
                return ds;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "WebServiceSWGateway", 1, "Error :" + e.Message, 1, 1, "WebServiceSWGateway/ServiceDeviceAll");
            }
            return null;
        }
        [WebMethod]
        public DataSet ServiceDeviceByID(int DeviceID)
        {

            DataSet ds = new DataSet();
            DeviceBF Obj = new DeviceBF();
            try
            {
                ds = Obj.DeviceByIDBF(DeviceID);
                return ds;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "WebServiceSWGateway", 1, "Error :" + e.Message, 1, 1, "WebServiceSWGateway/ServiceDeviceByID");
            }
            return null;
        }
        [WebMethod]
        public DataSet ServiceAllDeviceByCompanyID(int CustomerCompanyID)
        {

            DataSet ds = new DataSet();
            DeviceBF Obj = new DeviceBF();
            try
            {
                ds = Obj.AllDeviceByCompanyIDBF(CustomerCompanyID);
                return ds;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "WebServiceSWGateway", 1, "Error :" + e.Message, 1, 1, "WebServiceSWGateway/ServiceDeviceByCompanyID");
            }
            return null;
        }

        [WebMethod]
        public DataSet ServiceSystemDeviceGetAll()
        {

            DataSet ds = new DataSet();
            DeviceBF ObjSys = new DeviceBF();
            try
            {
                ds = ObjSys.AllDeviceBF();
                return ds;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "WebService SWGateway", 1, "Error :" + ex.Message, 1, 1, "WebServiceSWGateway/ServiceSystemDeviceGetAll");

            }
            return null;
        }
        [WebMethod]
        public DataSet ServiceSystemDeviceByID(int SystemDeviceID)
        {

            DataSet ds = new DataSet();
            SystemDeviceBF ObjSys = new SystemDeviceBF();
            try
            {
                ds = ObjSys.GetSystemDeviceByIDBF(SystemDeviceID);
                return ds;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "WebService SWGateway", 1, "Error :" + ex.Message, 1, 1, "WebServiceSWGateway/ServiceSystemDeviceByID");

            }
            return null;
        }
        [WebMethod]
        public Boolean ServiceSystemDevice_Ingreso(string SystemDeviceDescrip
                                        , string SystemDeviceUser
                                        , string SystemDevicePass
                                        , string SystemDeviceDateIng
                                        , int SystemDeviceEstado)
        {

            Boolean esExito = false;
            SystemDeviceBF ObjSys = new SystemDeviceBF();
            try
            {


                esExito = ObjSys.IngrSystemDeviceBF(SystemDeviceDescrip
                                         , SystemDeviceUser
                                         , SystemDevicePass
                                         , Convert.ToDateTime(SystemDeviceDateIng)
                                         , SystemDeviceEstado);

            }

            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "WebService SWGateway", 1, "Error :" + ex.Message, 1, 1, "WebServiceSWGateway/SystemDevice_Ingreso");
                esExito = false;
            }

            return esExito;
        }
        [WebMethod]
        public Boolean ServiceSystemDevice_Update(int SystemDeviceID
                                          , string SystemDeviceDescrip
                                         , string SystemDeviceUser
                                         , string SystemDevicePass
                                         , string SystemDeviceDateIng
                                         , int SystemDeviceEstado)
        {

            Boolean esExito = false;
            SystemDeviceBF ObjSys = new SystemDeviceBF();
            try
            {


                esExito = ObjSys.UpdateSystemDeviceBF(SystemDeviceID, SystemDeviceDescrip
                                     , SystemDeviceUser
                                     , SystemDevicePass
                                     , Convert.ToDateTime(SystemDeviceDateIng)
                                     , SystemDeviceEstado);

            }

            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "WebService SWGateway", 1, "Error :" + ex.Message, 1, 1, "WebServiceSWGateway/ServiceSystemDevice_Update");
                esExito = false;
            }

            return esExito;
        }
        [WebMethod]
        public Boolean ServiceSystemDevice_Delete(int SystemDeviceID)
        {

            Boolean esExito = false;
            SystemDeviceBF ObjSys = new SystemDeviceBF();
            try
            {

                esExito = ObjSys.DeleteSystemDeviceBF(SystemDeviceID);

            }

            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "WebService SWGateway", 1, "Error :" + ex.Message, 1, 1, "WebServiceSWGateway/ServiceSystemDevice_Delete");
                esExito = false;
            }

            return esExito;
        }

        [WebMethod]
        public DataSet ServiceDeviceByIDE(string DeviceIDE)
        {

            DataSet ds = new DataSet();
            DeviceBF Obj = new DeviceBF();

            ds = Obj.DeviceByIDEBF(DeviceIDE);
            return ds;

        }

        [WebMethod]
        public DataSet ServiceGetAllCities()
        {

            DataSet ds = new DataSet();
            CiudadBF Obj = new CiudadBF();

            ds = Obj.GetAllCityBF();

            return ds;

        }

        [WebMethod]
        public DataSet ServiceGetAllTypeDevice()
        {
            DataSet ds = new DataSet();
            TypeDeviceBF Obj = new TypeDeviceBF();

            ds = Obj.GetAllTypeDeviceBF();
            return ds;
        }
        [WebMethod]
        public DataSet ServiceGetAllSystemDeviceList()
        {
            SystemDeviceBF Obj = new SystemDeviceBF();
            DataSet ds = new DataSet();
            ds = Obj.GetAllSystemDeviceListBF();
            return ds;
        }

        [WebMethod]
        public DataSet ServiceCustomerCompanyByIDE(string CustomerCompanyIDE)
        {

            DataSet ds = new DataSet();
            CustomerCompanyBF Obj = new CustomerCompanyBF();
       
                ds = Obj.CustomerCompanyByIDEBF(CustomerCompanyIDE);
                return ds;
           
        }

        [WebMethod]
        public Boolean ServiceIngrCustomerCompanyDataComunications(int CustomerCompanyID
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
            CustomerCompanyDataComuniBF Obj = new CustomerCompanyDataComuniBF();
                esExito = Obj.IngrCustomerCompanyDataComuniBF(CustomerCompanyID
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
           
            return esExito;

        }
    }
}