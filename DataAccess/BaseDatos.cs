using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataAccess
{
    public class BaseDatos
    {
        public BaseDatos() { }

        public SqlConnection getConexion()
        {
            try
            {
                //string connetionString = null;
                //SqlConnection con;
                //connetionString = "Data Source=(local);Initial Catalog=SWG;Integrated Security=True";
                // SqlConnection con = new SqlConnection("SERVER=ID-WS2-PC\\JoseBustos;Initial Catalog=SWG;Integrated Security=True");
               // SqlConnection con = new SqlConnection("Data Source=ID-W7-JB-PC\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=SWG1");
                //SqlConnection con = new SqlConnection("Data Source=VM38-W7-SQL8R2;Initial Catalog=SWG1 ;User Id=sa;Password=%RightCom2355%");
                SqlConnection con = new SqlConnection("Data Source=VM-21-S16-SQL;Initial Catalog=SWG1 ;User Id=sa;Password=%RightCom2355%");
                //SqlConnection con = new SqlConnection("Data Source=VM38-W7-SQL8R2;Initial Catalog=SWG1 ;Integrated Security=SSPI");
               // SqlConnection con = new SqlConnection("Data Source=KORBEK\\KORBEK100;Integrated Security=SSPI;Initial Catalog=SWG1");
              //  con = new SqlConnection(connetionString);
                return con;

            }
            catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
            catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
            return null;
        }
    }
}
