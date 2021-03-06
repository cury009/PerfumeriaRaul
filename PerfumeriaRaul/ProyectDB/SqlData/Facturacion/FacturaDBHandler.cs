﻿using PerfumeriaRaul.ProductClass;
using PerfumeriaRaul.ProyectDB.SqlData.Facturacion.FacturaDS;
using PerfumeriaRaul.ProyectDB.SqlData.Facturacion.FacturaDS.facturaDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeriaRaul.ProyectDB.SqlData.Facturacion
{
    class FacturaDBHandler
    {
        public static clienteTableAdapter clienteAdapter = new clienteTableAdapter();
        public static facturaTableAdapter facturaAdapter = new facturaTableAdapter();
        public static informesTableAdapter adapter = new informesTableAdapter();
        public static fechasFacturasTableAdapter fechas_adapter = new fechasFacturasTableAdapter();
        public static producto_facturaTableAdapter detalleAdapter = new producto_facturaTableAdapter();
        
        public static facturaDataSet  facturaDataSet = new facturaDataSet();

        public static bool AddClient (Cliente client)
        {
            try
            {
                clienteAdapter.Insert(client.cif, client.nombre, client.direccion);
                return false;  
            }
            catch
            {
                return true;
            }
            
        }
        public static bool AddFactura(Cliente cliente, ObservableCollection<Producto> listaProducto, string refFactura)

        {
            try
            {
                facturaAdapter.Insert(refFactura, cliente.cif, DateTime.Today.Date);
                foreach (Producto producto in listaProducto)
                {
                    detalleAdapter.Insert(producto.Referencia, refFactura, producto.Cantidad, producto.Precio, producto.Descripcion);
                }
                return true;
            }
            catch
            {
                return false;
            }
            
            
        }
        public static DataTable GetCIF(string cif)
        {
            return adapter.GetDataByCIF(cif);
        }
        public static DataTable GetFechas(string fecha1, string fecha2)
        {
            return adapter.GetDataByFecha(fecha1, fecha2);
        }
        public static DataTable GetFechasFactura(string fecha1, string fecha2)
        {
            return fechas_adapter.GetFacturasFechas(fecha1, fecha2);
        }
        public static DataTable GetFacturas(string refFactura)
        {
            return adapter.GetDataByRefFacturas(refFactura);
            
        }
    }
}
