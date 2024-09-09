using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entities;
using System.Data.SqlClient;
namespace DataAccess
{
    public class DetectionMovesDAL
    {

        BaseDatos dbm = new BaseDatos();

        //public Boolean SendDataToNextivaDAL(string Data)
        //{
        //    bool SentInfo = false;

        //    try
        //    {
        //        SentInfo = true;
        //    }

        //    catch (Exception y)
        //    {
        //        SentInfo = false;
        //        //MessageBox.Show("Error :" + y.Message);
        //    }
        //    return SentInfo;
        //}




        public List<AlertasCapture> ListaAlertasCapturadas()
        {
            List<AlertasCapture> lista = new List<AlertasCapture>();
            try
            {
                AlertasCapture ent = new AlertasCapture();
                ent.AlertasCapID = 1;
                ent.AlertasCapIDLogon = "";
                ent.AlertasCapIP = "";
                ent.AlertasCapUser = "";
                ent.AlertasCapPass = "";
                ent.AlertasCapChannel = "";
                ent.AlertasCapTCPUDP = "";
                ent.AlertasCapMainSub = "";
                ent.AlertasCapAlert = "";
                ent.AlertasCapEstado = 1;

                lista.Add(ent);
                return lista;
            }
            catch (Exception ex)
            {
                lista = null;
                throw ex;
            }
            finally
            {

            }
        }

        public Boolean IngrAlarmInformationDAL(AlarmInfomation ObjAlarm)
        {
            Boolean esExito = false;
            try
            {
                SqlConnection con = new SqlConnection();
                SqlParameter parametros;
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_insert_AlarmInfomation", con);
                parametros = cmd.Parameters.Add("@AlarmInfIDE", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmInfIDE;
                parametros = cmd.Parameters.Add("@AlarmInfChannel", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmInfChannel;
                parametros = cmd.Parameters.Add("@AlarmInfState", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmInfState;
                parametros = cmd.Parameters.Add("@AlarmInfEventType", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmInfEventType;
                parametros = cmd.Parameters.Add("@AlarmInfRuleID", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmInfRuleID;
                parametros = cmd.Parameters.Add("@AlarmInTargetID", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmInTargetID;
                parametros = cmd.Parameters.Add("@AlarmInfTargetType", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmInfTargetType;
                parametros = cmd.Parameters.Add("@AlarmInfrctTarget", SqlDbType.VarChar);
                parametros.Value = ObjAlarm.AlarmInfrctTarget;
                parametros = cmd.Parameters.Add("@AlarmInfTargetSpeed", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmInfTargetSpeed;
                parametros = cmd.Parameters.Add("@AlarmInfTargetDirection", SqlDbType.VarChar);
                parametros.Value = ObjAlarm.AlarmInfTargetDirection;

                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                    esExito = true;
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                esExito = false;
            }
            return esExito;
        }

        public DataSet GetAllAlarmInformationDAL()
        {

            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_select_AlarmInfomation", con);
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

        public DataSet GetAllAlarmInformationByID_DAL(string IDECamera)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            try
            {
                //cmd.Connection = new SqlConnection("Data Source=MOVTOSHIPAPA\\SQLSERVER2005;Initial Catalog=DB_DAWPECEI;User Id=sa;Password=lcdp");
                //temporal conexion , se quita despues
                string StrConn = "SERVER=ID-WS2-PC;Initial Catalog=SWG;Integrated Security=True";

                cmd.Connection = new SqlConnection(StrConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SWG_select_AlarmInfomation_by_ID";

                // cmd.Parameters.Add("@IDECamera", SqlDbType.VarChar, 15).Value = IDECamera;

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
