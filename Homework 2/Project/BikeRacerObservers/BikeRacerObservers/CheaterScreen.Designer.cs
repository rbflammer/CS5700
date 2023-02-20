namespace BikeRacerObservers
{
    partial class CheaterScreen
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
            this.CheatersListView = new System.Windows.Forms.ListView();
            this.BibNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RacerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastSensor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CheatingWithListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RacersLbl = new System.Windows.Forms.Label();
            this.AreCheatingWithLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CheatersListView
            // 
            this.CheatersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BibNumber,
            this.RacerName,
            this.LastSensor,
            this.Time});
            this.CheatersListView.HideSelection = false;
            this.CheatersListView.Location = new System.Drawing.Point(12, 32);
            this.CheatersListView.Name = "CheatersListView";
            this.CheatersListView.Size = new System.Drawing.Size(562, 426);
            this.CheatersListView.TabIndex = 1;
            this.CheatersListView.UseCompatibleStateImageBehavior = false;
            this.CheatersListView.View = System.Windows.Forms.View.Details;
            // 
            // BibNumber
            // 
            this.BibNumber.Text = "Bib #";
            // 
            // RacerName
            // 
            this.RacerName.Text = "Name";
            this.RacerName.Width = 150;
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
            // CheatingWithListView
            // 
            this.CheatingWithListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.CheatingWithListView.HideSelection = false;
            this.CheatingWithListView.Location = new System.Drawing.Point(617, 32);
            this.CheatingWithListView.Name = "CheatingWithListView";
            this.CheatingWithListView.Size = new System.Drawing.Size(526, 426);
            this.CheatingWithListView.TabIndex = 2;
            this.CheatingWithListView.UseCompatibleStateImageBehavior = false;
            this.CheatingWithListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Bib #";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last Sensor";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Time";
            this.columnHeader4.Width = 120;
            // 
            // RacersLbl
            // 
            this.RacersLbl.AutoSize = true;
            this.RacersLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RacersLbl.Location = new System.Drawing.Point(12, 9);
            this.RacersLbl.Name = "RacersLbl";
            this.RacersLbl.Size = new System.Drawing.Size(68, 20);
            this.RacersLbl.TabIndex = 3;
            this.RacersLbl.Text = "Racers:";
            // 
            // AreCheatingWithLbl
            // 
            this.AreCheatingWithLbl.AutoSize = true;
            this.AreCheatingWithLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AreCheatingWithLbl.Location = new System.Drawing.Point(613, 9);
            this.AreCheatingWithLbl.Name = "AreCheatingWithLbl";
            this.AreCheatingWithLbl.Size = new System.Drawing.Size(150, 20);
            this.AreCheatingWithLbl.TabIndex = 4;
            this.AreCheatingWithLbl.Text = "Are Cheating WIth:";
            // 
            // CheaterScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 482);
            this.Controls.Add(this.AreCheatingWithLbl);
            this.Controls.Add(this.RacersLbl);
            this.Controls.Add(this.CheatingWithListView);
            this.Controls.Add(this.CheatersListView);
            this.Name = "CheaterScreen";
            this.Text = "CheaterDisplay";
            this.Load += new System.EventHandler(this.CheaterDisplay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView CheatersListView;
        private System.Windows.Forms.ColumnHeader BibNumber;
        private System.Windows.Forms.ColumnHeader RacerName;
        private System.Windows.Forms.ColumnHeader LastSensor;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ListView CheatingWithListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label RacersLbl;
        private System.Windows.Forms.Label AreCheatingWithLbl;
    }
}