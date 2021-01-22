using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeriaRaul.ProductClass
{
    public class Producto : ICloneable
    {
        public String referencia { set; get; }
        public String Tipo { set; get; }
        public String marca { set; get; }

        public String articulo { set; get; }
        public String envase { set; get; }
        public String descripcion { set; get;s }

        public String precio { set; get; }
        
        public DateTime fechaAlta { set; get; }

        public String stock { set; get; }

        public Producto(string referencia, string tipo, string marca, string precio, string stock, DateTime fechaAlta)
        {
            this.referencia = referencia;
            this.Tipo = tipo;
            this.marca = marca;
            this.precio = precio;
            this.stock = stock;
            this.fechaAlta = fechaAlta;
        }

        public Producto(string referencia, string marca, string precio, string stock, DateTime fechaAlta)
        {
            this.referencia = referencia;
            this.marca = marca;
            this.precio = precio;
            this.stock = stock;
            this.fechaAlta = fechaAlta;
        }

        public Producto(string referencia)
        {
            this.referencia = "";
            this.Tipo = "";
            this.marca = "";
            this.precio = "";
            this.stock = "";
            this.fechaAlta = DateTime.Now;
        }

        public Producto()
        {
        }

        public override string ToString()
        {
            return referencia;
        }

        public object Clone()
        {
            return this.MemberwiseClone();

        }
    }
