using PerfumeriaRaul.ProductClass;
using PerfumeriaRaul.ProyectDB.SqlData.Facturacion.FacturaDS;
using PerfumeriaRaul.ProyectDB.SqlData.Facturacion.FacturaDS.facturaDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeriaRaul.ProyectDB.SqlData.Facturacion
{
    class FacturaDBHandler
    {
        private static clienteTableAdapter clienteAdapter = new clienteTableAdapter();
        private static facturaTableAdapter facturaAdapter = new facturaTableAdapter();
        private static producto_facturaTableAdapter detalleAdapter = new producto_facturaTableAdapter();
        private static facturaDataSet  facturaDataSet = new facturaDataSet();

        public static void AddClient (Cliente client)
        {
            clienteAdapter.Insert(client.cif, client.nombre, client.direccion);
        }
    }
}
