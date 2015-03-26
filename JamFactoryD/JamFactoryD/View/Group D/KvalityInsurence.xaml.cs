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
        public KvalityInsurence()
        {
            InitializeComponent();
            Activity_Combo.IsEnabled = false;
            ActivityDescription_Box.IsEnabled = false;
            Details_Box.IsEnabled = false;
            Time_Box.IsEnabled = false;
            QualityControlController.GetQualityInsurence();
            for (int i = 0; i < QualityControlController.ControlList.Count; i++)
            {
                Control_Combo.Items.Add(QualityControlController.ControlList[i].Name);
                for (int k = 0; k < QualityControlController.ControlList[i].ActivityList.Count; k++)
			    {
                    Activity_Combo.Items.Add(QualityControlController.ControlList[i].ActivityList[i].Name);
			    }
                
            }
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Control_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ControlDescription_Box.Text = QualityControlController.ControlList[Control_Combo.SelectedIndex].Description;
            TimeCheck_Box.Text = QualityControlController.ControlList[Control_Combo.SelectedIndex].TimeCheck;
            Product_Box.Text = QualityControlController.ControlList[Control_Combo.SelectedIndex].Variant;
            Employee_Box.Text = QualityControlController.ControlList[Control_Combo.SelectedIndex].Employee;
            Activity_Combo.IsEnabled = true;
            ActivityDescription_Box.IsEnabled = true;
            Details_Box.IsEnabled = true;
            Time_Box.IsEnabled = true;
        }

        private void Activity_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActivityDescription_Box.Text = QualityControlController.ControlList[Control_Combo.SelectedIndex].ActivityList[Activity_Combo.SelectedIndex].Description;
            Details_Box.Text = QualityControlController.ControlList[Control_Combo.SelectedIndex].ActivityList[Activity_Combo.SelectedIndex].Details;
            Time_Box.Text = Convert.ToString(QualityControlController.ControlList[Control_Combo.SelectedIndex].ActivityList[Activity_Combo.SelectedIndex].Time);
        }
    }
}
