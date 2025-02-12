using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingPractice
{
    public partial class BinarySearch : Form
    {
        int count = 0;
        int left = 0;
        int right = 11;
        int middle;
        public BinarySearch()
        {
            InitializeComponent();
            loadUp();
            
        }
        public void loadUp()
        {
            foreach (Control gb in this.Controls)
            {
                if (gb is GroupBox)
                {
                    foreach (Control lab in gb.Controls)
                    {
                        if (lab is Label)
                        {
                            lab.Text = generateValues().ToString();
                        }
                    }
                }
            }
            middle = (left + right) / 2;
            lbl_left.Text=left.ToString();
            lbl_right.Text=right.ToString();
            lbl_middle.Text=middle.ToString();
        }
        public object generateValues()
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 100);
            return value;
        }

        private void button1_Click(object sender, EventArgs e)//search
        {

        }

        private void button2_Click(object sender, EventArgs e)//reset
        {
            loadUp();
            foreach (Control gb in this.Controls)
            {
                if (gb is GroupBox)
                {
                    foreach (Control lab in gb.Controls)
                    {
                        lab.BackColor = Color.Yellow;
                    }
                }
            }
        }
    }
}
