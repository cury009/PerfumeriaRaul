
using Microsoft.Reporting.WinForms;
using PerfumeriaRaul.ProyectDB.SqlData.Facturacion;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace PerfumeriaRaul.Reporting
{
    /// <summary>
    /// Lógica de interacción para ReportPreview.xaml
    /// </summary>
    public partial class ReportPreview : Window
    {
        private static string Currentpath = Environment.CurrentDirectory;
        private static string reportRef = "../../Informes/CrearFactura.rdlc";
        private static string reportCif = "../../Informes/ConsultaCIFinforme.rdlc";
        private static string reportFechas = "../../Informes/InformeFechas.rdlc";
        public ReportPreview()
        {
            InitializeComponent();
        }
        public bool GetFacturaCIF(string cif)
        {
            bool okConsulta = false;
            DataTable tablaInforme = FacturaDBHandler.GetCIF(cif);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DatosConsultaCIF";
            rds.Value = tablaInforme;
            myReportView.LocalReport.ReportPath = System.IO.Path.Combine(Currentpath, reportCif);
            myReportView.LocalReport.DataSources.Add(rds);
            myReportView.RefreshReport();
            if (tablaInforme.Rows.Count > 0)
            {
                okConsulta = true;
            }


            return okConsulta;
        }
        public bool GetCrearFactura(string factura)
        {
            bool okConsulta = false;
            DataTable tablaInforme = FacturaDBHandler.GetFacturas(factura);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DatosFactura";
            rds.Value = tablaInforme;
            myReportView.LocalReport.ReportPath = System.IO.Path.Combine(Currentpath, reportRef);
            myReportView.LocalReport.DataSources.Add(rds);
            myReportView.RefreshReport();
            if (tablaInforme.Rows.Count > 0)
            {
                okConsulta = true;
            }


            return okConsulta;
        }
        public bool GetInformeFecha(String fecha1, String fecha2)
        {
            DataTable informe = FacturaDBHandler.GetFechasFactura(fecha1, fecha2);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DatosFechas";
            rds.Value = informe;
            myReportView.LocalReport.ReportPath = System.IO.Path.Combine(Currentpath, reportFechas);
            myReportView.LocalReport.DataSources.Add(rds);
            myReportView.RefreshReport();

            bool okConsulta = false;
            if (informe.Rows.Count > 0)
            {
                okConsulta = true;
            }
            return okConsulta;
        }
    }
}
