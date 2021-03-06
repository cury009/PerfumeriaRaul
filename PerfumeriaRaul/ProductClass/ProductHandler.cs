﻿using PerfumeriaRaul.imagenes;
using PerfumeriaRaul.xml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeriaRaul.ProductClass
{
    public class ProductHandler
    {
        

            public ObservableCollection<Producto> ProductList { get; set; }

            public ProductHandler()
            {
                this.ProductList = new ObservableCollection<Producto>();
                Actualizarxml();
            }

            public void Addproduct(Producto producto)
            {
                ProductList.Add(producto);
            }
            public void Modifyproduct(Producto producto, int pos)
            {
                ProductList[pos] = producto;
            }
            public void Removeproduct(int pos)
            {
                ProductList.RemoveAt(pos);
            }

            public void Actualizarxml()
            {
                this.ProductList = XMLHandler.LoadProductos();
                
                foreach(Producto producto in ProductList)
            {
                producto.imagen = ImageHandler.LoadImage(producto.Referencia);
            }
            }
        
    }
}
