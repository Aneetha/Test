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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private bool drag = false;
        private Point start_point = new Point(0, 0);
        private bool draggable = true;
        private string calender_mode = "";
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

        private void Main_Load(object sender, EventArgs e)
        {
            theater_panel.Parent = main_panel;
            movie_panel.Parent = main_panel;
            booking_panel.Parent = main_panel;
            this.theater_panel.Location = new System.Drawing.Point(5, 8);
            this.movie_panel.Location = new System.Drawing.Point(5, 8);
            this.booking_panel.Location = new System.Drawing.Point(5, 8);
           
            theater_normal.Visible = false;
            theater_panel.Visible = true;
            movie_panel.Visible = false;
            booking_panel.Visible = false;
            db_query.search_theater("none", "");
            theater_search.DataSource = common.table;
            datagird_style();
                       
        }
        public void datagird_style()
        {
            try
            {
                if (!theater_search.Columns.Contains("edit"))
                {
                    DataGridViewImageColumn edit = new DataGridViewImageColumn();
                    DataGridViewImageColumn delete = new DataGridViewImageColumn();

                    Image image = Image.FromFile(@"E:\Current Working\E-booking\Eticket_picx\delete.PNG");
                    Image image1 = Image.FromFile(@"E:\Current Working\E-booking\Eticket_picx\edit.PNG");
                    delete.Image = image;
                    edit.Image = image1;
                    //button.DefaultCellStyle

                    theater_search.Columns.Add(edit);
                    theater_search.Columns.Add(delete);
                    theater_search.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    theater_search.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    theater_search.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    theater_search.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    theater_search.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    theater_search.Columns[theater_search.Columns.Count-2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    theater_search.Columns[theater_search.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                }
            }
            catch { }
           

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            this.drag = true;
            this.start_point = new Point(e.X, e.Y);
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            this.drag = false;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
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
            Environment.Exit(0);
        }

      

        private void min_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch { }
        }

        private void theater_normal_Click(object sender, EventArgs e)
        {
            theater_normal.Visible = false;
            theater_select.Visible = true;
            movie_normal.Visible = true;
            booking_normal.Visible = true;
            theater_panel.Visible = true;
            movie_panel.Visible = false;
            booking_panel.Visible = false;
            theater_showall_Click(theater_showall, null);
                    
        }

        private void movie_normal_Click(object sender, EventArgs e)
        {
            movie_normal.Visible = false;
            movie_select.Visible = true;
            theater_normal.Visible = true;
            booking_normal.Visible = true;
            theater_panel.Visible = false;
            movie_panel.Visible = true;
            booking_panel.Visible = false;
            movie_showall_Click(this.movie_showall, null);

         

        }

        private void booking_normal_Click(object sender, EventArgs e)
        {
            theater_normal.Visible = true;
            movie_normal.Visible = true;
            booking_normal.Visible = false;
            booking_select.Visible = true;
            booking_panel.Visible = true;
            theater_panel.Visible = false;
            movie_panel.Visible = false;
            
        }

       

        private void theater_add_Click(object sender, EventArgs e)
        {
             Manage_theater add = new Manage_theater();
            add.ShowDialog();
        }
        public static void seat_manage()
        {
            
            theater_Seating seat = new theater_Seating();
            seat.ShowDialog();
           

        }

      

        private void moive_add_Click(object sender, EventArgs e)
        {
            Manage_moive add = new Manage_moive();
            add.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(theater_theater_dropdown.Text.Trim()+ theater_screen_dropdown.Text.Trim()))
            {
                db_query.search_theater(theater_theater_dropdown.Text, theater_screen_dropdown.Text);
                theater_search.DataSource = common.table;    
                                                
            }
            else
            {
                MessageBox.Show("Please select any Filters to search.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void theater_theater_dropdown_KeyPress(object sender, KeyPressEventArgs e)
        {
            
           if( e.KeyChar != 8 || e.KeyChar == (char)Keys.Delete)
           e.KeyChar = (char)Keys.None;
            
          
        }
        private bool validate_booking()
        {
            if (string.IsNullOrEmpty(booking_theater_drop.Text))
            {
                MessageBox.Show("Please select a theater name.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(booking_screen_drop.Text))
            {
                MessageBox.Show("Please select a screen name.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(booking_timing_drop.Text))
            {
                MessageBox.Show("Please select the show timing.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(booking_moive_name_drop.Text))
            {
                MessageBox.Show("Please select the movie name.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
                return true;

        }

        private void booking_search_Click(object sender, EventArgs e)
        {
            if (validate_booking())
            {

            }
            
        }

        private void movie_search_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(Convert.ToString(moive_name_drop.Text + moive_fromdate_txt.Text + moive_todate_txt.Text + moive_theater_drop.Text + Language_box.Text).Trim()))
            {
                MessageBox.Show("Please select any Filters to search.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                string query = string.Empty;
               
              

                        if (!string.IsNullOrEmpty(moive_name_drop.Text.Trim()) && string.IsNullOrEmpty(moive_fromdate_txt.Text + moive_todate_txt.Text + moive_theater_drop.Text + moive_screen_drop.Text + Language_box.Text.Trim()))
                        {

                           // MessageBox.Show("movie search");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where m.movie_name=" + "'" + moive_name_drop.Text.Trim() + "'" + " and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(moive_fromdate_txt.Text) && string.IsNullOrEmpty(moive_todate_txt.Text + moive_name_drop.Text + moive_theater_drop.Text + moive_screen_drop.Text + Language_box.Text.Trim()))
                        {
                           // MessageBox.Show("From Date");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where s.date=" + "'" + moive_fromdate_txt.Text.Trim() + "'" + " and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";

                        }
                        else if (!string.IsNullOrEmpty(moive_fromdate_txt.Text) && !string.IsNullOrEmpty(moive_todate_txt.Text) && string.IsNullOrEmpty(moive_name_drop.Text + moive_theater_drop.Text + moive_screen_drop.Text + Language_box.Text.Trim()))
                        {
                            MessageBox.Show(" From Date, todate");
                            //query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where s.date BETWEEN " + moive_fromdate_txt.Text.Trim() + "AND " + moive_todate_txt.Text.Trim() + " and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(moive_theater_drop.Text.Trim()) && string.IsNullOrEmpty(moive_name_drop.Text + moive_fromdate_txt.Text + moive_todate_txt.Text + Language_box.Text.Trim()))
                        {
                            //MessageBox.Show("Theater");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where tm.theater_name=" + "'" + moive_theater_drop.Text.Trim() + "'" + " and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(Language_box.Text.Trim()) && string.IsNullOrEmpty((moive_name_drop.Text + moive_fromdate_txt.Text + moive_todate_txt.Text + moive_theater_drop.Text + moive_screen_drop.Text).Trim()))
                        {
                          //  MessageBox.Show("Language");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where m.language like " + "'%" + Language_box.Text.Trim() + "%'" + " and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(moive_name_drop.Text) && !string.IsNullOrEmpty(moive_theater_drop.Text) && string.IsNullOrEmpty((moive_fromdate_txt.Text + moive_screen_drop.Text + moive_todate_txt.Text + Language_box.Text).Trim()))
                        {
                            //MessageBox.Show("Movie, theater");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where m.movie_name = " + "'" + moive_name_drop.Text.Trim() + "'" + " and tm.theater_name ='" + moive_theater_drop.Text.Trim() + "' and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";

                        }
                        else if (!string.IsNullOrEmpty(moive_name_drop.Text) && !string.IsNullOrEmpty(moive_theater_drop.Text) && !string.IsNullOrEmpty(moive_fromdate_txt.Text) && string.IsNullOrEmpty(moive_screen_drop.Text + moive_todate_txt.Text + Language_box.Text.Trim()))
                        {
                           // MessageBox.Show("Movie, theater,from date");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where m.movie_name = " + "'" + moive_name_drop.Text.Trim() + "'" + " and tm.theater_name ='" + moive_theater_drop.Text.Trim() + "' and s.date = '" + moive_fromdate_txt.Text.Trim() + "' and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(moive_name_drop.Text) && !string.IsNullOrEmpty(moive_theater_drop.Text) && !string.IsNullOrEmpty(moive_fromdate_txt.Text) && !string.IsNullOrEmpty(moive_todate_txt.Text) && string.IsNullOrEmpty(moive_screen_drop.Text + Language_box.Text.Trim()))
                        {
                           // MessageBox.Show("Movie, theater,from date,todate");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where m.movie_name = " + "'" + moive_name_drop.Text.Trim() + "'" + " and tm.theater_name ='" + moive_theater_drop.Text.Trim() + "' and s.date between  " + moive_fromdate_txt.Text.Trim() + " and " + moive_todate_txt.Text.Trim() + " and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(moive_name_drop.Text) && !string.IsNullOrEmpty(moive_theater_drop.Text) && !string.IsNullOrEmpty(moive_screen_drop.Text) && string.IsNullOrEmpty(moive_fromdate_txt.Text + moive_todate_txt.Text + Language_box.Text.Trim()))
                        {
                            //MessageBox.Show("Movie, theater,screen");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where m.movie_name = " + "'" + moive_name_drop.Text.Trim() + "'" + " and tm.theater_name ='" + moive_theater_drop.Text.Trim() + "' and sn.screen_name ='" + moive_screen_drop.Text.Trim() + "' " + " and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(moive_name_drop.Text) && !string.IsNullOrEmpty(moive_theater_drop.Text) && !string.IsNullOrEmpty(moive_screen_drop.Text) && !string.IsNullOrEmpty(moive_fromdate_txt.Text) && string.IsNullOrEmpty(moive_todate_txt.Text + Language_box.Text.Trim()))
                        {
                           // MessageBox.Show("Movie, theater,screen,from date");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where m.movie_name = " + "'" + moive_name_drop.Text.Trim() + "'" + " and tm.theater_name ='" + moive_theater_drop.Text.Trim() + "' and sn.screen_name ='" + moive_screen_drop.Text.Trim() + "' and s.date = '" + moive_fromdate_txt.Text.Trim() + "' and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(moive_name_drop.Text) && !string.IsNullOrEmpty(moive_theater_drop.Text) && !string.IsNullOrEmpty(moive_screen_drop.Text) && !string.IsNullOrEmpty(moive_fromdate_txt.Text) && !string.IsNullOrEmpty(moive_todate_txt.Text) && string.IsNullOrEmpty(Language_box.Text.Trim()))
                        {
                            MessageBox.Show("Movie, theater,screen,from date,todate");
                            //query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where m.movie_name = " + "'" + moive_name_drop.Text.Trim() + "'" + " and tm.theater_name ='" + moive_theater_drop.Text.Trim() + "' and sn.screen_name ='" + moive_screen_drop.Text.Trim() + "' and s.date between  " + moive_fromdate_txt.Text.Trim() + " and " + moive_todate_txt.Text.Trim() + " and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(moive_name_drop.Text) && !string.IsNullOrEmpty(Language_box.Text.Trim()) && string.IsNullOrEmpty(moive_theater_drop.Text + moive_screen_drop.Text + moive_fromdate_txt.Text + moive_todate_txt.Text))
                        {
                           // MessageBox.Show("Movie, Language");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where m.movie_name ='" + moive_name_drop.Text.Trim() + "' and m.language like " + "'%" + Language_box.Text.Trim() + "%'" + " and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(moive_name_drop.Text) && !string.IsNullOrEmpty(moive_fromdate_txt.Text) && string.IsNullOrEmpty(moive_theater_drop.Text + moive_screen_drop.Text + moive_todate_txt.Text + Language_box.Text))
                        {
                           // MessageBox.Show("Movie, fromdate");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where m.movie_name = " + "'" + moive_name_drop.Text.Trim() + "'" + "and s.date = '" + moive_fromdate_txt.Text.Trim() + "' and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(moive_name_drop.Text) && !string.IsNullOrEmpty(moive_fromdate_txt.Text) && !string.IsNullOrEmpty(moive_todate_txt.Text) && string.IsNullOrEmpty(moive_theater_drop.Text + moive_screen_drop.Text + Language_box.Text))
                        {
                            MessageBox.Show("Movie, fromdate,todate");
                            //query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where m.movie_name = " + "'" + moive_name_drop.Text.Trim() + "'" + "and s.date between  " + moive_fromdate_txt.Text.Trim() + " and " + moive_todate_txt.Text.Trim() + " and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(moive_name_drop.Text) && !string.IsNullOrEmpty(Language_box.Text.Trim()) && !string.IsNullOrEmpty(moive_fromdate_txt.Text) && string.IsNullOrEmpty(moive_theater_drop.Text + moive_screen_drop.Text + moive_todate_txt.Text))
                        {
                           // MessageBox.Show("Movie, Language,fromdate");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where m.movie_name ='" + moive_name_drop.Text.Trim() + "' and m.language like " + "'%" + Language_box.Text.Trim() + "%'" + "and s.date = '" + moive_fromdate_txt.Text.Trim() + "' and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(moive_name_drop.Text) && !string.IsNullOrEmpty(Language_box.Text.Trim()) && !string.IsNullOrEmpty(moive_fromdate_txt.Text) && !string.IsNullOrEmpty(moive_todate_txt.Text) && string.IsNullOrEmpty(moive_theater_drop.Text + moive_screen_drop.Text))
                        {
                            MessageBox.Show("Movie, Language,fromdate,todate");
                            //query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where m.movie_name ='" + moive_name_drop.Text.Trim() + "' and m.language like " + "'%" + Language_box.Text.Trim() + "%'" + "and s.date between  " + moive_fromdate_txt.Text.Trim() + " and " + moive_todate_txt.Text.Trim() + " and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(Language_box.Text) && !string.IsNullOrEmpty(moive_theater_drop.Text) && string.IsNullOrEmpty((moive_fromdate_txt.Text + moive_screen_drop.Text + moive_todate_txt.Text + moive_name_drop.Text).Trim()))
                        {
                           // MessageBox.Show("Language, theater");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where tm.theater_name ='" + moive_theater_drop.Text.Trim() + "' and m.language like " + "'%" + Language_box.Text.Trim() + "%'" + " and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(Language_box.Text) && !string.IsNullOrEmpty(moive_theater_drop.Text) && !string.IsNullOrEmpty(moive_name_drop.Text) && string.IsNullOrEmpty((moive_fromdate_txt.Text + moive_screen_drop.Text + moive_todate_txt.Text).Trim()))
                        {
                           // MessageBox.Show("movie,Language, theater");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where tm.theater_name ='" + moive_theater_drop.Text.Trim() + "' and m.language like " + "'%" + Language_box.Text.Trim() + "%'" + " and m.movie_name='" + moive_name_drop.Text.Trim() + "' and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(Language_box.Text.Trim()) && !string.IsNullOrEmpty(moive_fromdate_txt.Text) && string.IsNullOrEmpty(moive_name_drop.Text + moive_theater_drop.Text + moive_screen_drop.Text + moive_todate_txt.Text))
                        {
                           // MessageBox.Show(" Language,fromdate");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where m.language like " + "'%" + Language_box.Text.Trim() + "%'" + "and s.date ='" + moive_fromdate_txt.Text.Trim() + "' and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(Language_box.Text.Trim()) && !string.IsNullOrEmpty(moive_fromdate_txt.Text) && !string.IsNullOrEmpty(moive_todate_txt.Text) && string.IsNullOrEmpty(moive_name_drop.Text + moive_theater_drop.Text + moive_screen_drop.Text))
                        {
                            MessageBox.Show(" Language,fromdate,todate");
                            //query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where language like " + "'%" + Language_box.Text.Trim() + "%'" + " and s.date between  " + moive_fromdate_txt.Text.Trim() + " and " + moive_todate_txt.Text.Trim() + " and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(Language_box.Text) && !string.IsNullOrEmpty(moive_fromdate_txt.Text) && !string.IsNullOrEmpty(moive_theater_drop.Text) && string.IsNullOrEmpty((moive_name_drop.Text + moive_todate_txt.Text).Trim()))
                        {
                           // MessageBox.Show("Date,Language, theater");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where s.date='" + moive_fromdate_txt.Text.Trim() + "'and m.language like " + "'%" + Language_box.Text.Trim() + "%'" + "' and tm.theater_name='" + moive_theater_drop.Text.Trim() + "' and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(Language_box.Text) && !string.IsNullOrEmpty(moive_fromdate_txt.Text) && !string.IsNullOrEmpty(moive_todate_txt.Text) && !string.IsNullOrEmpty(moive_theater_drop.Text) && string.IsNullOrEmpty((moive_name_drop.Text).Trim()))
                        {
                           // MessageBox.Show("Date from, to,Language, theater");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where  m.language like " + "'%" + Language_box.Text.Trim() + "%'" + "' and tm.theater_name='" + moive_theater_drop.Text.Trim() + "' and s.date between" + moive_fromdate_txt.Text + "and" + moive_todate_txt.Text + " and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(moive_name_drop.Text) && !string.IsNullOrEmpty(Language_box.Text.Trim()) && !string.IsNullOrEmpty(moive_fromdate_txt.Text) && !string.IsNullOrEmpty(moive_todate_txt.Text) && !string.IsNullOrEmpty(moive_theater_drop.Text) && !string.IsNullOrEmpty(moive_screen_drop.Text))
                        {
                            MessageBox.Show("Movie,theater,screen Language,fromdate,todate");
                            // query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where m.movie_name='" + moive_name_drop.Text.Trim() + "' and  m.language like " + "'%" + Language_box.Text.Trim() + "%'" + "' and tm.theater_name='" + moive_theater_drop.Text.Trim() + "' and sn.screen_name='" + moive_screen_drop.Text.Trim()+ "' and s.date between" + moive_fromdate_txt.Text + "and" + moive_todate_txt.Text + " and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(moive_name_drop.Text) && !string.IsNullOrEmpty(Language_box.Text.Trim()) && !string.IsNullOrEmpty(moive_fromdate_txt.Text) && !string.IsNullOrEmpty(moive_todate_txt.Text) && !string.IsNullOrEmpty(moive_theater_drop.Text) && string.IsNullOrEmpty(moive_screen_drop.Text))
                        {
                           // MessageBox.Show("Movie,theater,Language,fromdate,todate");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where m.movie_name='" + moive_name_drop.Text.Trim() + "' and  m.language like " + "'%" + Language_box.Text.Trim() + "%'" + "' and tm.theater_name='" + moive_theater_drop.Text.Trim() + "' and sn.screen_name='" + moive_screen_drop.Text.Trim() + "' and s.date ='" + moive_fromdate_txt.Text + "' and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }
                        else if (!string.IsNullOrEmpty(moive_name_drop.Text) && !string.IsNullOrEmpty(Language_box.Text.Trim()) && !string.IsNullOrEmpty(moive_fromdate_txt.Text) && string.IsNullOrEmpty(moive_todate_txt.Text) && !string.IsNullOrEmpty(moive_theater_drop.Text) && string.IsNullOrEmpty(moive_screen_drop.Text))
                        {
                           // MessageBox.Show("Movie,theater,screen, Language,fromdate");
                            query = "select m.movie_name,tm.theater_name,sn.screen_name,m.release_date,m.director,m.genre, m.language from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where m.movie_name='" + moive_name_drop.Text.Trim() + "' and  m.language like " + "'%" + Language_box.Text.Trim() + "%'" + "' and tm.theater_name='" + moive_theater_drop.Text.Trim() + "' and sn.screen_name='" + moive_screen_drop.Text.Trim() + "' and s.date ='" + moive_fromdate_txt.Text + "' and s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;";
                        }

                        if (!string.IsNullOrEmpty(query.Trim()))
                        {
                            db_query.moive_search(query);
                            theater_search.DataSource = null;
                            theater_search.Columns.Clear();
                            theater_search.Refresh();

                            theater_search.DataSource = common.table;
                            if (common.table.Rows.Count <= 0)
                            {
                                no_record.Visible = true;
                            }
                            else
                            {
                                no_record.Visible = false;
                            }
                            datagird_style();
                        }
                        
                    
                }
                catch(Exception ex)
                {
                   // MessageBox.Show(ex.Message);
                }

               

            }
        }

        private void movie_fom_calender_Click(object sender, EventArgs e)
        {
            calender.Visible = true;
            calender.Location = new System.Drawing.Point(movie_fom_calender.Location.X, movie_fom_calender.Location.Y);
            calender_mode = "movie_from";
        }

        private void movie_to_calender_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(moive_fromdate_txt.Text.Trim()))
            {
                calender.Visible = true;
                calender.Location = new System.Drawing.Point(movie_to_calender.Location.X, movie_to_calender.Location.Y);
                calender_mode = "movie_to";
            }
            else
            {
                MessageBox.Show("Please select from date range");
            }
        }

        private void calender_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (calender_mode == "movie_from")
                moive_fromdate_txt.Text = calender.SelectionStart.ToShortDateString();
            if (calender_mode == "movie_to")
                moive_todate_txt.Text = calender.SelectionStart.ToShortDateString();
            if (calender_mode == "movie_date")
               booking_date.Text = calender.SelectionStart.ToShortDateString();
            
            calender.Visible = false;
            
 

        }

        private void movie_date_Click(object sender, EventArgs e)
        {
            calender.Visible = true;
            calender.Location = new System.Drawing.Point(movie_date.Location.X, movie_date.Location.Y);
            calender_mode = "movie_date";
         }

        private void theater_search_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == theater_search.Columns.Count - 2 && movie_panel.Visible==true)
            {
               string query = "select movie_name, release_date, director,genre,written,language,run_time,image,video,featured,status,descrip from table_movie_details where movie_name = '"+theater_search.CurrentRow.Cells[0].Value.ToString().Trim()+"' and language ='"+theater_search.CurrentRow.Cells[6].Value.ToString().Trim()+"'";

               string query1 = "select tm.theater_name,s.screen_name,min(ts.date),max(ts.date) from theater_master tm, table_screen s, table_showing ts,table_movie_details m where m.movie_name ='" + theater_search.CurrentRow.Cells[0].Value.ToString().Trim() + "' and m.language like '" + theater_search.CurrentRow.Cells[6].Value.ToString().Trim() + "' and ts.movie_id=m.movie_id and ts.theater_id = tm.theater_id and s.screen_id = ts.screen_id group by theater_name and screen_name";
                db_query.moive_edit(query,query1);
               common.moive_edit = true;
               Manage_moive movie = new Manage_moive();
               movie.ShowDialog();
               common.moive_edit = false;

            }
        }

        private void theater_theater_dropdown_DropDown(object sender, EventArgs e)
        {
            db_query.theater_drop();
            theater_theater_dropdown.Items.Clear();
            moive_theater_drop.Items.Clear();
            theater_screen_dropdown.Text = string.Empty;
            moive_screen_drop.Text = string.Empty;
            for (int index = 0; index < common.theater_drop.Count; index++)
            {
                theater_theater_dropdown.Items.Add(common.theater_drop[index]);
                moive_theater_drop.Items.Add(common.theater_drop[index]);
            }
        }

        private void theater_screen_dropdown_DropDown(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(theater_theater_dropdown.Text.Trim()))
            {
                db_query.screen_drop(theater_theater_dropdown.Text.Trim());
                theater_screen_dropdown.Items.Clear();
                for (int index = 0; index < common.screen_drop.Count; index++)
                {
                    theater_screen_dropdown.Items.Add(common.screen_drop[index]);
                }

            }
            else if (!string.IsNullOrEmpty(moive_theater_drop.Text.Trim()))
            {
                db_query.screen_drop(moive_theater_drop.Text.Trim());
                moive_screen_drop.Items.Clear();
                for (int index = 0; index < common.screen_drop.Count; index++)
                {
                    moive_screen_drop.Items.Add(common.screen_drop[index]);
                }



            }
            else
            {


            }

        }

        private void theater_theater_dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            theater_screen_dropdown.Items.Clear();
            theater_screen_dropdown.Text = "";
        }

        private void theater_showall_Click(object sender, EventArgs e)
        {
            db_query.search_theater("none", "");
            theater_search.DataSource = null;
            db_query.show_all_movie();
            theater_search.Columns.Clear();
            theater_search.Refresh();
            theater_search.DataSource = common.table;
            datagird_style();
        }

        private void moive_name_drop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void moive_name_drop_DropDown(object sender, EventArgs e)
        {
            db_query.movie_name_drop();
            moive_name_drop.Items.Clear();
            for (int index = 0; index < common.movie_name_drop_list.Count; index++)
            {
                moive_name_drop.Items.Add(common.movie_name_drop_list[index]);
            }
        }

        private void moive_theater_drop_TextUpdate(object sender, EventArgs e)
        {
            moive_screen_drop.Text = "";
            moive_screen_drop.Items.Clear();
        }

        private void movie_showall_Click(object sender, EventArgs e)
        {
           theater_search.DataSource = null;
          //theater_search = new DataGridView();
            db_query.show_all_movie();
            //int i=common.table.Rows.Count;
            
            theater_search.Columns.Clear();
            theater_search.Refresh();
            theater_search.DataSource = common.table;
            datagird_style();
            if (common.table.Rows.Count <= 0)
            {
                no_record.Visible = true;
            }
            else
            {
                no_record.Visible = false;
            }
        }

      

       

       
    }
}
