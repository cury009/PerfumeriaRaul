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
    }
}
