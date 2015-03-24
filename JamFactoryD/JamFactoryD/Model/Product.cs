using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model {
    class Product {
        public int ProductID { get; set; }
        public string Variant { get; set; }
        public int Size { get; set; }
        public int FruitContent { get; set; }
        public double Price { get; set; }

        public Product(int id, string variant, int size, int fruitContent, double price) {
            ProductID = id;
            Variant = variant;
            Size = size;
            FruitContent = fruitContent;
            Price = price;
        }
    }
}
