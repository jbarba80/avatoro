using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Lógica de interacción para VentanaJuego.xaml
    /// </summary>
    public partial class VentanaJuego : Window
    {
        //DispatcherTimer t;
        public VentanaJuego()
        {
            InitializeComponent();

        }

        private void reloj(Object sender, EventArgs e)
        {
            txtGalleta.Visibility = Visibility.Hidden;
            txtGaren.Visibility = Visibility.Hidden;

        }

        private void volver(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).t1.Start();
            this.Close();
        }

        private void facecheckGaren(object sender, MouseButtonEventArgs e)
        {
            //t = new DispatcherTimer();
            //t.Interval = TimeSpan.FromMilliseconds(3000);
            //t.Tick += new EventHandler(reloj);
            //t.Start();
            txtGalleta.Visibility = Visibility.Hidden;
            ((MainWindow)App.Current.MainWindow).PBenergia.Value -= 20;
            txtGaren.Visibility = Visibility.Visible;

        }

        private void facecheckGalleta1(object sender, MouseButtonEventArgs e)
        {
            //t = new DispatcherTimer();
            //t.Interval = TimeSpan.FromMilliseconds(3000);
            //t.Tick += new EventHandler(reloj);
            //t.Start();
            txtGaren.Visibility = Visibility.Hidden;
            ((MainWindow)App.Current.MainWindow).PBapetito.Value += 20;
             txtGalleta.Visibility = Visibility.Visible;
        }

        private void facecheckGalleta2(object sender, MouseButtonEventArgs e)
        {
            //t = new DispatcherTimer();
            //t.Interval = TimeSpan.FromMilliseconds(3000);
            //t.Tick += new EventHandler(reloj);
            //t.Start();
            txtGaren.Visibility = Visibility.Hidden;
            ((MainWindow)App.Current.MainWindow).PBapetito.Value += 20;
            txtGalleta.Visibility = Visibility.Visible;
        }

        private void cerrar(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).t1.Start();
        }
    }
}
