﻿using PerfumeriaRaul.Pages;
using PerfumeriaRaul.ProductClass;
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

namespace PerfumeriaRaul
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static Frame myNavigationFrame;
        
        public ProductHandler productHandler;

    

        public MainWindow(ProductHandler productHandler)
        {
            this.productHandler = productHandler;
        }

        public MainWindow()
        {
            InitializeComponent();
            myNavigationFrame = myFrame;
            productHandler = new ProductHandler();
            myNavigationFrame.NavigationService.Navigate(new MainPage());
            productHandler = productHandler;
        }

        private void Button_ClickPrincipal(object sender, RoutedEventArgs e)
        {
            myNavigationFrame.NavigationService.Navigate(new MainPage());
        }
        private void Button_ClickNuevo(object sender, RoutedEventArgs e)
        {
            myNavigationFrame.NavigationService.Navigate(new NewProductPage("Nuevo producto", productHandler));
        }
        private void Button_ClickConsulta(object sender, RoutedEventArgs e)
        {
            myNavigationFrame.NavigationService.Navigate(new ConsultaProduct(productHandler));
        }






        private void Button_ClickSalir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
    }
}