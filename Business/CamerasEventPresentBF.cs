using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using Entities;

namespace Business
{
    public class CamerasEventPresentBF
    {
        //public Boolean IngrCameraPresetBF(CameraPreset Objcam)
        //{
        //    Boolean esExito = false;

        //    try
        //    {
        //        CamerasEventPresentDAL obj = new CamerasEventPresentDAL();
        //        esExito = obj.IngrCameraPresetDAL(Objcam);

        //    }
        //    catch (Exception ex)
        //    {
        //        esExito = false;
        //    }
        //    return esExito;
        //}

        public DataSet GetAllCameraPresetBF()
        {
            DataSet ds = new DataSet();
            try
            {
                CamerasEventPresentDAL obj = new CamerasEventPresentDAL();
                ds = obj.GetAllCameraPresetDAL();
                return ds;
            }

            catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
            return null;


        }
    }
}
