using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Lógica de interacción para VentanaDormir.xaml
    /// </summary>
    public partial class VentanaDormir : Window
    {
        DispatcherTimer t=new DispatcherTimer();
        int aux=0;
        public VentanaDormir()
        {
            InitializeComponent();
            PBenergia.Value=((MainWindow)App.Current.MainWindow).PBenergia.Value;
        }
        private void reloj(Object sender, EventArgs e)
        {
            if (aux == 0)
            {
                Sueño1.Visibility = Visibility.Visible;
              
            }
            if (aux == 1)
                {
                Sueño2.Visibility = Visibility.Visible;
                    
                }
            if( aux==2) {  
                TextoZZZ.Visibility = Visibility.Visible;
                   
            }
            if (aux == 3)  
            {
                Sueño1.Visibility = Visibility.Hidden;
                Sueño2.Visibility = Visibility.Hidden;
                TextoZZZ.Visibility = Visibility.Hidden;
                aux = -1;
            }
            aux++;
            PBenergia.Value += 5;

        }

        private void Dormir(object sender, RoutedEventArgs e)
        {
            botonAlarma.Visibility = Visibility.Visible;
            botonDormir.Visibility = Visibility.Hidden;
            Parpado1.Visibility = Visibility.Visible;
            Parpado2.Visibility = Visibility.Visible;
            Parpado3.Visibility = Visibility.Visible;
            Parpado4.Visibility = Visibility.Visible;
            lengua.Visibility = Visibility.Hidden;
            //Sueño1.Visibility = Visibility.Visible;
            //Sueño2.Visibility = Visibility.Visible;
            //TextoZZZ.Visibility = Visibility.Visible;
           
            t.Interval = TimeSpan.FromMilliseconds(1000);
            t.Tick += new EventHandler(reloj);
            t.Start();
        }

        private void Despertar(object sender, RoutedEventArgs e)
        {
            despertarse();
        }

        private void volver(object sender, RoutedEventArgs e)
        {
            t.Stop();
            ((MainWindow)App.Current.MainWindow).PBenergia.Value = PBenergia.Value;
            ((MainWindow)App.Current.MainWindow).t1.Start();
            this.Close();
        }

        private void cerrar(object sender, System.ComponentModel.CancelEventArgs e)
        {
            t.Stop();
            ((MainWindow)App.Current.MainWindow).t1.Start();
        }

        private void CambioValor(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (PBenergia.Value == 100)
            {
                despertarse();
                botonDormir.Visibility = Visibility.Hidden;
            }
        }
        private void despertarse()
        {
            botonAlarma.Visibility = Visibility.Hidden;
            botonDormir.Visibility = Visibility.Visible;
            Parpado1.Visibility = Visibility.Hidden;
            Parpado2.Visibility = Visibility.Hidden;
            Parpado3.Visibility = Visibility.Hidden;
            Parpado4.Visibility = Visibility.Hidden;
            Sueño1.Visibility = Visibility.Hidden;
            Sueño2.Visibility = Visibility.Hidden;
            TextoZZZ.Visibility = Visibility.Hidden;
            lengua.Visibility = Visibility.Visible;

            t.Stop();
        }
    }
}
