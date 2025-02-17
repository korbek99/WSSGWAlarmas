﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using Entities;
using System.Data.SqlClient;

namespace Business
{
   public class CustomerCompanyBF
    {
       CustomerCompanyDAL Obj = new CustomerCompanyDAL();

        public Boolean IngrCustomerCompanyBF(
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

           
            Boolean esExito = false;
            
            try
            {
                esExito = Obj.IngrCustomerCompanyDAL( CustomerCompanyIDE,
                                                      CustomerCompanyName,
                                                      CustomerCompanyDir,
                                                      CustomerCompanyPhone,
                                                      CustomerCompanyCelPhone,
                                                      CustomerCompanyEmail,
                                                      CustomerCompanyFax,
                                                      CustomerCompanyWebSite,
                                                      CiudadID,
                                                      CustomerCompanyDateIng,
                                                      CustomerCompanyState,
                                                      CustomerCompanyShortName); 
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyBF/IngrCustomerCompanyBF");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyBF/IngrCustomerCompanyBF");
                esExito = false;
            }
            return esExito;
        }

        public Boolean UpdateCustomerCompanyBF(
            int CustomerCompanyID,
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

           
            Boolean esExito = false;
            
            try
            {


                esExito = Obj.UpdateCustomerCompanyDAL(CustomerCompanyID,
                                                    CustomerCompanyIDE,
                                                   CustomerCompanyName,
                                                   CustomerCompanyDir,
                                                   CustomerCompanyPhone,
                                                   CustomerCompanyCelPhone,
                                                   CustomerCompanyEmail,
                                                   CustomerCompanyFax,
                                                   CustomerCompanyWebSite,
                                                   CiudadID,
                                                   CustomerCompanyDateIng,
                                                   CustomerCompanyState,
                                                   CustomerCompanyShortName); 
                
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyBF/UpdateCustomerCompanyBF");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyBF/UpdateCustomerCompanyBF");
                esExito = false;
            }
            return esExito;
        }

        public Boolean DeleteCustomerCompanyBF(
            int CustomerCompanyID)
        {

           
            Boolean esExito = false;
            
            try
            {


                esExito = Obj.DeleteCustomerCompanyDAL(CustomerCompanyID); 
                
               
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyDAL/DeleteCustomerCompanyBF");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "CustomerCompanyDAL/DeleteCustomerCompanyBF");
                esExito = false;
            }
            return esExito;
        }
       public DataSet CustomerCompanyByCustomerIPBF(string IP)
       {
           CustomerCompanyDAL Obj = new CustomerCompanyDAL();

           DataSet ds = new DataSet();
           try
           {
               ds = Obj.CustomerCompanyByCustomerIPDAL(IP);
               return ds;
           }
           catch (SqlException e)
           {
               Console.WriteLine("Error de SQL :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCustomerIPBF");

           }
           catch (Exception e)
           {
               Console.WriteLine("Error :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCustomerIPBF");
           }
           return null;
       }

       public DataSet CustomerCompanyByCustomerIDBF(int ID)
       {
           CustomerCompanyDAL Obj = new CustomerCompanyDAL();

           DataSet ds = new DataSet();
           try
           {
               ds = Obj.CustomerCompanyByCustomerIDDAL(ID);
               return ds;
           }
           catch (SqlException e)
           {
               Console.WriteLine("Error de SQL :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCustomerIPDAL");

           }
           catch (Exception e)
           {
               Console.WriteLine("Error :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCustomerIPDAL");
           }
           return null;
       }
       public DataSet AllCustomerCompanyByCustomerBF()
       {
           CustomerCompanyDAL Obj = new CustomerCompanyDAL();

           DataSet ds = new DataSet();
           try
           {
               ds = Obj.AllCustomerCompanyDAL();
               
               return ds;
           }
           catch (SqlException e)
           {
               Console.WriteLine("Error de SQL :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCustomerIPDAL");

           }
           catch (Exception e)
           {
               Console.WriteLine("Error :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCustomerIPDAL");
           }
           return null;


       }

       public DataSet AllCustomerCompanyListDropBF()
       {
            CustomerCompanyDAL Obj = new CustomerCompanyDAL();
           DataSet ds = new DataSet();
           try
           {

               ds = Obj.AllCustomerCompanyListDropDAL();
               
               return ds;
           }
           catch (SqlException e)
           {
               Console.WriteLine("Error de SQL :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCustomerIPDAL");

           }
           catch (Exception e)
           {
               Console.WriteLine("Error :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCustomerIPDAL");
           }
           return null;
       }

       public DataSet SearchCustomerCompanyByNameCustomerBF(string str_name)
       {
            CustomerCompanyDAL Obj = new CustomerCompanyDAL();
           DataSet ds = new DataSet();
           try
           {
               ds = Obj.SearchCustomerCompanyByNameCustomerDAL(str_name);
               
               return ds;
           }
           catch (SqlException e)
           {
               Console.WriteLine("Error de SQL :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/SearchCustomerCompanyByNameCustomerBF");

           }
           catch (Exception e)
           {
               Console.WriteLine("Error :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/SearchCustomerCompanyByNameCustomerBF");
           }
           return null;
       }

       public DataSet CustomerCompanyByCiudadIDBF(int CiudadID)
       {
           CustomerCompanyDAL Obj = new CustomerCompanyDAL();
           DataSet ds = new DataSet();
           try
           {
               ds = Obj.CustomerCompanyByCiudadIDDAL(CiudadID);
           
               return ds;
           }
           catch (SqlException e)
           {
               Console.WriteLine("Error de SQL :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCiudadIDBF");

           }
           catch (Exception e)
           {
               Console.WriteLine("Error :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCiudadIDBF");
           }
           return null;
       }

       public DataSet CustomerCompanyByIDEBF(string CustomerCompanyIDE)
       {
          
           DataSet ds = new DataSet();
            CustomerCompanyDAL Obj = new CustomerCompanyDAL();
           try
           {
               ds = Obj.CustomerCompanyByIDEDAL(CustomerCompanyIDE);
               return ds;
           }
          
           catch (Exception e)
           {
               Console.WriteLine("Error :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByIDEBF");
           }
           return null;
       }

       public DataSet AllCustomerCompanyBF()
       {
           
           DataSet ds = new DataSet();
           try
           {
               CustomerCompanyDAL Obj = new CustomerCompanyDAL();
               ds = Obj.AllCustomerCompanyDAL();
               return ds;
           }
           catch (Exception e)
           {
               Console.WriteLine("Error :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/AllCustomerCompanyByCustomer");
           }
           return null;
       }
    }
}
