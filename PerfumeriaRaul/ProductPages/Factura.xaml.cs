﻿using PerfumeriaRaul.Pages;
using PerfumeriaRaul.ProductClass;
using PerfumeriaRaul.ProyectDB.SqlData.Facturacion;
using PerfumeriaRaul.Reporting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PerfumeriaRaul.ProductPages
{
    /// <summary>
    /// Lógica de interacción para Factura.xaml
    /// </summary>
    public partial class Factura : Page
    {
        ProductHandler productHandler;
        ObservableCollection<Producto> listaProductosF;
        Producto producto;
        Cliente cliente;


        public Factura(ProductHandler productHandler)
        {
            InitializeComponent();
            cliente = new Cliente();
            this.datosCliente.DataContext = cliente;
            this.productHandler = productHandler;
            this.cmb_productos.ItemsSource = productHandler.ProductList;
            listaProductosF = new ObservableCollection<Producto>();
            tablaProductos.ItemsSource = listaProductosF;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool productoR = false;
            
            
            if(producto != null)
            {
                foreach (Producto p in listaProductosF)
                {
                    if (p.Referencia == producto.Referencia)
                    {
                        productoR = true;
                        p.Cantidad = p.Cantidad + int.Parse(txt_cantidad.Text);
                    }
                }
            }
            if (!productoR)
            {
                listaProductosF.Add(producto);
            }
            cmb_productos.SelectedIndex = -1;
            tablaProductos.Items.Refresh();

        }

        private void cmb_productos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            producto = (Producto)cmb_productos.SelectedItem;
            txt_cantidad.DataContext = producto;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (listaProductosF.Count > 0 && txb_nFactura.Text != "" && cliente != null)
            {
                Cliente nuevocliente = new Cliente(txb_cif.Text, txb_nombre.Text, txb_direccion.Text);
                FacturaDBHandler.AddClient(nuevocliente);
                bool okFactura = FacturaDBHandler.AddFactura(nuevocliente, listaProductosF, txb_nFactura.Text);


                if (okFactura)
                {
                    MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());
                    ReportPreview report = new ReportPreview();
                    string factura = txb_nFactura.Text;
                    if (txb_nFactura.Text != "")
                    {
                         bool okConsulta = report.GetCrearFactura(txb_nFactura.Text);
                        if (okConsulta)
                        {
                            report.Show();
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("no se ha encontrado el registro por factura");
                        }
                    }
                    else
                    {
                       MessageBox.Show("no se ha  podido cargar la factura");
                    }


                }
                else
                {
                    MessageBox.Show("No se ha encontrado el registro pro factura");
                }
                
            }
        }
    }
}
