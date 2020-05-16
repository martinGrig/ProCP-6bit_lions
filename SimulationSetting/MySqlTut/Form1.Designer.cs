namespace MySqlTut
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
            this.lvUsers = new System.Windows.Forms.ListView();
            this.clmID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmResultID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmEndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmWeather = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmHoliday = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDayOfTheWeek = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLoadAll = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.tbResultID = new System.Windows.Forms.TextBox();
            this.tbStartTime = new System.Windows.Forms.TextBox();
            this.tbEndTime = new System.Windows.Forms.TextBox();
            this.tbWeather = new System.Windows.Forms.TextBox();
            this.tbHoliday = new System.Windows.Forms.TextBox();
            this.tbDayOfTheWeek = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvUsers
            // 
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmID,
            this.clmResultID,
            this.clmStartTime,
            this.clmEndTime,
            this.clmWeather,
            this.clmHoliday,
            this.clmDayOfTheWeek});
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.HideSelection = false;
            this.lvUsers.Location = new System.Drawing.Point(11, 15);
            this.lvUsers.Margin = new System.Windows.Forms.Padding(4);
            this.lvUsers.MultiSelect = false;
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(715, 208);
            this.lvUsers.TabIndex = 0;
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
            this.clmResultID.Width = 70;
            // 
            // clmStartTime
            // 
            this.clmStartTime.Text = "StartTime";
            this.clmStartTime.Width = 70;
            // 
            // clmEndTime
            // 
            this.clmEndTime.Text = "EndTime";
            this.clmEndTime.Width = 70;
            // 
            // clmWeather
            // 
            this.clmWeather.Text = "Weather";
            this.clmWeather.Width = 70;
            // 
            // clmHoliday
            // 
            this.clmHoliday.Text = "Holiday";
            this.clmHoliday.Width = 70;
            // 
            // clmDayOfTheWeek
            // 
            this.clmDayOfTheWeek.Text = "DayOfTheWeek";
            this.clmDayOfTheWeek.Width = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 235);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 267);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "ResultID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 299);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "StartTime:";
            // 
            // btnLoadAll
            // 
            this.btnLoadAll.Location = new System.Drawing.Point(20, 402);
            this.btnLoadAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadAll.Name = "btnLoadAll";
            this.btnLoadAll.Size = new System.Drawing.Size(100, 28);
            this.btnLoadAll.TabIndex = 4;
            this.btnLoadAll.Text = "Load all";
            this.btnLoadAll.UseVisualStyleBackColor = true;
            this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(128, 402);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 28);
            this.btnInsert.TabIndex = 5;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(236, 402);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 328);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "EndTime:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(401, 235);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Weather:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(401, 267);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Holiday:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(401, 299);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Day Of The Week:";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(128, 235);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(100, 22);
            this.tbID.TabIndex = 15;
            // 
            // tbResultID
            // 
            this.tbResultID.Location = new System.Drawing.Point(128, 267);
            this.tbResultID.Name = "tbResultID";
            this.tbResultID.Size = new System.Drawing.Size(100, 22);
            this.tbResultID.TabIndex = 16;
            // 
            // tbStartTime
            // 
            this.tbStartTime.Location = new System.Drawing.Point(128, 294);
            this.tbStartTime.Name = "tbStartTime";
            this.tbStartTime.Size = new System.Drawing.Size(100, 22);
            this.tbStartTime.TabIndex = 17;
            // 
            // tbEndTime
            // 
            this.tbEndTime.Location = new System.Drawing.Point(128, 322);
            this.tbEndTime.Name = "tbEndTime";
            this.tbEndTime.Size = new System.Drawing.Size(100, 22);
            this.tbEndTime.TabIndex = 18;
            // 
            // tbWeather
            // 
            this.tbWeather.Location = new System.Drawing.Point(541, 230);
            this.tbWeather.Name = "tbWeather";
            this.tbWeather.Size = new System.Drawing.Size(100, 22);
            this.tbWeather.TabIndex = 19;
            // 
            // tbHoliday
            // 
            this.tbHoliday.Location = new System.Drawing.Point(541, 262);
            this.tbHoliday.Name = "tbHoliday";
            this.tbHoliday.Size = new System.Drawing.Size(100, 22);
            this.tbHoliday.TabIndex = 20;
            // 
            // tbDayOfTheWeek
            // 
            this.tbDayOfTheWeek.Location = new System.Drawing.Point(541, 299);
            this.tbDayOfTheWeek.Name = "tbDayOfTheWeek";
            this.tbDayOfTheWeek.Size = new System.Drawing.Size(100, 22);
            this.tbDayOfTheWeek.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 476);
            this.Controls.Add(this.tbDayOfTheWeek);
            this.Controls.Add(this.tbHoliday);
            this.Controls.Add(this.tbWeather);
            this.Controls.Add(this.tbEndTime);
            this.Controls.Add(this.tbStartTime);
            this.Controls.Add(this.tbResultID);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnLoadAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvUsers);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.ColumnHeader clmID;
        private System.Windows.Forms.ColumnHeader clmResultID;
        private System.Windows.Forms.ColumnHeader clmStartTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLoadAll;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ColumnHeader clmEndTime;
        private System.Windows.Forms.ColumnHeader clmWeather;
        private System.Windows.Forms.ColumnHeader clmHoliday;
        private System.Windows.Forms.ColumnHeader clmDayOfTheWeek;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.TextBox tbResultID;
        private System.Windows.Forms.TextBox tbStartTime;
        private System.Windows.Forms.TextBox tbEndTime;
        private System.Windows.Forms.TextBox tbWeather;
        private System.Windows.Forms.TextBox tbHoliday;
        private System.Windows.Forms.TextBox tbDayOfTheWeek;
    }
}

