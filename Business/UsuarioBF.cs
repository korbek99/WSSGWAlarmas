using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using Entities;
using System.Data.SqlClient;

namespace Business
{
   public class UsuarioBF
    {
      
        public DataSet AllUserBF()
        {
           
            DataSet ds = new DataSet();
            try
            {
                UsuarioDAL Obj = new UsuarioDAL();
                ds = Obj.AllUserDAL();
                return ds;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error de SQL :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioBF/AllUserBF");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioBF/AllUserBF");
            }
            return null;
        }

        public DataSet UserLoginBF(string UsuarioUser, string UsuarioPass)
        {

            DataSet ds = new DataSet();
            try
            {
                UsuarioDAL Obj = new UsuarioDAL();
                ds = Obj.UserLoginDAL(UsuarioUser, UsuarioPass);
                
                return ds;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error de SQL :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioBF/UserLoginBF");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioBF/UserLoginBF");
            }
            return null;
        }


        public Boolean IngresoUsuarioBF(string UsuarioRut,
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

            
            Boolean esExito = false;
            
            try
            {

                UsuarioDAL Obj = new UsuarioDAL();

                esExito = Obj.IngresoUsuarioDAL(UsuarioRut,
                                             UsuarioNombre,
                                             UsuarioApellido,
                                             UsuarioUser,
                                             UsuarioPass,
                                             UsuarioFechaIng,
                                             UsuarioTipoID,
                                             UsuarioPermisoCon,
                                             UsuarioPermisoMod,
                                             UsuarioPermisoDel,
                                             UsuarioPermisoIng,
                                             UsuarioFoto,
                                             UsuarioEstado);
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "UsuarioBF/IngresoUsuarioBF");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "UsuarioBF/IngresoUsuarioBF");
                esExito = false;
            }
            return esExito;
        }

        public Boolean UpdateUsuarioBF(int UsuarioID,
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

            
            Boolean esExito = false;
            
            try
            {
                UsuarioDAL Obj = new UsuarioDAL();

                esExito = Obj.UpdateUsuarioDAL( UsuarioID,
                                             UsuarioRut,
                                             UsuarioNombre,
                                             UsuarioApellido,
                                             UsuarioUser,
                                             UsuarioPass,
                                             UsuarioFechaIng,
                                             UsuarioTipoID,
                                             UsuarioPermisoCon,
                                             UsuarioPermisoMod,
                                             UsuarioPermisoDel,
                                             UsuarioPermisoIng,
                                             UsuarioFoto,
                                             UsuarioEstado);
                

               
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "UsuarioBF/UpdateUsuarioBF");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "UsuarioBF/UpdateUsuarioBF");
                esExito = false;
            }
            return esExito;
        }

        public Boolean DeleteUsuarioBF(int UsuarioID)
        {

        
            Boolean esExito = false;
          
            try
            {

                UsuarioDAL Obj = new UsuarioDAL();
                esExito = Obj.DeleteUsuarioDAL(UsuarioID);
                
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "UsuarioBF/DeleteUsuarioBF");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "UsuarioBF/DeleteUsuarioBF");
                esExito = false;
            }
            return esExito;
        }

        public DataSet UserByIDBF(int UsuarioID)
        {

            DataSet ds = new DataSet();
           
            try
            {
                UsuarioDAL Obj = new UsuarioDAL();
                ds = Obj.UserByIDDAL(UsuarioID);
                return ds;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error de SQL :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioBF/UserByIDBF");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioBF/UserByIDBF");
            }
            return null;
        }
        public Boolean UserLoginBoolBF(string UsuarioUser, string UsuarioPass)
        {
            
            Boolean Exits = false;
            try
            {
                UsuarioDAL Obj = new UsuarioDAL();
                Exits = Obj.UserLoginBoolDAL(UsuarioUser, UsuarioPass);
                

            }
            catch (SqlException e)
            {
                Console.WriteLine("Error de SQL :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioDAL/UserLoginBoolBF");
                Exits = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioDAL/UserLoginBoolBF");
                Exits = false;
            }
            return Exits;
        }

        public DataSet UserByIDUserNameBF(string UsuarioUser)
        {
            DataSet ds = new DataSet();
            try
            {
                UsuarioDAL Obj = new UsuarioDAL();
                ds = Obj.UserByIDUserNameDAL(UsuarioUser);
                return ds;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "UsuarioDAL/UserByIDUserNameBF");
            }
            return null;
        }
      
    }
}
