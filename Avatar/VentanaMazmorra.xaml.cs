using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Avatar
{
	/// <summary>
	/// Lógica de interacción para Window1.xaml
	/// </summary>
	public partial class VentanaMazmorra : Window
	{
        DispatcherTimer t1;
        public VentanaMazmorra()
		{
            
			this.InitializeComponent();
            PBtime.Foreground = Brushes.Yellow;
            t1 = new DispatcherTimer();
            t1.Interval = TimeSpan.FromMilliseconds(1000);
            t1.Tick += new EventHandler(reloj);
            t1.Start();

            // A partir de este punto se requiere la inserción de código para la creación del objeto.
        }
        private void reloj(Object sender, EventArgs e)
        {
            this.PBtime.Value -= 1;

        }

        private void Golpear(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
		
			this.PBvida.Value=PBvida.Value-1;
			// TODO: Agregar implementación de controlador de eventos aquí.
		}

		private void CambioValor(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{

            //String valor = PBvida.Value.ToString();
            //labelVida.Content = "" + valor;
            //NO FUNCIONA

            if (PBvida.Value<5){
				labelVida.Foreground= Brushes.Yellow;
				PBvida.Foreground= Brushes.Red;
			}
			if(PBvida.Value==0){
                t1.Stop();
				TxtAyuda.Visibility= Visibility.Hidden;
				TxtVictoria.Visibility=Visibility.Visible;
				TxtVictoria2.Visibility=Visibility.Visible;
				btnOtra_vez.Visibility=Visibility.Visible;
                ((MainWindow)App.Current.MainWindow).PBdiversion.Value = 100;
                twittearImagen.Visibility = Visibility.Visible;
            }
		}

		private void volver(object sender, System.Windows.RoutedEventArgs e)
		{
            ((MainWindow)App.Current.MainWindow).t1.Start();
             this.Close();
		}

		private void otra_vez(object sender, System.Windows.RoutedEventArgs e)
		{
            t1.Start();
			PBvida.Value=20;// TODO: Agregar implementación de controlador de eventos aquí.
			btnOtra_vez.Visibility=Visibility.Hidden;
			labelVida.Foreground= Brushes.White;
			PBvida.Foreground= Brushes.Green;
			TxtAyuda.Visibility= Visibility.Visible;
			TxtVictoria.Visibility=Visibility.Hidden;
            TxtVictoria2.Visibility = Visibility.Hidden;
            twittearImagen.Visibility = Visibility.Hidden;
            PBtime.Value = 30;
        }


        private void cerrar(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //MessageBox.Show("saliendooo");
            ((MainWindow)App.Current.MainWindow).t1.Start();
        }

        private void timer(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (PBtime.Value <= 5)
            {
                PBtime.Foreground = Brushes.Red;
                if (PBtime.Value == 0)
                {
                  
                    PBtime.Value = 30;
                    PBvida.Value = 20;
                    PBtime.Foreground = Brushes.Yellow;
                    labelVida.Foreground = Brushes.White;
                    PBvida.Foreground = Brushes.Green;
                }
            }
        }

        private void tweet(object sender, MouseButtonEventArgs e)
        {
            DateTime localDate = DateTime.Now;
            //MessageBox.Show(localDate.ToString());

            var oauth = new OAuthInfo
            {
                AccessToken = "740882911864459265-XU3v3Y3IPIiSsb1maMWMz7JJWRD5NV9",
                AccessSecret = "tQ86KiRdIDdM79iLGZFUPqgUNrdLlRGZjPEqcYPoY4J0U",
                ConsumerKey = "GxkZtMUulxt3tJbvsMgsXLpXd",
                ConsumerSecret = "4aqAubjdORM3KAjz1B70364Kg6SQXkq9MWgx4D5ALJdngI3MzP"
            };

            var twitter = new Twitter(oauth);
            twitter.UpdateStatus("¡¡¡He derrotado al Boss!!! " + localDate);
        }
    }
}