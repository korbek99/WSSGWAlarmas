using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using Entities;

namespace Business
{
    public class ErrorSWGNextivaBF
    {
        private DateTime GetTimeServerBF()
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
        public Boolean TrackingErrorSWGNextivaBF(DateTime Fecha,
                  string MachineName,
                  string UserName,
                  int IdSistema,
                  string Mensaje,
                  int Resuelto,
                  int NumeroError,
                  string Modulo)
        {
            Boolean esExito = false;

            try
            {
                Fecha = GetTimeServerBF();
                ErrorSWGNextivaDAL objError = new ErrorSWGNextivaDAL();
                if (objError.TrackingErrorSWGNextivaDAL(Fecha, MachineName, UserName, IdSistema, Mensaje, Resuelto, NumeroError, Modulo) == true)
                {
                    esExito = true;
                }
                else
                {

                    esExito = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                esExito = false;
            }
            return esExito;
        }

        public DataSet GetAllErrorSistemaBF()
        {
            DataSet ds = new DataSet();

            try
            {
                ErrorSWGNextivaDAL objError = new ErrorSWGNextivaDAL();
                ds = objError.GetAllErrorSistemaDAL();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
            }
            return ds;

        }
    }
}
