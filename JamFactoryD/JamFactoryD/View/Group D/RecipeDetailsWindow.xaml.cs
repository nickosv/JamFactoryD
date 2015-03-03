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

namespace JamFactoryD.View.Group_D
{
    /// <summary>
    /// Interaction logic for RecipeDetailsWindow.xaml
    /// </summary>
    public partial class RecipeDetailsWindow : Window
    {
        public RecipeDetailsWindow()
        {
            InitializeComponent();


            CorrespondanceTextBox.Text = "";
            DocumentationTextBox.Text = "";
        }

        private void ProductTypeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
