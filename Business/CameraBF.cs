using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using Entities;


namespace Business
{
    public class CameraBF
    {
        public DataSet GetAllCamerasBF()
        {
            DataSet ds = new DataSet();

            try
            {
                CameraDAL ObjData = new CameraDAL();

                ds = ObjData.GetAllCamerasDAL();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
            }
            return ds;

        }

        public Boolean IngrCamerasBF(Cameras ObjCam)
        {
            Boolean esExito = false;

            try
            {
                CameraDAL ObjData = new CameraDAL();

                if (ObjData.IngrCamerasDAL(ObjCam) == true)
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
    }
}
