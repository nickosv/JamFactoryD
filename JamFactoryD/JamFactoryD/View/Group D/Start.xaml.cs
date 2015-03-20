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
using JamFactoryD.Controller;

namespace JamFactory.View.Group_D {
    // Interaction logic for Start.xaml
    public partial class Start : Window {

        ProductController _controller;
        List<string> parameters = new List<string>();
        public Start() {
            InitializeComponent();
            _controller = new ProductController();
            PrintRecipes();
        }

        // Adds all the recipes to ListView
        private void PrintRecipes() {
            // Adding recipes to ListView
            RecipeList.ItemsSource = _controller.GetRecipes();
        }

        // Opens a new window with recipe details

        private void RecipeList_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            _controller.ShowDetailsForRecipe(RecipeList.SelectedIndex);
        }

        private void luksus_Checked(object sender, RoutedEventArgs e) {
            parameters.Add("Luksus");
        }

        private void weekday_Checked(object sender, RoutedEventArgs e) {
            parameters.Add("Hverdags");
        }

        private void discount_Checked(object sender, RoutedEventArgs e) {
            parameters.Add("Discount");
        }

        private void luksus_Unchecked(object sender, RoutedEventArgs e) {
            SortParameters("Luksus");
        }

        private void weekday_Unchecked(object sender, RoutedEventArgs e) {
            SortParameters("Hverdags");
        }

        private void discount_Unchecked(object sender, RoutedEventArgs e) {
            SortParameters("Discount");
        }
        public void SortParameters(string parameter) {
            for (int i = 0; i < parameters.Count; i++){
                if (parameters[i] == parameter) {
                    parameters.RemoveAt(i);
                }
			}
                
            
        }

    }
}
