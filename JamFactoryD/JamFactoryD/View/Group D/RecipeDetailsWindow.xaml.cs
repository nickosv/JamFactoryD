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

namespace JamFactoryD.View.Group_D
{
    /// <summary>
    /// Interaction logic for RecipeDetailsWindow.xaml
    /// </summary>
    public partial class RecipeDetailsWindow : Window
    {
        ProductController _controller;
        public RecipeDetailsWindow()
        {
            InitializeComponent();
        }

        private void ProductTypeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// Sets the controller to the currently used controller to be able to fetch the selected recipe
        /// </summary>
        /// <param name="productController"></param>
        internal void SetController(ProductController productController) {
            _controller = productController;
            PrintRecipe();
            PrintProducts();
        }

        /// <summary>
        /// Prints the selected recipes information
        /// </summary>
        private void PrintRecipe() {
            Dictionary<string, string> recipe = _controller.GetSelectedRecipe();

            RecipeNameLabel.Content = recipe["Name"];
            DocumentationTextBox.Text = recipe["Documentation"];
            CorrespondanceTextBox.Text = recipe["Correspondence"];
        }

        /// <summary>
        /// Prints product for selected recipe
        /// </summary>
        private void PrintProducts() {
            Dictionary<string, int> products = _controller.GetProducts();

            foreach (KeyValuePair<string, int> product in products) {
                ProductNames.Text += product.Key + "\n";
                ProductAmounts.Text += product.Value + "g\n";
            }
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Kvalitetssikring_btn_Click(object sender, RoutedEventArgs e)
        {
            KvalityInsurence kval = new KvalityInsurence();
            kval.Show();
            this.Close();

        }
    }
}
