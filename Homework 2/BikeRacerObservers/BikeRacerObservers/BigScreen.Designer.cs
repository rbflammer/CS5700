namespace BikeRacerObservers
{
    partial class BigScreenForm
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
            this.DisplayListView = new System.Windows.Forms.ListView();
            this.BibNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RacerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastSensor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DisplayListView
            // 
            this.DisplayListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BibNumber,
            this.RacerName,
            this.LastSensor,
            this.Time});
            this.DisplayListView.HideSelection = false;
            this.DisplayListView.Location = new System.Drawing.Point(12, 12);
            this.DisplayListView.Name = "DisplayListView";
            this.DisplayListView.Size = new System.Drawing.Size(776, 426);
            this.DisplayListView.TabIndex = 0;
            this.DisplayListView.UseCompatibleStateImageBehavior = false;
            this.DisplayListView.View = System.Windows.Forms.View.Details;
            // 
            // BibNumber
            // 
            this.BibNumber.Text = "Bib #";
            // 
            // RacerName
            // 
            this.RacerName.Text = "Name";
            this.RacerName.Width = 300;
            // 
            // LastSensor
            // 
            this.LastSensor.Text = "Last Sensor";
            this.LastSensor.Width = 90;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 120;
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshBtn.Location = new System.Drawing.Point(365, 444);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(105, 41);
            this.RefreshBtn.TabIndex = 1;
            this.RefreshBtn.Text = "Refresh";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // BigScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 497);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.DisplayListView);
            this.Name = "BigScreenForm";
            this.Text = "Big Screen";
            this.Load += new System.EventHandler(this.BigScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView DisplayListView;
        private System.Windows.Forms.ColumnHeader BibNumber;
        private System.Windows.Forms.ColumnHeader RacerName;
        private System.Windows.Forms.ColumnHeader LastSensor;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.Button RefreshBtn;
    }
}