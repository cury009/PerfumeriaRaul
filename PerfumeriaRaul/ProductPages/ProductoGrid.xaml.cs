﻿using PerfumeriaRaul.ProductClass;
using PerfumeriaRaul.ProyectDB.ProjectDB.RemoteProducts;
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
        //XDocument.Load("../../XML/XMLproductos.xml");
        private XDocument xml = XMLHandler.ReturnXDocument();
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
            MainWindow.myNavigationFrame.NavigationService.Navigate(new NewOrModifyProducto("Modificar producto", ProductoHandler, product));
        }

        private void Button_ClickBorrar(object sender, RoutedEventArgs e)
        {
            Producto product = (Producto)myDataGrid.SelectedItem;
            
            MessageBoxResult resultado = MessageBox.Show("¿Desea Borrarlo Realmente?", "Borrar", MessageBoxButton.YesNo, MessageBoxImage.Information);

            switch (resultado)
            {
                case MessageBoxResult.Yes:
                    XMLHandler.RemoveProducto(product);
                    RemoteProductsDBHandler.DeleteToProjectDB(product.Referencia);
                    LocalImageDBHandler.RemoveDataFrom(product.Referencia);
                    UpdateProductList();


                    break;
                case MessageBoxResult.No:
                    break;


            }
        }
        private void Button_ClickPublicar(object sender, RoutedEventArgs e)
        {
            Producto product = (Producto)myDataGrid.SelectedItem;
            if(product.publish == false)
            {
                //RemoteProductsDBHandler.DeleteToProjectDB(product.Referencia);
                
                MessageBoxResult resultado = MessageBox.Show("¿Desea Publicarlo Realmente?", "Publicar", MessageBoxButton.YesNo, MessageBoxImage.Information);

                switch (resultado)
                {
                    case MessageBoxResult.Yes:
                        RemoteProductsDBHandler.AddData_toDB(product);
                        product.publish = true;


                        break;
                    case MessageBoxResult.No:
                        break;


                }


            }
            else
            {
                MessageBoxResult resultado = MessageBox.Show("¿Desea Despublicarlo Realmente?", "Despublicar", MessageBoxButton.YesNo, MessageBoxImage.Information);

                switch (resultado)
                {
                    case MessageBoxResult.Yes:
                        RemoteProductsDBHandler.DeleteToProjectDB(product.Referencia);
                        product.publish = false;


                        break;
                    case MessageBoxResult.No:
                        break;


                }

                
               
            }
            XMLHandler.editarProducto(product);
            UpdateProductList();

        }

        private void Button_ClickActualizar(object sender, RoutedEventArgs e)
        {
            UpdateProductList();
        }

        
    }
}

