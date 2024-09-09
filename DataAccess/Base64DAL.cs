using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
   public class Base64DAL
    {

       public int ConvertToASCIIString(string var)
        {
            int int_ASCII = 0;

            string s = var;
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            int_ASCII = BitConverter.ToInt32(bytes, 0);

            return int_ASCII;

        }

        public  string Base64Encode(string plainText) {
          var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
          return System.Convert.ToBase64String(plainTextBytes);

        }
        

        public  string Base64Decode(string base64EncodedData) {
          var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
          return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public string ConvertStringToBase64(string p0)
        {
            string str2;
            try
            {
                byte[] buffer = new byte[p0.Length];
                str2 = Convert.ToBase64String(Encoding.UTF8.GetBytes(p0));
            }
            catch (Exception exception)
            {
                throw new Exception("Error in base64Encode" + exception.Message);
            }

            return str2;
        }
    }
}
