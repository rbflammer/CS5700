namespace BikeRacerObservers
{
    partial class ObserverSetup
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
            this.UnobservedRacersListView = new System.Windows.Forms.ListView();
            this.bib = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.racer_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ObservedRacersListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SubscribeBtn = new System.Windows.Forms.Button();
            this.UnsubscribeBtn = new System.Windows.Forms.Button();
            this.OtherRacersLbl = new System.Windows.Forms.Label();
            this.ObservedRacersLbl = new System.Windows.Forms.Label();
            this.ObserversOfRacersLbl = new System.Windows.Forms.Label();
            this.ObserversOfRacersListView = new System.Windows.Forms.ListView();
            this.CreateRacerObserverBtn = new System.Windows.Forms.Button();
            this.CreateCheaterObserverBtn = new System.Windows.Forms.Button();
            this.CheaterObserverListView = new System.Windows.Forms.ListView();
            this.ObserversOfCheatersLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UnobservedRacersListView
            // 
            this.UnobservedRacersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.bib,
            this.racer_name});
            this.UnobservedRacersListView.FullRowSelect = true;
            this.UnobservedRacersListView.HideSelection = false;
            this.UnobservedRacersListView.Location = new System.Drawing.Point(602, 34);
            this.UnobservedRacersListView.Name = "UnobservedRacersListView";
            this.UnobservedRacersListView.Size = new System.Drawing.Size(250, 472);
            this.UnobservedRacersListView.TabIndex = 0;
            this.UnobservedRacersListView.UseCompatibleStateImageBehavior = false;
            this.UnobservedRacersListView.View = System.Windows.Forms.View.Details;
            this.UnobservedRacersListView.SelectedIndexChanged += new System.EventHandler(this.UnobservedRacersListView_SelectedIndexChanged);
            // 
            // bib
            // 
            this.bib.Tag = "";
            this.bib.Text = "Bib #";
            // 
            // racer_name
            // 
            this.racer_name.Tag = "";
            this.racer_name.Text = "Racer Name";
            this.racer_name.Width = 190;
            // 
            // ObservedRacersListView
            // 
            this.ObservedRacersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.ObservedRacersListView.FullRowSelect = true;
            this.ObservedRacersListView.HideSelection = false;
            this.ObservedRacersListView.Location = new System.Drawing.Point(282, 34);
            this.ObservedRacersListView.Name = "ObservedRacersListView";
            this.ObservedRacersListView.Size = new System.Drawing.Size(250, 472);
            this.ObservedRacersListView.TabIndex = 1;
            this.ObservedRacersListView.UseCompatibleStateImageBehavior = false;
            this.ObservedRacersListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "";
            this.columnHeader1.Text = "Bib #";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "";
            this.columnHeader2.Text = "Racer Name";
            this.columnHeader2.Width = 190;
            // 
            // SubscribeBtn
            // 
            this.SubscribeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubscribeBtn.Location = new System.Drawing.Point(538, 180);
            this.SubscribeBtn.Name = "SubscribeBtn";
            this.SubscribeBtn.Size = new System.Drawing.Size(58, 35);
            this.SubscribeBtn.TabIndex = 2;
            this.SubscribeBtn.Text = "<";
            this.SubscribeBtn.UseVisualStyleBackColor = true;
            this.SubscribeBtn.Click += new System.EventHandler(this.SubscribeBtn_Click);
            // 
            // UnsubscribeBtn
            // 
            this.UnsubscribeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnsubscribeBtn.Location = new System.Drawing.Point(538, 250);
            this.UnsubscribeBtn.Name = "UnsubscribeBtn";
            this.UnsubscribeBtn.Size = new System.Drawing.Size(58, 35);
            this.UnsubscribeBtn.TabIndex = 3;
            this.UnsubscribeBtn.Text = ">";
            this.UnsubscribeBtn.UseVisualStyleBackColor = true;
            this.UnsubscribeBtn.Click += new System.EventHandler(this.UnsubscribeBtn_Click);
            // 
            // OtherRacersLbl
            // 
            this.OtherRacersLbl.AutoSize = true;
            this.OtherRacersLbl.Location = new System.Drawing.Point(599, 15);
            this.OtherRacersLbl.Name = "OtherRacersLbl";
            this.OtherRacersLbl.Size = new System.Drawing.Size(89, 16);
            this.OtherRacersLbl.TabIndex = 4;
            this.OtherRacersLbl.Text = "Other Racers:";
            // 
            // ObservedRacersLbl
            // 
            this.ObservedRacersLbl.AutoSize = true;
            this.ObservedRacersLbl.Location = new System.Drawing.Point(279, 15);
            this.ObservedRacersLbl.Name = "ObservedRacersLbl";
            this.ObservedRacersLbl.Size = new System.Drawing.Size(117, 16);
            this.ObservedRacersLbl.TabIndex = 5;
            this.ObservedRacersLbl.Text = "Observed Racers:";
            // 
            // ObserversOfRacersLbl
            // 
            this.ObserversOfRacersLbl.AutoSize = true;
            this.ObserversOfRacersLbl.Location = new System.Drawing.Point(9, 15);
            this.ObserversOfRacersLbl.Name = "ObserversOfRacersLbl";
            this.ObserversOfRacersLbl.Size = new System.Drawing.Size(134, 16);
            this.ObserversOfRacersLbl.TabIndex = 6;
            this.ObserversOfRacersLbl.Text = "Observers of Racers:";
            // 
            // ObserversOfRacersListView
            // 
            this.ObserversOfRacersListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObserversOfRacersListView.HideSelection = false;
            this.ObserversOfRacersListView.Location = new System.Drawing.Point(12, 34);
            this.ObserversOfRacersListView.MultiSelect = false;
            this.ObserversOfRacersListView.Name = "ObserversOfRacersListView";
            this.ObserversOfRacersListView.Size = new System.Drawing.Size(242, 181);
            this.ObserversOfRacersListView.TabIndex = 7;
            this.ObserversOfRacersListView.UseCompatibleStateImageBehavior = false;
            this.ObserversOfRacersListView.View = System.Windows.Forms.View.List;
            this.ObserversOfRacersListView.SelectedIndexChanged += new System.EventHandler(this.ObserversOfRacersListView_SelectedIndexChanged);
            this.ObserversOfRacersListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ObserversOfRacersListView_MouseClick);
            // 
            // CreateRacerObserverBtn
            // 
            this.CreateRacerObserverBtn.Location = new System.Drawing.Point(12, 221);
            this.CreateRacerObserverBtn.Name = "CreateRacerObserverBtn";
            this.CreateRacerObserverBtn.Size = new System.Drawing.Size(75, 40);
            this.CreateRacerObserverBtn.TabIndex = 8;
            this.CreateRacerObserverBtn.Text = "Create";
            this.CreateRacerObserverBtn.UseVisualStyleBackColor = true;
            this.CreateRacerObserverBtn.Click += new System.EventHandler(this.CreateRacerObserverBtn_Click);
            // 
            // CreateCheaterObserverBtn
            // 
            this.CreateCheaterObserverBtn.Location = new System.Drawing.Point(12, 466);
            this.CreateCheaterObserverBtn.Name = "CreateCheaterObserverBtn";
            this.CreateCheaterObserverBtn.Size = new System.Drawing.Size(75, 40);
            this.CreateCheaterObserverBtn.TabIndex = 11;
            this.CreateCheaterObserverBtn.Text = "Create";
            this.CreateCheaterObserverBtn.UseVisualStyleBackColor = true;
            this.CreateCheaterObserverBtn.Click += new System.EventHandler(this.CreateCheaterObserverBtn_Click);
            // 
            // CheaterObserverListView
            // 
            this.CheaterObserverListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheaterObserverListView.FullRowSelect = true;
            this.CheaterObserverListView.HideSelection = false;
            this.CheaterObserverListView.Location = new System.Drawing.Point(12, 279);
            this.CheaterObserverListView.MultiSelect = false;
            this.CheaterObserverListView.Name = "CheaterObserverListView";
            this.CheaterObserverListView.Size = new System.Drawing.Size(242, 181);
            this.CheaterObserverListView.TabIndex = 10;
            this.CheaterObserverListView.UseCompatibleStateImageBehavior = false;
            this.CheaterObserverListView.View = System.Windows.Forms.View.List;
            this.CheaterObserverListView.SelectedIndexChanged += new System.EventHandler(this.CheaterObserverListView_SelectedIndexChanged);
            this.CheaterObserverListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CheaterObserverListView_MouseClick);
            // 
            // ObserversOfCheatersLbl
            // 
            this.ObserversOfCheatersLbl.AutoSize = true;
            this.ObserversOfCheatersLbl.Location = new System.Drawing.Point(9, 260);
            this.ObserversOfCheatersLbl.Name = "ObserversOfCheatersLbl";
            this.ObserversOfCheatersLbl.Size = new System.Drawing.Size(144, 16);
            this.ObserversOfCheatersLbl.TabIndex = 9;
            this.ObserversOfCheatersLbl.Text = "Observers of Cheaters:";
            // 
            // ObserverSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 523);
            this.Controls.Add(this.CreateCheaterObserverBtn);
            this.Controls.Add(this.CheaterObserverListView);
            this.Controls.Add(this.ObserversOfCheatersLbl);
            this.Controls.Add(this.CreateRacerObserverBtn);
            this.Controls.Add(this.ObserversOfRacersListView);
            this.Controls.Add(this.ObserversOfRacersLbl);
            this.Controls.Add(this.ObservedRacersLbl);
            this.Controls.Add(this.OtherRacersLbl);
            this.Controls.Add(this.UnsubscribeBtn);
            this.Controls.Add(this.SubscribeBtn);
            this.Controls.Add(this.ObservedRacersListView);
            this.Controls.Add(this.UnobservedRacersListView);
            this.Name = "ObserverSetup";
            this.Text = "Observer Setup";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ObserverSetup_FormClosed);
            this.Load += new System.EventHandler(this.ObserverSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView UnobservedRacersListView;
        private System.Windows.Forms.ColumnHeader bib;
        private System.Windows.Forms.ColumnHeader racer_name;
        private System.Windows.Forms.ListView ObservedRacersListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button SubscribeBtn;
        private System.Windows.Forms.Button UnsubscribeBtn;
        private System.Windows.Forms.Label OtherRacersLbl;
        private System.Windows.Forms.Label ObservedRacersLbl;
        private System.Windows.Forms.Label ObserversOfRacersLbl;
        private System.Windows.Forms.ListView ObserversOfRacersListView;
        private System.Windows.Forms.Button CreateRacerObserverBtn;
        private System.Windows.Forms.Button CreateCheaterObserverBtn;
        private System.Windows.Forms.ListView CheaterObserverListView;
        private System.Windows.Forms.Label ObserversOfCheatersLbl;
    }
}

