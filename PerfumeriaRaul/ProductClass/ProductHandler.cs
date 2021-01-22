using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeriaRaul.ProductClass
{
    public class ProductHandler
    {
        public ObservableCollection<Producto> productoList { get; set; }

        public ProductHandler()
        {
            this.productoList = new ObservableCollection<Producto>();
        }

        public void AddProduct(Producto product)
        {
            productoList.Add(product);
        }

        public void ModifyProduct(Producto producto, int pos)
        {
            productoList[pos] = producto;
        }
        public void RemoveProduct(int pos)
        {
            productoList.RemoveAt(pos);
        }



    }
}
