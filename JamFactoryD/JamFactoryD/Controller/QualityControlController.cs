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
    
    static class QualityControlController
    {
        static int ProductID;
        public static List<QualityControl> ControlList = new List<QualityControl>();

        public static void GetQualityInsurence()
        {
            ControlList = QualityInsurenceFacade.GetQualityInsurence(ProductID);   
        }

        public static void SetProductID(Recipe recipe)
        {
            ProductID = QualityInsurenceFacade.GetProductsFromRecipe(recipe);

        }
    }
}
