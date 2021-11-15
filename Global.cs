using System;
using System.Collections.Generic;
using System.Text;

namespace Computer_User_Management_System
{
    static class Global
    {
        private static Locked locked = new Locked();
        public static string activeuser;

        public static void setactiveuser(string id)
        {
            activeuser = id;
        }

        public static string getactiveuser()
        {
            return activeuser;
        }

        public static Locked GetGlobalLocked()
        {
            return locked;
        }
    }
}
