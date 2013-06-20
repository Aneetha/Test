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
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "insert into theater_master(theater_name,status,location,city,state,latitude,longitude) Values(@name,@status,@location,@city,@state,@latitude,@longitude);";
                    cmd.Parameters.AddWithValue("@name", common.theter_name);
                    cmd.Parameters.AddWithValue("@status", common.status);
                    cmd.Parameters.AddWithValue("@location", common.location);
                    cmd.Parameters.AddWithValue("@city", common.city);
                    cmd.Parameters.AddWithValue("@state", common.state);
                    cmd.Parameters.AddWithValue("@latitude", common.latitude);
                    cmd.Parameters.AddWithValue("@longitude", common.longitude);
                    cmd.ExecuteNonQuery();
                    con.Close();
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
           
            if (con.State.ToString().ToLower() == "closed")
            {
                connection();
            }

            try
            {

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT MAX(theater_id) FROM theater_master;", con))
                {
                    SQLiteDataReader rec = cmd.ExecuteReader();
                    while (rec.Read())
                    {
                        common.theater_id = rec.GetInt32(0);
                    }

                }
            }
            catch { }
            if (common.theater_id > 0)
            {
                try
                {

                    using (SQLiteCommand cmd = new SQLiteCommand(con))
                    {
                        cmd.CommandText = "insert into table_screen(theater_id,screen_name,rows,cols,status) Values(@t_id,@s_name,@rows,@cols,@status);";
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
            if (con.State.ToString().ToLower() == "closed")
            {
                connection();
            }

            
            try
            {

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT screen_id FROM table_screen WHERE theater_id=" + "'" + common.theater_id + "'" + " AND screen_name=" + "'" + common.screen_name + "'" + ";", con))
                {
                    SQLiteDataReader rec = cmd.ExecuteReader();
                    while (rec.Read())
                    {
                       common.screen_id = rec.GetInt32(0);
                    }

                }
            }
            catch { }
            if (common.theater_id > 0 && common.screen_id > 0)
            {
                try
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(con))
                    {
                        for (int index = 0; index < common.show_timing.Count; index++)
                        {
                            cmd.CommandText = "insert into table_screen_timing(show_timing,theater_id,screen_id) Values(@show_time,@t_id,@s_id);";
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
            if (con.State.ToString().ToLower() == "closed")
            {
                connection();
            }
            if (common.theater_id > 0 && common.screen_id > 0)
            {

                try
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(con))
                    {

                        for (int index = 0; index < common.category.Count; index++)
                        {
                            cmd.CommandText = "insert into table_category(category_name,price,theater_id,screen_id) Values(@cat_name,@price,@t_id,@s_id);";
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

        //theater drop down
        public static void theater_drop()
        {
            try
            {

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT theater_name FROM theater_master;", con))
                {
                    if (con.State.ToString().ToLower() == "closed")
                    {
                        connection();
                    }
                    SQLiteDataReader rec = cmd.ExecuteReader();
                    common.theater_drop.Clear();
                    while (rec.Read())
                    {
                       common.theater_drop.Add( rec.GetString(0));
                    }

                }
            }
            catch { }

        }

        public static void screen_drop(string theater)
        {
            try
            {
                if (con.State.ToString().ToLower() == "closed")
                {
                    connection();
                }
                int t_id = 0;

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT theater_id FROM theater_master where theater_name = '"+ theater+ "' ;", con))
                {
                  SQLiteDataReader rec = cmd.ExecuteReader();
                       while (rec.Read())
                    {
                           
                        t_id = rec.GetInt32(0);                       
                    }

                }
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT screen_name FROM table_screen where theater_id = " + t_id + " ;", con))
                {
                    SQLiteDataReader rec = cmd.ExecuteReader();
                    common.screen_drop.Clear();
                    while (rec.Read())
                    {
                        common.screen_drop.Add( rec.GetString(0));
                    }

                }
            }
            catch { }

        }
        public static void search_theater(string t_name, string s_name)
        {
              int t_id = 0;
            try
            {
                if (con.State.ToString().ToLower() == "closed")
                {
                    connection();
                }
              
                if (!string.IsNullOrEmpty(t_name.Trim()))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT theater_id FROM theater_master where theater_name = '" + t_name + "' ;", con))
                    {
                        SQLiteDataReader rec = cmd.ExecuteReader();
                        while (rec.Read())
                        {
                            t_id = rec.GetInt32(0);
                        }

                    }

                }
            }
            catch { }
            
                if (!string.IsNullOrEmpty(t_name.Trim()) && !string.IsNullOrEmpty(s_name.Trim()))
                {
                    if (t_id > 0)
                    {
                        using (SQLiteDataAdapter adapurl = new SQLiteDataAdapter("SELECT t.theater_name,s.screen_name,t.location,t.city,s.status FROM theater_master t,table_screen s WHERE t.theater_id=" + "'" + t_id + "'" + "AND s.screen_name=" + "'" + s_name + "'" + " ; ", con))
                        {
                            common.table = new DataTable();
                            adapurl.Fill(common.table);
                        }
                    }

                }
                else if (!string.IsNullOrEmpty(t_name.Trim()) && t_name != "none")
                {
                    if (t_id > 0)
                    {
                        using (SQLiteDataAdapter adapurl = new SQLiteDataAdapter("SELECT t.theater_name,s.screen_name,t.location,t.city,s.status FROM theater_master t,table_screen s WHERE t.theater_id=" + "'" + t_id + "'" + "AND s.theater_id=" + "'" + t_id + "'" + " ; ", con))
                        {
                            common.table = new DataTable();
                            adapurl.Fill(common.table);

                        }
                    }

                }
                else
                {
                    List<int> theater_ids = new List<int>();
                    if (t_name == "none")
                    {
                        using (SQLiteCommand cmd = new SQLiteCommand("SELECT theater_id FROM theater_master; ", con))
                        {
                            if (con.State.ToString().ToLower() == "closed")
                            {
                                connection();
                            }
                            SQLiteDataReader rec = cmd.ExecuteReader();
                            while (rec.Read())
                            {
                                theater_ids.Add(rec.GetInt32(0));
                            }
                        }

                        common.table = new DataTable();
                        for (int i = 0; i < theater_ids.Count; i++)
                        {
                            using (SQLiteDataAdapter adapurl = new SQLiteDataAdapter("SELECT t.theater_name,s.screen_name,t.location,t.city,t.status FROM theater_master t,table_screen s WHERE t.theater_id=" + theater_ids[i] + " AND s.theater_id=" + theater_ids[i] + ";", con))
                            {

                                adapurl.Fill(common.table);
                            }
                        }
                    }

                }
            

        }
        public static void timing_pannel(string theater, string screen)
        {
            try
            {
                common.screen_timing.Clear();
                if (db_query.con.State.ToString().ToLower() == "closed")
                {
                    db_query.connection();
                }

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT st.show_timing from table_screen_timing st,theater_master t, table_screen s where t.theater_name = '"+theater+"'and s.screen_name='"+screen+"' and st.theater_id=t.theater_id and st.screen_id= s.screen_id;", con))
                {
                    SQLiteDataReader rec = cmd.ExecuteReader();
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
                    con.Close();
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
                common.manage_moive = new DataTable();
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
                                  
                }
               
            }
            else
            {
                common.manage_moive = new DataTable();
                common.manage_theater = new DataTable();
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
                common.manage_theater.Columns.Add("min_date", typeof(string));
                common.manage_theater.Columns.Add("max_date", typeof(string));

            }
            
        }
        public static void moive_edit(string query, string query1)
        {
            try
            {
                if (db_query.con.State.ToString().ToLower() == "closed")
                {
                    db_query.connection();
                }
                manage_movie_data("edit");
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader rec = cmd.ExecuteReader())
                    {

                        while (rec.Read())
                        {
                            common.manage_moive.Rows.Add(rec.GetString(0), rec.GetString(1), rec.GetString(2), rec.GetString(3), rec.GetString(4), rec.GetString(5), rec.GetString(6), rec.GetString(7), rec.GetString(8), rec.GetString(9), rec.GetString(10), rec.GetString(11));
                            // common.movie_name_drop_list.Add(rec.GetString(0));
                        }
                    }
                }

                using (SQLiteCommand cmd = new SQLiteCommand(query1, con))
                {
                    using (SQLiteDataReader rec = cmd.ExecuteReader())
                    {

                        while (rec.Read())
                        {

                            common.manage_theater.Rows.Add(rec.GetString(0), rec.GetString(1), rec.GetString(2), rec.GetString(3));
                        }
                    }
                }
            }
            catch
            {
            }

        }
        public static void edit_timing(string query)
        {
            common.edit_screen_timing.Clear();
            try
            {
                if (db_query.con.State.ToString().ToLower() == "closed")
                {
                    db_query.connection();
                }
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader rec = cmd.ExecuteReader())
                    {

                        while (rec.Read())
                        {

                            common.edit_screen_timing.Add(rec.GetString(0));
                        }
                    }
                }
                int i = common.edit_screen_timing.Count;
            }
            catch { }


        }
        public static void moive_search(string query)
        {
            try

            {
                if (db_query.con.State.ToString().ToLower() == "closed")
                {

                    con.Open();
                }
                using (SQLiteCommand qurey_cmd = new SQLiteCommand(con))
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
