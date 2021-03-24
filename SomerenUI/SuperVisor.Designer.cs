
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ActivityTitleLabel
            // 
            this.ActivityTitleLabel.AutoSize = true;
            this.ActivityTitleLabel.Location = new System.Drawing.Point(130, 36);
            this.ActivityTitleLabel.Name = "ActivityTitleLabel";
            this.ActivityTitleLabel.Size = new System.Drawing.Size(87, 13);
            this.ActivityTitleLabel.TabIndex = 0;
            this.ActivityTitleLabel.Text = "ActivityTitleLabel";
            // 
            // startTimeLbl
            // 
            this.startTimeLbl.AutoSize = true;
            this.startTimeLbl.Location = new System.Drawing.Point(350, 36);
            this.startTimeLbl.Name = "startTimeLbl";
            this.startTimeLbl.Size = new System.Drawing.Size(58, 13);
            this.startTimeLbl.TabIndex = 1;
            this.startTimeLbl.Text = "StartTime: ";
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.Location = new System.Drawing.Point(25, 36);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(24, 13);
            this.idLbl.TabIndex = 2;
            this.idLbl.Text = "ID: ";
            // 
            // endTimeLbl
            // 
            this.endTimeLbl.AutoSize = true;
            this.endTimeLbl.Location = new System.Drawing.Point(539, 36);
            this.endTimeLbl.Name = "endTimeLbl";
            this.endTimeLbl.Size = new System.Drawing.Size(55, 13);
            this.endTimeLbl.TabIndex = 3;
            this.endTimeLbl.Text = "End Time:";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(28, 138);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(434, 97);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Supervisors for this activity";
            // 
            // SuperVisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
    }
}