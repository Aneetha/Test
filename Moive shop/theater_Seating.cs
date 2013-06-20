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
    public partial class theater_Seating : Form
    {
        private bool drag = false;
        private Point start_point = new Point(0, 0);
        private bool draggable = true;

        public theater_Seating()
        {
            InitializeComponent();
        }
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

        int row_count = 0; int col_count = 0;

        private void seat_prev_Click(object sender, EventArgs e)
        {

        }

        private void theater_Seating_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
            Manage_theater theat = new Manage_theater();
            theat.Close();
        }

        private void Theater_info_normal_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_theater theat = new Manage_theater();
            theat.ShowDialog();

        }
    }
}
