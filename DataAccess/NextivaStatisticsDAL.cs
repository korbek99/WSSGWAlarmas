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
   public class NextivaStatisticsDAL
    {
        BaseDatos dbm = new BaseDatos();
        public DataSet AllNextivaStatisticsDAL(int CustomerCompanyID, int AlarmSentRuleID, DateTime FechaInicio, DateTime FechaFin)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Select_EstadisticaNextica", con);
                parametros = cmd.Parameters.Add("@CustomerCompanyID", SqlDbType.Int);
                parametros.Value = CustomerCompanyID;
                parametros = cmd.Parameters.Add("@AlarmSentRuleID", SqlDbType.Int);
                parametros.Value = AlarmSentRuleID;
                parametros = cmd.Parameters.Add("@FechaInicio", SqlDbType.DateTime);
                parametros.Value = FechaInicio;
                parametros = cmd.Parameters.Add("@FechaFin", SqlDbType.DateTime);
                parametros.Value = FechaFin;
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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "TypeRulesDAL/AllNextivaStatisticsDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "TypeRulesDAL/AllNextivaStatisticsDAL");
            }
            return null;
        }

        public DataSet AllCostumersAndTypeRulesNextivaStatisticsDAL(int AlarmSentRuleID )
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Select_EstadisticaNextica_AllCostumers", con);
                parametros = cmd.Parameters.Add("@AlarmSentRuleID", SqlDbType.Int);
                parametros.Value = AlarmSentRuleID;
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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "TypeRulesDAL/AllCostumersAndTypeRulesNextivaStatisticsDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "TypeRulesDAL/AllCostumersAndTypeRulesNextivaStatisticsDAL");
            }
            return null;
        }

        public DataSet AllCostumersByTypeRulesNextivaStatisticsDAL()
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Select_EstadisticaNextica_AllCostumersByRules", con);
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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "TypeRulesDAL/AllCostumersByTypeRulesNextivaStatisticsDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "TypeRulesDAL/AllCostumersByTypeRulesNextivaStatisticsDAL");
            }
            return null;
        }
    }
}
