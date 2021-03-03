using PerfumeriaRaul.imagenes;
using PerfumeriaRaul.ProductClass;
using PerfumeriaRaul.ProyectDB.ProjectDB.RemoteProducts.RemoteProductsDataSet;
using PerfumeriaRaul.ProyectDB.ProjectDB.RemoteProducts.RemoteProductsDataSet.projectdbDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeriaRaul.ProyectDB.ProjectDB.RemoteProducts
{
    class RemoteProductsDBHandler
    {
        private static publshrsTableAdapter publshrsTableAdapter = new publshrsTableAdapter();
        private static projectdbDataSet dataSet = new projectdbDataSet ();

        public static void AddData_toDB(Producto producto )
        {
            publshrsTableAdapter.Insert(producto.Referencia, producto.Tipo, producto.Marca, producto.Envase, producto.Descripcion, producto.Precio, producto.FechaAlta, producto.Stock, ImageHandler.EncodeImage(producto.imagen));
            publshrsTableAdapter.Update(dataSet);

        }
        
        public static void DeleteToProjectDB(string Referencia)
        {
            publshrsTableAdapter.DeleteToProjectDB(Referencia);
            publshrsTableAdapter.Update(dataSet);
        }
        public static void ActualizarToProjectDB(Producto producto)
        {
            
            float precio = producto.Precio;
            decimal Precio = Convert.ToDecimal(precio);
            publshrsTableAdapter.ActualizarToProjectDB(producto.Referencia, producto.Tipo, producto.Marca, producto.Envase, producto.Descripcion, Precio, producto.FechaAlta, producto.Stock, ImageHandler.EncodeImage(producto.imagen));
            
        }
    }
}
