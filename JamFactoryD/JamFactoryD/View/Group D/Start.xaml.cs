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
            parameters.Add("Luksus");
            parameters.Add("Hverdags");
            parameters.Add("Discount");
        }

        // Adds all the recipes to ListView
        private void PrintRecipes() {
            // Adding recipes to ListView
            RecipeList.ItemsSource = _controller.GetRecipes();
        }
        private void PrintSortedRecipeByType() {
            RecipeList.ItemsSource = null;
            RecipeList.Items.Clear();
            RecipeList.ItemsSource = _controller.GetRecipeByType(parameters);
        }

        // Opens a new window with recipe details

        private void RecipeList_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            _controller.ShowDetailsForRecipe(RecipeList.SelectedIndex);
        }

        public void SortParameters(string parameter) {
            // Removes parameter from parameterlist
            for (int i = 0; i < parameters.Count; i++){
                if (parameters[i] == parameter) {
                    parameters.RemoveAt(i);
                }
			} 
        }

        private void luksus_Click(object sender, RoutedEventArgs e) {
            // unchecked
            if (luksus.IsChecked != true) {
                SortParameters("Luksus");
            }
            // checked
            else {
                parameters.Add("Luksus");
            }
            PrintSortedRecipeByType();
        }

        private void weekday_Click(object sender, RoutedEventArgs e) {
            // unchecked
            if (weekday.IsChecked != true) {
                SortParameters("Hverdags");
            }
            // checked
            else {
                parameters.Add("Hverdags");
            }
            PrintSortedRecipeByType();
        }

        private void discount_Click(object sender, RoutedEventArgs e) {
            // unchecked
            if (discount.IsChecked != true) {
                SortParameters("Discount");
            }
            // checked
            else {
                parameters.Add("Discount");
            }
            PrintSortedRecipeByType();
        }

    }
}
