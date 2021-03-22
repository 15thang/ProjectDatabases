
namespace SomerenUI
{
    partial class AddAmount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.productLabel = new System.Windows.Forms.Label();
            this.AmountBox = new System.Windows.Forms.TextBox();
            this.AddProduct = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // productLabel
            // 
            this.productLabel.AutoSize = true;
            this.productLabel.Location = new System.Drawing.Point(9, 9);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(44, 13);
            this.productLabel.TabIndex = 0;
            this.productLabel.Text = "Product";
            // 
            // AmountBox
            // 
            this.AmountBox.Location = new System.Drawing.Point(12, 64);
            this.AmountBox.Name = "AmountBox";
            this.AmountBox.Size = new System.Drawing.Size(45, 20);
            this.AmountBox.TabIndex = 1;
            // 
            // AddProduct
            // 
            this.AddProduct.Location = new System.Drawing.Point(12, 102);
            this.AddProduct.Name = "AddProduct";
            this.AddProduct.Size = new System.Drawing.Size(75, 23);
            this.AddProduct.TabIndex = 2;
            this.AddProduct.Text = "Add product";
            this.AddProduct.UseVisualStyleBackColor = true;
            this.AddProduct.Click += new System.EventHandler(this.AddProduct_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select the amount of items you want to add";
            // 
            // AddAmount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 171);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddProduct);
            this.Controls.Add(this.AmountBox);
            this.Controls.Add(this.productLabel);
            this.Name = "AddAmount";
            this.Text = "AddAmount";
            this.Load += new System.EventHandler(this.AddAmount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.TextBox AmountBox;
        private System.Windows.Forms.Button AddProduct;
        private System.Windows.Forms.Label label1;
    }
}