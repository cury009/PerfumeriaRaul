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

namespace PerfumeriaRaul.Pages
{
    /// <summary>
    /// Lógica de interacción para ConsultaProduct.xaml
    /// </summary>
    public partial class ConsultaProduct : Window
    {
        private ProductHandler productHandler;

        public ConsultaProduct()
        {
            InitializeComponent();
        }

        public ConsultaProduct(ProductHandler productHandler)
        {
            this.productHandler = productHandler;
        }
    }
}
