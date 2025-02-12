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
        int searchItem;
        public BinarySearch()
        {
            InitializeComponent();
            sortControls();
            loadUp();

        }
        public void loadUp()
        {
            
            int tempValue = 0;
            foreach (Control gb in this.Controls)
            {
                if (gb is GroupBox)
                {
                    foreach (Control lab in gb.Controls)
                    {
                        if (lab is Label )
                        {
                            tempValue = tempValue+  generateValues();
                            lab.Text = tempValue.ToString();
                            
                        }
                    }
                    
                }
            }
            middle = (left + right) / 2;
            lbl_left.Text = left.ToString();
            lbl_right.Text = right.ToString();
            lbl_middle.Text = middle.ToString();
        }
        public int generateValues()
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 12);
            return value;
        }

        private void button1_Click(object sender, EventArgs e)//search
        {
            groupBox1.Controls[left].BackColor = Color.LightGreen;
            groupBox1.Controls[right].BackColor = Color.LightGreen;
            groupBox1.Controls[middle].BackColor = Color.Violet;
            searchItem =Convert.ToInt32(txt_searchItem.Text);
            int foundItem = Convert.ToInt32(groupBox1.Controls[middle].Text);
            if (searchItem == foundItem)
            {
                lbl_result.Text = "Item Found at Location" + middle.ToString();
            }
            else if (searchItem > foundItem)
            {
                lbl_result.Text = "The Search item is larger than the middle item";
            }
            else { lbl_result.Text = "The Search item is smaller than the middle item"; }
        }

        private void button2_Click(object sender, EventArgs e)//reset
        {
            right = 11;
            left = 0;
            loadUp();
            
            button1.Enabled = true;
            btn_step.Enabled = false;
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

        private void btn_step_Click(object sender, EventArgs e)//step through the search
        {
            for (int i = 0; i < groupBox1.Controls.Count; i++)
            {
                groupBox1.Controls[i].BackColor = Color.Yellow;
            }
            if (searchItem < Convert.ToInt32(groupBox1.Controls[middle].Text))
            {
                right = middle - 1;
                middle = (right + left) / 2;
            }
            else
            {
                right = middle + 1;
                middle =(right + left) / 2;
            }
            groupBox1.Controls[left].BackColor = Color.LightGreen;
            groupBox1.Controls[right].BackColor = Color.LightGreen;
            groupBox1.Controls[middle].BackColor = Color.Violet;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        public void sortControls() //sort the controls into tag order
        {
            var mySortedList = groupBox1.Controls
            .Cast<Control>()
            .OrderBy(x => Convert.ToInt32(x.Tag))
            .ToArray();
            groupBox1.Controls.Clear();
            groupBox1.Controls.AddRange(mySortedList);

            
        }
        
        
    }
}
