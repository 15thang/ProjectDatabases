using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenUI
{
    //Ruben Stoop
    // This is the form to add the items to the selected items.
    public partial class AddAmount : Form
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

        //list to check amounts
        public List<Product> Products = new List<Product>();
        public AddAmount(Product product, List<Product> products)
        {
            InitializeComponent();
            this.ProductID = product.ProductID;
            this.ProductName = product.ProductName;
            productLabel.Text = product.ProductName;
            this.Price = product.Price;
            this.Products = products;

        }

        private void AddAmount_Load(object sender, EventArgs e)
        {

        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            int checkAmount = 0;

            foreach(Product p in Products)
            {
                if(ProductID == p.ProductID)
                {
                    if (p.Stock == 0)
                    {
                        MessageBox.Show("There aren't enough products in stock.", "Error!");
                        return;
                    } else
                    {
                        checkAmount = p.Stock;
                    }
                }

            }
            int amount = 0;
            try
            {
                amount = int.Parse(AmountBox.Text);
            } catch
            {
                MessageBox.Show("Not the correct input", "Error!");
            }
            if (amount == 0) {
                MessageBox.Show("Order atleast one product.", "Error!");
                return;
            }

            this.Amount = amount;
            if (ProductID == 1 || checkAmount >= amount)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else
            {
                MessageBox.Show("There aren't enough products in stock.", "Error!");
                return;
            }
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
