using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Service.Models
{
    class UserModel
    {
        public static readonly UserModel Instance = new UserModel();

        static UserModel() { }

        //Возвращает данные пользователя
        public User GetUser(string Email, string Passwd)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            var result = from u in db.Users
                    where u.Email == Email && u.Passwd == Passwd
                    select u;

            if (result.Count<User>() > 0)
                return (result).First<User>();
            throw new Exception("UserNotExist");
        }
        //-------------------------------------------------------------------

        //Проверяет существование пользователя
        public bool Exist(string Email, string Passwd)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            var result = from u in db.Users
                         where u.Email == Email && u.Passwd == Passwd
                         select u;

            if (result.Count<User>() > 0)
                return true;
            return false;
        }
        //-------------------------------------------------------------------


        //Добавляет нового пользователя
        public void AddUser(string Email, string Passwd)
        {
            throw new NotImplementedException();
        }
        //-------------------------------------------------------------------


        //Удаляет пользователя
        public void DeleteUser(int UserId)
        {
            throw new NotImplementedException();
        }
        //-------------------------------------------------------------------
    }
}
