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
    public class ParamServerBF
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

        public DataSet GetTimeServerDAL()
        {
           ParamServerDAL obj =new ParamServerDAL();
            DataSet ds = new DataSet();
            try
            {
                ds = obj.GetTimeServerDAL();
                return ds;
            }
           
            catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
            return null;
        }
    }
}
