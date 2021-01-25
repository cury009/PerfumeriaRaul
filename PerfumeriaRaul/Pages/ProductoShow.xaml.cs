using PerfumeriaRaul.ProductClass;
using PerfumeriaRaul.xml;
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

namespace PerfumeriaRaul.Pages
{
    /// <summary>
    /// Lógica de interacción para ProductoShow.xaml
    /// </summary>
    public partial class ProductoShow : Page
    {
        public ProductHandler ProductoHandler;
        public Producto producto;
        public int pos;
        public ProductoShow(ProductHandler productoHandler)
        {
            InitializeComponent();
            this.ProductoHandler = productoHandler;
            comboProduct.DataContext = productoHandler;
            pos = comboProduct.SelectedIndex;
            buttonsPanel.Visibility = Visibility.Hidden;
        }

        private void comboProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            producto = (Producto)comboProduct.SelectedItem;
            ProductoDataGrid.DataContext = producto;
            pos = comboProduct.SelectedIndex;
            buttonsPanel.Visibility = Visibility.Visible;
        }

        private void Button_ClickModificar(object sender, RoutedEventArgs e)
        {
            XMLHandler.editarProducto(producto);
            MainWindow.myNavigationFrame.NavigationService.Navigate(new NewOrModifyProducto("Modificar usuario", ProductoHandler, (Producto)producto.Clone()));
        }

        private void Button_ClickBorrar(object sender, RoutedEventArgs e)
        {
            XMLHandler  .RemoveProducto(producto);
            MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());
        }
    }
}
