using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlTut
{
    public partial class Form2 : Form
    {
        private Result currResult;
        public Form2()
        {
            InitializeComponent();
            Result.InitializeDB();
            this.Text = "Shop Results";
        }
        private void LoadAll()
        {
            List<Result> results = Result.GetResults();

            lvUsers.Items.Clear();

            foreach (Result r in results)
            {

                ListViewItem item = new ListViewItem(new String[] { r.ID.ToString(), r.ResultID.ToString(), r.ShopID.ToString(), r.Income.ToString(), r.Visits.ToString() });
                item.Tag = r;

                lvUsers.Items.Add(item);

            }
        }
        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            LoadAll();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(tbID.Text);
            int ResultID = Convert.ToInt32(tbResultID.Text);
            int ShopID = Convert.ToInt32(tbShopID.Text);
            double Income = Convert.ToDouble(tbIncome.Text);
            int Visits = Convert.ToInt32(tbVisits.Text);
            if (ID == 0 || ResultID == 0 || ShopID == 0 || Income == 0 || Visits == 0)
            {
                MessageBox.Show("It's empty");
                return;
            }

            currResult = Result.Insert(ID, ResultID, ShopID, Income, Visits);

            LoadAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(tbID.Text);
            if (currResult == null)
            {
                MessageBox.Show("No result selected!");
                return;
            }

            currResult.Delete(ID);

            LoadAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(tbID.Text);
            double Income = Convert.ToDouble(tbIncome.Text);
            int Visits = Convert.ToInt32(tbVisits.Text);

            if (ID == 0 || Income == 0 || Visits == 0)
            {
                MessageBox.Show("It's empty");
                return;
            }


            currResult.Update(ID,Income,Visits);

            LoadAll();
        }

        private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count > 0)
            {
                ListViewItem item = lvUsers.SelectedItems[0];
                currResult = (Result)item.Tag;

                int ID = currResult.ID;
                int ResultID = currResult.ResultID;
                int ShopID = currResult.ShopID;
                double Income = currResult.Income;
                int Visits = currResult.Visits;
                
                tbID.Text = ID.ToString();
                tbResultID.Text = ResultID.ToString();
                tbShopID.Text = ShopID.ToString();
                tbIncome.Text = Income.ToString();
                tbVisits.Text = Visits.ToString();
            }
        }
    }
}
