using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model {
    class Recipe {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Documentation { get; set; }
        public string Correspondence { get; set; }
        public List<Product> Products { get; set; }
        public List<IngredientLine> Ingredients { get; set; }

        public Recipe(int id, string name, string documentation, string correspondence) {
            ID = id;
            Name = name;
            Documentation = documentation;
            Correspondence = correspondence;
            Products = new List<Product>();
            Ingredients = new List<IngredientLine>();
        }
    }
}
