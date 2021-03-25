
namespace SomerenUI
{
    partial class AddActivity
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
            this.btn_AddChange = new System.Windows.Forms.Button();
            this.dtp_ActivityEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_ActivityBeginTime = new System.Windows.Forms.DateTimePicker();
            this.lbl_ActivityName = new System.Windows.Forms.Label();
            this.tb_type = new System.Windows.Forms.TextBox();
            this.lbl_ActivityEndTime = new System.Windows.Forms.Label();
            this.lbl_ActivityBeginTime = new System.Windows.Forms.Label();
            this.dtp_ActivityEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_ActivityBeginDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btn_AddChange
            // 
            this.btn_AddChange.Location = new System.Drawing.Point(101, 135);
            this.btn_AddChange.Name = "btn_AddChange";
            this.btn_AddChange.Size = new System.Drawing.Size(102, 23);
            this.btn_AddChange.TabIndex = 22;
            this.btn_AddChange.Text = "Add Activity";
            this.btn_AddChange.UseVisualStyleBackColor = true;
            this.btn_AddChange.Click += new System.EventHandler(this.btn_AddChange_Click);
            // 
            // dtp_ActivityEndTime
            // 
            this.dtp_ActivityEndTime.Location = new System.Drawing.Point(227, 58);
            this.dtp_ActivityEndTime.Name = "dtp_ActivityEndTime";
            this.dtp_ActivityEndTime.Size = new System.Drawing.Size(88, 20);
            this.dtp_ActivityEndTime.TabIndex = 21;
            // 
            // dtp_ActivityBeginTime
            // 
            this.dtp_ActivityBeginTime.Location = new System.Drawing.Point(227, 26);
            this.dtp_ActivityBeginTime.Name = "dtp_ActivityBeginTime";
            this.dtp_ActivityBeginTime.Size = new System.Drawing.Size(88, 20);
            this.dtp_ActivityBeginTime.TabIndex = 20;
            // 
            // lbl_ActivityName
            // 
            this.lbl_ActivityName.AutoSize = true;
            this.lbl_ActivityName.Location = new System.Drawing.Point(12, 96);
            this.lbl_ActivityName.Name = "lbl_ActivityName";
            this.lbl_ActivityName.Size = new System.Drawing.Size(75, 13);
            this.lbl_ActivityName.TabIndex = 19;
            this.lbl_ActivityName.Text = "Activity Name:";
            // 
            // tb_type
            // 
            this.tb_type.Location = new System.Drawing.Point(101, 93);
            this.tb_type.Name = "tb_type";
            this.tb_type.Size = new System.Drawing.Size(120, 20);
            this.tb_type.TabIndex = 18;
            // 
            // lbl_ActivityEndTime
            // 
            this.lbl_ActivityEndTime.AutoSize = true;
            this.lbl_ActivityEndTime.Location = new System.Drawing.Point(12, 64);
            this.lbl_ActivityEndTime.Name = "lbl_ActivityEndTime";
            this.lbl_ActivityEndTime.Size = new System.Drawing.Size(55, 13);
            this.lbl_ActivityEndTime.TabIndex = 17;
            this.lbl_ActivityEndTime.Text = "End Time:";
            // 
            // lbl_ActivityBeginTime
            // 
            this.lbl_ActivityBeginTime.AutoSize = true;
            this.lbl_ActivityBeginTime.Location = new System.Drawing.Point(12, 32);
            this.lbl_ActivityBeginTime.Name = "lbl_ActivityBeginTime";
            this.lbl_ActivityBeginTime.Size = new System.Drawing.Size(63, 13);
            this.lbl_ActivityBeginTime.TabIndex = 16;
            this.lbl_ActivityBeginTime.Text = "Begin Time:";
            // 
            // dtp_ActivityEndDate
            // 
            this.dtp_ActivityEndDate.Location = new System.Drawing.Point(101, 58);
            this.dtp_ActivityEndDate.Name = "dtp_ActivityEndDate";
            this.dtp_ActivityEndDate.Size = new System.Drawing.Size(120, 20);
            this.dtp_ActivityEndDate.TabIndex = 13;
            this.dtp_ActivityEndDate.Value = new System.DateTime(2021, 3, 24, 20, 51, 48, 0);
            // 
            // dtp_ActivityBeginDate
            // 
            this.dtp_ActivityBeginDate.Location = new System.Drawing.Point(101, 26);
            this.dtp_ActivityBeginDate.Name = "dtp_ActivityBeginDate";
            this.dtp_ActivityBeginDate.Size = new System.Drawing.Size(120, 20);
            this.dtp_ActivityBeginDate.TabIndex = 12;
            this.dtp_ActivityBeginDate.Value = new System.DateTime(2021, 3, 24, 20, 51, 48, 0);
            // 
            // AddActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 178);
            this.Controls.Add(this.btn_AddChange);
            this.Controls.Add(this.dtp_ActivityEndTime);
            this.Controls.Add(this.dtp_ActivityBeginTime);
            this.Controls.Add(this.lbl_ActivityName);
            this.Controls.Add(this.tb_type);
            this.Controls.Add(this.lbl_ActivityEndTime);
            this.Controls.Add(this.lbl_ActivityBeginTime);
            this.Controls.Add(this.dtp_ActivityEndDate);
            this.Controls.Add(this.dtp_ActivityBeginDate);
            this.Name = "AddActivity";
            this.Text = "AddActivity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_AddChange;
        private System.Windows.Forms.DateTimePicker dtp_ActivityEndTime;
        private System.Windows.Forms.DateTimePicker dtp_ActivityBeginTime;
        private System.Windows.Forms.Label lbl_ActivityName;
        private System.Windows.Forms.TextBox tb_type;
        private System.Windows.Forms.Label lbl_ActivityEndTime;
        private System.Windows.Forms.Label lbl_ActivityBeginTime;
        private System.Windows.Forms.DateTimePicker dtp_ActivityEndDate;
        private System.Windows.Forms.DateTimePicker dtp_ActivityBeginDate;
    }
}