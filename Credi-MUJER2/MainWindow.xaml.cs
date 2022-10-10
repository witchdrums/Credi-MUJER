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

namespace Credi_MUJER2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Credito credito;
        public MainWindow()
        {
            InitializeComponent();
            this.credito = new Credito();
        }

        private void Button_TipoNegocio(object sender, RoutedEventArgs e)
        {
            this.credito.TipoNegocio = ((Button)sender).Name;
        }

        private void Button_Producto(object sender, RoutedEventArgs e)
        {
            this.credito.Producto = ((Button)sender).Content.ToString();
        }


        private void Button_Ingresos(object sender, RoutedEventArgs e)
        {
            this.credito.Ingresos = ((Button)sender).Content.ToString();
        }


        private void Button_SimularCredito_Click(object sender, RoutedEventArgs e)
        {
            
            switch (credito.TipoNegocio)
            {
                case "Button_Negocio_Establecido":
                    this.SetImporte_Establecido();
                    break;
                case "Button_Negocio_VentaDirecta":
                    this.SetImporte_VentaDirecta();
                    break;
                case "Button_Negocio_Semifijo":
                    this.SetImporte_Semifijo();
                    break;
                case "Button_Negocio_Movil":
                    this.SetImporte_Semifijo();
                    break;
            }

            switch (credito.Ingresos)
            {
                
                case "Menos de $10,000":
                    this.credito.PlazoEnAnios = 3;
                    this.Label_Plazo.Content = "3 años";
                    break;
                case "Mas de $30,000":
                    this.credito.PlazoEnAnios = 1;
                    this.Label_Plazo.Content = "1 año";
                    break;
                default:
                    this.credito.PlazoEnAnios = 2;
                    this.Label_Plazo.Content = "2 años";
                    break;
            }

            this.Label_PagoMensual.Content = GetPagoMensual().ToString();
        }

        private float GetPagoMensual() {
            

            int prestamo = credito.Prestamo;
            int plazoEnAnios = credito.PlazoEnAnios;
            string ingresos = credito.Ingresos;
            float interes;
            if (ingresos == "De $20,000 a $30,000")
            {
                interes = 0.14F;
            }
            else 
            {
                interes = 0.12F;
            }

            float pagoMensual =
                (prestamo + ((prestamo * interes) * plazoEnAnios)) / (12 * plazoEnAnios);
            return pagoMensual;
        }


        private void SetImporte_Semifijo()
        {
            switch (credito.Producto)
            {
                case "Abarrotes":
                case "Limpieza y hogar":
                    this.Label_Importe.Content = "$75,000";
                    credito.Prestamo = 75000;
                    break;
                case "Alimentos preparados":
                    this.Label_Importe.Content = "$50,000";
                    credito.Prestamo = 50000;
                    break;
                case "Moda y belleza":
                    this.Label_Importe.Content = "$25,000";
                    credito.Prestamo = 25000;
                    break;
            }
        }

        private void SetImporte_VentaDirecta() 
        {
            switch (credito.Producto)
            {
                case "Alimentos preparados":
                case "Moda y belleza":
                    this.Label_Importe.Content = "$50,000";
                    credito.Prestamo = 50000;
                    break;
                default:
                    this.Label_Importe.Content = "$100,000";
                    credito.Prestamo = 100000;
                    break;
            }
        }

        private void SetImporte_Establecido()
        {
            switch (credito.Producto)
            {
                case "Alimentos preparados":
                    this.Label_Importe.Content = "$50,000";
                    credito.Prestamo = 50000;
                    break;
                default:
                    this.Label_Importe.Content = "$100,000";
                    credito.Prestamo = 100000;
                    break;   
            }
        }
    }
}
