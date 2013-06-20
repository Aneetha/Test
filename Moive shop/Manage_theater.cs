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
           
            
            
        }

        private void seat_manage_normal_Click(object sender, EventArgs e)
        {
            this.Hide();
            theater_Seating seat = new theater_Seating();
            seat.ShowDialog();
            
            

        
                          
            //if (theater_validate("none"))
            //{

            //    ////theater_label.Text = "";
            //    ////theater_screen_label.Text = "";
            //    ////theater_Location_label.Text = "";
            //    //theater_label.Text = common.theter_name;
            //    //theater_screen_label.Text = common.screen_name;
            //    //theater_Location_label.Text = common.location;   

            //    //this.Hide();
            //    //theater_Seating seat_manage = new theater_Seating();
            //    //seat_manage.Show();
            //}
         }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //if (rows_text.Text != "" && cols_txt.Text != "")
            //{
            //    int rows=0, cols=0;
            //    try
            //    {
            //        rows = Convert.ToInt32(rows_text.Text);

            //        cols = Convert.ToInt32(cols_txt.Text);
            //    }
            //    catch { }
                

            //    if (row_count != rows || col_count != cols)
            //    {
            //        try
            //        {
            //            dataGridView1.Rows.Clear();
            //            dataGridView1.Columns.Clear();

            //            row_count = rows;
            //            col_count = cols;
            //            DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
            //            DataGridViewTextBoxColumn dvgtxt = new DataGridViewTextBoxColumn();
            //            dataGridView1.Columns.Add(dgvCmb);
            //            for (int index = 0; index < common.category.Count; index++)
            //            {
            //                dgvCmb.Items.Add(common.category[index]);
            //            }
            //            dataGridView1.Columns.Add(dvgtxt);
            //            dataGridView1.Columns[0].ReadOnly = false;
            //            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //            dataGridView1.Columns[1].ReadOnly = false;
            //            for (int i = 2; i < cols + 2; i++)
            //            {
            //                dataGridView1.Columns.Add("", "");
            //                dataGridView1.Columns[i].ReadOnly = true;

            //            }
            //            int count = 0;
            //            for (int i = 0; i < rows; i++)
            //            {
            //                dataGridView1.Rows.Add();

            //                for (int j = 2; j < dataGridView1.Columns.Count; j++)
            //                {
            //                    count = count + 1;

            //                    dataGridView1.Rows[i].Cells[j].Value = count;
            //                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.ForestGreen;
                                
            //                }
            //            }
            //        }
            //        catch { }
            //    }
            //    else
            //    {
            //        try
            //        {
            //            int num = 0;
            //            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //            {
            //                for (int j = 2; j < dataGridView1.Columns.Count; j++)
            //                {
            //                    if (dataGridView1.Rows[i].Cells[j].Style.BackColor == Color.DarkGray)
            //                    {
            //                        dataGridView1.Rows[i].Cells[j].Value = "";
            //                        continue;
            //                    }
            //                    num = num + 1;
            //                    dataGridView1.Rows[i].Cells[j].Value = num;


            //                }
            //            }
            //        }
            //        catch { }
            //    }
            //}
           

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Convert.ToString(e.Button).ToLower() == "right")
            {
                contextMenuStrip1.Visible = true;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        //private void spaceToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (dataGridView1.SelectedCells.Count > 0)
        //        {
        //            for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
        //            {
        //                if (dataGridView1.SelectedCells[i].ColumnIndex == 0 || dataGridView1.SelectedCells[i].ColumnIndex == 1)
        //                {
        //                    continue;
        //                }
        //                dataGridView1.SelectedCells[i].Style.BackColor = Color.DarkGray;
        //            }
        //        }
        //    }
        //    catch { }
        //}

        //private void holdToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (dataGridView1.SelectedCells.Count > 0)
        //        {

        //            for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
        //            {
        //                if (dataGridView1.SelectedCells[i].ColumnIndex == 0 || dataGridView1.SelectedCells[i].ColumnIndex == 1)
        //                {
        //                    continue;
        //                }
        //                if (dataGridView1.SelectedCells[i].Style.BackColor == Color.DarkGray)
        //                {
        //                    continue;
        //                }
        //                dataGridView1.SelectedCells[i].Style.BackColor = Color.Yellow;
        //            }
        //        }
        //    }
        //    catch { }
        //}

        //private void availabToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (dataGridView1.SelectedCells.Count > 0)
        //        {
        //            for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
        //            {
        //                if (dataGridView1.SelectedCells[i].ColumnIndex == 0 || dataGridView1.SelectedCells[i].ColumnIndex == 1)
        //                {
        //                    continue;
        //                }
        //                if (dataGridView1.SelectedCells[i].Style.BackColor == Color.DarkGray)
        //                {
        //                    continue;
        //                }
        //                dataGridView1.SelectedCells[i].Style.BackColor = Color.ForestGreen;
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}

        //private void rows_text_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //   e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8;
           
        //}

        //private void undoSpaceToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
        //    {
        //        if (dataGridView1.SelectedCells[i].ColumnIndex == 0 || dataGridView1.SelectedCells[i].ColumnIndex == 1)
        //        {
        //            continue;
        //        }
        //        if (dataGridView1.SelectedCells[i].Style.BackColor == Color.DarkGray)
        //        {
        //            dataGridView1.SelectedCells[i].Style.BackColor = Color.Green;
        //        }
               
        //    }
        //}

      

    

      
        private bool theater_validate(string mode)
        {
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
            //else if (show_timing_list.Items.Count <= 0)
            //{
            //    MessageBox.Show("Please enter least one show timing.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}
            //else if (categories_list.Items.Count <= 0)
            //{
            //    MessageBox.Show("Please enter the categories and its price.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}
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
                    if (string.IsNullOrEmpty(theater_latitude.Text.Trim()) && !string.IsNullOrEmpty(theater_longitude.Text.Trim()))
                    {
                        common.latitude = theater_latitude.Text.Trim();
                        common.longitude = theater_longitude.Text.Trim();
                    }
                    //for (int item = 0; item < show_timing_list.Items.Count; item++)
                    //{
                    //    common.show_timing.Add(show_timing_list.Items[item].ToString());
                    //}
                    //if (theater_inactive.Checked == true)
                    //    common.status = "1";
                    //for (int item = 0; item < categories_list.Items.Count; item++)
                    //{
                    //    int split = categories_list.Items[item].ToString().IndexOf("->");
                    //    common.category.Add(categories_list.Items[item].ToString().Substring(0, split).Trim());
                    //    common.price.Add(Convert.ToDecimal(categories_list.Items[item].ToString().Substring(split + 2).Trim()));
                    //}
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

        //private void booking_refresh_Click(object sender, EventArgs e)
        //{
        //    row_count = 0;
        //     col_count =0;
        //     pictureBox3_Click(this.seat_prev, null);

        //}
        //private bool validate_seats()
        //{
        //    if (string.IsNullOrEmpty(rows_text.Text.Trim()) && string.IsNullOrEmpty(cols_txt.Text.Trim()))
        //    {
        //        MessageBox.Show("Please sepcify rows/columns.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return false;
        //    }
        //    else
        //    {
        //        common.rows = 0;
        //        common.cols = 0;
        //        common.rows = Convert.ToInt32(rows_text.Text.Trim());
        //        common.cols = Convert.ToInt32(cols_txt.Text.Trim());
        //        return true;
        //    }           
        //}
        //private bool seat_update()
        //{
        //    try
        //    {
        //        if (db_query.con.State.ToString().ToLower() == "closed")
        //        {
        //            db_query.connection();
        //        }
        //        using (SQLiteCommand cmd = new SQLiteCommand(db_query.con))
        //        {

        //            for (int row = 0; row < dataGridView1.Rows.Count; row++)
        //            {
        //                int category_id = 0;

        //                using (SQLiteCommand cmd_cat = new SQLiteCommand("SELECT category_id FROM table_category WHERE screen_id=" + "'" + common.screen_id + "'" + " AND category_name=" + "'" + dataGridView1.Rows[row].Cells[0].Value.ToString().Trim() + "'" + ";", db_query.con))
        //                {
        //                    SQLiteDataReader rec = cmd_cat.ExecuteReader();
        //                    while (rec.Read())
        //                    {
        //                        category_id = rec.GetInt32(0);

        //                    }

        //                }
        //                for (int col = 0; col < dataGridView1.Columns.Count; col++)
        //                {
        //                    string seat_no = string.Empty;
        //                    string status = string.Empty;
                                                 
                                                     
        //                    if (col == 0)
        //                    {
        //                        continue;
        //                    }
        //                    seat_no = Convert.ToString(dataGridView1.Rows[row].Cells[col].Value);
        //                    if (col == 1)
        //                    {
        //                        seat_no = "0";
        //                    }

        //                    if (dataGridView1.Rows[row].Cells[col].Style.BackColor == Color.DarkGray)
        //                    {
        //                        status = "space";
        //                        seat_no = "0";
        //                    }
        //                    else if (dataGridView1.Rows[row].Cells[col].Style.BackColor == Color.ForestGreen)
        //                    {
        //                        status = "available";
        //                    }
        //                    else if (dataGridView1.Rows[row].Cells[col].Style.BackColor == Color.Yellow)
        //                    {
        //                        status = "holded";
        //                    }
        //                    else
        //                    {
        //                        status = "name";
        //                    }

        //                    cmd.CommandText = "insert into table_screen_seats(theater_id,screen_id,category_id,seat_no,status) Values(@t_id,@s_id,@c_id,@seat_no,@satus);";
        //                    cmd.Parameters.AddWithValue("@t_id", common.theater_id);
        //                    cmd.Parameters.AddWithValue("@s_id", common.screen_id);
        //                    cmd.Parameters.AddWithValue("@c_id", category_id);
        //                    cmd.Parameters.AddWithValue("@seat_no", seat_no);
        //                    cmd.Parameters.AddWithValue("@satus", status);
        //                   cmd.ExecuteNonQuery();
        //                }
        //            }
        //            return true;
        //        }

        //    }
        //    catch { return false; }

        //}

        //private void sseat_save_Click(object sender, EventArgs e)
        //{

        //   if (validate_seats() && theater_validate("save"))
        //   {
                                      
        //       if (string.IsNullOrEmpty(theater_dropdown.Text))
        //       {
        //           if (db_query.theater_update() && db_query.screen_update() && db_query.screen_timing_update() && db_query.screen_category_update() && seat_update())
        //           {
        //               MessageBox.Show("Updated successfully", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //               this.Close();
        //           }
        //           else
        //           {
        //               MessageBox.Show("Falied to Update, Please Try Again.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //           }

        //       }
        //       else
        //       {
        //           if (db_query.screen_update() && db_query.screen_timing_update() && db_query.screen_category_update() && seat_update())
        //           {
        //               MessageBox.Show("Updated successfully", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //              this.Close();
        //           }
        //           else
        //           {
        //               MessageBox.Show("Falied to Update, Please Try Again.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //           }
        //       }
        //  }
        
        //}

        private void theater_dropdown_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (theater_dropdown.Text != "")
            {
                theater_text.Enabled = false;
            }
        }

        private void theater_info_select_Click(object sender, EventArgs e)
        {

        }     

    }
}
