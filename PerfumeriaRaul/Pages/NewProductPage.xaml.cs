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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace PerfumeriaRaul.Pages
{
    /// <summary>
    /// Lógica de interacción para NewProductPage.xaml
    /// </summary>
    public partial class NewProductPage : Window
    {
        private XDocument xml = XDocument.Load("../../xml/xmlProductos.xml");
        public ProductHandler productoHandler;
        public Producto producto;
        public int pos;
        public bool verify;

        public NewProductPage(ProductHandler productoHandler)
        {
            this.productoHandler = productoHandler;
        }
        // constructor de nuevo
        public NewProductPage(string title, ProductHandler productoHandler)
        {
            InitializeComponent();
            titleNewOrModify.Text = title;
            this.productoHandler = productoHandler;
            this.verify = false;
            producto = new Producto();
            this.productoGrid.DataContext = producto;
            // CategoryCombo();
        }



        private bool Validation()
        {

            bool validate = true;

            foreach (UIElement element in productoGrid.Children)
            {

                if (element is TextBox)
                {
                    TextBox textBox = (TextBox)element;

                    if (textBox.Text.Equals(""))
                    {
                        textBox.BorderBrush = new SolidColorBrush(Colors.Blue);
                        validate = false;
                    }
                    else
                    {
                        textBox.BorderBrush = new SolidColorBrush(Colors.LightGray);
                    }
                }

            }

            return validate;
        } //validacion

        /*private void CategoryCombo()
        {
            var listaCategorias = xml.Root.Elements("Categoria").Attributes("IdCategoria");

            for (int i = 0; i < listaCategorias.Count(); i++)
            {
                categoryCombo.Items.Add(listaCategorias.ElementAt(i).Value);
            } //fin for
            //categoryCombo.SelectedIndex = 0;


        } //fin initCategoryCombo*/

        /*private void categoryCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            brandCombo.Items.Clear();
            var brandList = xml.Root.Elements("SubCategoria").Attributes("IdSubCategoria");
            for (int i = 0; i < brandList.Count(); i++)
            {
                brandCombo.Items.Add(brandList.ElementAt(i).Value);
            } //fin for
            //brandCombo.SelectedIndex = 0;

        } // categoryCombo_SelectionChanged*/

        private void Button_ClickRegistrar(object sender, RoutedEventArgs e)
        {
            MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());
            /*if (verify)

                MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());
            }*/
            /*else
            {
                String referencia = txt_Ref.Text;
                String tipo = categoryCombo.Text;

                String marca = txt_Marca.Text;
                String precio = txt_Precio.Text;
                String stock = txt_Stock.Text;

                DateTime fechaAlta = (DateTime)txt_fechaAlta.SelectedDate;
                if (Validation())
                {
                    Producto producto = new Producto(referencia, tipo, marca, precio, stock, fechaAlta);
                    productoHandler.AddProduct(producto);

                    MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());

                }
                else
                {
                    warning.Content = "ERROR, INTRODUCE LOS DATOS";
                }


            }*/

        }


    }
}
    

