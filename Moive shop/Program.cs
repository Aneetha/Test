using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Moive_shop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (File.Exists(Application.StartupPath + "\\login.txt"))
            {
                int i = 1;
                System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + "\\login.txt");
                common.remember_id = file.ReadToEnd();
                file.Dispose();
            }
            Application.Run(new Main());
        }
        
    }
}
