using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Moive_shop
{
    class common
    {
        //theater managament
        public static string theter_name = null;
        public static string screen_name = null;
        public static string location = null;
        public static string city = null;
        public static string state = null;
        public static string latitude = null;
        public static string longitude = null;
        public static List<string> show_timing = new List<string>();
        public static string status = "0";
        public static List<string> category = new List<string>();
        public static List<decimal> price = new List<decimal>();
        public static int rows = 0;
        public static int cols = 0;

        public static int theater_id;
        public static int screen_id ;
        public static int category_id;
        public static List<string> movie_name_drop_list = new List<string>();
        public static DataTable dt = new DataTable();

        public static List<string> theater_drop = new List<string>();
        public static List<string> screen_drop = new List<string>();
        public static List<string> screen_timing = new List<string>();
        public static DataTable table = new DataTable();
        public static string remember_id = string.Empty;
        public static DataTable manage_moive = new DataTable();
        public static DataTable manage_theater = new DataTable();
        public static Form movie;
        public static Form movie_theater;
        public static Form movie_preview;
        public static bool moive_edit = false;

      
     
       
       

       
       

        //..........................................................
        public static DataTable t_s_table = new DataTable();
        public static DataTable show_table = new DataTable();
        public static bool edit_flag = false;


        public static List<int> edit_seat_id = new List<int>();
        public static List<string> edit_status = new List<string>();
        public static List<string> edit_row_name = new List<string>();
        public static List<int> edit_seat_no = new List<int>();
        public static List<int> order_edit_seat_no = new List<int>();
        public static List<int> row_edit_seat_no = new List<int>();
        public static List<int> edit_cat_id = new List<int>();
        public static List<int> tab_cat_id = new List<int>();
        public static List<int> edit_tab_id = new List<int>();
        public static List<string> edit_cat_name = new List<string>();
        public static DataTable cat_table = new DataTable();



        public static List<string> categories_list = new List<string>();
        public static List<string> show_timing_list = new List<string>();
        public static string t_old_name = null;
        public static string theater_drop_name = null;

        public static bool m_edit_flag = false;
    }
}
