using PerfumeriaRaul.ProductClass;
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

        public Factura(ProductHandler productHandler)
        {
            InitializeComponent();
            this.productHandler = productHandler;
            this.cmb_productos.ItemsSource = productHandler.ProductList;
            listaProductosF = new ObservableCollection<Producto>();
            tablaProductos.ItemsSource = listaProductosF;

        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Producto producto = (Producto)cmb_productos.SelectedItem;
            listaProductosF.Add(producto);
        }

        
    }
}
