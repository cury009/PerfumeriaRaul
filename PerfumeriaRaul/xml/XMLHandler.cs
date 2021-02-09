using PerfumeriaRaul.ProductClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PerfumeriaRaul.xml
{
    public class XMLHandler
    {
        private static XDocument xml;
        public static Producto producto;
        private static XElement xmlCategoria;
        private static XElement xmlModelo;

        private static void LoadXMl() { xml = XDocument.Load("../../XML/XMLproductos.xml"); }
        private static void saveXML()
        {
            xml.Save("../../XML/XMLproductos.xml");
        }



        private static void AddTipo(Producto p)
        {
            var listaCAtegorias = xml.Root.Elements("Tipo").Attributes("idTipo");
            bool isNewCategory = true;
            foreach (XAttribute categoria in listaCAtegorias)
            {
                if (categoria.Value.Equals(producto.Tipo))
                {
                    xmlCategoria = categoria.Parent;
                    isNewCategory = false;
                    break;
                }
                else
                {
                    xmlCategoria = new XElement("Tipo", new XAttribute("idTipo", producto.Tipo));
                    xmlModelo = new XElement("Marca", new XAttribute("nombre", producto.Marca));
                    isNewCategory = true;
                }
            }
            if (isNewCategory)
            {
                xmlCategoria.Add(xmlModelo);
                xml.Root.Add(xmlCategoria);
            }
        }
        public static void addXMLProduct(Producto p)
        {
            producto = p;
            LoadXMl();
            AddTipo(p);
            addModelo();
            crearProducto();
            saveXML();
        }

        private static void addModelo()
        {
            bool isNewModelo = true;
            foreach (XAttribute marca in xmlCategoria.Elements("Marca").Attributes("nombre"))
            {
                if (marca.Value.Equals(producto.Marca))
                {
                    xmlModelo = marca.Parent;
                    isNewModelo = false;
                    break;
                }
                else
                {
                    xmlModelo = new XElement("Marca", new XAttribute("nombre", producto.Marca));
                    isNewModelo = true;
                }
            }
            if (isNewModelo) { xmlCategoria.Add(xmlModelo); }
        }

        public static void crearProducto()
        {
            XElement xmlProducto = new XElement("Articulo", 
            new XAttribute("Referencia", producto.Referencia),
            new XAttribute("Descripcion", producto.Descripcion),
            new XAttribute("Envase", producto.Envase),
            new XAttribute("Precio", producto.Precio),
            new XAttribute("Fecha", producto.FechaAlta),
            new XAttribute("Stock", producto.Stock));
            new XAttribute("Publish", producto.publish);
            xmlModelo.Add(xmlProducto);
        }

        public static ObservableCollection<Producto> LoadProductos()
        {
            ObservableCollection<Producto> productiList = new ObservableCollection<Producto>();
            LoadXMl();
            var listaProductos = xml.Root.Elements("Tipo").Elements("Marca").Elements("Articulo");
            foreach (XElement productoxml in listaProductos)
            {

                producto = new Producto();
                producto.Referencia = productoxml.Attribute("Referencia").Value;
                producto.Tipo = productoxml.Parent.Parent.Attribute("idTipo").Value;
                producto.Marca = productoxml.Parent.Attribute("nombre").Value;
                producto.Envase = productoxml.Attribute("Envase").Value;
                producto.Descripcion = productoxml.Attribute("Descripcion").Value;
                producto.Precio = float.Parse(productoxml.Attribute("Precio").Value);
                
                producto.FechaAlta = DateTime.Parse(productoxml.Attribute("Fecha").Value);
                producto.Stock = int.Parse(s: productoxml.Attribute("Stock").Value);
                producto.publish = bool.Parse(productoxml.Attribute("Publish").Value);
                productiList.Add(producto);

            }
            return productiList;
        }

        public static void RemoveProducto(Producto p)
        {
            LoadXMl();
            var listaProductos = xml.Root.Elements("Tipo").Elements("Marca").Elements("Articulo").Attributes("Referencia");

            foreach (XAttribute referencia in listaProductos)
            {
                if (p.Referencia == referencia.Value)
                {
                    referencia.Parent.Remove();
                    break;
                }
            }
            saveXML();
        }

        public static void editarProducto(Producto p)
        {
            LoadXMl();
            var listaProductos = xml.Root.Elements("Tipo").Elements("Marca").Elements("Articulo").Attributes("Referencia");

            foreach (XAttribute Referencia in listaProductos)
            {
                if (p.Referencia == Referencia.Value)
                {
                    Referencia.Parent.Remove();
                    break;
                }
            }
            saveXML();
            addXMLProduct(p);
        }
    }
}
