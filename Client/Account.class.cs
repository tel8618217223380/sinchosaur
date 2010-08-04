using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Client.ServiceReference;

namespace Client
{
    static public class Account
    {
        //возвращает Email юзера
        static public string GetUserEmail()
        {
            return Properties.Settings.Default.UserLogin;
        }
        //--------------------------------------------------------------------------------

        //возвращает пароль юзера
        static public string GetUserPass()
        {
            return Properties.Settings.Default.UserPasswd;
        }
        //--------------------------------------------------------------------------------



    }
}
