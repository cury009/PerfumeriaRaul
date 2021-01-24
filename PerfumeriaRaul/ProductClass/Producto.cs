﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeriaRaul.ProductClass
{
    public class Producto : ICloneable
    {
        public String Referencia { set; get; }
        public String Envase { set; get; }
        public String Marca { set; get; }

        
        
        public String Descripcion { set; get;  }

        public float Precio { set; get; }

        public DateTime FechaAlta { set; get; }

        public int Stock { set; get; }

        public Producto(string referencia, string envase, string marca,  string descripcion, float precio, DateTime fechaAlta, int stock) : this(referencia, envase)
        {
            Referencia = referencia;
            Envase = envase;
            Marca = marca;
            Descripcion = descripcion;
            Precio = precio;
            FechaAlta = fechaAlta;
            Stock = stock;
        }

        public Producto(string referencia, string tipo)
        {
            this.Referencia = "";
            this.Envase = "";
            this.Descripcion = "";
            this.Marca = "";
            this.Precio = 0.0f;
            this.Stock = 0;
            this.FechaAlta = DateTime.Now;
        }

        public Producto()
        {
            this.Referencia = "";
            this.Envase = "";
            this.Descripcion = "";
            this.Marca = "";
            this.Precio = 0.0f;
            this.Stock = 0;
            this.FechaAlta = DateTime.Now;
        }

        public override string ToString()
        {
            return Referencia;
        }

        public object Clone()
        {
            return this.MemberwiseClone();

        }

        public string GetAllValues()
        {
            return this.Referencia + " " + this.Envase + " " + this.Marca + " " + this.Precio + " "+ this.Stock + " " + this.FechaAlta;
        }
    }
}
