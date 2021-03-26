
namespace SomerenUI
{
    partial class TeacherForm
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
            this.pnl_AddTeacher = new System.Windows.Forms.Panel();
            this.cancelBTN = new System.Windows.Forms.Button();
            this.addteacherBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lastnameBox = new System.Windows.Forms.TextBox();
            this.firstnameBox = new System.Windows.Forms.TextBox();
            this.Birthdatelbl = new System.Windows.Forms.Label();
            this.Lastnamelbl = new System.Windows.Forms.Label();
            this.FirstNamelbl = new System.Windows.Forms.Label();
            this.birthdatePicker = new System.Windows.Forms.DateTimePicker();
            this.pnl_AddTeacher.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_AddTeacher
            // 
            this.pnl_AddTeacher.Controls.Add(this.cancelBTN);
            this.pnl_AddTeacher.Controls.Add(this.addteacherBTN);
            this.pnl_AddTeacher.Controls.Add(this.label1);
            this.pnl_AddTeacher.Controls.Add(this.lastnameBox);
            this.pnl_AddTeacher.Controls.Add(this.firstnameBox);
            this.pnl_AddTeacher.Controls.Add(this.Birthdatelbl);
            this.pnl_AddTeacher.Controls.Add(this.Lastnamelbl);
            this.pnl_AddTeacher.Controls.Add(this.FirstNamelbl);
            this.pnl_AddTeacher.Controls.Add(this.birthdatePicker);
            this.pnl_AddTeacher.Location = new System.Drawing.Point(12, 28);
            this.pnl_AddTeacher.Name = "pnl_AddTeacher";
            this.pnl_AddTeacher.Size = new System.Drawing.Size(262, 257);
            this.pnl_AddTeacher.TabIndex = 0;
            // 
            // cancelBTN
            // 
            this.cancelBTN.Location = new System.Drawing.Point(162, 203);
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(75, 23);
            this.cancelBTN.TabIndex = 8;
            this.cancelBTN.Text = "Cancel";
            this.cancelBTN.UseVisualStyleBackColor = true;
            this.cancelBTN.Click += new System.EventHandler(this.cancelBTN_Click);
            // 
            // addteacherBTN
            // 
            this.addteacherBTN.Location = new System.Drawing.Point(37, 203);
            this.addteacherBTN.Name = "addteacherBTN";
            this.addteacherBTN.Size = new System.Drawing.Size(75, 23);
            this.addteacherBTN.TabIndex = 7;
            this.addteacherBTN.Text = "Add teacher";
            this.addteacherBTN.UseVisualStyleBackColor = true;
            this.addteacherBTN.Click += new System.EventHandler(this.addteacherBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Add Teacher";
            // 
            // lastnameBox
            // 
            this.lastnameBox.Location = new System.Drawing.Point(37, 122);
            this.lastnameBox.Name = "lastnameBox";
            this.lastnameBox.Size = new System.Drawing.Size(200, 20);
            this.lastnameBox.TabIndex = 5;
            // 
            // firstnameBox
            // 
            this.firstnameBox.Location = new System.Drawing.Point(37, 83);
            this.firstnameBox.Name = "firstnameBox";
            this.firstnameBox.Size = new System.Drawing.Size(200, 20);
            this.firstnameBox.TabIndex = 4;
            // 
            // Birthdatelbl
            // 
            this.Birthdatelbl.AutoSize = true;
            this.Birthdatelbl.Location = new System.Drawing.Point(37, 145);
            this.Birthdatelbl.Name = "Birthdatelbl";
            this.Birthdatelbl.Size = new System.Drawing.Size(54, 13);
            this.Birthdatelbl.TabIndex = 3;
            this.Birthdatelbl.Text = "Birth Date";
            // 
            // Lastnamelbl
            // 
            this.Lastnamelbl.AutoSize = true;
            this.Lastnamelbl.Location = new System.Drawing.Point(37, 106);
            this.Lastnamelbl.Name = "Lastnamelbl";
            this.Lastnamelbl.Size = new System.Drawing.Size(58, 13);
            this.Lastnamelbl.TabIndex = 2;
            this.Lastnamelbl.Text = "Last Name";
            // 
            // FirstNamelbl
            // 
            this.FirstNamelbl.AutoSize = true;
            this.FirstNamelbl.Location = new System.Drawing.Point(35, 67);
            this.FirstNamelbl.Name = "FirstNamelbl";
            this.FirstNamelbl.Size = new System.Drawing.Size(57, 13);
            this.FirstNamelbl.TabIndex = 1;
            this.FirstNamelbl.Text = "First Name";
            // 
            // birthdatePicker
            // 
            this.birthdatePicker.Location = new System.Drawing.Point(37, 161);
            this.birthdatePicker.Name = "birthdatePicker";
            this.birthdatePicker.Size = new System.Drawing.Size(200, 20);
            this.birthdatePicker.TabIndex = 0;
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 316);
            this.Controls.Add(this.pnl_AddTeacher);
            this.Name = "TeacherForm";
            this.Text = "Teacher";
            this.Load += new System.EventHandler(this.TeacherForm_Load);
            this.pnl_AddTeacher.ResumeLayout(false);
            this.pnl_AddTeacher.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_AddTeacher;
        private System.Windows.Forms.DateTimePicker birthdatePicker;
        private System.Windows.Forms.Button cancelBTN;
        private System.Windows.Forms.Button addteacherBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lastnameBox;
        private System.Windows.Forms.TextBox firstnameBox;
        private System.Windows.Forms.Label Birthdatelbl;
        private System.Windows.Forms.Label Lastnamelbl;
        private System.Windows.Forms.Label FirstNamelbl;
    }
}