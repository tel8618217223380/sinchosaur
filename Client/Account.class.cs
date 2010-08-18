using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Client.FileSystemServiceReference;
using Client.AccountServiceReference;
using System.Data.SqlClient;

namespace Client
{
    static public class Account
    {
        //возвращает Email юзера
        static public string GetUserEmail()
        {
            return Properties.Settings.Default.UserLogin;
        }
        

        //возвращает пароль юзера
        static public string GetUserPass()
        {
            return Properties.Settings.Default.UserPasswd;
        }
        

        //проверяет существование пользователя на сервере
        static public bool Exist()
        {
            try
            {
                AccountClient server = new AccountClient();
                return server.Exist(GetUserEmail(), GetUserPass());
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        






    }
}
