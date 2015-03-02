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

namespace JamFactory {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            View.Group_A.Start start = new View.Group_A.Start();
            start.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            View.Group_B.Start start = new View.Group_B.Start();
            start.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            View.Group_C.Start start = new View.Group_C.Start();
            start.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) {
            View.Group_D.Start start = new View.Group_D.Start();
            start.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) {
            View.Group_E.Start start = new View.Group_E.Start();
            start.Show();
            this.Close();
        }
    }
}
