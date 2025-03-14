using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingPractice
{
    public partial class BinarySearch : Form
    {
        
        int left = 0;
        int right = 31;
        int middle;
        int searchItem;
        int foundItem;
        int delay;
        int compCount = 0;
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
                        if (lab is Label)
                        {
                            tempValue = tempValue + generateValues();
                            lab.Text = tempValue.ToString();

                        }
                    }

                }
            }
            
        }
        public int generateValues()
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 7);
            return value;
        }

        private void button1_Click(object sender, EventArgs e)//search
        {
            delay = Convert.ToInt32(numericUpDown1.Value * 1000);
            searchItem = Convert.ToInt32(txt_searchItem.Text);
            if (search(left,right)==-1)
            {
                
                richTextBox1.AppendText("Item not found in array\n");
            }
            else
                { 
                
                richTextBox1.AppendText("Item found at location "+ middle.ToString());
            }
            
        }

        private void button2_Click(object sender, EventArgs e)//reset
        {
            
            loadUp();

            button1.Enabled = true;
            
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
            lbl_left.Text = 0.ToString();
            lbl_middle.Text = 0.ToString();
            lbl_right.Text = 0.ToString();
            label74.Text ="0";
            richTextBox1.Clear();

        }

        private void btn_step_Click(object sender, EventArgs e)//step through the search
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
        public int search(int left, int right)//recursive binary search
        { Thread.Sleep(delay);
            for (int i = 0;i<32;i++)
            { 
                groupBox1.Controls[i].BackColor = Color.Yellow;
                groupBox1.Controls[i].Refresh();
            }
            

            
                    lbl_left.Text = left.ToString();
                    lbl_left.Refresh();
                    lbl_right.Text = right.ToString();
                     lbl_right.Refresh();
                    int tempLeft = left;
                    if (tempLeft > 31) {  tempLeft = 31; }
                    groupBox1.Controls[tempLeft].BackColor = Color.LightGreen;
                    groupBox1.Controls[tempLeft].Refresh();
                    int tempRight = right;
                    if (tempRight < 0) {  tempRight = 0; }
                    groupBox1.Controls[tempRight].BackColor = Color.LightGreen;            
                    groupBox1.Controls[tempRight].Refresh();


            if (right >= left)
            {
                middle = left + (right - left) / 2;
                foundItem = Convert.ToInt32(groupBox1.Controls[middle].Text);
                lbl_middle.Text = middle.ToString();
                lbl_middle.Refresh();
                groupBox1.Controls[middle].BackColor = Color.Violet;
                groupBox1.Controls[middle].Refresh();

                compCount++;
                label74.Text = compCount.ToString();
                label74.Refresh();
                if (searchItem == foundItem)
                {
                    richTextBox1.AppendText ( "Item found at the middle pointer\n");
                    richTextBox1.Refresh();
                    return middle;
                }

                if (foundItem > searchItem)
                {
                    richTextBox1.AppendText( "Discard the right hand side of the array\n");
                    richTextBox1.Refresh();
                    return search(left, middle - 1);
                }
                richTextBox1.AppendText( "discard the left hand side of the array\n");
                richTextBox1.Refresh();
                return search(middle + 1, right);
            }
            return -1;

        }

        
    }
}