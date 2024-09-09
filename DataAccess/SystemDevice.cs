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
   public class SystemDeviceDAL
    {
        BaseDatos dbm = new BaseDatos();
        public DataSet GetAllSystemDeviceDAL()
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_SystemDevice_Select", con);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                con.Close();
                return ds;
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "SystemDeviceDAL/GetAllSystemDeviceDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "SystemDeviceDAL/GetAllSystemDeviceDAL");

            }
            return null;
        }
        public DataSet GetAllSystemDeviceListDAL()
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_SystemDevice_Select_List", con);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                con.Close();
                return ds;
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "SystemDeviceDAL/GetAllSystemDeviceListDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "SystemDeviceDAL/GetAllSystemDeviceDAL");

            }
            return null;
        }
        public DataSet GetSystemDeviceByIDDAL(int SystemDeviceID)
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            SqlParameter parametros;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_SystemDevice_Select_ID", con);
                parametros = cmd.Parameters.Add("@SystemDeviceID", SqlDbType.Int);
                parametros.Value = SystemDeviceID;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                con.Close();
                return ds;
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "SystemDeviceDAL/GetAllSystemDeviceDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "SystemDeviceDAL/GetAllSystemDeviceDAL");

            }
            return null;
        }
        public Boolean IngrSystemDeviceDAL(string SystemDeviceDescrip
                                         ,string SystemDeviceUser 
                                         ,string SystemDevicePass
                                         ,DateTime SystemDeviceDateIng
                                         ,int SystemDeviceEstado)
        {
            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {

                con = dbm.getConexion();
                con.Close();
                con.Open();

                SqlCommand cmd = new SqlCommand("SWG_SystemDevice_Insert", con);

                parametros = cmd.Parameters.Add("@SystemDeviceDescrip", SqlDbType.VarChar);
                parametros.Value = SystemDeviceDescrip;
                parametros = cmd.Parameters.Add("@SystemDeviceUser", SqlDbType.VarChar);
                parametros.Value = SystemDeviceUser;
                parametros = cmd.Parameters.Add("@SystemDevicePass", SqlDbType.VarChar);
                parametros.Value = SystemDevicePass;
                parametros = cmd.Parameters.Add("@SystemDeviceDateIng", SqlDbType.DateTime);
                parametros.Value = SystemDeviceDateIng;
                parametros = cmd.Parameters.Add("@SystemDeviceEstado", SqlDbType.Int);
                parametros.Value = SystemDeviceEstado;


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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "SystemDeviceDAL/IngrSystemDeviceDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "SystemDeviceDAL/IngrSystemDeviceDAL");
                esExito = false;
            }

            return esExito;
        }

        public Boolean UpdateSystemDeviceDAL(int SystemDeviceID
                                           ,string SystemDeviceDescrip
                                          , string SystemDeviceUser
                                          , string SystemDevicePass
                                          , DateTime SystemDeviceDateIng
                                          , int SystemDeviceEstado)
        {
            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {

                con = dbm.getConexion();
                con.Close();
                con.Open();

                SqlCommand cmd = new SqlCommand("SWG_SystemDevice_Update", con);
                parametros = cmd.Parameters.Add("@SystemDeviceID", SqlDbType.Int);
                parametros.Value = SystemDeviceID;
                parametros = cmd.Parameters.Add("@SystemDeviceDescrip", SqlDbType.VarChar);
                parametros.Value = SystemDeviceDescrip;
                parametros = cmd.Parameters.Add("@SystemDeviceUser", SqlDbType.VarChar);
                parametros.Value = SystemDeviceUser;
                parametros = cmd.Parameters.Add("@SystemDevicePass", SqlDbType.VarChar);
                parametros.Value = SystemDevicePass;
                parametros = cmd.Parameters.Add("@SystemDeviceDateIng", SqlDbType.DateTime);
                parametros.Value = SystemDeviceDateIng;
                parametros = cmd.Parameters.Add("@SystemDeviceEstado", SqlDbType.Int);
                parametros.Value = SystemDeviceEstado;


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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "SystemDeviceDAL/UpdateSystemDeviceDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "SystemDeviceDAL/UpdateSystemDeviceDAL");
                esExito = false;
            }

            return esExito;
        }

        public Boolean DeleteSystemDeviceDAL(int SystemDeviceID)
        {
            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {

                con = dbm.getConexion();
                con.Close();
                con.Open();

                SqlCommand cmd = new SqlCommand("SWG_SystemDevice_Delete", con);
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
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "SystemDeviceDAL/DeleteSystemDeviceDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "SystemDeviceDAL/DeleteSystemDeviceDAL");
                esExito = false;
            }

            return esExito;
        }
    }
}
