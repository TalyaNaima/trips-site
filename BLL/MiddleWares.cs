using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MiddleWares
    {
        //בדיקת תקינות שם
        public static bool CheckName(string name)
        {
            if(name.Length > 1)
                return true;
            return false;
        }

        //בדיקת תקינות מייל
        public static bool CheckEmail(string email)
        {
            if (email.Length > 1)
                return true;
            return false;
        }

        //בדיקת תקינות פלאפון
        public static bool CheckPhone(string phone)
        {
            if (phone.Length > 1)
                return true;
            return false;
        }

        //בדיקת תקינות סיסמה
        public static bool CheckPassword(string password)
        {
            if (password.Length > 1)
                return true;
            return false;
        }
    }
}
