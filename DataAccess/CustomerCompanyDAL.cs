﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace DataAccess
{
    public class CustomerCompanyDAL
    {
        BaseDatos dbm = new BaseDatos();

        public Boolean IngrCustomerCompanyDAL(
            string CustomerCompanyIDE,
            string CustomerCompanyName ,
            string CustomerCompanyDir,
            string CustomerCompanyPhone ,
            string CustomerCompanyCelPhone ,
            string CustomerCompanyEmail ,
            string CustomerCompanyFax ,
            string CustomerCompanyWebSite ,
            int CiudadID ,
            DateTime CustomerCompanyDateIng,
            int CustomerCompanyState ,
            string CustomerCompanyShortName )
        {

            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {

                con = dbm.getConexion();
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Insert_CustomerCompany", con);
                parametros = cmd.Parameters.Add("@CustomerCompanyIDE", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyIDE;
                parametros = cmd.Parameters.Add("@CustomerCompanyName", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyName;
                parametros = cmd.Parameters.Add("@CustomerCompanyDir", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyDir;
                parametros = cmd.Parameters.Add("@CustomerCompanyPhone", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyPhone;
                parametros = cmd.Parameters.Add("@CustomerCompanyCelPhone", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyCelPhone;
                parametros = cmd.Parameters.Add("@CustomerCompanyEmail", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyEmail;
                parametros = cmd.Parameters.Add("@CustomerCompanyFax", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyFax;
                parametros = cmd.Parameters.Add("@CustomerCompanyWebSite", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyWebSite;
                parametros = cmd.Parameters.Add("@CiudadID", SqlDbType.Int);
                parametros.Value = CiudadID;
                parametros = cmd.Parameters.Add("@CustomerCompanyDateIng", SqlDbType.DateTime);
                parametros.Value = CustomerCompanyDateIng;
                parametros = cmd.Parameters.Add("@CustomerCompanyState", SqlDbType.Int);
                parametros.Value = CustomerCompanyState;
                parametros = cmd.Parameters.Add("@CustomerCompanyShortName", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyShortName;


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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyDAL/IngrCustomerCompanyDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyDAL/IngrCustomerCompanyDAL");
                esExito = false;
            }
            return esExito;
        }

        public Boolean UpdateCustomerCompanyDAL(
            int CustomerCompanyID ,
            string CustomerCompanyIDE,
            string CustomerCompanyName,
            string CustomerCompanyDir,
            string CustomerCompanyPhone,
            string CustomerCompanyCelPhone,
            string CustomerCompanyEmail,
            string CustomerCompanyFax,
            string CustomerCompanyWebSite,
            int CiudadID,
            DateTime CustomerCompanyDateIng,
            int CustomerCompanyState,
            string CustomerCompanyShortName)
        {

            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {

                con = dbm.getConexion();
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Update_CustomerCompany", con);

                parametros = cmd.Parameters.Add("@CustomerCompanyID", SqlDbType.Int);
                parametros.Value = CustomerCompanyID;
                parametros = cmd.Parameters.Add("@CustomerCompanyIDE", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyIDE;
                parametros = cmd.Parameters.Add("@CustomerCompanyName", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyName;
                parametros = cmd.Parameters.Add("@CustomerCompanyDir", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyDir;
                parametros = cmd.Parameters.Add("@CustomerCompanyPhone", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyPhone;
                parametros = cmd.Parameters.Add("@CustomerCompanyCelPhone", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyCelPhone;
                parametros = cmd.Parameters.Add("@CustomerCompanyEmail", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyEmail;
                parametros = cmd.Parameters.Add("@CustomerCompanyFax", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyFax;
                parametros = cmd.Parameters.Add("@CustomerCompanyWebSite", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyWebSite;
                parametros = cmd.Parameters.Add("@CiudadID", SqlDbType.Int);
                parametros.Value = CiudadID;
                parametros = cmd.Parameters.Add("@CustomerCompanyDateIng", SqlDbType.DateTime);
                parametros.Value = CustomerCompanyDateIng;
                parametros = cmd.Parameters.Add("@CustomerCompanyState", SqlDbType.Int);
                parametros.Value = CustomerCompanyState;
                parametros = cmd.Parameters.Add("@CustomerCompanyShortName", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyShortName;


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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyDAL/UpdateCustomerCompanyDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyDAL/UpdateCustomerCompanyDAL");
                esExito = false;
            }
            return esExito;
        }

        public Boolean DeleteCustomerCompanyDAL(
            int CustomerCompanyID)
        {

            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {

                con = dbm.getConexion();
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Delete_CustomerCompany", con);

                parametros = cmd.Parameters.Add("@CustomerCompanyID", SqlDbType.Int);
                parametros.Value = CustomerCompanyID;
            


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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyDAL/DeleteCustomerCompanyDAL");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyDAL/DeleteCustomerCompanyDAL");
                esExito = false;
            }
            return esExito;
        }
        public DataSet CustomerCompanyByCustomerIPDAL(string IP)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Select_Camera_CostumerIP", con);
                parametros = cmd.Parameters.Add("@CameraIP", SqlDbType.VarChar);
                parametros.Value = IP;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                con.Close();
                return ds;
            }
            catch (SqlException e) { 
                Console.WriteLine("Error de SQL :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDAL/CustomerCompanyByCustomerIPDAL");
            
            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDAL/CustomerCompanyByCustomerIPDAL");
            }
            return null;
        }
        public DataSet CustomerCompanyByCiudadIDDAL(int CiudadID)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_select_CustomerCompany_By_Parameters", con);
                parametros = cmd.Parameters.Add("@CiudadID", SqlDbType.Int);
                parametros.Value = CiudadID;
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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDAL/CustomerCompanyByCiudadIDDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDAL/CustomerCompanyByCiudadIDDAL");
            }
            return null;
        }
        public DataSet CustomerCompanyByCustomerIDDAL(int ID)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_select_CustomerCompany_by_Id", con);
                parametros = cmd.Parameters.Add("@CustomerCompanyID", SqlDbType.Int);
                parametros.Value = ID;
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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDAL/CustomerCompanyByCustomerIPDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDAL/CustomerCompanyByCustomerIPDAL");
            }
            return null;
        }

        public DataSet CustomerCompanyByIDEDAL(string CustomerCompanyIDE)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_select_CustomerCompany_by_IDE", con);
                parametros = cmd.Parameters.Add("@CustomerCompanyIDE", SqlDbType.VarChar);
                parametros.Value = CustomerCompanyIDE;
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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDAL/CustomerCompanyByIDEDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDAL/CustomerCompanyByIDEDAL");
            }
            return null;
        }
        public DataSet AllCustomerCompanyDAL()
        {
            SqlConnection con = new SqlConnection();
            //SqlParameter parametros;
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_select_CustomerCompany", con);
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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDAL/AllCustomerCompanyDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDAL/AllCustomerCompanyDAL");
            }
            return null;
        }

        public DataSet AllCustomerCompanyListDropDAL()
        {
            SqlConnection con = new SqlConnection();
            //SqlParameter parametros;
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Select_CustomerCompany_droplist", con);

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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDAL/CustomerCompanyByCustomerIPDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDAL/CustomerCompanyByCustomerIPDAL");
            }
            return null;
        }



        public DataSet SearchCustomerCompanyByNameCustomerDAL(string str_name)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_select_CustomerCompany_by_Name", con);
                parametros = cmd.Parameters.Add("@NameParam", SqlDbType.VarChar);
                parametros.Value = str_name;
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
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDAL/CustomerCompanyByCustomerIPDAL");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyDAL/CustomerCompanyByCustomerIPDAL");
            }
            return null;
        }
        //public DataSet GetAllCustomerCompanyDAL()
        //{
        //    SqlConnection con = new SqlConnection();
        //    SqlParameter parametros;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        con = dbm.getConexion();
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("SWG_Select_Camera_CostumerIP", con);
               
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        //        ad.Fill(ds);
        //        con.Close();
        //        return ds;
        //    }
        //    catch (SqlException e)
        //    {
        //        Console.WriteLine("Error de SQL :" + e.Message);
        //        Console.WriteLine("Error :" + e.Message);
        //        ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
        //        objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompany/CustomerCompanyByCustomerIPDAL");

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error :" + e.Message);
        //        ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
        //        objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompany/CustomerCompanyByCustomerIPDAL");
        //    }
        //    return null;
        //}
    }
}
