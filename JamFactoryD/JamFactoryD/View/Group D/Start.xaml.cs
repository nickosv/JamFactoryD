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
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Window {

        ProductController _controller;
        public Start() {
            InitializeComponent();
            _controller = new ProductController();

            PrintRecipes();
        }

        private void PrintRecipes() {
            foreach (string recipe in _controller.GetRecipes()) {
                RecipeList.Items.Add(recipe);
            } 
        }
    }
}
