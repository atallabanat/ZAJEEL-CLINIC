using Clinics.Pharmacy;
using Clinics.pharmacy_Control;
using Clinics.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinics
{
    static class Program
    {

        public static string user_ID;
        public static string Name_User;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Open());
        }
    }
}
