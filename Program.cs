using Microsoft.Win32;
using System;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Computer_User_Management_System
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Locked instance = Global.GetGlobalLocked();
            Application.Run(instance);

        }
       

    }
}
