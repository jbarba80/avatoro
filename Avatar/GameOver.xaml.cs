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

namespace Avatar
{
    /// <summary>
    /// Lógica de interacción para GameOver.xaml
    /// </summary>
    public partial class GameOver : Window
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private void inicio(object sender, RoutedEventArgs e)
        {
            this.Close();
            ((MainWindow)App.Current.MainWindow).PBenergia.Value = 100;
            ((MainWindow)App.Current.MainWindow).PBdiversion.Value = 100;
            ((MainWindow)App.Current.MainWindow).PBapetito.Value = 100;
        }

        private void cerrar(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).PBenergia.Value = 100;
            ((MainWindow)App.Current.MainWindow).PBdiversion.Value = 100;
            ((MainWindow)App.Current.MainWindow).PBapetito.Value = 100;
        }
    }
}
