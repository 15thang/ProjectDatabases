
namespace SomerenUI
{
    partial class ChangeActivity
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
            this.dtp_ActivityBeginDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_ActivityEndDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_IDtxt = new System.Windows.Forms.Label();
            this.lbl_ActivityID = new System.Windows.Forms.Label();
            this.lbl_ActivityBeginTime = new System.Windows.Forms.Label();
            this.lbl_ActivityEndTime = new System.Windows.Forms.Label();
            this.tb_type = new System.Windows.Forms.TextBox();
            this.lbl_ActivityName = new System.Windows.Forms.Label();
            this.dtp_ActivityBeginTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_ActivityEndTime = new System.Windows.Forms.DateTimePicker();
            this.btn_ActivityChange = new System.Windows.Forms.Button();
            this.btn_ActivityDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtp_ActivityBeginDate
            // 
            this.dtp_ActivityBeginDate.Location = new System.Drawing.Point(101, 54);
            this.dtp_ActivityBeginDate.Name = "dtp_ActivityBeginDate";
            this.dtp_ActivityBeginDate.Size = new System.Drawing.Size(120, 20);
            this.dtp_ActivityBeginDate.TabIndex = 0;
            this.dtp_ActivityBeginDate.Value = new System.DateTime(2021, 3, 24, 20, 51, 48, 0);
            // 
            // dtp_ActivityEndDate
            // 
            this.dtp_ActivityEndDate.Location = new System.Drawing.Point(101, 86);
            this.dtp_ActivityEndDate.Name = "dtp_ActivityEndDate";
            this.dtp_ActivityEndDate.Size = new System.Drawing.Size(120, 20);
            this.dtp_ActivityEndDate.TabIndex = 1;
            this.dtp_ActivityEndDate.Value = new System.DateTime(2021, 3, 24, 20, 51, 48, 0);
            // 
            // lbl_IDtxt
            // 
            this.lbl_IDtxt.AutoSize = true;
            this.lbl_IDtxt.Location = new System.Drawing.Point(12, 28);
            this.lbl_IDtxt.Name = "lbl_IDtxt";
            this.lbl_IDtxt.Size = new System.Drawing.Size(58, 13);
            this.lbl_IDtxt.TabIndex = 2;
            this.lbl_IDtxt.Text = "ActivityID: ";
            // 
            // lbl_ActivityID
            // 
            this.lbl_ActivityID.AutoSize = true;
            this.lbl_ActivityID.Location = new System.Drawing.Point(98, 28);
            this.lbl_ActivityID.Name = "lbl_ActivityID";
            this.lbl_ActivityID.Size = new System.Drawing.Size(162, 13);
            this.lbl_ActivityID.TabIndex = 3;
            this.lbl_ActivityID.Text = "You are not supposed to see this";
            // 
            // lbl_ActivityBeginTime
            // 
            this.lbl_ActivityBeginTime.AutoSize = true;
            this.lbl_ActivityBeginTime.Location = new System.Drawing.Point(12, 60);
            this.lbl_ActivityBeginTime.Name = "lbl_ActivityBeginTime";
            this.lbl_ActivityBeginTime.Size = new System.Drawing.Size(63, 13);
            this.lbl_ActivityBeginTime.TabIndex = 4;
            this.lbl_ActivityBeginTime.Text = "Begin Time:";
            // 
            // lbl_ActivityEndTime
            // 
            this.lbl_ActivityEndTime.AutoSize = true;
            this.lbl_ActivityEndTime.Location = new System.Drawing.Point(12, 92);
            this.lbl_ActivityEndTime.Name = "lbl_ActivityEndTime";
            this.lbl_ActivityEndTime.Size = new System.Drawing.Size(55, 13);
            this.lbl_ActivityEndTime.TabIndex = 5;
            this.lbl_ActivityEndTime.Text = "End Time:";
            // 
            // tb_type
            // 
            this.tb_type.Location = new System.Drawing.Point(101, 121);
            this.tb_type.Name = "tb_type";
            this.tb_type.Size = new System.Drawing.Size(120, 20);
            this.tb_type.TabIndex = 6;
            // 
            // lbl_ActivityName
            // 
            this.lbl_ActivityName.AutoSize = true;
            this.lbl_ActivityName.Location = new System.Drawing.Point(12, 124);
            this.lbl_ActivityName.Name = "lbl_ActivityName";
            this.lbl_ActivityName.Size = new System.Drawing.Size(75, 13);
            this.lbl_ActivityName.TabIndex = 7;
            this.lbl_ActivityName.Text = "Activity Name:";
            // 
            // dtp_ActivityBeginTime
            // 
            this.dtp_ActivityBeginTime.Location = new System.Drawing.Point(227, 54);
            this.dtp_ActivityBeginTime.Name = "dtp_ActivityBeginTime";
            this.dtp_ActivityBeginTime.Size = new System.Drawing.Size(88, 20);
            this.dtp_ActivityBeginTime.TabIndex = 8;
            // 
            // dtp_ActivityEndTime
            // 
            this.dtp_ActivityEndTime.Location = new System.Drawing.Point(227, 86);
            this.dtp_ActivityEndTime.Name = "dtp_ActivityEndTime";
            this.dtp_ActivityEndTime.Size = new System.Drawing.Size(88, 20);
            this.dtp_ActivityEndTime.TabIndex = 9;
            // 
            // btn_ActivityChange
            // 
            this.btn_ActivityChange.Location = new System.Drawing.Point(15, 166);
            this.btn_ActivityChange.Name = "btn_ActivityChange";
            this.btn_ActivityChange.Size = new System.Drawing.Size(102, 23);
            this.btn_ActivityChange.TabIndex = 10;
            this.btn_ActivityChange.Text = "Change Activity";
            this.btn_ActivityChange.UseVisualStyleBackColor = true;
            this.btn_ActivityChange.Click += new System.EventHandler(this.btn_ActivityChange_Click);
            // 
            // btn_ActivityDelete
            // 
            this.btn_ActivityDelete.Location = new System.Drawing.Point(123, 166);
            this.btn_ActivityDelete.Name = "btn_ActivityDelete";
            this.btn_ActivityDelete.Size = new System.Drawing.Size(102, 23);
            this.btn_ActivityDelete.TabIndex = 11;
            this.btn_ActivityDelete.Text = "Delete Activity";
            this.btn_ActivityDelete.UseVisualStyleBackColor = true;
            this.btn_ActivityDelete.Click += new System.EventHandler(this.btn_ActivityDelete_Click);
            // 
            // ChangeActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 228);
            this.Controls.Add(this.btn_ActivityDelete);
            this.Controls.Add(this.btn_ActivityChange);
            this.Controls.Add(this.dtp_ActivityEndTime);
            this.Controls.Add(this.dtp_ActivityBeginTime);
            this.Controls.Add(this.lbl_ActivityName);
            this.Controls.Add(this.tb_type);
            this.Controls.Add(this.lbl_ActivityEndTime);
            this.Controls.Add(this.lbl_ActivityBeginTime);
            this.Controls.Add(this.lbl_ActivityID);
            this.Controls.Add(this.lbl_IDtxt);
            this.Controls.Add(this.dtp_ActivityEndDate);
            this.Controls.Add(this.dtp_ActivityBeginDate);
            this.Name = "ChangeActivity";
            this.Text = "ChangeActivity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_ActivityBeginDate;
        private System.Windows.Forms.DateTimePicker dtp_ActivityEndDate;
        private System.Windows.Forms.Label lbl_IDtxt;
        private System.Windows.Forms.Label lbl_ActivityID;
        private System.Windows.Forms.Label lbl_ActivityBeginTime;
        private System.Windows.Forms.Label lbl_ActivityEndTime;
        private System.Windows.Forms.TextBox tb_type;
        private System.Windows.Forms.Label lbl_ActivityName;
        private System.Windows.Forms.DateTimePicker dtp_ActivityBeginTime;
        private System.Windows.Forms.DateTimePicker dtp_ActivityEndTime;
        private System.Windows.Forms.Button btn_ActivityChange;
        private System.Windows.Forms.Button btn_ActivityDelete;
    }
}