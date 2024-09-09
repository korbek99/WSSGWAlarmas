using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using Entities;
using System.Data.SqlClient;
using System.Net.Sockets;


namespace DataAccess
{
    public class DataCommandSDKDAL
    {
        public Boolean SendCommandSDKDAL(int SystemID)
        {
            Boolean isReady = false;

            try {


                isReady = true;

            }
            catch (SocketException ex)
            {
                Console.WriteLine("Error :" + ex.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/SendCommandSDKDAL");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DataNextivaDAL/SendCommandSDKDAL");
            }


           return isReady;
        }
    }
}
