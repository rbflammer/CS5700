namespace BikeRacerObservers
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UnobservedRacersListView
            // 
            this.UnobservedRacersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.bib,
            this.racer_name});
            this.UnobservedRacersListView.HideSelection = false;
            this.UnobservedRacersListView.Location = new System.Drawing.Point(570, 34);
            this.UnobservedRacersListView.Name = "UnobservedRacersListView";
            this.UnobservedRacersListView.Size = new System.Drawing.Size(218, 472);
            this.UnobservedRacersListView.TabIndex = 0;
            this.UnobservedRacersListView.UseCompatibleStateImageBehavior = false;
            this.UnobservedRacersListView.View = System.Windows.Forms.View.Details;
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
            // 
            // ObservedRacersListView
            // 
            this.ObservedRacersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.ObservedRacersListView.HideSelection = false;
            this.ObservedRacersListView.Location = new System.Drawing.Point(282, 34);
            this.ObservedRacersListView.Name = "ObservedRacersListView";
            this.ObservedRacersListView.Size = new System.Drawing.Size(218, 472);
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
            // 
            // SubscribeBtn
            // 
            this.SubscribeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubscribeBtn.Location = new System.Drawing.Point(506, 180);
            this.SubscribeBtn.Name = "SubscribeBtn";
            this.SubscribeBtn.Size = new System.Drawing.Size(58, 35);
            this.SubscribeBtn.TabIndex = 2;
            this.SubscribeBtn.Text = "<";
            this.SubscribeBtn.UseVisualStyleBackColor = true;
            // 
            // UnsubscribeBtn
            // 
            this.UnsubscribeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnsubscribeBtn.Location = new System.Drawing.Point(506, 248);
            this.UnsubscribeBtn.Name = "UnsubscribeBtn";
            this.UnsubscribeBtn.Size = new System.Drawing.Size(58, 35);
            this.UnsubscribeBtn.TabIndex = 3;
            this.UnsubscribeBtn.Text = ">";
            this.UnsubscribeBtn.UseVisualStyleBackColor = true;
            this.UnsubscribeBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // OtherRacersLbl
            // 
            this.OtherRacersLbl.AutoSize = true;
            this.OtherRacersLbl.Location = new System.Drawing.Point(567, 15);
            this.OtherRacersLbl.Name = "OtherRacersLbl";
            this.OtherRacersLbl.Size = new System.Drawing.Size(89, 16);
            this.OtherRacersLbl.TabIndex = 4;
            this.OtherRacersLbl.Text = "Other Racers:";
            this.OtherRacersLbl.Click += new System.EventHandler(this.OtherRacersLbl_Click);
            // 
            // ObservedRacersLbl
            // 
            this.ObservedRacersLbl.AutoSize = true;
            this.ObservedRacersLbl.Location = new System.Drawing.Point(279, 15);
            this.ObservedRacersLbl.Name = "ObservedRacersLbl";
            this.ObservedRacersLbl.Size = new System.Drawing.Size(117, 16);
            this.ObservedRacersLbl.TabIndex = 5;
            this.ObservedRacersLbl.Text = "Observed Racers:";
            this.ObservedRacersLbl.Click += new System.EventHandler(this.label1_Click);
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
            this.ObserversOfRacersListView.HideSelection = false;
            this.ObserversOfRacersListView.Location = new System.Drawing.Point(12, 34);
            this.ObserversOfRacersListView.Name = "ObserversOfRacersListView";
            this.ObserversOfRacersListView.Size = new System.Drawing.Size(242, 181);
            this.ObserversOfRacersListView.TabIndex = 7;
            this.ObserversOfRacersListView.UseCompatibleStateImageBehavior = false;
            // 
            // CreateRacerObserverBtn
            // 
            this.CreateRacerObserverBtn.Location = new System.Drawing.Point(12, 221);
            this.CreateRacerObserverBtn.Name = "CreateRacerObserverBtn";
            this.CreateRacerObserverBtn.Size = new System.Drawing.Size(75, 40);
            this.CreateRacerObserverBtn.TabIndex = 8;
            this.CreateRacerObserverBtn.Text = "Create";
            this.CreateRacerObserverBtn.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 11;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 279);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(242, 181);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Observers of Racers:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 523);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreateRacerObserverBtn);
            this.Controls.Add(this.ObserversOfRacersListView);
            this.Controls.Add(this.ObserversOfRacersLbl);
            this.Controls.Add(this.ObservedRacersLbl);
            this.Controls.Add(this.OtherRacersLbl);
            this.Controls.Add(this.UnsubscribeBtn);
            this.Controls.Add(this.SubscribeBtn);
            this.Controls.Add(this.ObservedRacersListView);
            this.Controls.Add(this.UnobservedRacersListView);
            this.Name = "Form1";
            this.Text = "Observer Setup";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
    }
}

