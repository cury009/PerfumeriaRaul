﻿using PerfumeriaRaul.ProductClass;
using PerfumeriaRaul.Reporting;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para MenuInformes.xaml
    /// </summary>
    public partial class MenuInformes : Page
    {
        ProductHandler productHandler;
        public MenuInformes(ProductHandler productHandler)
        {
            InitializeComponent();
            menu.Visibility = Visibility.Hidden;
            panelCIF.Visibility = Visibility.Hidden;
            panelFechas.Visibility = Visibility.Hidden;
            panelFacturas.Visibility = Visibility.Hidden;

            this.productHandler = productHandler;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (menu.Visibility == Visibility.Visible)
            {
                menu.Visibility = Visibility.Hidden;
            }
            else
            {
                menu.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            panelCIF.Visibility = Visibility.Visible;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            panelFechas.Visibility = Visibility.Visible;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            panelFacturas.Visibility = Visibility.Visible;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow.myNavigationFrame.NavigationService.Navigate(new Factura(productHandler));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ReportPreview report = new ReportPreview();
            string cif = txb_cif.Text;

            if (cif != "")
            {
                bool okConsulta = report.GetFacturaCIF(cif);
                if(okConsulta)
                {
                    report.Show();
                }
                else {
                    MessageBox.Show("No se han econtrado registro para el CIF");
                    txb_cif.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Es necesario escribir un CIF de cliente");
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (fechaInicio.Text != "" && fechaFin.Text != "")
            {
                string fechainicio = fechaInicio.Text;
                string fechafin = fechaFin.Text;
                ReportPreview report = new ReportPreview();
                bool okConsulta = report.GetInformeFecha(fechainicio, fechafin);

                if (okConsulta)
                {
                    report.Show();
                }
                else
                {
                    System.Windows.MessageBox.Show("No existen registros para las fechas seleccionadas");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Selecciona Fecha Inicio y Fecha Fin");

            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            ReportPreview report = new ReportPreview();
            string factura = numeroFactura.Text;
            if (numeroFactura.Text != "")
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
