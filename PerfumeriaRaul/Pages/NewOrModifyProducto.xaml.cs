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
using System.Xml.Linq;


namespace PerfumeriaRaul.Pages
{
    /// <summary>
    /// Lógica de interacción para NewOrModifyProducto.xaml
    /// </summary>
    public partial class NewOrModifyProducto : Page
    {
        private XDocument xml = XDocument.Load("../../XML/XMLproductos.xml");
        public ProductHandler productoHandler;
        public Producto producto;
        public bool verify;
       

        private bool Validation()
        {

            bool validate = true;

            foreach (UIElement element in productGrid.Children)
            {

                if (element is TextBox)
                {
                    TextBox textBox = (TextBox)element;

                    if (textBox.Text.Equals(""))
                    {
                        textBox.BorderBrush = new SolidColorBrush(Colors.Red);
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
        //constructor de nuevo
        public NewOrModifyProducto(string title, ProductHandler productoHandler)
        {
            InitializeComponent();
            Combo();
            nuevoProducto.Text = title;
            this.productoHandler = productoHandler;
            this.verify = false;
            producto = new Producto();
            this.productGrid.DataContext = producto;
        }

        //constructor de modificar
        public NewOrModifyProducto(string title, ProductHandler productoHandler, Producto producto)
        {
            InitializeComponent();
            Combo();
            nuevoProducto.Text = title;
            this.productoHandler = productoHandler;
            this.producto = producto;
            this.productGrid.DataContext = producto;
            this.verify = true;

        }

       

        private void Combo()
        {
            var listaProductos = xml.Root.Elements("Tipo").Attributes("idTipo");

            for (int i = 0; i < listaProductos.Count(); i++)
            {
               TipoCategoria.Items.Add(listaProductos.ElementAt(i).Value);
            }
        }

        private void txt_tipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboMarca.Items.Clear();
            var modeloList = xml.Root.Elements("Tipo").ElementAt(TipoCategoria.SelectedIndex).Elements("Marca").Attributes("nombre");

            for (int i = 0; i < modeloList.Count(); i++)
            {
                ComboMarca.Items.Add(modeloList.ElementAt(i).Value);
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (verify)
            {
                //productoHandler.Modifyproduct(producto, pos);
                XMLHandler.editarProducto(producto);
                MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());

            }
            else
            {

                String Referencia = txtReferencia.Text;
                String Tipo = TipoCategoria.Text;
                String Marca = txtMarca.Text;
                String Envase = EnvaseCombo.Text;
                String Descripcion = txtDescripcion.Text;
                float Precio = float.Parse(txtPrecio.Text);
                int stock = int.Parse(txtStock.Text);
                DateTime fechaAlta = (DateTime)txtFecha.SelectedDate;



                if (Validation())
                {
                    MessageBoxResult resultado = MessageBox.Show(
                    "Referencia: " + Referencia + "\n" +
                    "Categoria: " + Tipo + "\n" +
                    "Marca:" + Marca + "\n" +
                    "Envase: " + Envase + "\n" +
                    "Precio:" + Precio + "\n" +
                    "Stock: " + stock + "\n" +
                    "Fecha de alta: " + fechaAlta + "\n\n" +
                    "¿ESTOS DATOS SON CORRECTOS?",
                    "registro usuarios",
                    MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Question);

                    switch (resultado)
                    {
                        case MessageBoxResult.Yes:
                            MessageBox.Show("se ha registrado correctamente");
                            Producto producto = new Producto(Referencia,  Envase,  Marca, Tipo,  Descripcion,  Precio,  fechaAlta, stock);
                            XMLHandler.addXMLProduct(producto);
                            MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());
                            
                            break;
                        case MessageBoxResult.No:
                            break;
                        case MessageBoxResult.Cancel:
                            break;

                    }
                }
                else
                {
                    label.Content = "INTRODUZCA BIEN LA INFORMACION DEL PRODUCTO";
                    label.Visibility = Visibility.Visible;
                }
            }
        }

        private void checkCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (TipoCategoria.IsVisible)
            {
                TipoCategoria.Visibility = Visibility.Hidden;
                ComboMarca.Visibility = Visibility.Hidden;
                textCategoria.Visibility = Visibility.Visible;
                txtMarca.Visibility = Visibility.Visible;
                checkCategoria.IsEnabled = true;
            }
            else
            {
                TipoCategoria.Visibility = Visibility.Visible;
                ComboMarca.Visibility = Visibility.Visible;
                TipoCategoria.Visibility = Visibility.Hidden;
                txtMarca.Visibility = Visibility.Hidden;
                checkCategoria.IsEnabled = false;
            }
        }
        private void checkMarca_Click(object sender, RoutedEventArgs e)
        {
            if (ComboMarca.IsVisible)
            {

                ComboMarca.Visibility = Visibility.Hidden;

                txtMarca.Visibility = Visibility.Visible;
                checkMarca.IsEnabled = true;
            }
            else
            {

                ComboMarca.Visibility = Visibility.Visible;
                checkMarca.IsEnabled = false;
            }

        }

        
    }
}
