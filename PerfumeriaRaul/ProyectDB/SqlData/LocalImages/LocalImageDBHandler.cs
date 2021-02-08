using PerfumeriaRaul.ProyectDB.SqlData.LocalImages.LocalImagesDataSet;
using PerfumeriaRaul.ProyectDB.SqlData.LocalImages.LocalImagesDataSet.DataSet_Local_ImagesTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeriaRaul.ProyectDB.SqlData.LocalImages
{
    public class LocalImageDBHandler
    {
        private static ImagesTableAdapter imageAdapter = new ImagesTableAdapter();
        private static DataSet_Local_Images dataSet = new DataSet_Local_Images();

        public static void AddData_toDB(String idImage, byte[] productImage)
        {
            imageAdapter.Insert(idImage, productImage);
            imageAdapter.Update(dataSet);

        }
        
        public  static byte[] GetDataFromDB(string idImage)
        {
            byte[] imageData = null;
            try
            {
                imageData = imageAdapter.GetImage(idImage).ElementAt(0).productImage;
            }
            catch (Exception ex)
            {
                
            }
            
            return imageData;
        }
        public static void UpdateDataFromDB(string idImage, byte[] productImage)
        {
            byte[] dataImage = GetDataFromDB(idImage);

            if( dataImage == null)
            {
                AddData_toDB(idImage, productImage);
            }
            else
            {
                imageAdapter.UpdateData(idImage, productImage);
                imageAdapter.Update(dataSet);
            }

            
        }
        public static void RemoveDataFrom(string idImage)
        {
            imageAdapter.Delete(idImage);
            imageAdapter.Update(dataSet);
        }

    }
}
