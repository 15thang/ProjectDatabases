
namespace SomerenUI
{
    partial class SuperVisor
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
            this.ActivityTitleLabel = new System.Windows.Forms.Label();
            this.startTimeLbl = new System.Windows.Forms.Label();
            this.idLbl = new System.Windows.Forms.Label();
            this.endTimeLbl = new System.Windows.Forms.Label();
            this.Supervisor_LV = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.TeacherListView = new System.Windows.Forms.ListView();
            this.removeBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.AddTeacherBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ActivityTitleLabel
            // 
            this.ActivityTitleLabel.AutoSize = true;
            this.ActivityTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivityTitleLabel.Location = new System.Drawing.Point(24, 9);
            this.ActivityTitleLabel.Name = "ActivityTitleLabel";
            this.ActivityTitleLabel.Size = new System.Drawing.Size(148, 24);
            this.ActivityTitleLabel.TabIndex = 0;
            this.ActivityTitleLabel.Text = "ActivityTitleLabel";
            // 
            // startTimeLbl
            // 
            this.startTimeLbl.AutoSize = true;
            this.startTimeLbl.Location = new System.Drawing.Point(125, 54);
            this.startTimeLbl.Name = "startTimeLbl";
            this.startTimeLbl.Size = new System.Drawing.Size(58, 13);
            this.startTimeLbl.TabIndex = 1;
            this.startTimeLbl.Text = "StartTime: ";
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.Location = new System.Drawing.Point(25, 54);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(24, 13);
            this.idLbl.TabIndex = 2;
            this.idLbl.Text = "ID: ";
            // 
            // endTimeLbl
            // 
            this.endTimeLbl.AutoSize = true;
            this.endTimeLbl.Location = new System.Drawing.Point(296, 54);
            this.endTimeLbl.Name = "endTimeLbl";
            this.endTimeLbl.Size = new System.Drawing.Size(55, 13);
            this.endTimeLbl.TabIndex = 3;
            this.endTimeLbl.Text = "End Time:";
            // 
            // Supervisor_LV
            // 
            this.Supervisor_LV.HideSelection = false;
            this.Supervisor_LV.Location = new System.Drawing.Point(28, 113);
            this.Supervisor_LV.Name = "Supervisor_LV";
            this.Supervisor_LV.Size = new System.Drawing.Size(434, 97);
            this.Supervisor_LV.TabIndex = 4;
            this.Supervisor_LV.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Supervisors for this activity";
            // 
            // TeacherListView
            // 
            this.TeacherListView.HideSelection = false;
            this.TeacherListView.Location = new System.Drawing.Point(28, 275);
            this.TeacherListView.Name = "TeacherListView";
            this.TeacherListView.Size = new System.Drawing.Size(434, 97);
            this.TeacherListView.TabIndex = 6;
            this.TeacherListView.UseCompatibleStateImageBehavior = false;
            // 
            // removeBTN
            // 
            this.removeBTN.Location = new System.Drawing.Point(28, 216);
            this.removeBTN.Name = "removeBTN";
            this.removeBTN.Size = new System.Drawing.Size(129, 23);
            this.removeBTN.TabIndex = 7;
            this.removeBTN.Text = "Remove Supervisor";
            this.removeBTN.UseVisualStyleBackColor = true;
            this.removeBTN.Click += new System.EventHandler(this.removeBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Available teachers for Supervision";
            // 
            // AddTeacherBTN
            // 
            this.AddTeacherBTN.Location = new System.Drawing.Point(28, 378);
            this.AddTeacherBTN.Name = "AddTeacherBTN";
            this.AddTeacherBTN.Size = new System.Drawing.Size(184, 23);
            this.AddTeacherBTN.TabIndex = 9;
            this.AddTeacherBTN.Text = "Add teacher to Supervisors";
            this.AddTeacherBTN.UseVisualStyleBackColor = true;
            this.AddTeacherBTN.Click += new System.EventHandler(this.AddTeacherBTN_Click);
            // 
            // SuperVisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddTeacherBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.removeBTN);
            this.Controls.Add(this.TeacherListView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Supervisor_LV);
            this.Controls.Add(this.endTimeLbl);
            this.Controls.Add(this.idLbl);
            this.Controls.Add(this.startTimeLbl);
            this.Controls.Add(this.ActivityTitleLabel);
            this.Name = "SuperVisor";
            this.Text = "SuperVisor";
            this.Load += new System.EventHandler(this.SuperVisor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ActivityTitleLabel;
        private System.Windows.Forms.Label startTimeLbl;
        private System.Windows.Forms.Label idLbl;
        private System.Windows.Forms.Label endTimeLbl;
        private System.Windows.Forms.ListView Supervisor_LV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView TeacherListView;
        private System.Windows.Forms.Button removeBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddTeacherBTN;
    }
}