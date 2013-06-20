using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Moive_shop
{
    
    public partial class Moive_add_theater : Form
    {
       
        public Moive_add_theater()
        {
            InitializeComponent();
                     
        }
        private bool drag = false;
        private Point start_point = new Point(0, 0);
        private bool draggable = true;
        public int row_count = 0;
        public int col_count = 0;
        string calender_mode = "";
       
       
        public bool Draggable
        {
            set
            {
                this.draggable = value;
            }
            get
            {
                return this.draggable;
            }
        }
     

        private void theater_add_more1_Load(object sender, EventArgs e)
        {
            
        }

        private void Moive_add_theater_Load(object sender, EventArgs e)
        {
           // MessageBox.Show(common.manage_moive.Rows[0].ItemArray[0].ToString());
            if (Add_theater_panel.Controls.Count <= 0)
            {
                Add_more_Click(Add_more, null);
            }
        }

     

       

        private void Bg_Click(object sender, EventArgs e)
        {
            
        }

        private void Add_more_Click(object sender, EventArgs e)
        {
            theater_add_more add = new theater_add_more();
            add.Parent = Add_theater_panel;
            add.Dock = DockStyle.Top;

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.drag = true;
            this.start_point = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            this.drag = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.drag)
            {
                Point p1 = new Point(e.X, e.Y);
                Point p2 = this.PointToScreen(p1);
                Point p3 = new Point(p2.X - this.start_point.X,
                                     p2.Y - this.start_point.Y);
                this.Location = p3;
            }
        }

        private void close_Click(object sender, EventArgs e)
        {

            common.movie = null;
            common.movie_theater = null;
            common.movie_preview = null;
           // movie_info.Close();
            this.Close();
        }

        private void movie_info_normal_Click(object sender, EventArgs e)
        {
            if (common.movie != null)
            {
                this.Hide();
                common.movie_theater = null;
                common.movie_theater = this;
              
                common.movie.Show();
            }
            else
            {

            }
              
           
           // movie_info.Visible = true;
        }
       
        private void preview_normal_Click(object sender, EventArgs e)
        {
            movie_preview preview = new movie_preview();
            this.Hide();
            preview.ShowDialog();
            
        }

        private void Save_Click(object sender, EventArgs e)
        {
            for (int i = 0; i<Add_theater_panel.Controls.Count; i++)
            {
              
                    for (int k = 0; k < Add_theater_panel.Controls[i].Controls[14].Controls.Count; k++)
                    {
                        CheckBox check = Add_theater_panel.Controls[i].Controls[14].Controls[k] as CheckBox;
                        if (check.Checked == true)
                        {
                             //MessageBox.Show(Add_theater_panel.Controls[i].Controls[9].Text + "---" + Add_theater_panel.Controls[i].Controls[8].Text + "----" + Add_theater_panel.Controls[i].Controls[7].Text + "-------" + Add_theater_panel.Controls[i].Controls[6].Text + "-----" + Add_theater_panel.Controls[i].Controls[14].Controls[k].Text);
                        }
                    
                    }
            }
        
        }
    }
}
