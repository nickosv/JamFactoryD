using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamFactoryD.Model;
using JamFactoryD.Controller.Facades;

namespace JamFactoryD.Controller
{
    class QualityControlController
    {
        public List<QualityControl> GetQualityInsurence(int productID)
        {
            return QualityInsurenceFacade.GetQualityInsurence(productID);
        }
    }
}
