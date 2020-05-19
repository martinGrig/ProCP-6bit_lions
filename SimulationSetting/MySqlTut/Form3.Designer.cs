namespace MySqlTut
{
    partial class Form3
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
            this.lvUsers = new System.Windows.Forms.ListView();
            this.clmID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPositionID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCapacity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPopularity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPriceRange = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmBusyHours = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbPopularity = new System.Windows.Forms.TextBox();
            this.tbCapacity = new System.Windows.Forms.TextBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.tbPositionID = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblPopularity = new System.Windows.Forms.Label();
            this.lblIncome = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPositionID = new System.Windows.Forms.Label();
            this.lblPriceRange = new System.Windows.Forms.Label();
            this.tbPriceRange = new System.Windows.Forms.TextBox();
            this.lblBusyHours = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.tbBusyHours = new System.Windows.Forms.TextBox();
            this.tbCategory = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnLoadAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvUsers
            // 
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmID,
            this.clmPositionID,
            this.clmName,
            this.clmCapacity,
            this.clmPopularity,
            this.clmPriceRange,
            this.clmBusyHours,
            this.clmCategory});
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.HideSelection = false;
            this.lvUsers.Location = new System.Drawing.Point(13, 13);
            this.lvUsers.Margin = new System.Windows.Forms.Padding(4);
            this.lvUsers.MultiSelect = false;
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(760, 208);
            this.lvUsers.TabIndex = 1;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            this.lvUsers.SelectedIndexChanged += new System.EventHandler(this.lvUsers_SelectedIndexChanged);
            // 
            // clmID
            // 
            this.clmID.Text = "ID";
            this.clmID.Width = 49;
            // 
            // clmPositionID
            // 
            this.clmPositionID.Text = "PositionID";
            this.clmPositionID.Width = 79;
            // 
            // clmName
            // 
            this.clmName.Text = "Name";
            this.clmName.Width = 70;
            // 
            // clmCapacity
            // 
            this.clmCapacity.Text = "Capacity";
            this.clmCapacity.Width = 70;
            // 
            // clmPopularity
            // 
            this.clmPopularity.Text = "Popularity";
            this.clmPopularity.Width = 80;
            // 
            // clmPriceRange
            // 
            this.clmPriceRange.Text = "PriceRange";
            this.clmPriceRange.Width = 120;
            // 
            // clmBusyHours
            // 
            this.clmBusyHours.Text = "BusyHours";
            this.clmBusyHours.Width = 90;
            // 
            // clmCategory
            // 
            this.clmCategory.Text = "Category";
            this.clmCategory.Width = 87;
            // 
            // tbPopularity
            // 
            this.tbPopularity.Location = new System.Drawing.Point(416, 302);
            this.tbPopularity.Name = "tbPopularity";
            this.tbPopularity.Size = new System.Drawing.Size(100, 22);
            this.tbPopularity.TabIndex = 31;
            // 
            // tbCapacity
            // 
            this.tbCapacity.Location = new System.Drawing.Point(416, 261);
            this.tbCapacity.Name = "tbCapacity";
            this.tbCapacity.Size = new System.Drawing.Size(100, 22);
            this.tbCapacity.TabIndex = 30;
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(102, 256);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(100, 22);
            this.tbID.TabIndex = 29;
            // 
            // tbPositionID
            // 
            this.tbPositionID.Location = new System.Drawing.Point(102, 299);
            this.tbPositionID.Name = "tbPositionID";
            this.tbPositionID.Size = new System.Drawing.Size(100, 22);
            this.tbPositionID.TabIndex = 28;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(102, 340);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 22);
            this.tbName.TabIndex = 27;
            // 
            // lblPopularity
            // 
            this.lblPopularity.AutoSize = true;
            this.lblPopularity.Location = new System.Drawing.Point(302, 302);
            this.lblPopularity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPopularity.Name = "lblPopularity";
            this.lblPopularity.Size = new System.Drawing.Size(75, 17);
            this.lblPopularity.TabIndex = 26;
            this.lblPopularity.Text = "Popularity:";
            // 
            // lblIncome
            // 
            this.lblIncome.AutoSize = true;
            this.lblIncome.Location = new System.Drawing.Point(302, 261);
            this.lblIncome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.Size = new System.Drawing.Size(66, 17);
            this.lblIncome.TabIndex = 25;
            this.lblIncome.Text = "Capacity:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(29, 261);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(25, 17);
            this.lblID.TabIndex = 24;
            this.lblID.Text = "ID:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(29, 348);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 17);
            this.lblName.TabIndex = 23;
            this.lblName.Text = "Name:";
            // 
            // lblPositionID
            // 
            this.lblPositionID.AutoSize = true;
            this.lblPositionID.Location = new System.Drawing.Point(24, 304);
            this.lblPositionID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPositionID.Name = "lblPositionID";
            this.lblPositionID.Size = new System.Drawing.Size(75, 17);
            this.lblPositionID.TabIndex = 22;
            this.lblPositionID.Text = "PositionID:";
            // 
            // lblPriceRange
            // 
            this.lblPriceRange.AutoSize = true;
            this.lblPriceRange.Location = new System.Drawing.Point(302, 340);
            this.lblPriceRange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPriceRange.Name = "lblPriceRange";
            this.lblPriceRange.Size = new System.Drawing.Size(86, 17);
            this.lblPriceRange.TabIndex = 32;
            this.lblPriceRange.Text = "PriceRange:";
            // 
            // tbPriceRange
            // 
            this.tbPriceRange.Location = new System.Drawing.Point(416, 340);
            this.tbPriceRange.Name = "tbPriceRange";
            this.tbPriceRange.Size = new System.Drawing.Size(100, 22);
            this.tbPriceRange.TabIndex = 33;
            // 
            // lblBusyHours
            // 
            this.lblBusyHours.AutoSize = true;
            this.lblBusyHours.Location = new System.Drawing.Point(570, 264);
            this.lblBusyHours.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusyHours.Name = "lblBusyHours";
            this.lblBusyHours.Size = new System.Drawing.Size(81, 17);
            this.lblBusyHours.TabIndex = 34;
            this.lblBusyHours.Text = "BusyHours:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(570, 299);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(69, 17);
            this.lblCategory.TabIndex = 35;
            this.lblCategory.Text = "Category:";
            // 
            // tbBusyHours
            // 
            this.tbBusyHours.Location = new System.Drawing.Point(688, 261);
            this.tbBusyHours.Name = "tbBusyHours";
            this.tbBusyHours.Size = new System.Drawing.Size(100, 22);
            this.tbBusyHours.TabIndex = 36;
            // 
            // tbCategory
            // 
            this.tbCategory.Location = new System.Drawing.Point(688, 299);
            this.tbCategory.Name = "tbCategory";
            this.tbCategory.Size = new System.Drawing.Size(100, 22);
            this.tbCategory.TabIndex = 37;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(487, 397);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 28);
            this.btnUpdate.TabIndex = 41;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(364, 397);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(242, 397);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 28);
            this.btnInsert.TabIndex = 39;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnLoadAll
            // 
            this.btnLoadAll.Location = new System.Drawing.Point(120, 397);
            this.btnLoadAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadAll.Name = "btnLoadAll";
            this.btnLoadAll.Size = new System.Drawing.Size(100, 28);
            this.btnLoadAll.TabIndex = 38;
            this.btnLoadAll.Text = "Load all";
            this.btnLoadAll.UseVisualStyleBackColor = true;
            this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnLoadAll);
            this.Controls.Add(this.tbCategory);
            this.Controls.Add(this.tbBusyHours);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblBusyHours);
            this.Controls.Add(this.tbPriceRange);
            this.Controls.Add(this.lblPriceRange);
            this.Controls.Add(this.tbPopularity);
            this.Controls.Add(this.tbCapacity);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.tbPositionID);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblPopularity);
            this.Controls.Add(this.lblIncome);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblPositionID);
            this.Controls.Add(this.lvUsers);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.ColumnHeader clmID;
        private System.Windows.Forms.ColumnHeader clmPositionID;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmCapacity;
        private System.Windows.Forms.ColumnHeader clmPopularity;
        private System.Windows.Forms.ColumnHeader clmPriceRange;
        private System.Windows.Forms.ColumnHeader clmBusyHours;
        private System.Windows.Forms.ColumnHeader clmCategory;
        private System.Windows.Forms.TextBox tbPopularity;
        private System.Windows.Forms.TextBox tbCapacity;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.TextBox tbPositionID;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblPopularity;
        private System.Windows.Forms.Label lblIncome;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPositionID;
        private System.Windows.Forms.Label lblPriceRange;
        private System.Windows.Forms.TextBox tbPriceRange;
        private System.Windows.Forms.Label lblBusyHours;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox tbBusyHours;
        private System.Windows.Forms.TextBox tbCategory;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnLoadAll;
    }
}