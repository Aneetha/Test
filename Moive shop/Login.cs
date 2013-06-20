using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Moive_shop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private bool drag = false;
        private Point start_point = new Point(0, 0);
        private bool draggable = true;

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

       
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.drag = true;
            this.start_point = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            this.drag = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
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

        private void Cancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void login_Click(object sender, EventArgs e)
        {

            if (validate())
            {
                if (db_query.check(User_name.Text.Trim(), password.Text.Trim()))
                {
                    Remember_Login();
                    this.Hide();
                    Main main = new Main();
                    main.Show();
                }
                else
                {

                    MessageBox.Show("Invalid Username or Password.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
           
        }

        public bool validate()
        {
            if (string.IsNullOrEmpty(User_name.Text.ToString().Trim()))
            {
                MessageBox.Show("Please enter the username.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                User_name.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(password.Text.ToString().Trim()))
            {

                MessageBox.Show("Please enter the password.", "Movie Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                password.Focus();
                return false;
            }
            else
            {
                return true;
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(common.remember_id))
            {
                int id = common.remember_id.IndexOf(":");
                User_name.Text = common.remember_id.Substring(0, id);
                password.Text = common.remember_id.Substring(id + 1);

                remember_me.Checked = true;
            }
        }
        private void Remember_Login()
        {
            try
            {
                string LogFilename = Application.StartupPath + "\\login.txt";
                if (remember_me.Checked == true && !string.IsNullOrEmpty(User_name.Text) && !string.IsNullOrEmpty(password.Text))
                {
                    string username = User_name.Text + ":" + password.Text;
                    LogFilename = Application.StartupPath + "\\login.txt";
                    try
                    {
                        if (!File.Exists(@LogFilename))
                        {
                            File.WriteAllText(@LogFilename, username);
                        }
                        else
                        {

                            File.Delete(@LogFilename);
                            File.WriteAllText(@LogFilename, username);
                        }
                    }
                    finally
                    {
                        GC.Collect();
                    }
                }
                else
                {
                    File.Delete(@LogFilename);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
      

        

       
    }
}
