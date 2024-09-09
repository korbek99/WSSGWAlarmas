using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace DataAccess
{
    public class CustomerCompanyDataComuniDAL
    {
        BaseDatos dbm = new BaseDatos();

        public Boolean DeleteCustomerCompanyDataComuniDAL(int CusCompanyDataID)
        {

            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {

                con = dbm.getConexion();
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_CustomerCompanyDataComunication_Delete", con);
                parametros = cmd.Parameters.Add("@CusCompanyDataID", SqlDbType.Int);
                parametros.Value = CusCompanyDataID;

                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    esExito = true;
                }

                con.Close();
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyDataComuniDAL/DeleteCustomerCompanyDataComuniDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyDataComuniDAL/DeleteCustomerCompanyDataComuniDAL");
                esExito = false;
            }
            return esExito;

        }
        public Boolean UpdateCustomerCompanyDataComuniDAL(int CusCompanyDataID
                                                          ,int CustomerCompanyID
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

            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {

                con = dbm.getConexion();
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_CustomerCompanyDataComunication_Update", con);
                parametros = cmd.Parameters.Add("@CusCompanyDataID", SqlDbType.Int);
                parametros.Value = CusCompanyDataID;
                parametros = cmd.Parameters.Add("@CustomerCompanyID", SqlDbType.Int);
                parametros.Value = CustomerCompanyID;
                parametros = cmd.Parameters.Add("@CusCompanyDataCameraName", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataCameraName;
                parametros = cmd.Parameters.Add("@CusCompanyDataIDE", SqlDbType.Int);
                parametros.Value = CusCompanyDataIDE;
                parametros = cmd.Parameters.Add("@CusCompanyDataNextNiveles", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataNextNiveles;
                parametros = cmd.Parameters.Add("@CusCompanyDataSiteName", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataSiteName;
                parametros = cmd.Parameters.Add("@CusCompanyDataNameUrl", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataNameUrl;
                parametros = cmd.Parameters.Add("@CusCompanyDataSiteUser", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataSiteUser;
                parametros = cmd.Parameters.Add("@CusCompanyDataSitePass", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataSitePass;
                parametros = cmd.Parameters.Add("@CusCompanyDataAlarmSite", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataAlarmSite;
                parametros = cmd.Parameters.Add("@CusCompanyDataListenResponse", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataListenResponse;
                parametros = cmd.Parameters.Add("@CusCompanyDataListenError", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataListenError;
                parametros = cmd.Parameters.Add("@CusCompanyDataPathString", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataPathString;
                parametros = cmd.Parameters.Add("@CusCompanyDataFileName", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataFileName;
                parametros = cmd.Parameters.Add("@CusCompanyDataActivo", SqlDbType.Int);
                parametros.Value = CusCompanyDataActivo;

                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    esExito = true;
                }

                con.Close();
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyDataComuniDAL/UpdateCustomerCompanyDataComuniDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyDataComuniDAL/UpdateCustomerCompanyDataComuniDAL");
                esExito = false;
            }
            return esExito;

        }
        public Boolean IngrCustomerCompanyDataComuniDAL(int CustomerCompanyID 
                                                         ,string CusCompanyDataCameraName
                                                         ,int  CusCompanyDataIDE
                                                         ,string CusCompanyDataNextNiveles
                                                         ,string CusCompanyDataSiteName
                                                         ,string CusCompanyDataNameUrl 
                                                         ,string CusCompanyDataSiteUser 
                                                         ,string CusCompanyDataSitePass 
                                                         ,string CusCompanyDataAlarmSite 
                                                         ,string CusCompanyDataListenResponse 
                                                         ,string CusCompanyDataListenError 
                                                         ,string CusCompanyDataPathString 
                                                         ,string CusCompanyDataFileName 
                                                         ,int CusCompanyDataActivo )
        { 
        
            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {

                con = dbm.getConexion();
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_CustomerCompanyDataComunication_Insert", con);
                parametros = cmd.Parameters.Add("@CustomerCompanyID", SqlDbType.Int);
                parametros.Value = CustomerCompanyID;
                parametros = cmd.Parameters.Add("@CusCompanyDataCameraName", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataCameraName;
                parametros = cmd.Parameters.Add("@CusCompanyDataIDE", SqlDbType.Int);
                parametros.Value = CusCompanyDataIDE;
                parametros = cmd.Parameters.Add("@CusCompanyDataNextNiveles", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataNextNiveles;
                parametros = cmd.Parameters.Add("@CusCompanyDataSiteName", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataSiteName;
                parametros = cmd.Parameters.Add("@CusCompanyDataNameUrl", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataNameUrl;
                parametros = cmd.Parameters.Add("@CusCompanyDataSiteUser", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataSiteUser;
                parametros = cmd.Parameters.Add("@CusCompanyDataSitePass", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataSitePass;
                parametros = cmd.Parameters.Add("@CusCompanyDataAlarmSite", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataAlarmSite;
                parametros = cmd.Parameters.Add("@CusCompanyDataListenResponse", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataListenResponse;
                parametros = cmd.Parameters.Add("@CusCompanyDataListenError", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataListenError;
                parametros = cmd.Parameters.Add("@CusCompanyDataPathString", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataPathString;
                parametros = cmd.Parameters.Add("@CusCompanyDataFileName", SqlDbType.VarChar);
                parametros.Value = CusCompanyDataFileName;
                parametros = cmd.Parameters.Add("@CusCompanyDataActivo", SqlDbType.Int);
                parametros.Value = CusCompanyDataActivo;

                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    esExito = true;
                }

                con.Close();
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyDataComuniDAL/IngrCustomerCompanyDataComuniDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyDataComuniDAL/IngrCustomerCompanyDataComuniDAL");
                esExito = false;
            }
            return esExito;
        
        }


        public DataSet CustomerCompanyDataComuniByCompanyIDDAL(int CustomerCompanyID)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_CustomerCompanyDataComunication_Select_CustomerCompanyID", con);
                parametros = cmd.Parameters.Add("@CustomerCompanyID", SqlDbType.Int);
                parametros.Value = CustomerCompanyID;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                con.Close();
                return ds;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error de SQL :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDataComuniDAL/CustomerCompanyDataComuniByCompanyIDDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDataComuniDAL/CustomerCompanyDataComuniByCompanyIDDAL");
            }
            return null;
        }

        public DataSet CustomerCompanyDataComuniByIDDAL(int CusCompanyDataID)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_CustomerCompanyDataComunication_Select_ID", con);
                parametros = cmd.Parameters.Add("@CusCompanyDataID", SqlDbType.Int);
                parametros.Value = CusCompanyDataID;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                con.Close();
                return ds;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error de SQL :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDataComuniDAL/CustomerCompanyDataComuniByIDDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDataComuniDAL/CustomerCompanyDataComuniByIDDAL");
            }
            return null;
        }
    }
}
