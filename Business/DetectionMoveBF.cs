using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using Entities;
namespace Business
{
    public class DetectionMoveBF
    {

        public DataSet GetAllAlarmInformationBF()
        {
            DataSet ds = new DataSet();

            try
            {
                DetectionMovesDAL ObjData = new DetectionMovesDAL();

                ds = ObjData.GetAllAlarmInformationDAL();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
            }
            return ds;

        }
        public Boolean IngrAlarmInformationBF(AlarmInfomation ObjAlarm)
        {
            Boolean esExito = false;

            try
            {
                DetectionMovesDAL ObjData = new DetectionMovesDAL();

                if (ObjData.IngrAlarmInformationDAL(ObjAlarm) == true)
                {
                    esExito = true;
                }
                else
                {

                    esExito = false;
                }

                esExito = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                esExito = false;
            }
            return esExito;
        }

        //public string GetAlertCameraDetectionBF()
        //{
        //    string messages = "";

        //    try
        //    {

        //    }

        //    catch (Exception y)
        //    {
        //        // MessageBox.Show("Error :" + y.Message);
        //    }
        //    return messages;
        //}

        //public DataSet GetAllMensageAlertBF()
        //{
        //    DataSet Dts = new DataSet();

        //    try
        //    {
        //        DetectionMovesDAL ObjData = new DetectionMovesDAL();
        //        // Dts = ObjData.GetAllMensageAlertDAL();
        //    }

        //    catch (Exception y)
        //    {
        //        // MessageBox.Show("Error :" + y.Message);
        //    }

        //    return Dts;
        //}

        //public DataSet GetAllMensageAlertByDateBF(DateTime Date)
        //{
        //    DataSet Dts = new DataSet();
        //    try
        //    {

        //    }

        //    catch (Exception y)
        //    {
        //        // MessageBox.Show("Error :" + y.Message);
        //    }

        //    return Dts;
        //}

        //public DataSet GetAllMensageAlertByIDLogonBF(string logon)
        //{
        //    DataSet Dts = new DataSet();
        //    try
        //    {

        //    }

        //    catch (Exception y)
        //    {
        //        // MessageBox.Show("Error :" + y.Message);
        //    }

        //    return Dts;
        //}
    }
}
