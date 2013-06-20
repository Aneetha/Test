using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace Moive_shop
{
    class db_query
    {
       public static string con_str = "Data Source=192.168.0.239;Initial Catalog=MovieShop;User id=rifluxyss;Password=rifluxyss;";
         public static SqlConnection conn = new SqlConnection(con_str);
            
        public static string con_string = "Data Source=" + Application.StartupPath + "\\movieshop.s3db;UTF8Encoding=True;Version=3;Legacy Format=true ";
     public static SQLiteConnection con = new SQLiteConnection(con_string);
     
       
        public static void connection()
        {
            try
            {
                con.Open();
            }
            catch  {  }
        }
        public static void connect()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch
            {

            }
        }

        public static bool theater_update()
        {
            if (con.State.ToString().ToLower() == "closed")
            {
                connection();
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("insert into theater_master(theater_name,status,location,city,state,latitude,longitude) Values(@name,@status,@location,@city,@state,@latitude,@longitude);", conn))
                {
                    //cmd.CommandText = "insert into theater_master(theater_name,status,location,city,state,latitude,longitude) Values(@name,@status,@location,@city,@state,@latitude,@longitude);";
                    //cmd.Parameters.AddWithValue("@id", 5);
                    cmd.Parameters.AddWithValue("@name", common.theter_name);
                    cmd.Parameters.AddWithValue("@status", common.status);
                    cmd.Parameters.AddWithValue("@location", common.location);
                    cmd.Parameters.AddWithValue("@city", common.city);
                    cmd.Parameters.AddWithValue("@state", common.state);
                    cmd.Parameters.AddWithValue("@latitude", common.latitude);
                    cmd.Parameters.AddWithValue("@longitude", common.longitude);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool screen_update()
        {
            if (conn.State.ToString().ToLower() == "closed")
            {
                connect();
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT MAX(theater_id) FROM theater_master;", conn))
                {
                    common.theater_id= Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch { }
            if (common.theater_id > 0)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("insert into table_screen(theater_id,screen_name,rows,cols,status) Values(@t_id,@s_name,@rows,@cols,@status);",conn))
                    {
                        cmd.Parameters.AddWithValue("@t_id", common.theater_id);
                        cmd.Parameters.AddWithValue("@s_name", common.screen_name);
                        cmd.Parameters.AddWithValue("@rows", common.rows);
                        cmd.Parameters.AddWithValue("@cols", common.cols);
                        cmd.Parameters.AddWithValue("@status", common.status);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool screen_timing_update()
        {
            string theater_id = string.Empty;
            if (conn.State.ToString().ToLower() == "closed")
            {
                connect();
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT screen_id FROM table_screen WHERE theater_id=" + "'" + common.theater_id + "'" + " AND screen_name=" + "'" + common.screen_name + "'" + ";", conn))
                {
                    common.screen_id =Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch { }
            if (common.theater_id > 0 && common.screen_id > 0)
            {
                try
                {
                    for (int index = 0; index < common.show_timing.Count; index++)
                    {
                        using (SqlCommand cmd = new SqlCommand("insert into table_screen_timing(show_timing,theater_id,screen_id) Values(@show_time,@t_id,@s_id);", conn))
                        {
                        cmd.Parameters.AddWithValue("@show_time", common.show_timing[index]);
                        cmd.Parameters.AddWithValue("@t_id", common.theater_id);
                        cmd.Parameters.AddWithValue("@s_id", common.screen_id);
                        cmd.ExecuteNonQuery();
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool screen_category_update()
        {
            string theater_id = string.Empty;
            if (conn.State.ToString().ToLower() == "closed")
            {
                connect();
            }
            if (common.theater_id > 0 && common.screen_id > 0)
            {
                try
                {
                       for (int index = 0; index < common.category.Count; index++)
                       {
                           using (SqlCommand cmd = new SqlCommand("insert into table_category(category_name,price,theater_id,screen_id) Values(@cat_name,@price,@t_id,@s_id);", conn))
                           {
                            cmd.Parameters.AddWithValue("@cat_name", common.category[index]);
                            cmd.Parameters.AddWithValue("@price", common.price[index]);
                            cmd.Parameters.AddWithValue("@t_id", common.theater_id);
                            cmd.Parameters.AddWithValue("@s_id", common.screen_id);
                            cmd.ExecuteNonQuery();
                           }
                        }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static void theater_drop()
        {
            try
            {
                connect();
                using (SqlCommand cmd = new SqlCommand("SELECT theater_name FROM theater_master;", conn))
                {
                    using (SqlDataReader rec = cmd.ExecuteReader())
                    {
                        common.theater_drop = new List<string>();
                        while (rec.Read())
                        {
                            common.theater_drop.Add(rec.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public static void screen_drop(string theater)
        {
            try
            {
                if (conn.State.ToString().ToLower() == "closed")
                {
                    connect();
                }
                int t_id = 0;
                using (SqlCommand cmd = new SqlCommand("SELECT theater_id FROM theater_master where theater_name = '" + theater + "' ;", conn))
                {
                   t_id = Convert.ToInt32(cmd.ExecuteScalar());
                }
                using (SqlCommand cmd = new SqlCommand("SELECT screen_name FROM table_screen where theater_id = " + t_id + " ;", conn))
                {
                    using (SqlDataReader rec = cmd.ExecuteReader())
                    {
                        common.screen_drop = new List<string>();
                        while (rec.Read())
                        {
                            common.screen_drop.Add(rec.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public static void search_theater(string t_name, string s_name)
        {
            int t_id = 0;
            try
            {
                if (conn.State.ToString().ToLower() == "closed")
                {
                    connect();
                }
                
                if (!string.IsNullOrEmpty(t_name.Trim()))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT theater_id FROM theater_master where theater_name = '" + t_name + "' ;", conn))
                    {
                        using (SqlDataReader rec = cmd.ExecuteReader())
                        {
                            while (rec.Read())
                            {
                                t_id = rec.GetInt32(0);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
            try
            {
                if (!string.IsNullOrEmpty(t_name.Trim()) && !string.IsNullOrEmpty(s_name.Trim()))
                {
                    if (t_id > 0)
                    {
                        using (SqlDataAdapter adapurl = new SqlDataAdapter("SELECT t.theater_name,s.screen_name,t.location,t.city,t.status FROM theater_master t,table_screen s WHERE t.theater_id=" + "'" + t_id + "'" + "AND s.screen_name=" + "'" + s_name + "'" + " ; ", conn))
                        {
                            if (common.t_s_table != null)
                            {
                                common.t_s_table = new DataTable();
                                adapurl.Fill(common.t_s_table);
                            }
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(t_name.Trim()))
                {
                    if (t_id > 0)
                    {
                        using (SqlDataAdapter adapurl = new SqlDataAdapter("SELECT t.theater_name,s.screen_name,t.location,t.city,t.status FROM theater_master t,table_screen s WHERE t.theater_id=" + t_id + " AND s.theater_id=" + t_id + " ; ", conn))
                        {
                            if (common.t_s_table != null)
                            {
                                common.t_s_table = new DataTable();
                                adapurl.Fill(common.t_s_table);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void theater_show_all()
        {
            try
            {
                List<int> theater_ids = new List<int>();
                theater_ids.Clear();
                using (SqlCommand cmd = new SqlCommand("SELECT theater_id FROM theater_master; ", conn))
                {
                    if (conn.State.ToString().ToLower() == "closed")
                    {
                        connect();
                    }
                    using (SqlDataReader rec = cmd.ExecuteReader())
                    {
                        while (rec.Read())
                        {
                            theater_ids.Add(rec.GetInt32(0));
                        }
                    }
                }
                if (theater_ids.Count > 0)
                {
                    common.show_table.Clear();
                    common.show_table = new DataTable();
                    for (int i = 0; i < theater_ids.Count; i++)
                    {
                        using (SqlDataAdapter adapurl = new SqlDataAdapter("SELECT t.theater_name,s.screen_name,t.location,t.city,t.status FROM theater_master t,table_screen s WHERE t.theater_id=" + theater_ids[i] + " AND s.theater_id=" + theater_ids[i] + ";", conn))
                        {
                            adapurl.Fill(common.show_table);
                        }
                    }
                }
                else if (theater_ids.Count == 0)
                {
                    MessageBox.Show("No Recoreds");
                }
                // using (SQLiteDataAdapter adapurl = new SQLiteDataAdapter("SELECT t.theater_name,s.screen_name,t.location,t.city,t.status FROM theater_master as t Left Join table_screen as s on t.theater_id = s.theater_id", con))
                // {
                //     adapurl.Fill(common.show_table);
                // }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        public static void edit_text_pass()
        {
            int t_id = 0;
            try
            {
                if (conn.State.ToString().ToLower() == "closed")
                {
                    connect();
                }
                if (!string.IsNullOrEmpty(common.theter_name.Trim()))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT theater_id FROM theater_master where theater_name = '" + common.theter_name + "' ;", conn))
                    {
                        using (SqlDataReader rec = cmd.ExecuteReader())
                        {
                            while (rec.Read())
                            {
                                t_id = rec.GetInt32(0);
                            }
                        }
                    }
                }
            }
            catch { }
            int s_id = 0;
            using (SqlCommand cmd = new SqlCommand("SELECT screen_id FROM table_screen where screen_name = '" + common.screen_name + "'; ", conn))
            {
                using (SqlDataReader rec = cmd.ExecuteReader())
                {
                    while (rec.Read())
                    {
                        s_id = rec.GetInt32(0);
                    }
                }
            }
            if (!string.IsNullOrEmpty(common.theter_name.Trim()) && !string.IsNullOrEmpty(common.screen_name.Trim()))
            {
                try
                {
                    if (t_id > 0)
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT t.theater_name,s.screen_name,t.location,t.city,t.status,t.latitude,t.longitude,t.state FROM theater_master t, table_screen s where t.theater_id=" + "'" + t_id + "'" + "AND s.screen_name=" + "'" + common.screen_name + "'" + " ; ", conn))
                        {
                            using (SqlDataReader rec = cmd.ExecuteReader())
                            {
                                common.show_timing.Clear();
                                common.category.Clear();
                                common.price.Clear();
                                while (rec.Read())
                                {
                                    common.t_old_name = Convert.ToString(rec[0]);
                                    common.screen_name = Convert.ToString(rec[1]);
                                    common.location = Convert.ToString(rec[2]);
                                    common.city = Convert.ToString(rec[3]);
                                    common.state = Convert.ToString(rec[7]);
                                    common.latitude = Convert.ToString(rec[5]);
                                    common.longitude = Convert.ToString(rec[6]);
                                    common.status = Convert.ToString(rec[4]);
                                }
                            }
                            using (SqlCommand cmd1 = new SqlCommand("SELECT show_timing FROM table_screen_timing WHERE theater_id=" + "'" + t_id + "'" + " AND screen_id=" + s_id + " ; ", conn))
                            {
                                using (SqlDataReader rec1 = cmd1.ExecuteReader())
                                {
                                    while (rec1.Read())
                                    {
                                        common.show_timing.Add(rec1.GetString(0));
                                    }
                                }
                            }
                            List<int> cat_id = new List<int>();
                            common.edit_cat_id.Clear();
                            using (SqlCommand cmd2 = new SqlCommand("SELECT c.category_id,c.category_name,c.price FROM table_category c WHERE theater_id=" + "'" + t_id + "'" + " AND screen_id=" + s_id + " ; ", conn))
                            {
                                using (SqlDataReader rec2 = cmd2.ExecuteReader())
                                {
                                    while (rec2.Read())
                                    {
                                        common.edit_cat_id.Add(Convert.ToInt32(rec2[0]));
                                        common.category.Add(Convert.ToString(rec2[1]));
                                        common.price.Add(Convert.ToDecimal(rec2[2]));
                                    }
                                }
                            }
                            using (SqlCommand cmd3 = new SqlCommand("SELECT rows,cols FROM table_screen c WHERE theater_id=" + "'" + t_id + "'" + " AND screen_id=" + s_id + " ; ", conn))
                            {
                                using (SqlDataReader rec3 = cmd3.ExecuteReader())
                                {
                                    while (rec3.Read())
                                    {
                                        common.rows = rec3.GetInt32(0);
                                        common.cols = rec3.GetInt32(1);
                                    }
                                }
                            }
                            try
                            {
                                common.edit_tab_id.Clear();
                                common.order_edit_seat_no.Clear();
                                common.edit_row_name.Clear();
                                common.edit_seat_id.Clear();
                                common.edit_status.Clear();
                                common.edit_seat_no.Clear();
                                common.row_edit_seat_no.Clear();
                                common.cat_table = new DataTable();
                                for (int ind = 0; ind < common.edit_cat_id.Count; ind++)
                                {
                                    int n = Convert.ToInt32(common.edit_cat_id[ind]);
                                    using (SqlCommand cd = new SqlCommand("SELECT status,seat_no FROM table_screen_seats WHERE theater_id=" + t_id + " AND screen_id=" + s_id + " AND category_id=" + n + "; ", conn))
                                    {
                                        using (SqlDataReader rec4 = cd.ExecuteReader())
                                        {
                                            while (rec4.Read())
                                            {
                                                common.edit_seat_no.Add(Convert.ToInt32(rec4[1]));
                                                common.edit_status.Add(Convert.ToString(rec4[0]));
                                            }
                                        }
                                    }
                                }
                                using (SqlCommand cd = new SqlCommand("SELECT row_name,seat_no FROM table_screen_seats WHERE theater_id=" + t_id + " AND screen_id=" + s_id + " ORDER BY seat_no ASC; ", conn))
                                {
                                    using (SqlDataReader rec4 = cd.ExecuteReader())
                                    {
                                        while (rec4.Read())
                                        {
                                            common.row_edit_seat_no.Add(Convert.ToInt32(rec4[1]));
                                            common.edit_row_name.Add(Convert.ToString(rec4[0]));
                                        }
                                    }
                                }
                                using (SqlCommand cmndline = new SqlCommand("SELECT category_id,seat_no FROM table_screen_seats WHERE theater_id=" + t_id + " AND screen_id=" + s_id + " ORDER BY seat_no ASC;", conn))
                                {
                                    using (SqlDataReader rec4 = cmndline.ExecuteReader())
                                    {
                                        while (rec4.Read())
                                        {
                                            common.order_edit_seat_no.Add(Convert.ToInt32(rec4[1]));
                                            common.edit_tab_id.Add(Convert.ToInt32(rec4[0]));
                                        }
                                    }
                                }
                                using (SqlDataAdapter cmnd = new SqlDataAdapter("SELECT category_name,category_id FROM table_category WHERE theater_id=" + t_id + " AND screen_id=" + s_id + ";", conn))
                                {
                                    if (common.cat_table != null)
                                    {
                                        cmnd.Fill(common.cat_table);
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public static void theater_delete()
        {
            try
            {
                int t_id = 0;
                int s_id = 0;
                if (conn.State.ToString().ToLower() == "closed")
                {
                    connection();
                }
               
                using (SqlCommand cmd = new SqlCommand("SELECT theater_id FROM theater_master where theater_name = '" + common.theter_name + "'; ", conn))
                {
                    t_id = Convert.ToInt32(cmd.ExecuteScalar());
                }
                using (SqlCommand cmd = new SqlCommand("SELECT screen_id FROM table_screen where screen_name = '" + common.screen_name + "' AND theater_id=" + t_id + "; ", conn))
                {
                     s_id = Convert.ToInt32(cmd.ExecuteScalar());
                }
                //if (common.theater_del_flag == true)
                //{
                //    SQLiteCommand cmd_1 = new SQLiteCommand("DELETE  FROM theater_master where theater_id = " + t_id + "; ", con);
                //    SQLiteCommand cmd_2 = new SQLiteCommand("DELETE  FROM table_screen where screen_id = " + s_id + " AND theater_id=" + t_id + "; ", con);
                //    cmd_1.ExecuteNonQuery();
                //    cmd_2.ExecuteNonQuery();
                //}
                //if (common.theater_screen_flag == true)
                //{
                    SQLiteCommand cmd_3 = new SQLiteCommand("DELETE  FROM table_screen where screen_id = " + s_id + " AND theater_id=" + t_id + "; ", con);
                    cmd_3.ExecuteNonQuery();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public static void update_theater_detail()
        {
            try
            {
                int t_id = 0;
                int s_id = 0;
                if (con.State.ToString().ToLower() == "closed")
                {
                    connection();
                }
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT theater_id FROM theater_master where theater_name = '" + common.t_old_name + "'; ", conn))
                    {
                        SqlDataReader rec = cmd.ExecuteReader();
                        while (rec.Read())
                        {
                            common.theater_id = rec.GetInt32(0);
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT screen_id FROM table_screen where screen_name = '" + common.screen_name + "' AND theater_id=" + common.theater_id + "; ", conn))
                    {
                        SqlDataReader rec = cmd.ExecuteReader();
                        while (rec.Read())
                        {
                            common.screen_id = rec.GetInt32(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                List<int> c_id = new List<int>();
                using (SqlCommand cmd = new SqlCommand("SELECT category_id FROM table_category where screen_id = '" + common.screen_id + "' AND theater_id=" + common.theater_id + "; ", conn))
                {
                    SqlDataReader rec = cmd.ExecuteReader();
                    while (rec.Read())
                    {
                        c_id.Add(rec.GetInt32(0));
                    }
                }
                //table_screen_timing
                List<int> show_time_id = new List<int>();
                using (SqlCommand cmd = new SqlCommand("SELECT show_timing_id FROM table_screen_timing where screen_id = '" + common.screen_id + "' AND theater_id=" + common.theater_id + "; ", conn))
                {
                    SqlDataReader rec = cmd.ExecuteReader();
                    while (rec.Read())
                    {
                        show_time_id.Add(rec.GetInt32(0));
                    }
                }
                try
                {
                    using (SqlCommand cmd1 = new SqlCommand("UPDATE  theater_master  set theater_name=@name,location=@location,city=@city,status=@status,latitude=@latitude,longitude=@longitude,state=@state  WHERE theater_id=" + common.theater_id + " ; ", conn))
                    {
                        cmd1.Parameters.AddWithValue("@name", common.theter_name);
                        cmd1.Parameters.AddWithValue("@location", common.location);
                        cmd1.Parameters.AddWithValue("@city", common.city);
                        cmd1.Parameters.AddWithValue("@status", common.status);
                        cmd1.Parameters.AddWithValue("@latitude", common.latitude);
                        cmd1.Parameters.AddWithValue("@longitude", common.longitude);
                        cmd1.Parameters.AddWithValue("@state", common.state);
                        cmd1.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd2 = new SqlCommand("Update table_screen set theater_id=@t_id,screen_name=@s_name,rows=@rows,cols=@cols,status=@status where theater_id=" + common.theater_id + " AND screen_id=" + common.screen_id + ";",conn))
                    {
                        cmd2.Parameters.AddWithValue("@t_id", common.theater_id);
                        cmd2.Parameters.AddWithValue("@s_name", common.screen_name);
                        cmd2.Parameters.AddWithValue("@rows", common.rows);
                        cmd2.Parameters.AddWithValue("@cols", common.cols);
                        cmd2.Parameters.AddWithValue("@status", common.status);
                        cmd2.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                        for (int ind = 0; ind < show_time_id.Count; ind++)
                        {
                            for (int index = 0; index < common.show_timing.Count; index++)
                            {
                                using (SqlCommand cmd3 = new SqlCommand("update table_screen_timing set show_timing=@show_time,theater_id=@t_id,screen_id=@s_id where theater_id=" + common.theater_id + " AND screen_id=" + common.screen_id + " AND show_timing_id=" + show_time_id[ind] + ";",conn))
                                {
                                cmd3.Parameters.AddWithValue("@show_time", common.show_timing[index]);
                                cmd3.Parameters.AddWithValue("@t_id", common.theater_id);
                                cmd3.Parameters.AddWithValue("@s_id", common.screen_id);
                                cmd3.ExecuteNonQuery();
                                }
                            }
                        }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                SqlCommand cmd_2 = new SqlCommand("DELETE  FROM table_category where theater_id=" + common.theater_id + " AND screen_id=" + common.screen_id + "; ", conn);
                cmd_2.ExecuteNonQuery();
                try
                {
                    using (SqlCommand cmd4 = new SqlCommand("insert into table_category(category_name,price,theater_id,screen_id) Values(@cat_name,@price,@t_id,@s_id);",conn))
                    {
                        for (int index = 0; index < common.price.Count; index++)
                        {
                            cmd4.Parameters.AddWithValue("@cat_name", common.price[index]);
                            cmd4.Parameters.AddWithValue("@price", common.category[index]);
                            cmd4.Parameters.AddWithValue("@t_id", common.theater_id);
                            cmd4.Parameters.AddWithValue("@s_id", common.screen_id);
                            cmd4.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    SqlCommand cmd_1 = new SqlCommand("DELETE  FROM table_screen_seats where theater_id=" + common.theater_id + " AND screen_id=" + common.screen_id + "; ", conn);
                    cmd_1.ExecuteNonQuery();
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

        public static void timing_pannel(string theater, string screen)
        {
            try
            {
                common.screen_timing.Clear();
                if (db_query.conn.State.ToString().ToLower() == "closed")
                {
                    db_query.connection();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT st.show_timing from table_screen_timing st,theater_master t, table_screen s where t.theater_name = '" + theater + "'and s.screen_name='" + screen + "' and st.theater_id=t.theater_id and st.screen_id= s.screen_id;", conn))
                {
                    SqlDataReader rec = cmd.ExecuteReader();
                    common.movie_name_drop_list.Clear();
                    while (rec.Read())
                    {
                        common.screen_timing.Add(rec.GetString(0));
                    }
                }
            }
            catch
            {
            }

        }
        public static void movie_name_drop()
        {
            try
            {
                if (db_query.con.State.ToString().ToLower() == "closed")
                {
                    db_query.connection();
                }

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT movie_name FROM table_movie_details;", con))
                {
                    SQLiteDataReader rec = cmd.ExecuteReader();
                    common.movie_name_drop_list.Clear();
                    while (rec.Read())
                    {
                        common.movie_name_drop_list.Add(rec.GetString(0));
                    }
                }
            }
            catch
            {
            }
        }
        public static void show_all_movie()
        {
            try
            {
                using (SQLiteDataAdapter adapurl = new SQLiteDataAdapter("select m.movie_name AS'Moive Name',tm.theater_name AS 'Theater Name',sn.screen_name AS 'Screen Name',m.release_date AS'Release Date' ,m.director AS Director,m.genre AS 'Genre', m.language AS 'Language'from table_movie_details m ,  table_showing s , table_screen sn,theater_master tm where s.movie_id=m.movie_id and tm.theater_id = s.theater_id and s.screen_id=sn.screen_id;", con))
                {
                    common.table = new DataTable();
                    adapurl.Fill(common.table);
                }
                con.Close();

            }
            catch
            {
            }
        }
        public static bool check(string user, string password)
        {
            connect();
            string text = "";
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT user_name FROM table_login WHERE user_name=" + "'" + user + "'" + "AND password=" + "'" + password + "'" + "; ", conn))
                {
                    object test = cmd.ExecuteScalar();
                    if (test != null)
                    {
                        text = test.ToString();
                    }
                    //con.Close();
                }
                if (string.IsNullOrEmpty(text.Trim()))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch { return false; }
        }
        public static void manage_movie_data(string mode)
        {
            if (mode == "add")
            {
                if (common.manage_moive.Columns.Count ==0)
                {
                    common.manage_moive = new DataTable();
                    common.manage_moive.Columns.Add("moive name", typeof(string));
                    common.manage_moive.Columns.Add("release date", typeof(string));
                    common.manage_moive.Columns.Add("director", typeof(string));
                    common.manage_moive.Columns.Add("genre", typeof(string));
                    common.manage_moive.Columns.Add("written", typeof(string));
                    common.manage_moive.Columns.Add("language", typeof(string));
                    common.manage_moive.Columns.Add("runtime", typeof(string));
                    common.manage_moive.Columns.Add("image_path", typeof(string));
                    common.manage_moive.Columns.Add("video_path", typeof(string));
                    common.manage_moive.Columns.Add("featured", typeof(string));
                    common.manage_moive.Columns.Add("active", typeof(string));
                    common.manage_moive.Columns.Add("desc", typeof(string));

                    common.manage_theater.Columns.Add("theater name", typeof(string));
                    common.manage_theater.Columns.Add("screen name", typeof(string));
                    common.manage_theater.Columns.Add("from_date", typeof(string));
                    common.manage_theater.Columns.Add("to_date", typeof(string));
                    common.manage_theater.Columns.Add("timing_panel", typeof(string));
                }
            }
            else
            {

            }
            
        }
        public static void moive_edit(string query)
        {
            try
            {
                if (db_query.con.State.ToString().ToLower() == "closed")
                {
                    db_query.connection();
                }
                manage_movie_data("add");
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    SQLiteDataReader rec = cmd.ExecuteReader();
                   
                    while (rec.Read())
                    {
                        common.manage_moive.Rows.Add(rec.GetString(0), rec.GetString(1), rec.GetString(2), rec.GetString(3), rec.GetString(4), rec.GetString(5), rec.GetString(6), rec.GetString(7), rec.GetString(8), rec.GetString(9), rec.GetString(10), rec.GetString(11));
                        // common.movie_name_drop_list.Add(rec.GetString(0));
                    }
                }
            }
            catch
            {
            }

        }
        public static void moive_search(string query)
        {
            try

            {
                if (db_query.con.State.ToString().ToLower() == "closed")
                {

                    db_query.con.Open();
                }
                using (SQLiteCommand qurey_cmd = new SQLiteCommand())
                {
                    qurey_cmd.CommandText = query;
                    common.table = new DataTable();
                    common.table.Load(qurey_cmd.ExecuteReader());
                }

            }
            catch
            {
            }
        }

        //public bool login(string user, string pass)
        //{

        //    try
        //    {
        //        if (con.State.ToString().ToLower() == "closed")
        //        {
        //            connection();
        //        }

        //        string check = "";

        //        using (SQLiteCommand cmd = new SQLiteCommand("SELECT user_name FROM tbl_login where usr  = '" + user + "' AND pass  = '" + pass + "' ;", con))
        //        {
        //            SQLiteDataReader rec = cmd.ExecuteReader();
        //            while (rec.Read())
        //            {
        //                check = rec.GetString(0);
        //            }

        //        }
        //        if (string.IsNullOrEmpty(check.Trim()))
        //        {
        //        }



        //    }
        //    catch { }

        //}

       
     

  
    }
}
