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
        public Product(int productID, bool isalcohol, string productName, double price, int stock, int sold)
        {
            this.ProductID = productID;
            this.IsAlcohol = isalcohol;
            this.ProductName = productName;
            this.Price = price;
            this.Stock = stock;
            this.Sold = sold;
            
            if(isalcohol)
            {
                this.AlcoholString = "Yes";
            } else if(!isalcohol)
            {
                this.AlcoholString = "No";
            }
        }
        // Key
        public int ProductID { get; set; } 
        // Is alcoholic drink
        public bool IsAlcohol { get; set; }   
        // The name of the product
        public string ProductName { get; set; }
        // Price
        public double Price { get; set; }
        // Stock
        public int Stock { get; set; }
        //Bool alcohol naar string
        public string AlcoholString { get; set; }
        // Amount sold
        public int Sold { get; set; }
        public override string ToString()
        {
            return ProductName;
        }
    }
}
