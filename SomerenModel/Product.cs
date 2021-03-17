using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Product
    {
        // Ruben Stoop
        
        // Key
        public int ProductID { get; set; } 
        // Is alcoholic drink
        public bool isAlcohol { get; set; }   
        // The name of the product
        public string ProductName { get; set; }
        // Price
        public double Price { get; set; }
        // Stock
        public int Stock { get; set; }
    }
}
