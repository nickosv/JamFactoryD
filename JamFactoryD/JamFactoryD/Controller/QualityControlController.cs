using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamFactoryD.Model;
using JamFactory.Model;
using JamFactoryD.Controller.Facades;
using JamFactory.View.Group_D;

namespace JamFactoryD.Controller
{
    
    class QualityControlController
    {
        Start startview = new Start();
        Controller.ProductController _controller;

        public List<QualityControl> GetQualityInsurence()
        {
            List<QualityControl> QualityControlList = new List<QualityControl>();
            _controller = new ProductController();

            _controller.ShowDetailsForRecipe(startview.RecipeList.SelectedIndex);
            List<Product> productList = RecipeFacade.GetProductsFromRecipe(_controller.selectedRecipe);
            for (int i = 0; i < productList.Count; i++)
            {
                QualityControlList = QualityInsurenceFacade.GetQualityInsurence(productList[i].ProductID);
            }

            return QualityControlList;
            
        }
    }
}
