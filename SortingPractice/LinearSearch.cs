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
    public partial class LinearSearch : Form
    {
        int count = 0;
        public LinearSearch()
        {
            InitializeComponent();
            loadUp();
        }

        private void button1_Click(object sender, EventArgs e)//search
        {
            count = 0;
            timer1.Enabled = true;
            
            
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
        }
        public object generateValues()
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 100);
            return value;
        }

        private void button2_Click(object sender, EventArgs e) //reset
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            foreach (Control gb in this.Controls)
            {
                if (gb is GroupBox)
                {
                    foreach (Control lab in gb.Controls)
                    {
                        if (count.ToString() == lab.Tag.ToString())
                        { 
                            lab.BackColor = Color.Violet;
                            lbl_result.Text = "Searching location " + count.ToString();
                        }
                        else
                        { lab.BackColor = Color.Yellow; }
                        if (count.ToString() == lab.Tag.ToString() && textBox1.Text==lab.Text)
                        {
                            lbl_result.Text ="Item found at location " + count.ToString();
                           timer1.Enabled = false;
                        }
                    }
                }
            }
            count++;
            if (count == 12)
                lbl_result.Text = "item not found";
        }
    }
}