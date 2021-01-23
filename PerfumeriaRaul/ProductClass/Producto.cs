using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeriaRaul.ProductClass
{
    public class Producto : ICloneable
    {
        public String Referencia { set; get; }
        public String Tipo { set; get; }
        public String Marca { set; get; }

        public String Articulo { set; get; }
        public String Envase { set; get; }
        public String Descripcion { set; get;  }

        public String Precio { set; get; }

        public DateTime FechaAlta { set; get; }

        public String Stock { set; get; }

        public Producto(string referencia, string tipo, string marca, string precio, float precio1, string stock, DateTime fechaAlta)
        {
            this.Referencia = referencia;
            this.Tipo = tipo;
            this.Marca = marca;
            this.Precio = precio;
            this.Stock = stock;
            this.FechaAlta = fechaAlta;
        }

       

        public Producto(string referencia, string tipo)
        {
            this.Referencia = "";
            this.Tipo = "";
            this.Marca = "";
            this.Precio = "";
            this.Stock = "";
            this.FechaAlta = DateTime.Now;
        }

        public Producto()
        {
        }

        public override string ToString()
        {
            return Referencia;
        }

        public object Clone()
        {
            return this.MemberwiseClone();

        }
    }
}
