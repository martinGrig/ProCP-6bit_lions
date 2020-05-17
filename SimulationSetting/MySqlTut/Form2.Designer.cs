namespace MySqlTut
{
    partial class Form2
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
            this.clmResultID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmShopID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmIncome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmVisits = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblResultID = new System.Windows.Forms.Label();
            this.lblShopID = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblIncome = new System.Windows.Forms.Label();
            this.lblVisits = new System.Windows.Forms.Label();
            this.tbShopID = new System.Windows.Forms.TextBox();
            this.tbResultID = new System.Windows.Forms.TextBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.tbIncome = new System.Windows.Forms.TextBox();
            this.tbVisits = new System.Windows.Forms.TextBox();
            this.btnLoadAll = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvUsers
            // 
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmID,
            this.clmResultID,
            this.clmShopID,
            this.clmIncome,
            this.clmVisits});
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.HideSelection = false;
            this.lvUsers.Location = new System.Drawing.Point(13, 13);
            this.lvUsers.Margin = new System.Windows.Forms.Padding(4);
            this.lvUsers.MultiSelect = false;
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(715, 208);
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
            // clmResultID
            // 
            this.clmResultID.Text = "ResultID";
            this.clmResultID.Width = 65;
            // 
            // clmShopID
            // 
            this.clmShopID.Text = "ShopID";
            // 
            // clmIncome
            // 
            this.clmIncome.Text = "Income";
            // 
            // clmVisits
            // 
            this.clmVisits.Text = "Visits";
            // 
            // lblResultID
            // 
            this.lblResultID.AutoSize = true;
            this.lblResultID.Location = new System.Drawing.Point(23, 279);
            this.lblResultID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResultID.Name = "lblResultID";
            this.lblResultID.Size = new System.Drawing.Size(65, 17);
            this.lblResultID.TabIndex = 4;
            this.lblResultID.Text = "ResultID:";
            // 
            // lblShopID
            // 
            this.lblShopID.AutoSize = true;
            this.lblShopID.Location = new System.Drawing.Point(23, 313);
            this.lblShopID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShopID.Name = "lblShopID";
            this.lblShopID.Size = new System.Drawing.Size(58, 17);
            this.lblShopID.TabIndex = 5;
            this.lblShopID.Text = "ShopID:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(23, 245);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(25, 17);
            this.lblID.TabIndex = 6;
            this.lblID.Text = "ID:";
            // 
            // lblIncome
            // 
            this.lblIncome.AutoSize = true;
            this.lblIncome.Location = new System.Drawing.Point(390, 245);
            this.lblIncome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.Size = new System.Drawing.Size(57, 17);
            this.lblIncome.TabIndex = 7;
            this.lblIncome.Text = "Income:";
            // 
            // lblVisits
            // 
            this.lblVisits.AutoSize = true;
            this.lblVisits.Location = new System.Drawing.Point(390, 289);
            this.lblVisits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVisits.Name = "lblVisits";
            this.lblVisits.Size = new System.Drawing.Size(45, 17);
            this.lblVisits.TabIndex = 8;
            this.lblVisits.Text = "Visits:";
            // 
            // tbShopID
            // 
            this.tbShopID.Location = new System.Drawing.Point(117, 308);
            this.tbShopID.Name = "tbShopID";
            this.tbShopID.Size = new System.Drawing.Size(100, 22);
            this.tbShopID.TabIndex = 16;
            // 
            // tbResultID
            // 
            this.tbResultID.Location = new System.Drawing.Point(117, 279);
            this.tbResultID.Name = "tbResultID";
            this.tbResultID.Size = new System.Drawing.Size(100, 22);
            this.tbResultID.TabIndex = 17;
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(117, 245);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(100, 22);
            this.tbID.TabIndex = 18;
            // 
            // tbIncome
            // 
            this.tbIncome.Location = new System.Drawing.Point(477, 245);
            this.tbIncome.Name = "tbIncome";
            this.tbIncome.Size = new System.Drawing.Size(100, 22);
            this.tbIncome.TabIndex = 19;
            // 
            // tbVisits
            // 
            this.tbVisits.Location = new System.Drawing.Point(477, 289);
            this.tbVisits.Name = "tbVisits";
            this.tbVisits.Size = new System.Drawing.Size(100, 22);
            this.tbVisits.TabIndex = 20;
            // 
            // btnLoadAll
            // 
            this.btnLoadAll.Location = new System.Drawing.Point(26, 398);
            this.btnLoadAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadAll.Name = "btnLoadAll";
            this.btnLoadAll.Size = new System.Drawing.Size(100, 28);
            this.btnLoadAll.TabIndex = 21;
            this.btnLoadAll.Text = "Load all";
            this.btnLoadAll.UseVisualStyleBackColor = true;
            this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(148, 398);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 28);
            this.btnInsert.TabIndex = 22;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(270, 398);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(393, 398);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 28);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 491);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnLoadAll);
            this.Controls.Add(this.tbVisits);
            this.Controls.Add(this.tbIncome);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.tbResultID);
            this.Controls.Add(this.tbShopID);
            this.Controls.Add(this.lblVisits);
            this.Controls.Add(this.lblIncome);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblShopID);
            this.Controls.Add(this.lblResultID);
            this.Controls.Add(this.lvUsers);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.ColumnHeader clmID;
        private System.Windows.Forms.ColumnHeader clmResultID;
        private System.Windows.Forms.ColumnHeader clmShopID;
        private System.Windows.Forms.ColumnHeader clmIncome;
        private System.Windows.Forms.ColumnHeader clmVisits;
        private System.Windows.Forms.Label lblResultID;
        private System.Windows.Forms.Label lblShopID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblIncome;
        private System.Windows.Forms.Label lblVisits;
        private System.Windows.Forms.TextBox tbShopID;
        private System.Windows.Forms.TextBox tbResultID;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.TextBox tbIncome;
        private System.Windows.Forms.TextBox tbVisits;
        private System.Windows.Forms.Button btnLoadAll;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
    }
}