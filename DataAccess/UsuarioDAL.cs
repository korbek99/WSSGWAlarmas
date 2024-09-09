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
    public class UsuarioDAL
    {
        BaseDatos dbm = new BaseDatos();
        public DataSet AllUserDAL()
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_select_Usuarios", con);
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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioDAL/AllUserDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioDAL/AllUserDAL");
            }
            return null;
        }

        public DataSet UserLoginDAL(string UsuarioUser, string UsuarioPass)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_select_Usuario_Loging", con);
                parametros = cmd.Parameters.Add("@UsuarioUser", SqlDbType.Int);
                parametros.Value = UsuarioUser;
                parametros = cmd.Parameters.Add("@UsuarioPass", SqlDbType.Int);
                parametros.Value = UsuarioPass;
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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioDAL/UserLoginDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioDAL/UserLoginDAL");
            }
            return null;
        }


        public Boolean IngresoUsuarioDAL(string UsuarioRut, 
            string UsuarioNombre, 
            string UsuarioApellido, 
            string UsuarioUser, 
            string UsuarioPass,
            DateTime UsuarioFechaIng,
            int UsuarioTipoID,
            int UsuarioPermisoCon,
            int UsuarioPermisoMod,
            int UsuarioPermisoDel ,
            int UsuarioPermisoIng ,
            string UsuarioFoto,
            int UsuarioEstado)
        {

            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {
                Base64DAL Obj64 = new Base64DAL();
                con = dbm.getConexion();
                con.Close();
                con.Open();

                SqlCommand cmd = new SqlCommand("SWG_select_Insert_Usuarios", con);
                parametros = cmd.Parameters.Add("@UsuarioRut", SqlDbType.VarChar);
                parametros.Value = @UsuarioRut;
                parametros = cmd.Parameters.Add("@UsuarioNombre", SqlDbType.VarChar);
                parametros.Value = @UsuarioNombre;
                parametros = cmd.Parameters.Add("@UsuarioApellido", SqlDbType.VarChar);
                parametros.Value = UsuarioApellido;
                parametros = cmd.Parameters.Add("@UsuarioUser", SqlDbType.VarChar);
                parametros.Value = UsuarioUser;
                parametros = cmd.Parameters.Add("@UsuarioPass", SqlDbType.VarChar);
                parametros.Value = Obj64.Base64Decode(UsuarioPass);
                parametros = cmd.Parameters.Add("@UsuarioFechaIng", SqlDbType.DateTime);
                parametros.Value = UsuarioFechaIng;
                parametros = cmd.Parameters.Add("@UsuarioTipoID", SqlDbType.Int);
                parametros.Value = UsuarioTipoID;
                parametros = cmd.Parameters.Add("@UsuarioPermisoCon", SqlDbType.Int);
                parametros.Value = UsuarioPermisoCon;
                parametros = cmd.Parameters.Add("@UsuarioPermisoMod", SqlDbType.Int);
                parametros.Value = UsuarioPermisoMod;
                parametros = cmd.Parameters.Add("@UsuarioPermisoDel", SqlDbType.Int);
                parametros.Value = UsuarioPermisoDel;
                parametros = cmd.Parameters.Add("@UsuarioPermisoIng", SqlDbType.Int);
                parametros.Value = UsuarioPermisoIng;
                parametros = cmd.Parameters.Add("@UsuarioFoto", SqlDbType.VarChar);
                parametros.Value = UsuarioFoto;
                parametros = cmd.Parameters.Add("@UsuarioEstado", SqlDbType.Int);
                parametros.Value = UsuarioEstado;

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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "UsuarioDAL/IngresoUsuarioDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "UsuarioDAL/IngresoUsuarioDAL");
                esExito = false;
            }
            return esExito;
        }

        public Boolean UpdateUsuarioDAL(int UsuarioID, 
            string UsuarioRut,
            string UsuarioNombre,
            string UsuarioApellido,
            string UsuarioUser,
            string UsuarioPass,
            DateTime UsuarioFechaIng,
            int UsuarioTipoID,
            int UsuarioPermisoCon,
            int UsuarioPermisoMod,
            int UsuarioPermisoDel,
            int UsuarioPermisoIng,
            string UsuarioFoto,
            int UsuarioEstado)
        {

            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {
                Base64DAL Obj64 = new Base64DAL();
                con = dbm.getConexion();
                con.Close();
                con.Open();

                SqlCommand cmd = new SqlCommand("SWG_select_Update_Usuarios", con);

                parametros = cmd.Parameters.Add("@UsuarioID", SqlDbType.Int);
                parametros.Value = UsuarioID;
                parametros = cmd.Parameters.Add("@UsuarioRut", SqlDbType.VarChar);
                parametros.Value = @UsuarioRut;
                parametros = cmd.Parameters.Add("@UsuarioNombre", SqlDbType.VarChar);
                parametros.Value = @UsuarioNombre;
                parametros = cmd.Parameters.Add("@UsuarioApellido", SqlDbType.VarChar);
                parametros.Value = UsuarioApellido;
                parametros = cmd.Parameters.Add("@UsuarioUser", SqlDbType.VarChar);
                parametros.Value = UsuarioUser;
                parametros = cmd.Parameters.Add("@UsuarioPass", SqlDbType.VarChar);
                parametros.Value =Obj64.Base64Decode(UsuarioPass);
                parametros = cmd.Parameters.Add("@UsuarioFechaIng", SqlDbType.DateTime);
                parametros.Value = UsuarioFechaIng;
                parametros = cmd.Parameters.Add("@UsuarioTipoID", SqlDbType.Int);
                parametros.Value = UsuarioTipoID;
                parametros = cmd.Parameters.Add("@UsuarioPermisoCon", SqlDbType.Int);
                parametros.Value = UsuarioPermisoCon;
                parametros = cmd.Parameters.Add("@UsuarioPermisoMod", SqlDbType.Int);
                parametros.Value = UsuarioPermisoMod;
                parametros = cmd.Parameters.Add("@UsuarioPermisoDel", SqlDbType.Int);
                parametros.Value = UsuarioPermisoDel;
                parametros = cmd.Parameters.Add("@UsuarioPermisoIng", SqlDbType.Int);
                parametros.Value = UsuarioPermisoIng;
                parametros = cmd.Parameters.Add("@UsuarioFoto", SqlDbType.VarChar);
                parametros.Value = UsuarioFoto;
                parametros = cmd.Parameters.Add("@UsuarioEstado", SqlDbType.Int);
                parametros.Value = UsuarioEstado;

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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "UsuarioDAL/UpdateUsuarioDAL");

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
        public Boolean DeleteUsuarioDAL(int UsuarioID)
        {

            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {

                con = dbm.getConexion();
                con.Close();
                con.Open();

                SqlCommand cmd = new SqlCommand("SWG_select_delete_Usuarios", con);

                parametros = cmd.Parameters.Add("@UsuarioID", SqlDbType.Int);
                parametros.Value = UsuarioID;
               

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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "UsuarioDAL/DeleteUsuarioDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "UsuarioDAL/DeleteUsuarioDAL");
                esExito = false;
            }
            return esExito;
        }
        public DataSet UserByIDDAL(int UsuarioID)
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            SqlParameter parametros;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_select_Usuarios_By_ID", con);
                parametros = cmd.Parameters.Add("@UsuarioID", SqlDbType.Int);
                parametros.Value = UsuarioID;
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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioDAL/UserByIDDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioDAL/UserByIDDAL");
            }
            return null;
        }
        public Boolean UserLoginBoolDAL(string UsuarioUser, string UsuarioPass)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            DataSet ds = new DataSet();
            Boolean Exits = false;
            Base64DAL Obj64 = new Base64DAL();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_select_Usuario_Loging", con);
                parametros = cmd.Parameters.Add("@UsuarioUser", SqlDbType.VarChar);
                parametros.Value = UsuarioUser;
                parametros = cmd.Parameters.Add("@UsuarioPass", SqlDbType.VarChar);
                parametros.Value = Obj64.Base64Encode(UsuarioPass);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Exits = true;
                }
                
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error de SQL :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioDAL/UserLoginBoolDAL");
                Exits = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioDAL/UserLoginBoolDAL");
                Exits = false;
            }
            return Exits;
        }

        public DataSet UserByIDUserNameDAL(string UsuarioUser)
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            SqlParameter parametros;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_select_Usuarios_by_UserName", con);
                parametros = cmd.Parameters.Add("@UsuarioUser", SqlDbType.VarChar);
                parametros.Value = UsuarioUser;
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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioDAL/UserByIDUserNameDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioDAL/UserByIDUserNameDAL");
            }
            return null;
        }
    }
}
