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
    public class CamerasEventPresentDAL
    {
        // SWG_insert_CameraPreset



        public Boolean IngrCameraPresetDAL(CameraPreset Objcam)
        {

            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {
                BaseDatos dbm = new BaseDatos();
                con = dbm.getConexion();
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_insert_CameraPreset", con);
                parametros = cmd.Parameters.Add("@CameraID", SqlDbType.Int);
                parametros.Value = Objcam.CameraID;
                parametros = cmd.Parameters.Add("@CameraPresetChannel", SqlDbType.Int);
                parametros.Value = Objcam.CameraPresetChannel;
                parametros = cmd.Parameters.Add("@CameraPresetPresNumber", SqlDbType.Int);
                parametros.Value = Objcam.CameraPresetPresNumber;
                parametros = cmd.Parameters.Add("@CameraPresetPresCabecera", SqlDbType.VarChar);
                parametros.Value = Objcam.CameraPresetPresCabecera;
                parametros = cmd.Parameters.Add("@CameraPresetPresArgument", SqlDbType.VarChar);
                parametros.Value = Objcam.CameraPresetPresArgument;

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
        }

        public DataSet GetAllCameraPresetDAL()
        {

            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            try
            {
                BaseDatos dbm = new BaseDatos();
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_select_CameraPreset", con);
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
    }
}
