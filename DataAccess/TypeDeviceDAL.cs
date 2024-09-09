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
   public class TypeDeviceDAL
    {
        BaseDatos dbm = new BaseDatos();
        public DataSet GetAllTypeDeviceDAL()
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("TypeDevice_Select", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                con.Close();
                return ds;
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "TypeDeviceDAL/GetAllTypeDeviceDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "TypeDeviceDAL/GetAllTypeDeviceDAL");

            }
            return null;
        }
        public DataSet GetTypeDeviceByIDDAL(int TypeDeviceID)
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            SqlParameter parametros;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_TypeDevice_Select_by_ID", con);
                parametros = cmd.Parameters.Add("@TypeDeviceID", SqlDbType.Int);
                parametros.Value = TypeDeviceID;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "TypeDeviceDAL/GetTypeDeviceByIDDAL");

            }
            return null;
        }
        public Boolean IngrTypeDeviceDAL(string TypeDeviceDescrip)
        {
             SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {

                con = dbm.getConexion();
                con.Close();
                con.Open();

                SqlCommand cmd = new SqlCommand("SWG_TypeDevice_Insert", con);

                parametros = cmd.Parameters.Add("@TypeDeviceDescrip", SqlDbType.VarChar);
                parametros.Value = TypeDeviceDescrip;
 

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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "TypeDeviceDAL/IngrTypeDeviceDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "UsuarioDAL/UpdateUsuarioDAL");
                esExito = false;
            }

                return esExito;
        }

        public Boolean UpdateTypeDeviceDAL(int TypeDeviceID ,string TypeDeviceDescrip)
        {
            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {
                con = dbm.getConexion();
                con.Close();
                con.Open();

                SqlCommand cmd = new SqlCommand("SWG_TypeDevice_Update", con);

                parametros = cmd.Parameters.Add("@TypeDeviceID", SqlDbType.Int);
                parametros.Value = TypeDeviceID;
                
                parametros = cmd.Parameters.Add("@TypeDeviceDescrip", SqlDbType.VarChar);
                parametros.Value = TypeDeviceDescrip;


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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "TypeDeviceDAL/UpdateTypeDeviceDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "UsuarioDAL/UpdateTypeDeviceDAL");
                esExito = false;
            }

            return esExito;
        }

        public Boolean DeleteTypeDeviceDAL(int TypeDeviceID)
        {
            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {
                con = dbm.getConexion();
                con.Close();
                con.Open();

                SqlCommand cmd = new SqlCommand("SWG_TypeDevice_Delete", con);

                parametros = cmd.Parameters.Add("@TypeDeviceID", SqlDbType.Int);
                parametros.Value = TypeDeviceID;

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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "TypeDeviceDAL/SWG_TypeDevice_Delete");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "UsuarioDAL/SWG_TypeDevice_Delete");
                esExito = false;
            }

            return esExito;
        }
    }
}
