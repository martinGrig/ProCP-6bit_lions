using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MySqlTut
{
    public partial class Form1 : Form
    {

        private Simulation currSimulation;
        Form2 form2;
        Form3 form3;
        public Form1()
        {
            InitializeComponent();
            Simulation.InitializeDB();
           // Result.InitializeDB();
            form2 = new Form2();
            form3 = new Form3();
            form2.Show();
            form3.Show();
            this.Text = "Settings";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Form2 form2 = new Form2();
            //form2.Show();
        }
        private void LoadAll()
        {
            List<Simulation> simulations = Simulation.GetSimulations();

            lvUsers.Items.Clear();

            foreach (Simulation s in simulations)
            {

                ListViewItem item = new ListViewItem(new String[] { s.ID.ToString(), s.StartTime.ToString(), s.EndTime.ToString(), s.Weather.ToString(), s.Holiday.ToString(), s.DayOfTheWeek.ToString(), s.Sales.ToString() });
                item.Tag = s;

                lvUsers.Items.Add(item);

            }
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            LoadAll();
        }

        private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (lvUsers.SelectedItems.Count > 0)
            {
                ListViewItem item = lvUsers.SelectedItems[0];
                currSimulation = (Simulation)item.Tag;

                int ID = currSimulation.ID;
                String StartTime = currSimulation.StartTime;
                String EndTime = currSimulation.EndTime;
                String Weather = currSimulation.Weather;
                String Holiday = currSimulation.Holiday;
                String DayOfTheWeek = currSimulation.DayOfTheWeek;
                double Sales = currSimulation.Sales;
                tbID.Text = ID.ToString();
                tbStartTime.Text = StartTime;
                tbEndTime.Text = EndTime;
                tbWeather.Text = Weather;
                tbHoliday.Text = Holiday;
                tbDayOfTheWeek.Text = DayOfTheWeek;
                tbSales.Text = Sales.ToString();
            }
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            int ID = Convert.ToInt32(tbID.Text);
            string StartTime = tbStartTime.Text;
            string EndTime = tbEndTime.Text;
            string Weather = tbWeather.Text;
            string Holiday = tbHoliday.Text;
            string DayOfTheWeek = tbDayOfTheWeek.Text;
            double Sales = Convert.ToDouble(tbSales.Text);
            if (String.IsNullOrEmpty(StartTime) || String.IsNullOrEmpty(EndTime) || String.IsNullOrEmpty(Weather) || String.IsNullOrEmpty(Holiday) || String.IsNullOrEmpty(DayOfTheWeek))
            {
                MessageBox.Show("It's empty");
                return;
            }

            currSimulation = Simulation.Insert(ID, StartTime, EndTime, Weather, Holiday, DayOfTheWeek, Sales);

            LoadAll();

        }

        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(tbID.Text);
            if (currSimulation == null)
            {
                MessageBox.Show("No simulation selected!");
                return;
            }

            currSimulation.Delete(ID);

            LoadAll();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
