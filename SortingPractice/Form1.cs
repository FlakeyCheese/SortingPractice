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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public object generateValues()
        {
            if (radioButton4.Checked)
            {
                //Random Uppercase letter:
                Random rnd = new Random();
                int ascii_index = rnd.Next(65, 91); //ASCII character codes 65-90
                char myRandomUpperCase = Convert.ToChar(ascii_index); //produces any char A-Z
                return myRandomUpperCase;
            }
            else
            {
                Random rnd = new Random();
                int value = rnd.Next(1, 100);
                return value;
            }
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

        private void Form1_Load(object sender, EventArgs e)
        {
            loadUp();
            comboBox1.Items.Add("Temp");
            comboBox1.Items.Add("Current Item");
            comboBox1.Items.Add("Pivot");
        }

        private void reset_Click(object sender, EventArgs e)
        {
            loadUp();
            temp.Text = "";
        }
        private void common_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.Text)) e.Effect = DragDropEffects.Copy;
        }
        private void common_DragDrop(object sender, DragEventArgs e)
        {
            Label lbl = sender as Label;
            lbl.Text = (string)e.Data.GetData(DataFormats.Text);
        }
        private void common_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Label lbl = sender as Label;
            if (e.Button == MouseButtons.Left)
            {
                //invoke the drag and drop operation
                DoDragDrop(lbl.Text, DragDropEffects.Copy);
                if (radioButton1.Checked) { lbl.Text = ""; }
            }

        }

        private void index_toggle(object sender, MouseEventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl.ForeColor == Color.Black)
            {
                lbl.ForeColor = Color.White;
                lbl.BackColor = Color.Black;

            }
            else
            {
                lbl.ForeColor = Color.Black;
                lbl.BackColor = Color.White;
            }
        }

        private void toggleBackground(object sender, MouseEventArgs e)
        {
            Label lbl = null;
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "button1":
                    lbl = label1;
                    break;
                case "button2":
                    lbl = label2;
                    break;
                case "button3":
                    lbl = label3;
                    break;
                case "button4":
                    lbl = label4;
                    break;
                case "button5":
                    lbl = label5;
                    break;
                case "button6":
                    lbl = label6;
                    break;
                case "button7":
                    lbl = label7;
                    break;
                case "button8":
                    lbl = label8;
                    break;
                case "button9":
                    lbl = label9;
                    break;
                case "button10":
                    lbl = label10;
                    break;
            }
            if (lbl.BackColor == Color.Yellow) { lbl.BackColor = Color.Red; }
            else { lbl.BackColor = Color.Yellow; }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void temp_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            MergeSort mergeSort = new MergeSort();
            mergeSort.Show();
        }
    }
}
