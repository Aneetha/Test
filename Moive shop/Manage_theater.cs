using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Moive_shop
{
    public partial class Manage_theater : Form
    {
        public Manage_theater()
        {
            InitializeComponent();
        }
        private bool drag = false;
        private Point start_point = new Point(0, 0);
        private bool draggable = true;
       public int  row_count = 0;
       public int col_count =0;
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
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Theater_info_normal_Click(object sender, EventArgs e)
        {
            //this.panel1.Size = new System.Drawing.Size(548, 543);
            //this.Size = new System.Drawing.Size(550, 582);
            //pictureBox1.Size = new System.Drawing.Size(559, 34);
            //label11.Location = new Point(198, 14);
            //close.Location = new Point(532, 7);
            //Theater_info_normal.Visible = false;
            //seat_manage_normal.Visible = true;
            //theater_info_panel.Visible = true;
            //seat_manage_panel.Visible = false;
            //Theater_info_normal.BringToFront();
            //this.CenterToScreen();                      
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

        private void Manage_theater_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            if(panel1.Controls.Count<=0)
            {
                for (int ind = 0; ind < 4;ind++ )
                {
                    add_timing add = new add_timing();
                    panel1.Controls.Add(add);
                    add.Dock = DockStyle.Top;
                }
            }
            if(panel2.Controls.Count<=0)
            {
                for (int ind = 0; ind < 4;ind++ )
                {
                    add_category add = new add_category();
                    panel2.Controls.Add(add);
                    add.Dock = DockStyle.Top;
                }
            }
            if (common.edit_flag == true)
            {
                db_query.edit_text_pass();
                theater_dropdown.Enabled = false;
                theater_text.Text = common.t_old_name;
                theater_Screen_name_txt.Text = common.screen_name;
                theater_location_txt.Text = common.location;
                theater_city_txt.Text = common.city;
                sate_txt.Text = common.state;
                theater_latitude.Text = common.latitude;
                theater_longitude.Text = common.longitude;
                //rows_text.Text = common.rows.ToString();
                //cols_txt.Text = common.rows.ToString();
                if (common.status.ToLower() == "active")
                {
                    theater_active.Checked = true;
                }
                else
                {
                    theater_inactive.Checked = true;
                }
            }
        }

        private void seat_manage_normal_Click(object sender, EventArgs e)
        {
            this.Hide();
            theater_Seating seat = new theater_Seating();
            seat.ShowDialog();
         }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Convert.ToString(e.Button).ToLower() == "right")
            {
                contextMenuStrip1.Visible = true;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
        private bool theater_validate(string mode)
        {
           common.show_timing_list.Clear();
           common.categories_list.Clear();
           for (int ind = 0; ind < panel1.Controls.Count; ind++)
           {
                if (!string.IsNullOrEmpty(panel1.Controls[ind].Controls[2].Text) && !string.IsNullOrEmpty(panel1.Controls[ind].Controls[1].Text) && !string.IsNullOrEmpty(panel1.Controls[ind].Controls[0].Text))
               {
                  common.show_timing_list.Add(panel1.Controls[ind].Controls[2].Text + ":" + panel1.Controls[ind].Controls[1].Text + ":" + panel1.Controls[ind].Controls[0].Text);
               }
            }
           for (int cat_ind = 0; cat_ind < panel2.Controls.Count; cat_ind++)
           {
               if (!string.IsNullOrEmpty(panel2.Controls[cat_ind].Controls[2].Text) && !string.IsNullOrEmpty(panel2.Controls[cat_ind].Controls[1].Text))
               {
                  common.categories_list.Add(panel2.Controls[cat_ind].Controls[2].Text + "->" + panel2.Controls[cat_ind].Controls[1].Text);
               }
           }
            if(string.IsNullOrEmpty(theater_dropdown.Text.Trim())&&string.IsNullOrEmpty(theater_text.Text.Trim()))
            {
                MessageBox.Show("Please select or enter a theater name.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                theater_text.Focus();
                return false;
            }
            else if(string.IsNullOrEmpty( theater_Screen_name_txt.Text.Trim()))
            {
                MessageBox.Show("Please enter a screen.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                theater_Screen_name_txt.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(theater_location_txt.Text.Trim()))
            {
                MessageBox.Show("Please enter a location.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                theater_location_txt.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(theater_city_txt.Text.Trim()))
            {
                MessageBox.Show("Please enter a city name.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                theater_city_txt.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(sate_txt.Text.Trim()))
            {
                MessageBox.Show("Please enter the state name.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sate_txt.Focus();
                return false;
            }
            else if (common.show_timing_list.Count <= 0)
            {
                MessageBox.Show("Please enter least one show timing.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (common.categories_list.Count <= 0)
            {
                MessageBox.Show("Please enter the categories and its price.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                if (mode == "save")
                {
                    common.show_timing.Clear();
                    common.category.Clear();
                    common.price.Clear();
                    common.theter_name = null; common.screen_name = null; common.location = null; common.city = null;
                    common.state = null;
                    common.latitude = null;
                    common.longitude = null;
                    common.status = "0";
                    if (!string.IsNullOrEmpty(theater_dropdown.Text.Trim()))
                    {
                        common.theater_drop_name = theater_dropdown.Text.Trim();
                        common.theter_name = theater_dropdown.Text.Trim();
                    }
                    else
                    {
                        common.theter_name = theater_text.Text.Trim();
                    }

                    common.screen_name = theater_Screen_name_txt.Text.Trim();
                    common.location = theater_location_txt.Text.Trim();
                    common.city = theater_city_txt.Text.Trim();
                    common.state = sate_txt.Text.Trim();
                    if (!string.IsNullOrEmpty(theater_latitude.Text.Trim()) && !string.IsNullOrEmpty(theater_longitude.Text.Trim()))
                    {
                        common.latitude = theater_latitude.Text.Trim();
                        common.longitude = theater_longitude.Text.Trim();
                    }
                    for (int item = 0; item < common.show_timing_list.Count; item++)
                    {
                        common.show_timing.Add(common.show_timing_list[item].ToString());
                    }
                    if (theater_inactive.Checked == true)
                        common.status = "1";
                    for (int item = 0; item < common.categories_list.Count; item++)
                    {
                        int split = common.categories_list[item].ToString().IndexOf("->");
                        common.category.Add(common.categories_list[item].ToString().Substring(0, split).Trim());
                        common.price.Add(Convert.ToDecimal(common.categories_list[item].ToString().Substring(split + 2).Trim()));
                    }
                }
                return true;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (theater_validate("save"))
            {
                seat_manage_normal_Click(this.seat_manage_normal, null);
            }
        }

        private void theater_info_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void theater_dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            db_query.theater_drop();
            for (int index = 0; index < common.theater_drop.Count; index++)
            {
                theater_dropdown.Items.Add(common.theater_drop[index]);
            }
        }

        private void theater_dropdown_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }
        private void theater_dropdown_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (theater_dropdown.Text != "")
            {
                theater_text.Enabled = false;
            }
        }
        private void theater_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32;
        }

        private void theater_Screen_name_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && !Char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32;
        }

        private void theater_location_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32;
        }

        private void theater_city_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32;
        }

        private void sate_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32;
        }

        private void theater_latitude_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8;
        }

        private void theater_longitude_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_timing_Click(object sender, EventArgs e)
        {
            if (panel1.Controls.Count <= 1)
            {
                MessageBox.Show("Sorry.You can't delete show timing.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                add_timing add_time = new add_timing();
                panel1.Controls.Add(add_time);
                add_time.Dock = DockStyle.Top;
            }
        }

        private void category_add_Click(object sender, EventArgs e)
        {
            if (panel2.Controls.Count <= 1)
            {
                MessageBox.Show("Sorry.You can't delete category.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                add_category add_cat = new add_category();
                panel2.Controls.Add(add_cat);
                add_cat.Dock = DockStyle.Top;
            }
        }     

    }
}
