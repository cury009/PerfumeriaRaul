using PerfumeriaRaul.ProductClass;
using PerfumeriaRaul.xml;
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
using System.Xml.Linq;
using static PerfumeriaRaul.ProductClass.ProductHandler;

namespace PerfumeriaRaul.Pages
{
    /// <summary>
    /// Lógica de interacción para ProductoGrid.xaml
    /// </summary>
    public partial class ProductoGrid : Page
    {
        ProductHandler ProductoHandler;
        private XDocument xml = XDocument.Load("../../XML/XMLproductos.xml");
        private ObservableCollection<Producto> listaFiltrada;

        public ProductoGrid(ProductHandler productHandler)
        {
            InitializeComponent();
            this.ProductoHandler = productHandler;
            UpdateProductList();
            InitTipoCategoria();

        }

        public ProductoGrid()
        {
        }

        private void InitTipoCategoria()
        {
            Tipocategory.Items.Add("Todas ...");
            var listaCategoriasXML = xml.Root.Elements("Tipo").Attributes("idTipo");

            foreach (XAttribute categoriaXML in listaCategoriasXML)
            {

                Tipocategory.Items.Add(categoriaXML.Value);
            }
            Tipocategory.SelectedIndex = 0;
        }

        private void UpdateProductList()
        {

            Tipocategory.SelectedIndex = 0;
            busquedaTextBox.Text = "";
            listaFiltrada = new ObservableCollection<Producto>(ProductoHandler.ProductList);
            myDataGrid.ItemsSource = ProductoHandler.ProductList;
            myDataGrid.DataContext = ProductoHandler.ProductList;
            myDataGrid.Items.Refresh();
            ProductoHandler.Actualizarxml();
        }

        private void TipoCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tipocategory.SelectedIndex == 0)
            {

                UpdateProductList();

            }
            else
            {

                listaFiltrada.Clear();


                foreach (Producto product in ProductoHandler.ProductList)
                {

                    if (product.Envase.Equals((string)Tipocategory.SelectedItem))
                    {

                        listaFiltrada.Add(product);
                    }
                }

                myDataGrid.ItemsSource = listaFiltrada;
                myDataGrid.DataContext = listaFiltrada;
                myDataGrid.Items.Refresh();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ObservableCollection<Producto> nuevaListaFiltrada = new ObservableCollection<Producto>();
            foreach (Producto product in listaFiltrada)
            {

                if (product.GetAllValues().Contains(busquedaTextBox.Text))
                {

                    nuevaListaFiltrada.Add(product);

                }
            }
            myDataGrid.ItemsSource = nuevaListaFiltrada;
            myDataGrid.DataContext = nuevaListaFiltrada;
            myDataGrid.Items.Refresh();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Producto product = (Producto)myDataGrid.SelectedItem;
            MainWindow.myNavigationFrame.NavigationService.Navigate(new NewOrModifyProducto("Modificar usuario", ProductoHandler, product));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Producto product = (Producto)myDataGrid.SelectedItem;
            Class1.RemoveProducto(product);
            UpdateProductList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UpdateProductList();
        }
    }
}

