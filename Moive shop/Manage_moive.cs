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
    public partial class Manage_moive : Form
    {
       
        public Manage_moive()
        {

            InitializeComponent();
            
        }
        private bool drag = false;
        private Point start_point = new Point(0, 0);
        private bool draggable = true;
        public int row_count = 0;
        public int col_count = 0;
        string calender_mode="";
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
      

        private void manage_moive_Load(object sender, EventArgs e)
        {
           // movie_info_normal.Visible = false;
           // movie_info_panel.Parent = panel1;
           // theater_info_panel.Parent = panel1;
           // preview_panel.Parent = panel1;
           // theater_info_panel.Visible = false;
           //this. theater_info_panel.Location = new Point(11,123);
           //this .movie_info_panel.Location = new Point(11,123);
           //this.preview_panel.Location = new Point(11, 123);
            if (common.moive_edit)
            {
                movie_name_txt.Text = common.manage_moive.Rows[0].ItemArray[0].ToString();
                 release_date_txt.Text = common.manage_moive.Rows[0].ItemArray[1].ToString();
                 director_txt.Text = common.manage_moive.Rows[0].ItemArray[2].ToString();
                genre_txt.Text = common.manage_moive.Rows[0].ItemArray[3].ToString();
                written_txt.Text =common.manage_moive.Rows[0].ItemArray[4].ToString();
                lang_txt.Text = common.manage_moive.Rows[0].ItemArray[5].ToString();
                 runtime_txt.Text = common.manage_moive.Rows[0].ItemArray[6].ToString();
                 movie_img_txt.Text = common.manage_moive.Rows[0].ItemArray[7].ToString();
                 movie_video_txt.Text = common.manage_moive.Rows[0].ItemArray[8].ToString();

                 desc_txt.Text = common.manage_moive.Rows[0].ItemArray[11].ToString();

            }
           

            
        }

        private void movie_info_normal_Click(object sender, EventArgs e)
        {
            //movie_info_normal.Visible = false;
            //theater_info_normal.Visible = true;
            //preview_normal.Visible = true;
            //theater_info_panel.Visible = false;
            //movie_info_panel.Visible = true;
            //preview_panel.Visible = false;
            
        }

        private void preview_normal_Click(object sender, EventArgs e)
        {
            movie_preview preview = new movie_preview();
            this.Hide();
            preview.ShowDialog();
            //movie_info_normal.Visible = true;
            //theater_info_normal.Visible = true;
            //preview_normal.Visible = false;
            //preview_panel.Visible = true;
            //movie_info_panel.Visible = false;
            //theater_info_panel.Visible = false;
            
        }

      
        
        private void theater_info_normal_Click(object sender, EventArgs e)
        {
            //movie_info_normal.Visible = true;
            //theater_info_normal.Visible = false;
            //preview_normal.Visible = true;
            //movie_info_panel.Visible = false;
            //theater_info_panel.Visible = true;
            //preview_panel.Visible = false;
           // db_query.manage_movie_data("add");
            //common.manage_moive.Rows.Add(movie_name_txt.Text, release_date_txt.Text, director_txt.Text,genre_txt.Text, written_txt.Text, lang_txt.Text, runtime_txt.Text, movie_img_txt.Text, movie_video_txt.Text,true,0,desc_txt.Text);
            //common.manage_moive.Rows.Add("","","","","","","","","",true,0,"");
            if (validate("add"))
            {
                if (common.movie_theater != null)
                {
                    this.Hide();
                    common.movie = null;
                    common.movie = this;
                    common.movie_theater.ShowDialog();


                }
                else
                {
                    this.Hide();
                    common.movie = null;
                    common.movie = this;
                    Moive_add_theater theater = new Moive_add_theater();
                    theater.ShowDialog();

                }
            }
           

            
            //form2.Show();
           

        
            
        }

       

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void close_Click(object sender, EventArgs e)
        {
            common.movie = null;
            common.movie_theater = null;
            common.movie_preview = null;
            
            
            this.Close();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            release_date_txt.Text = e.Start.Date.ToShortDateString();
            monthCalendar1.Visible = false;
        }

        

        

        private void from_date_Click(object sender, EventArgs e)
        {
            //calender.Visible = true;
            //calender.BringToFront();
            //calender.Location = new System.Drawing.Point(from_date.Location.X, from_date.Location.Y);
            //calender_mode = "from";
           
        }

        private void to_date_Click(object sender, EventArgs e)
        {
        //    calender.Visible = true;
        //    calender.BringToFront();
        //    calender.Location = new System.Drawing.Point(to_date.Location.X - 100, to_date.Location.Y);
        //    calender_mode = "to";
        //    calender.Visible = true;
            
            
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

        private void calender_DateSelected(object sender, DateRangeEventArgs e)
        {
            //if (calender_mode == "from")
            //    from_txt.Text = e.Start.Date.ToShortDateString();
            //if (calender_mode == "to")
            //    to_txt.Text = e.Start.Date.ToShortDateString();

            //calender.Visible = false;
        }
        private bool validate(string mode)
        {
            if (string.IsNullOrEmpty(movie_name_txt.Text.Trim()))
            {
                MessageBox.Show("Please enter a movie name.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                movie_name_txt.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(release_date_txt.Text.Trim()))
            {
                MessageBox.Show("Please enter a release date.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                release_date_txt.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(director_txt.Text.Trim()))
            {
                MessageBox.Show("Please enter a director.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                director_txt.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(genre_txt.Text.Trim()))
            {
                MessageBox.Show("Please enter a genre.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                genre_txt.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(lang_txt.Text.Trim()))
            {
                MessageBox.Show("Please enter the language.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lang_txt.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(runtime_txt.Text.Trim()))
            {
                MessageBox.Show("Please enter runtime.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                runtime_txt.Focus();
                return false;
            }
            else
            {
                if (mode == "add")
                {
                    string featured = "no";
                    string active = "active";
                    if (checkBox1.Checked == true)
                    {
                        featured = "yes";  
                    }

                    if (radioButton2.Checked == true)
                    {
                        active = "inactive";
                    }

                    db_query.manage_movie_data("add");
                   common.manage_moive.Rows.Add(movie_name_txt.Text, release_date_txt.Text, director_txt.Text,genre_txt.Text, written_txt.Text, lang_txt.Text, runtime_txt.Text, movie_img_txt.Text, movie_video_txt.Text,featured,active,desc_txt.Text);
                    //db_query.movie_details_add();
                }
                return true;
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if (validate("add"))
            {
                theater_info_normal_Click(theater_info_normal, null);
            }
            
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void movie_video_txt_TextChanged(object sender, EventArgs e)
        {

        }

      
    }
}
