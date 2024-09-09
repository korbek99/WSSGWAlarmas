using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace DataAccess
{
    public class ErrorSWGNextivaDAL
    {
        BaseDatos dbm = new BaseDatos();


        public DataSet GetTimeServerDAL()
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_TimeServer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                con.Close();
                return ds;
            }
            catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
            catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
            return null;
        }

        private DateTime GetTimeServerDALParams()
        {
            ParamServerDAL objTime = new ParamServerDAL();
            DateTime dtime = new DateTime();
            DataSet ds = new DataSet();

            ds = objTime.GetTimeServerDAL();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dataRow in ds.Tables[0].Rows)
                {
                    dtime = Convert.ToDateTime(dataRow["GETDATE"].ToString());
                }
            }
            return dtime;
        }
        public Boolean TrackingErrorSWGNextivaDAL(DateTime Fecha,
                string MachineName,
                string UserName,
                int IdSistema,
                string Mensaje,
                int Resuelto,
                int NumeroError,
                string Modulo)
        {
            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {
                Fecha = GetTimeServerDALParams();
                con = dbm.getConexion();
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Insert_Errores", con);

                parametros = cmd.Parameters.Add("@Fecha", SqlDbType.DateTime);
                parametros.Value = Fecha;

                parametros = cmd.Parameters.Add("@MachineName", SqlDbType.VarChar);
                parametros.Value = MachineName;

                parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
                parametros.Value = UserName;

                parametros = cmd.Parameters.Add("@IdSistema", SqlDbType.Int);
                parametros.Value = IdSistema;

                parametros = cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar);
                parametros.Value = Mensaje;

                parametros = cmd.Parameters.Add("@Resuelto", SqlDbType.Int);
                parametros.Value = Resuelto;

                parametros = cmd.Parameters.Add("@NumeroError", SqlDbType.Int);
                parametros.Value = NumeroError;

                parametros = cmd.Parameters.Add("@Modulo", SqlDbType.VarChar);
                parametros.Value = Modulo;

                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    esExito = true;
                }

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                esExito = false;
            }
            return esExito;
            //Boolean esExito = false;
            //SqlCommand cmd = new SqlCommand();
            //try
            //{

            //    ////temporal conexion , se quita despues
            //    //string StrConn = "Data Source=MOVTOSHIPAPA\\SQLSERVER2005;Initial Catalog=DB_DAWPECEI;User Id=sa;Password=lcdp";

            //    //cmd.Connection = new SqlConnection(StrConn); // 
            //    //cmd.CommandType = CommandType.StoredProcedure;
            //    //cmd.CommandText = "SWG_Insert_Errores";

            //    //cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha;
            //    //cmd.Parameters.Add("@MachineName", SqlDbType.VarChar, 50).Value = MachineName;
            //    //cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
            //    //cmd.Parameters.Add("@IdSistema", SqlDbType.Int).Value = IdSistema;
            //    //cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 8000).Value = Mensaje;
            //    //cmd.Parameters.Add("@Resuelto", SqlDbType.Int).Value = Resuelto;
            //    //cmd.Parameters.Add("@NumeroError", SqlDbType.Int).Value = NumeroError;
            //    //cmd.Parameters.Add("@Modulo", SqlDbType.VarChar, 50).Value = Modulo;

            //    //cmd.Connection.Open();
            //    //cmd.ExecuteNonQuery();
            //    //cmd.Connection.Close();
            //    //esExito = true;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Excepcion Capturada : {0}", ex);
            //    esExito = false;
            //}
            //return esExito;
        }

        public DataSet GetAllErrorSistemaDAL()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            try
            {
                //cmd.Connection = new SqlConnection("Data Source=MOVTOSHIPAPA\\SQLSERVER2005;Initial Catalog=DB_DAWPECEI;User Id=sa;Password=lcdp");
                //temporal conexion , se quita despues
                string StrConn = "Data Source=MOVTOSHIPAPA\\SQLSERVER2005;Initial Catalog=DB_DAWPECEI;User Id=sa;Password=lcdp";

                cmd.Connection = new SqlConnection(StrConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SWG_select_Errores";

                // cmd.Parameters.Add("@rut", SqlDbType.VarChar, 15).Value = ObjUsuario.Rut;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                sda.Fill(ds);
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
            }
            return ds;

        }
    }
}
