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
    public partial class Form3 : Form
    {
        private Shop currShop;
        public Form3()
        {
            InitializeComponent();
            Shop.InitializeDB();
            this.Text = "Shops";
        }
        private void LoadAll()
        {
            List<Shop> shops = Shop.GetShops();

            lvUsers.Items.Clear();

            foreach (Shop s in shops)
            {

                ListViewItem item = new ListViewItem(new String[] { s.ID.ToString(), s.PositionID.ToString(), s.Name, s.Capacity.ToString(), s.Popularity.ToString(), s.PriceRange.ToString(), s.BusyHours.ToString(), s.Category.ToString() });
                item.Tag = s;

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
            int PositionID = Convert.ToInt32(tbPositionID.Text);
            string Name = (tbName.Text);
            int Capacity = Convert.ToInt32(tbCapacity.Text);
            double Popularity = Convert.ToDouble(tbPopularity.Text);
            double PriceRange = Convert.ToDouble(tbPriceRange.Text);
            string BusyHours = tbBusyHours.Text;
            string Category = tbCategory.Text;
            if (ID == 0 || PositionID == 0 || String.IsNullOrEmpty(Name) || Capacity == 0 || Popularity == 0 || PriceRange == 0 || String.IsNullOrEmpty(BusyHours) || String.IsNullOrEmpty(Category))
            {
                MessageBox.Show("It's empty");
                return;
            }

            currShop = Shop.Insert( ID,  PositionID,  Name,  Capacity,  Popularity,  PriceRange,  BusyHours, Category);

            LoadAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(tbID.Text);
            if (currShop == null)
            {
                MessageBox.Show("No shop selected!");
                return;
            }

            currShop.Delete(ID);

            LoadAll();
        }

        private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count > 0)
            {
                ListViewItem item = lvUsers.SelectedItems[0];
                currShop = (Shop)item.Tag;

                int ID = currShop.ID;
                int PositionID = currShop.PositionID;
                string Name = currShop.Name;
                int Capacity = currShop.Capacity;
                double Popularity = currShop.Popularity;
                double PriceRange = currShop.PriceRange;
                string BusyHours = currShop.BusyHours;
                string Category = currShop.Category;

                tbID.Text = ID.ToString();
                tbPositionID.Text = PositionID.ToString();
                tbName.Text = Name.ToString();
                tbCapacity.Text = Capacity.ToString();
                tbPopularity.Text = Popularity.ToString();
                tbPriceRange.Text = PriceRange.ToString();
                tbBusyHours.Text = BusyHours.ToString();
                tbCategory.Text = Category.ToString();
                
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(tbID.Text);
            int PositionID = Convert.ToInt32(tbPositionID.Text);
            string Name = tbName.Text;
            int Capacity = Convert.ToInt32(tbCapacity.Text);
            double Popularity = Convert.ToDouble(tbPopularity.Text);
            int PriceRange = Convert.ToInt32(tbPriceRange.Text);
            string BusyHours = tbBusyHours.Text;
            string Category = tbCategory.Text;


            if (ID == 0 || PositionID == 0 || String.IsNullOrEmpty(Name) || Capacity == 0 || Popularity == 0 || PriceRange == 0 || String.IsNullOrEmpty(BusyHours) || String.IsNullOrEmpty(Category))
            {
                MessageBox.Show("It's empty");
                return;
            }


            currShop.Update(ID, PositionID, Name, Capacity, Popularity, PriceRange, BusyHours, Category);

            LoadAll();
        }
    }
}
