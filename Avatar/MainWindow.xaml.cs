using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Avatar
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public  DispatcherTimer t1;
        //Double intervalo = 1000;
        int flag = 0;

        public MainWindow()
        {
            this.InitializeComponent();
            Barras barras = new Barras(100, 100, 100);
            t1 = new DispatcherTimer();
            t1.Interval = TimeSpan.FromMilliseconds(1000);
            t1.Tick += new EventHandler(reloj);
            t1.Start();
        }

        private int Dado(int max)
        {
            Random ran = new Random();
            return 1 + ran.Next(max);
        }

        private void reloj(Object sender, EventArgs e)
        {
            this.PBapetito.Value = this.PBapetito.Value - this.Dado(3);
            this.PBdiversion.Value = this.PBdiversion.Value - this.Dado(3);
            this.PBenergia.Value = this.PBenergia.Value - this.Dado(3);

        }

        private void dormir(object sender, RoutedEventArgs e)
        {
            t1.Stop();
            VentanaDormir ventanaDormir = new VentanaDormir();
            ventanaDormir.Show();
            //this.PBenergia.Value += Dado(3);
            //intervalo -= 20;
            //t1.Interval = TimeSpan.FromMilliseconds(intervalo);
        }

        private void comer(object sender, RoutedEventArgs e)
        {
            t1.Stop();
            VentanaJuego ventanaJuego = new VentanaJuego();
            ventanaJuego.Show();
            // this.Hide();
            //this.PBapetito.Value += Dado(10);
            //intervalo -= 20;
            //t1.Interval = TimeSpan.FromMilliseconds(intervalo);
        }

        private void jugar(object sender, RoutedEventArgs e)
		{
            t1.Stop();
            VentanaMazmorra vMaz = new VentanaMazmorra();
			vMaz.Show();
		}
			/*  {

            this.PBdiversion.Value += Dado(10);
            intervalo -= 20;
            t1.Interval = TimeSpan.FromMilliseconds(intervalo);
        }
*/
       

        private void PBenergia_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.PBenergia.Value < 25)
            {
                PBenergia.Foreground = Brushes.Red;
                Parpado1.Visibility = Visibility.Visible;
                Parpado2.Visibility = Visibility.Visible;
                Sueño1.Visibility = Visibility.Visible;
                Sueño2.Visibility = Visibility.Visible;
                TextoZZZ.Visibility = Visibility.Visible;
                flag = 1;
                if (this.PBenergia.Value == 0)
                {
                    btnComer.Visibility = Visibility.Hidden;
                    btnJugar.Visibility = Visibility.Hidden;
					txtSueño.Visibility=Visibility.Visible;

                    comprobarGameOver();
                }
            }
            else {
                if (flag == 1)
                {

                    PBenergia.Foreground = Brushes.Green;
                    Sueño1.Visibility = Visibility.Hidden;
                    Sueño2.Visibility = Visibility.Hidden;
                    TextoZZZ.Visibility = Visibility.Hidden;
                    Parpado1.Visibility = Visibility.Hidden;
                    Parpado2.Visibility = Visibility.Hidden;
                    btnComer.Visibility = Visibility.Visible;
                    btnJugar.Visibility = Visibility.Visible;
					txtSueño.Visibility=Visibility.Hidden;
                    flag = 0;

                }

            }
        }

        private void valueChanged_apetito(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.PBapetito.Value < 25)
            {
                PBapetito.Foreground = Brushes.Red;
                if (this.PBapetito.Value == 0)
                {
                    comprobarGameOver();
                }
            }
            else
            {
                PBapetito.Foreground = Brushes.Green;
            }
            
        }

        private void valueChanged_diversion(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.PBdiversion.Value < 25)
            {
                PBdiversion.Foreground = Brushes.Red;
                if (PBdiversion.Value == 0)
                {
                    comprobarGameOver();
                }
            }
            else
            {
                PBdiversion.Foreground = Brushes.Green;
            }
        }

        private void comprobarGameOver()
        {
            if (this.PBenergia.Value == 0 && this.PBdiversion.Value == 0 && this.PBapetito.Value == 0)
            {
                GameOver over = new GameOver();
                over.Show();
            }
        }
    }
}