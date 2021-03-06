﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PerfumeriaRaul.ProductClass
{
    public class Producto : ICloneable
    {
        public String Referencia { set; get; }
        public String Envase { set; get; }
        public String Marca { set; get; }

        public String Tipo { set; get; }
        
        public String Descripcion { set; get;  }

        public float Precio { set; get; }

        public DateTime FechaAlta { set; get; }
        public int Cantidad { get; set; }
        public BitmapImage imagen { set; get; }

        public int Stock { set; get; }

        public bool publish { set; get; }

        public Producto(string referencia, string envase, string marca, string tipo,  string descripcion, float precio, DateTime fechaAlta, int stock)
        {
            this.Referencia = referencia;
            this.Envase = envase;
            this.Marca = marca;
            this.Tipo = tipo;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.FechaAlta = fechaAlta;
            this.Stock = stock;
            this.publish = false;

        }

        
        /*public Producto(string referencia, string tipo)
        {
            this.Referencia = "";
            this.Envase = "";
            this.Descripcion = "";
            this.Marca = "";
            this.Tipo = "";
            this.Precio = 0.0f;
            this.Stock = 0;
            this.FechaAlta = DateTime.Now;
            this.publish = false;
        }*/

        public Producto()
        {
            this.Referencia = "";
            this.Envase = "";
            this.Descripcion = "";
            this.Marca = "";
            this.Tipo = "";
            this.Precio = 0.0f;
            this.Stock = 0;
            this.FechaAlta = DateTime.Now;
            this.Cantidad = 1;

            this.publish = false;

        }

        public override string ToString()
        {
            return "Referencia: " + Referencia + "; Tipo: " + Tipo + "; Marca:" + Marca + "; Descripcion: " +Descripcion  + "; Envase: " + Envase ;
        }

        public object Clone()
        {
            return this.MemberwiseClone();

        }

        public string GetAllValues()
        {
            return this.Referencia + " " + this.Envase + " " + this.Marca + " "+this.Tipo+" " +this.Descripcion+" "+ this.Precio + " "+ this.Stock + " " + this.FechaAlta;
        }
    }
}
