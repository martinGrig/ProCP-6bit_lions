using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int DefaultSpawnRate;
        public Form1()
        {
            InitializeComponent();
        }
        public void Multiply(string time)
        {
            DefaultSpawnRate = 50;
            TimeSpan now = TimeSpan.Parse(time);
            if ((now >= new TimeSpan(09, 00, 00)) && (now < new TimeSpan(11, 00, 00)))
            {
                DefaultSpawnRate = Convert.ToInt32(DefaultSpawnRate * 0.5);
            }
            else if ((now >= new TimeSpan(11, 00, 00)) && (now < new TimeSpan(12, 00, 00)))
            {
                DefaultSpawnRate = Convert.ToInt32(DefaultSpawnRate * 1);
            }
            else if ((now >= new TimeSpan(12, 00, 00)) && (now < new TimeSpan(13, 00, 00)))
            {
                DefaultSpawnRate = Convert.ToInt32(DefaultSpawnRate * 1.5);
            }
            else if ((now >= new TimeSpan(13, 00, 00)) && (now < new TimeSpan(16, 00, 00)))
            {
                DefaultSpawnRate = Convert.ToInt32(DefaultSpawnRate * 1);
            }
            else if ((now >= new TimeSpan(16, 00, 00)) && (now < new TimeSpan(18, 00, 00)))
            {
                DefaultSpawnRate = Convert.ToInt32(DefaultSpawnRate * 2);
            }
            else if ((now >= new TimeSpan(18, 00, 00)) && (now < new TimeSpan(19, 00, 00)))
            {
                DefaultSpawnRate = Convert.ToInt32(DefaultSpawnRate * 1.5);
            }
            else if ((now >= new TimeSpan(19, 00, 00)) && (now < new TimeSpan(20, 00, 00)))
            {
                DefaultSpawnRate = Convert.ToInt32(DefaultSpawnRate * 1);
            }
            else if ((now >= new TimeSpan(20, 00, 00)) && (now < new TimeSpan(22, 00, 00)))
            {
                DefaultSpawnRate = Convert.ToInt32(DefaultSpawnRate * 0.5);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Multiply(DateTime.Now.ToString("hh:mm"));
            label1.Text = DefaultSpawnRate.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Multiply(DateTime.Now.ToString());
            label1.Text = DefaultSpawnRate.ToString();
        }
    }
}
