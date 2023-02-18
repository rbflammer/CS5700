namespace BikeRacerObservers
{
    partial class FileSelector
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
            this.GroupFileTxt = new System.Windows.Forms.TextBox();
            this.GroupBrowseBtn = new System.Windows.Forms.Button();
            this.RacerBrowseBtn = new System.Windows.Forms.Button();
            this.RacerFileTxt = new System.Windows.Forms.TextBox();
            this.SensorBrowseBtn = new System.Windows.Forms.Button();
            this.SensorFileTxt = new System.Windows.Forms.TextBox();
            this.GroupFileLbl = new System.Windows.Forms.Label();
            this.RacerFileLbl = new System.Windows.Forms.Label();
            this.SensorFileLbl = new System.Windows.Forms.Label();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.ErrorLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GroupFileTxt
            // 
            this.GroupFileTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupFileTxt.Location = new System.Drawing.Point(12, 34);
            this.GroupFileTxt.Name = "GroupFileTxt";
            this.GroupFileTxt.Size = new System.Drawing.Size(604, 30);
            this.GroupFileTxt.TabIndex = 0;
            // 
            // GroupBrowseBtn
            // 
            this.GroupBrowseBtn.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBrowseBtn.Location = new System.Drawing.Point(622, 34);
            this.GroupBrowseBtn.Name = "GroupBrowseBtn";
            this.GroupBrowseBtn.Size = new System.Drawing.Size(44, 30);
            this.GroupBrowseBtn.TabIndex = 1;
            this.GroupBrowseBtn.Text = "...";
            this.GroupBrowseBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.GroupBrowseBtn.UseVisualStyleBackColor = true;
            this.GroupBrowseBtn.Click += new System.EventHandler(this.GroupBrowseBtn_Click);
            // 
            // RacerBrowseBtn
            // 
            this.RacerBrowseBtn.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RacerBrowseBtn.Location = new System.Drawing.Point(622, 107);
            this.RacerBrowseBtn.Name = "RacerBrowseBtn";
            this.RacerBrowseBtn.Size = new System.Drawing.Size(44, 30);
            this.RacerBrowseBtn.TabIndex = 3;
            this.RacerBrowseBtn.Text = "...";
            this.RacerBrowseBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RacerBrowseBtn.UseVisualStyleBackColor = true;
            this.RacerBrowseBtn.Click += new System.EventHandler(this.RacerBrowseBtn_Click);
            // 
            // RacerFileTxt
            // 
            this.RacerFileTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RacerFileTxt.Location = new System.Drawing.Point(12, 107);
            this.RacerFileTxt.Name = "RacerFileTxt";
            this.RacerFileTxt.Size = new System.Drawing.Size(604, 30);
            this.RacerFileTxt.TabIndex = 2;
            // 
            // SensorBrowseBtn
            // 
            this.SensorBrowseBtn.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SensorBrowseBtn.Location = new System.Drawing.Point(622, 179);
            this.SensorBrowseBtn.Name = "SensorBrowseBtn";
            this.SensorBrowseBtn.Size = new System.Drawing.Size(44, 30);
            this.SensorBrowseBtn.TabIndex = 5;
            this.SensorBrowseBtn.Text = "...";
            this.SensorBrowseBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SensorBrowseBtn.UseVisualStyleBackColor = true;
            this.SensorBrowseBtn.Click += new System.EventHandler(this.SensorBrowseBtn_Click);
            // 
            // SensorFileTxt
            // 
            this.SensorFileTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SensorFileTxt.Location = new System.Drawing.Point(12, 179);
            this.SensorFileTxt.Name = "SensorFileTxt";
            this.SensorFileTxt.Size = new System.Drawing.Size(604, 30);
            this.SensorFileTxt.TabIndex = 4;
            // 
            // GroupFileLbl
            // 
            this.GroupFileLbl.AutoSize = true;
            this.GroupFileLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupFileLbl.Location = new System.Drawing.Point(12, 11);
            this.GroupFileLbl.Name = "GroupFileLbl";
            this.GroupFileLbl.Size = new System.Drawing.Size(92, 20);
            this.GroupFileLbl.TabIndex = 6;
            this.GroupFileLbl.Text = "Group File:";
            // 
            // RacerFileLbl
            // 
            this.RacerFileLbl.AutoSize = true;
            this.RacerFileLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RacerFileLbl.Location = new System.Drawing.Point(12, 84);
            this.RacerFileLbl.Name = "RacerFileLbl";
            this.RacerFileLbl.Size = new System.Drawing.Size(91, 20);
            this.RacerFileLbl.TabIndex = 7;
            this.RacerFileLbl.Text = "Racer File:";
            // 
            // SensorFileLbl
            // 
            this.SensorFileLbl.AutoSize = true;
            this.SensorFileLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SensorFileLbl.Location = new System.Drawing.Point(12, 156);
            this.SensorFileLbl.Name = "SensorFileLbl";
            this.SensorFileLbl.Size = new System.Drawing.Size(99, 20);
            this.SensorFileLbl.TabIndex = 8;
            this.SensorFileLbl.Text = "Sensor File:";
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitBtn.Location = new System.Drawing.Point(506, 239);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(110, 51);
            this.SubmitBtn.TabIndex = 9;
            this.SubmitBtn.Text = "Submit";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // ErrorLbl
            // 
            this.ErrorLbl.AutoSize = true;
            this.ErrorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLbl.ForeColor = System.Drawing.Color.Red;
            this.ErrorLbl.Location = new System.Drawing.Point(13, 239);
            this.ErrorLbl.Name = "ErrorLbl";
            this.ErrorLbl.Size = new System.Drawing.Size(0, 20);
            this.ErrorLbl.TabIndex = 10;
            // 
            // FileSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 302);
            this.Controls.Add(this.ErrorLbl);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.SensorFileLbl);
            this.Controls.Add(this.RacerFileLbl);
            this.Controls.Add(this.GroupFileLbl);
            this.Controls.Add(this.SensorBrowseBtn);
            this.Controls.Add(this.SensorFileTxt);
            this.Controls.Add(this.RacerBrowseBtn);
            this.Controls.Add(this.RacerFileTxt);
            this.Controls.Add(this.GroupBrowseBtn);
            this.Controls.Add(this.GroupFileTxt);
            this.Name = "FileSelector";
            this.Text = "File Selector";
            this.Load += new System.EventHandler(this.FileSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox GroupFileTxt;
        private System.Windows.Forms.Button GroupBrowseBtn;
        private System.Windows.Forms.Button RacerBrowseBtn;
        private System.Windows.Forms.TextBox RacerFileTxt;
        private System.Windows.Forms.Button SensorBrowseBtn;
        private System.Windows.Forms.TextBox SensorFileTxt;
        private System.Windows.Forms.Label GroupFileLbl;
        private System.Windows.Forms.Label RacerFileLbl;
        private System.Windows.Forms.Label SensorFileLbl;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Label ErrorLbl;
    }
}