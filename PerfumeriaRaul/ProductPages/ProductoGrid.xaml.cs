using PerfumeriaRaul.ProductClass;
using PerfumeriaRaul.ProyectDB.SqlData.LocalImages;
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
        ObservableCollection<Producto> filterList;

        public ProductoGrid(ProductHandler productHandler)
        {
            InitializeComponent();
            this.ProductoHandler = productHandler;
            this.filterList = new ObservableCollection<Producto>(productHandler.ProductList);
            UpdateProductList();
            InitTipoCategoria();

        }

        public ProductoGrid()
        {

        }

        private void InitTipoCategoria()
        {
            Tipocategory.Items.Add("Todas ...");
            var listaTipoXML = xml.Root.Elements("Tipo").Attributes("idTipo");

            foreach (XAttribute tipoXML in listaTipoXML)
            {

                Tipocategory.Items.Add(tipoXML.Value);
            }
            Tipocategory.SelectedIndex = 0;
        }

        private void UpdateProductList()
        {
            ProductoHandler.Actualizarxml();
            Tipocategory.SelectedIndex = 0;
            busquedaTextBox.Text = "";
            this.filterList = new ObservableCollection<Producto>(ProductoHandler.ProductList);
            myDataGrid.ItemsSource = ProductoHandler.ProductList;
            myDataGrid.DataContext = ProductoHandler.ProductList;
            myDataGrid.Items.Refresh();
            
        }

        
        private void TipoCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tipocategory.SelectedIndex == 0)
            {

                UpdateProductList();

            }
            else
            {
                filterList.Clear();
                


                foreach (Producto product in ProductoHandler.ProductList)
                {

                    if (product.Tipo.Equals((string)Tipocategory.SelectedItem))
                    {

                        filterList.Add(product);
                    }
                }

                myDataGrid.ItemsSource = filterList;
                myDataGrid.DataContext = filterList;
                myDataGrid.Items.Refresh();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ObservableCollection<Producto> newFilterList = new ObservableCollection<Producto>();

            foreach (Producto product in filterList)
            {

                if (product.GetAllValues().Contains(busquedaTextBox.Text))
                {

                    newFilterList.Add(product);

                }
            }
            myDataGrid.ItemsSource = newFilterList;
            myDataGrid.DataContext = newFilterList;
            myDataGrid.Items.Refresh();
        }


        private void Button_ClickModificar(object sender, RoutedEventArgs e)
        {
            Producto product = (Producto)myDataGrid.SelectedItem;
            MainWindow.myNavigationFrame.NavigationService.Navigate(new NewOrModifyProducto("Modificar usuario", ProductoHandler, product));
        }

        private void Button_ClickBorrar(object sender, RoutedEventArgs e)
        {
            Producto product = (Producto)myDataGrid.SelectedItem;
            XMLHandler.RemoveProducto(product);
            LocalImageDBHandler.RemoveDataFrom(product.Referencia);
            UpdateProductList();
        }

        private void Button_ClickActualizar(object sender, RoutedEventArgs e)
        {
            UpdateProductList();
        }
    }
}

