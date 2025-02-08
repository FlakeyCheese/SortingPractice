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
    public partial class MergeSort : Form
    {
        public MergeSort()
        {
            InitializeComponent();
            this.Location = (new Point(0, 0));
            loadUp();
        }

        private void common_drag_Enter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text)) e.Effect = DragDropEffects.Copy;
        }

        private void common_Drag_Drop(object sender, DragEventArgs e)
        {
            Label lbl = sender as Label;
            lbl.Text = (string)e.Data.GetData(DataFormats.Text);
        }

        private void common_Mouse_Down(object sender, MouseEventArgs e)
        {
            Label lbl = sender as Label;
            if (e.Button == MouseButtons.Left)
            {
                //invoke the drag and drop operation
                DoDragDrop(lbl.Text, DragDropEffects.Copy);                
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
        public object generateValues()
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 100);
            return value;            
        }
    }
}
