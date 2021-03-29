
namespace SomerenUI
{
    partial class RegisterForm
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.NameLBL = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.passwordBOX = new System.Windows.Forms.TextBox();
            this.usernameBOX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.registerBTN = new System.Windows.Forms.Button();
            this.Cancelbtn = new System.Windows.Forms.Button();
            this.registerlbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.licenceBOX = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(92, 72);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(203, 20);
            this.nameBox.TabIndex = 0;
            // 
            // NameLBL
            // 
            this.NameLBL.AutoSize = true;
            this.NameLBL.Location = new System.Drawing.Point(4, 75);
            this.NameLBL.Name = "NameLBL";
            this.NameLBL.Size = new System.Drawing.Size(38, 13);
            this.NameLBL.TabIndex = 1;
            this.NameLBL.Text = "Name:";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(4, 148);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(56, 13);
            this.Password.TabIndex = 2;
            this.Password.Text = "Password:";
            // 
            // passwordBOX
            // 
            this.passwordBOX.Location = new System.Drawing.Point(92, 145);
            this.passwordBOX.Name = "passwordBOX";
            this.passwordBOX.Size = new System.Drawing.Size(203, 20);
            this.passwordBOX.TabIndex = 2;
            // 
            // usernameBOX
            // 
            this.usernameBOX.Location = new System.Drawing.Point(92, 109);
            this.usernameBOX.Name = "usernameBOX";
            this.usernameBOX.Size = new System.Drawing.Size(203, 20);
            this.usernameBOX.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Register";
            // 
            // registerBTN
            // 
            this.registerBTN.Location = new System.Drawing.Point(7, 216);
            this.registerBTN.Name = "registerBTN";
            this.registerBTN.Size = new System.Drawing.Size(98, 23);
            this.registerBTN.TabIndex = 7;
            this.registerBTN.Text = "Register";
            this.registerBTN.UseVisualStyleBackColor = true;
            this.registerBTN.Click += new System.EventHandler(this.registerBTN_Click);
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.Location = new System.Drawing.Point(196, 216);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(99, 23);
            this.Cancelbtn.TabIndex = 8;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = true;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // registerlbl
            // 
            this.registerlbl.AutoSize = true;
            this.registerlbl.Location = new System.Drawing.Point(12, 44);
            this.registerlbl.Name = "registerlbl";
            this.registerlbl.Size = new System.Drawing.Size(229, 13);
            this.registerlbl.TabIndex = 9;
            this.registerlbl.Text = "Register here to gain access to the application!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "License Key:";
            // 
            // licenceBOX
            // 
            this.licenceBOX.Location = new System.Drawing.Point(92, 179);
            this.licenceBOX.Name = "licenceBOX";
            this.licenceBOX.Size = new System.Drawing.Size(203, 20);
            this.licenceBOX.TabIndex = 3;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 278);
            this.Controls.Add(this.licenceBOX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.registerlbl);
            this.Controls.Add(this.Cancelbtn);
            this.Controls.Add(this.registerBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usernameBOX);
            this.Controls.Add(this.passwordBOX);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.NameLBL);
            this.Controls.Add(this.nameBox);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label NameLBL;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox passwordBOX;
        private System.Windows.Forms.TextBox usernameBOX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button registerBTN;
        private System.Windows.Forms.Button Cancelbtn;
        private System.Windows.Forms.Label registerlbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox licenceBOX;
    }
}