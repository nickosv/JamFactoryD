﻿using System;
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
        Controller.ProductController _productController;
        JamFactory.View.Group_D.Start startView;
        
        public KvalityInsurence()
        {
            InitializeComponent();
            Activity_Combo.IsEnabled = false;
            ActivityDescription_Box.IsEnabled = false;
            Details_Box.IsEnabled = false;
            Time_Box.IsEnabled = false;
            _productController = new ProductController();
            startView = new JamFactory.View.Group_D.Start();

            for (int i = 0; i < QualityControlController.GetQualityInsurence().Count; i++)
			{
                Control_Combo.Items.Add(QualityControlController.GetQualityInsurence()[i].Name);
			}
          
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Control_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
