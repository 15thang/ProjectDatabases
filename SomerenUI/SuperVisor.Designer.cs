
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
            // SuperVisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}