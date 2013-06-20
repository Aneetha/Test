using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

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
        
        private void theater_Seating_Load(object sender, EventArgs e)
        {
            if (common.edit_flag == true)
            {
                //if (row_count != common.rows || col_count != common.cols)
                //{
                try
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    row_count = common.rows;
                    col_count = common.cols;
                    DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
                    DataGridViewTextBoxColumn dvgtxt = new DataGridViewTextBoxColumn();
                    dvgtxt.MaxInputLength = 4;

                    dataGridView1.Columns.Add(dgvCmb);
                    //int cat_count = panel_category_holder.Controls.Count;
                    for (int index = 0; index < common.price.Count; index++)
                    {
                        dgvCmb.Items.Add(common.price[index]);
                    }
                    dataGridView1.Columns.Add(dvgtxt);
                    dataGridView1.Columns[0].ReadOnly = false;
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[1].ReadOnly = false;
                    for (int i = 2; i < common.cols + 2; i++)
                    {
                        dataGridView1.Columns.Add("", "");
                        dataGridView1.Columns[i].ReadOnly = true;
                    }
                    int count1 = 0;
                    for (int i = 0; i < common.rows; i++)
                    {
                        dataGridView1.Rows.Add();
                        for (int j = 2; j < dataGridView1.Columns.Count; j++)
                        {
                            count1 = count1 + 1;
                            dataGridView1.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            dataGridView1.Rows[i].Cells[j].Value = count1;
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.ForestGreen;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    int row_name_list = 0;
                    int cat_name = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (j == 0)
                            {
                                string number = common.edit_tab_id[j].ToString();
                                DataRow[] dt_result = common.cat_table.Select("category_id=" + common.edit_tab_id[cat_name]);
                                foreach (DataRow rows in dt_result)
                                {
                                    dataGridView1.Rows[i].Cells[0].Value = rows[0].ToString();
                                }
                                cat_name++;
                            }
                            //if (j == 1)
                            //{
                            //    dataGridView1.Rows[i].Cells[1].Value = common.edit_row_name[row_name_list];
                            //    row_name_list++;
                            //}

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    int num = 0;
                    int row_name_list = 0;
                    //int cat_name = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 1; j < dataGridView1.Columns.Count; j++)
                        {
                            if (j == 0)
                            {
                                continue;
                            }
                            if (j == 1)
                            {
                                dataGridView1.Rows[i].Cells[1].Value = common.edit_row_name[row_name_list];
                                row_name_list++;
                            }
                            //int n = common.edit_seat_no[j];
                            else if (common.edit_seat_no[j - 1] == 0)
                            {
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.DarkGray;
                                dataGridView1.Rows[i].Cells[j].Value = "";
                            }
                            else if (common.edit_seat_no[j] != 0)
                            {
                                if (common.edit_status[j].ToLower() == "holded")
                                {
                                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                                    num = num + 1;
                                    dataGridView1.Rows[i].Cells[j].Value = num;
                                }
                                else if (common.edit_status[j].ToLower() == "available")
                                {
                                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.ForestGreen;
                                    num = num + 1;
                                    dataGridView1.Rows[i].Cells[j].Value = num;
                                }
                                else if (common.edit_status[j].ToLower() == "space")
                                {
                                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.DarkGray;
                                    dataGridView1.Rows[i].Cells[j].Value = "";
                                }
                            }

                        }
                    }
                    int number = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 2; j < dataGridView1.Columns.Count; j++)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Style.BackColor == Color.DarkGray)
                            {
                                dataGridView1.Rows[i].Cells[j].Value = "";
                                continue;
                            }
                            number = number + 1;
                            dataGridView1.Rows[i].Cells[j].Value = number;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //}
                common.edit_flag = true;
                // seat_manage_normal_Click(this.seat_manage_normal, null);
            }

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
        private bool seat_update()
        {
            try
            {
                if (db_query.conn.State.ToString().ToLower() == "closed")
                {
                    db_query.connect();
                }
                //using (SqlCommand cmd = new SqlCommand(db_query.conn))
                //{
                for (int row = 0; row <= dataGridView1.Rows.Count - 1; row++)
                {
                    string c_name = Convert.ToString(dataGridView1.Rows[row].Cells[0].Value);
                    int category_id = 0;
                    try
                    {
                        using (SqlCommand cmd_cat = new SqlCommand("SELECT category_id FROM table_category WHERE theater_id=" + common.theater_id + " AND screen_id=" + common.screen_id + " AND category_name=" + "'" + c_name + "'" + ";", db_query.conn))
                        {
                            using (SqlDataReader rec = cmd_cat.ExecuteReader())
                            {
                                while (rec.Read())
                                {
                                    category_id = rec.GetInt32(0);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    int n = 0;
                    for (int col = 0; col < dataGridView1.Columns.Count; col++)
                    {
                        string seat_no = string.Empty;
                        string status = string.Empty;
                        string rowname = string.Empty;
                        if (col == 0)
                        {
                            continue;
                        }
                        seat_no = Convert.ToString(dataGridView1.Rows[row].Cells[col].Value);
                        if (col == 1)
                        {
                            seat_no = "0";
                        }
                        if (dataGridView1.Rows[row].Cells[col].Style.BackColor == Color.DarkGray)
                        {
                            status = "space";
                            seat_no = "0";
                        }
                        else if (dataGridView1.Rows[row].Cells[col].Style.BackColor == Color.ForestGreen)
                        {
                            status = "available";
                        }
                        else if (dataGridView1.Rows[row].Cells[col].Style.BackColor == Color.Yellow)
                        {
                            status = "holded";
                        }
                        else
                        {
                            status = "name";
                        }
                        rowname = Convert.ToString(dataGridView1.Rows[row].Cells[1].Value);
                        try
                        {
                            using (SqlCommand cmd_1 = new SqlCommand("insert into table_screen_seats(theater_id,screen_id,category_id,seat_no,status,row_name) Values(@t_id,@s_id,@c_id,@seat_no,@satus,@r_name);", db_query.conn))
                            {
                                cmd_1.Parameters.AddWithValue("@t_id", common.theater_id);
                                cmd_1.Parameters.AddWithValue("@s_id", common.screen_id);
                                cmd_1.Parameters.AddWithValue("@c_id", category_id);
                                cmd_1.Parameters.AddWithValue("@seat_no", seat_no);
                                cmd_1.Parameters.AddWithValue("@satus", status);
                                cmd_1.Parameters.AddWithValue("@r_name", rowname);
                                cmd_1.ExecuteNonQuery();
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "error");
                        }
                    }
                }
                return true;
                // }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace + ex.InnerException + "wrong execution");
                return false;
            }
        }
        private bool validate_seats()
        {
            
                if (string.IsNullOrEmpty(rows_text.Text.Trim()) || string.IsNullOrEmpty(cols_txt.Text.Trim()))
                {
                    MessageBox.Show("Please enter rows/columns.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    return false;
                }
                else
                {
                    common.rows = 0;
                    common.cols = 0;
                    common.rows = Convert.ToInt32(rows_text.Text.Trim());
                    common.cols = Convert.ToInt32(cols_txt.Text.Trim());
                    return true;
                }
            
        }


        private void seat_prev_Click_1(object sender, EventArgs e)
        {
            if (validate_seats())
            {
                if (rows_text.Text != "" && cols_txt.Text != "")
                {
                    int rows = 0, cols = 0;
                    try
                    {
                        rows = Convert.ToInt32(rows_text.Text);
                        cols = Convert.ToInt32(cols_txt.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    if (row_count != Convert.ToInt32(rows_text.Text) || col_count != Convert.ToInt32(cols_txt.Text))
                    {
                        try
                        {
                            dataGridView1.Rows.Clear();
                            dataGridView1.Columns.Clear();
                            row_count = rows;
                            col_count = cols;
                            DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
                            DataGridViewTextBoxColumn dvgtxt = new DataGridViewTextBoxColumn();
                            dvgtxt.MaxInputLength = 4;
                            dataGridView1.Columns.Add(dgvCmb);
                           int cat= common.category.Count;
                           for (int index = 0; index < cat; index++)
                            {
                                dgvCmb.Items.Add(common.category[index]);
                            }
                            dataGridView1.Columns.Add(dvgtxt);
                            dataGridView1.Columns[0].ReadOnly = false;

                            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                            dataGridView1.Columns[1].ReadOnly = false;
                            for (int i = 2; i < cols + 2; i++)
                            {
                                dataGridView1.Columns.Add("", "");
                                dataGridView1.Columns[i].ReadOnly = true;
                            }
                            int count = 0;
                            for (int i = 0; i < rows; i++)
                            {
                                dataGridView1.Rows.Add();
                                for (int j = 2; j < dataGridView1.Columns.Count; j++)
                                {
                                    count = count + 1;
                                    dataGridView1.Rows[i].Cells[j].Value = count;
                                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.ForestGreen;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        bool remov_name_flag = false;
                        try
                        {
                            int num = 0;
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                //sseat_save.Visible = false;
                                for (int j = 2; j < dataGridView1.Columns.Count; j++)
                                {
                                    sseat_save.Visible = false;
                                    if (dataGridView1.Rows[i].Cells[j].Style.BackColor == Color.DarkGray)
                                    {
                                        dataGridView1.Rows[i].Cells[j].Value = "";
                                        continue;
                                    }
                                    num = num + 1;
                                    dataGridView1.Rows[i].Cells[j].Value = num;
                                }
                            }
                            //------------row sapce to remove category name and row name----------
                            try
                            {
                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {
                                    for (int j = 2; j < dataGridView1.Columns.Count; j++)
                                    {
                                        if (dataGridView1.Rows[i].Cells[j].Value == null || dataGridView1.Rows[i].Cells[j].Value == "")
                                        {
                                            remov_name_flag = true;
                                            continue;
                                        }
                                        else
                                        {
                                            remov_name_flag = false;
                                            break;
                                        }
                                    }
                                    if (remov_name_flag == true)
                                    {
                                        dataGridView1.Rows[i].Cells[0].Value = null;
                                        dataGridView1.Rows[i].Cells[1].Value = null;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            // -----------------save button visible validate----------------------------------

                            try
                            {
                                bool flag = false;
                                bool c_flag = false;
                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {
                                    sseat_save.Visible = false;
                                    for (int j = 2; j < dataGridView1.Columns.Count; j++)
                                    {
                                        sseat_save.Visible = false;
                                        if (dataGridView1.Rows[i].Cells[j].Value == null)
                                        {
                                            flag = true;
                                        }
                                    }
                                    if (dataGridView1.Rows[i].Cells[0].Value == null && dataGridView1.Rows[i].Cells[1].Value != null && dataGridView1.Rows[i].Cells[0].Value != null || dataGridView1.Rows[i].Cells[1].Value == null)
                                    {
                                        MessageBox.Show("Please specify category name, row name and theater seat alignment", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        break;
                                    }
                                    else
                                    {
                                        sseat_save.Visible = true;
                                    }
                                    if (flag == true)
                                    {
                                        sseat_save.Visible = true;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }
        private void sseat_save_Click(object sender, EventArgs e)
        {
            if (common.edit_flag == true)
            {
                try
                {
                    db_query.update_theater_detail();
                    seat_update();
                    MessageBox.Show("Updated successfully", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    common.edit_flag = false;
                    db_query.theater_show_all();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                {
                    try{
                        if (string.IsNullOrEmpty(common.theater_drop_name))
                    {
                        if (db_query.theater_update() && db_query.screen_update() && db_query.screen_timing_update() && db_query.screen_category_update() && seat_update())
                        {
                            common.show_table.Clear();
                            MessageBox.Show("Updated successfully", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            db_query.theater_show_all();
                            this.Close();
                            common.theater_drop_name = null;
                        }
                        else
                        {
                            common.theater_drop_name = null;
                            //db_query.remove_rec(common.theter_name);
                            MessageBox.Show("Falied to Update, Please Try Again.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (db_query.screen_update() && db_query.screen_timing_update() && db_query.screen_category_update() && seat_update())
                        {
                            MessageBox.Show("Updated successfully", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            db_query.theater_show_all();
                            this.Close();
                        }
                        else
                        {
                            //db_query.remove_rec(common.theter_name);
                            MessageBox.Show("Falied to Update, Please Try Again.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Convert.ToString(e.Button).ToLower() == "right")
            {
                contextMenuStrip1.Visible = true;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void spaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                    {
                        if (dataGridView1.SelectedCells[i].ColumnIndex == 0 || dataGridView1.SelectedCells[i].ColumnIndex == 1)
                        {
                            continue;
                        }
                        dataGridView1.SelectedCells[i].Style.BackColor = Color.DarkGray;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void holdedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                    {
                        if (dataGridView1.SelectedCells[i].ColumnIndex == 0 || dataGridView1.SelectedCells[i].ColumnIndex == 1)
                        {
                            continue;
                        }
                        if (dataGridView1.SelectedCells[i].Style.BackColor == Color.DarkGray)
                        {
                            continue;
                        }
                        dataGridView1.SelectedCells[i].Style.BackColor = Color.Yellow;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void availableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                    {
                        if (dataGridView1.SelectedCells[i].ColumnIndex == 0 || dataGridView1.SelectedCells[i].ColumnIndex == 1)
                        {
                            continue;
                        }
                        if (dataGridView1.SelectedCells[i].Style.BackColor == Color.DarkGray)
                        {
                            continue;
                        }
                        dataGridView1.SelectedCells[i].Style.BackColor = Color.ForestGreen;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void undospaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                {
                    if (dataGridView1.SelectedCells[i].ColumnIndex == 0 || dataGridView1.SelectedCells[i].ColumnIndex == 1)
                    {
                        continue;
                    }
                    if (dataGridView1.SelectedCells[i].Style.BackColor == Color.DarkGray)
                    {
                        dataGridView1.SelectedCells[i].Style.BackColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }  
}
    

