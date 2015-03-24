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
    /// Interaction logic for KvalitetsSikring.xaml
    /// </summary>
    public partial class KvalityInsurence : Window
    {
        Controller.QualityControlController _qualityController;
        Controller.ProductController _productController;
        JamFactory.View.Group_D.Start startView;
        
        public KvalityInsurence()
        {
            InitializeComponent();
            Activity_Combo.IsEnabled = false;
            ActivityDescription_Box.IsEnabled = false;
            Details_Box.IsEnabled = false;
            Time_Box.IsEnabled = false;
            _qualityController = new QualityControlController();
            _productController = new ProductController();
            startView = new JamFactory.View.Group_D.Start();

            for (int i = 0; i < _qualityController.GetQualityInsurence(startView.RecipeList.SelectedIndex).Count; i++)
			{
                Control_Combo.Items.Add(_qualityController.GetQualityInsurence(startView.RecipeList.SelectedIndex)[i].Name);
			}
            
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
