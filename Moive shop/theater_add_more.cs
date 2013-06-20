using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Moive_shop
{
    public partial class theater_add_more : UserControl
    {
        public theater_add_more()
        {
            InitializeComponent();
        }
        public string calender_mode = string.Empty;
        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
            
            
        }

        private void from_date_Click(object sender, EventArgs e)
        {
            calender.Visible = true;
            calender.BringToFront();
            calender.Location = new System.Drawing.Point(from_date.Location.X, from_date.Location.Y);
            calender.BringToFront();
            calender_mode = "from";
        }

        private void to_date_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(from_txt.Text.Trim()))
            {
                calender.Visible = true;
                calender.BringToFront();
                calender.Location = new System.Drawing.Point(to_date.Location.X - 200, to_date.Location.Y);
                calender.BringToFront();
                calender_mode = "to";
                calender.Visible = true;
            }
            else
                MessageBox.Show("Please enter from Range");
        }

        private void calender_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (calender_mode == "from")
                from_txt.Text = e.Start.Date.ToShortDateString();
            if (calender_mode == "to")
                to_txt.Text = e.Start.Date.ToShortDateString();

            calender.Visible = false;
        }

        private void Save_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void theater_drop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void theater_drop_DropDown(object sender, EventArgs e)
        {
            db_query.theater_drop();
            theater_drop.Items.Clear();
            screen_drop.Items.Clear();
            screen_drop.Text = "";

          
            for (int index = 0; index < common.theater_drop.Count; index++)
            {
                theater_drop.Items.Add(common.theater_drop[index]);
               
            }

        }

        private void screen_drop_DropDown(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(theater_drop.Text.Trim()))
            {
                db_query.screen_drop(theater_drop.Text.Trim());
                screen_drop.Items.Clear();
                for (int index = 0; index < common.screen_drop.Count; index++)
                {
                    screen_drop.Items.Add(common.screen_drop[index]);
                }

            }
        }

        private void theater_drop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 || e.KeyChar == (char)Keys.Delete)
                e.KeyChar = (char)Keys.None;
        }

        private void screen_drop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(theater_drop.Text.Trim()) && !string.IsNullOrEmpty(screen_drop.Text.Trim()))
            {
                timing_panel.Controls.Clear();
                db_query.timing_pannel(theater_drop.Text.Trim(), screen_drop.Text.Trim());
                for (int i = common.screen_timing.Count - 1; i >= 0;i-- )
                {
                    CheckBox timing_check = new CheckBox();
                    timing_check.Text = common.screen_timing[i];
                    timing_panel.Controls.Add(timing_check);
                    timing_check.Dock = DockStyle.Left;

                }
                

            }

        }

        private void calender_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void screen_drop_TextUpdate(object sender, EventArgs e)
        {
            
        }

        private void timing_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
