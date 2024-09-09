using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entities;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace DataAccess
{
   public class DeviceDAL
    {
        BaseDatos dbm = new BaseDatos();
        public DataSet AllDeviceDAL()
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Device_Select", con);
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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceDAL/AllTypeRulesListDropDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceDAL/AllTypeRulesListDropDAL");
            }
            return null;
        }
        public DataSet ListDeviceByCompanyIDDAL(int CustomerCompanyID)
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            SqlParameter parametros;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Device_SelectList_By_CompanyID", con);
                parametros = cmd.Parameters.Add("@CustomerCompanyID", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyID;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                con.Close();
                return ds;
            }
            
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceDAL/ListDeviceByCompanyIDDAL");
            }
            return null;
        }
        public DataSet AllDeviceByCompanyIDDAL(int CustomerCompanyID)
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            SqlParameter parametros;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Device_Select_By_CompanyID", con);
                parametros = cmd.Parameters.Add("@CustomerCompanyID", SqlDbType.VarChar);
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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceDAL/AllDeviceByCompanyIDDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceDAL/AllDeviceByCompanyIDDAL");
            }
            return null;
        }

        public DataSet DeviceByIDDAL(int DeviceID)
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            SqlParameter parametros;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Device_Select_by_DeviceID", con);
                parametros = cmd.Parameters.Add("@DeviceID", SqlDbType.Int);
                parametros.Value = DeviceID;
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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceDAL/AllDeviceByCompanyIDDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceDAL/AllDeviceByCompanyIDDAL");
            }
            return null;
        }
        public DataSet DeviceByIPDeviceDAL(string DeviceIP)
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            SqlParameter parametros;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Device_Select_by_DeviceIP", con);
                parametros = cmd.Parameters.Add("@DeviceIP", SqlDbType.VarChar);
                parametros.Value = DeviceIP;
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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceDAL/AllDeviceByCompanyIDDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceDAL/AllDeviceByCompanyIDDAL");
            }
            return null;
        }
        public Boolean IngrDeviceDAL(string DeviceIDE
                                     ,string DeviceNameDescrip
                                     , int TypeDeviceID
                                     ,int CustomerCompanyID 
                                     ,int DeviceChannel 
                                     ,string DeviceIDLogon 
                                     ,string DeviceIP 
                                     ,string DeviceUser
                                     ,string DevicePass
                                     ,string DevicePort 
                                     ,DateTime DeviceDateIng 
                                     ,int DeviceEstado
                                     , int SystemDeviceID)
        {

            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {

                con = dbm.getConexion();
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Device_Insert", con);
                parametros = cmd.Parameters.Add("@DeviceIDE", SqlDbType.VarChar);
                parametros.Value = DeviceIDE;
                parametros = cmd.Parameters.Add("@DeviceNameDescrip", SqlDbType.VarChar);
                parametros.Value = DeviceNameDescrip;
                parametros = cmd.Parameters.Add("@TypeDeviceID", SqlDbType.Int);
                parametros.Value = TypeDeviceID;
                parametros = cmd.Parameters.Add("@CustomerCompanyID", SqlDbType.Int);
                parametros.Value = CustomerCompanyID;
                parametros = cmd.Parameters.Add("@DeviceChannel", SqlDbType.Int);
                parametros.Value = DeviceChannel;
                parametros = cmd.Parameters.Add("@DeviceIDLogon", SqlDbType.VarChar);
                parametros.Value = DeviceIDLogon;
                parametros = cmd.Parameters.Add("@DeviceIP", SqlDbType.VarChar);
                parametros.Value = DeviceIP;
                parametros = cmd.Parameters.Add("@DeviceUser", SqlDbType.VarChar);
                parametros.Value = DeviceUser;
                parametros = cmd.Parameters.Add("@DevicePass", SqlDbType.VarChar);
                parametros.Value = DevicePass;
                parametros = cmd.Parameters.Add("@DevicePort", SqlDbType.VarChar);
                parametros.Value = DevicePort;
                parametros = cmd.Parameters.Add("@DeviceDateIng", SqlDbType.DateTime);
                parametros.Value = DeviceDateIng;
                parametros = cmd.Parameters.Add("@DeviceEstado", SqlDbType.Int);
                parametros.Value = DeviceEstado;
                parametros = cmd.Parameters.Add("@SystemDeviceID", SqlDbType.Int);
                parametros.Value = SystemDeviceID;
                
        

                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    esExito = true;
                }

                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error de SQL :" + ex.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DeviceDAL/IngrDeviceDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DeviceDAL/IngrDeviceDAL");
                esExito = false;
            }
            return esExito;
        }

        public Boolean UpdateDeviceDAL(int DeviceID, string DeviceIDE
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
                                      , int DeviceEstado,
                                        int SystemDeviceID)
        {

            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {

                con = dbm.getConexion();
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Device_Update", con);
                parametros = cmd.Parameters.Add("@DeviceID", SqlDbType.Int);
                parametros.Value = DeviceID;
                parametros = cmd.Parameters.Add("@DeviceIDE", SqlDbType.VarChar);
                parametros.Value = DeviceIDE;
                parametros = cmd.Parameters.Add("@DeviceNameDescrip", SqlDbType.VarChar);
                parametros.Value = DeviceNameDescrip;
                parametros = cmd.Parameters.Add("@TypeDeviceID", SqlDbType.Int);
                parametros.Value = TypeDeviceID;
                parametros = cmd.Parameters.Add("@CustomerCompanyID", SqlDbType.Int);
                parametros.Value = CustomerCompanyID;
                parametros = cmd.Parameters.Add("@DeviceChannel", SqlDbType.Int);
                parametros.Value = DeviceChannel;
                parametros = cmd.Parameters.Add("@DeviceIDLogon", SqlDbType.VarChar);
                parametros.Value = DeviceIDLogon;
                parametros = cmd.Parameters.Add("@DeviceIP", SqlDbType.VarChar);
                parametros.Value = DeviceIP;
                parametros = cmd.Parameters.Add("@DeviceUser", SqlDbType.VarChar);
                parametros.Value = DeviceUser;
                parametros = cmd.Parameters.Add("@DevicePass", SqlDbType.VarChar);
                parametros.Value = DevicePass;
                parametros = cmd.Parameters.Add("@DevicePort", SqlDbType.VarChar);
                parametros.Value = DevicePort;
                parametros = cmd.Parameters.Add("@DeviceDateIng", SqlDbType.DateTime);
                parametros.Value = DeviceDateIng;
                parametros = cmd.Parameters.Add("@DeviceEstado", SqlDbType.Int);
                parametros.Value = DeviceEstado;
                parametros = cmd.Parameters.Add("@SystemDeviceID", SqlDbType.Int);
                parametros.Value = SystemDeviceID;
                


                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    esExito = true;
                }

                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error de SQL :" + ex.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DeviceDAL/UpdateDeviceDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DeviceDAL/UpdateDeviceDAL");
                esExito = false;
            }
            return esExito;
        }

        public Boolean DeleteDeviceDAL(int DeviceID)
        {

            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {

                con = dbm.getConexion();
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Device_Delete", con);
                parametros = cmd.Parameters.Add("@DeviceID", SqlDbType.Int);
                parametros.Value = DeviceID;

                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    esExito = true;
                }

                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error de SQL :" + ex.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DeviceDAL/DeleteDeviceDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DeviceDAL/DeleteDeviceDAL");
                esExito = false;
            }
            return esExito;
        }


        public DataSet DeviceByIDEDAL(string DeviceIDE)
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            SqlParameter parametros;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Device_Select_by_DeviceIDE", con);
                parametros = cmd.Parameters.Add("@DeviceIDE", SqlDbType.VarChar);
                parametros.Value = DeviceIDE;
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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceDAL/DeviceByIDEDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DeviceDAL/DeviceByIDEDAL");
            }
            return null;
        }
    }
}
