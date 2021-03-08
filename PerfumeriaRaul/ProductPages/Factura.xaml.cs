using PerfumeriaRaul.Pages;
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
            if(listaProductosF.Count>0 && txt_nFactura.Text != "" && cliente!=null) 
            {
                FacturaDBHandler.AddClient(cliente);
                FacturaDBHandler.AddFactura(cliente, listaProductosF, txt_nFactura.Text);
                MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());
                ReportPreview report = new ReportPreview();
                string factura = txt_nFactura.Text;
                if (txt_nFactura.Text != "")
                {
                    bool okConsulta = report.GetCrearFactura(factura);
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
                    System.Windows.MessageBox.Show("es necesario insertar por una factura");
                }
            }
        }
    }
}
