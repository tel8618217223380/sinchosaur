using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Service.Models
{
    class OperatorModel
    {
        public static readonly OperatorModel Instance = new OperatorModel();

        static OperatorModel() { }

        //проверяет существование оператора
        public bool Exist(string login, string passwd)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            int count = (from u in db.Operators
                          where u.Login == login && u.Passwd == passwd
                            select u).Count();

            if (count > 0)
                return true;
            return false;
        }
        

        //Добавляет нового пользователя
        public void AddUser(string Email, string Passwd)
        {
            throw new NotImplementedException();
        }
        

        //Удаляет пользователя
        public void DeleteUser(int UserId)
        {
            throw new NotImplementedException();
        }

    }
}
