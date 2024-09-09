using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace DataAccess
{
    public class CameraDAL
    {
        BaseDatos dbm = new BaseDatos();
        public DataSet GetAllCamerasDAL()
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_select_Camera", con);
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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CameraDAL/GetAllCamerasDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CameraDAL/GetAllCamerasDAL");
            }
            return null;
        }
        //public DataSet GetAllCamerasDAL()
        //{

        //     SqlConnection con = new SqlConnection();
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        con = dbm.getConexion();
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("SWG_select_UsuarioTipo", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        //        ad.Fill(ds);
        //        con.Close();
        //        return ds;
        //    }
        //    catch (SqlException e)
        //    {
        //        Console.WriteLine("Error de SQL :" + e.Message);
        //        ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
        //        objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioTipoDAL/AllUsuarioTipoDAL");

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error :" + e.Message);
        //        ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
        //        objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioTipoDAL/AllUsuarioTipoDAL");
        //    }

        //}

        public Boolean IngrCamerasDAL(Cameras ObjCam)
        {
            Boolean esExito = false;
            SqlCommand cmd = new SqlCommand();
            try
            {
                //cmd.Connection = new SqlConnection("Data Source=MOVTOSHIPAPA\\SQLSERVER2005;Initial Catalog=DB_DAWPECEI;User Id=sa;Password=lcdp");

                //temporal conexion , se quita despues
                string StrConn = "Data Source=MOVTOSHIPAPA\\SQLSERVER2005;Initial Catalog=DB_DAWPECEI;User Id=sa;Password=lcdp";

                cmd.Connection = new SqlConnection(StrConn); // 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SWG_insert_Camera";

                cmd.Parameters.Add("@CameraIDE", SqlDbType.VarChar, 300).Value = ObjCam.CameraIDE;
                cmd.Parameters.Add("@CameraIDLogon", SqlDbType.VarChar, 300).Value = ObjCam.CameraIDLogon;
                cmd.Parameters.Add("@CameraIP", SqlDbType.VarChar, 300).Value = ObjCam.CameraIP;
                cmd.Parameters.Add("@CameraUser", SqlDbType.VarChar, 20).Value = ObjCam.CameraUser;
                cmd.Parameters.Add("@CameraPass", SqlDbType.VarChar, 20).Value = ObjCam.CameraPass;
                cmd.Parameters.Add("@CameraPort", SqlDbType.VarChar, 100).Value = ObjCam.CameraPort;
                cmd.Parameters.Add("@CameraEstado", SqlDbType.Int).Value = ObjCam.CameraEstado;


                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                esExito = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                esExito = false;
            }
            return esExito;
        }
    }
}
