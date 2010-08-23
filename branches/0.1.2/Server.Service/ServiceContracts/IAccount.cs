using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;

namespace Server.Service
{
    [ServiceContract]
   public interface IAccount
    {
        //проверяет существование пользователя
        [OperationContract]
        bool Exist(string userEmail, string userPass);

        //проверяет существование оператора
        [OperationContract]
        bool ExistOperator(string login, string password);


        //возвращает количество пользователей
        [OperationContract]
        int GetCountUsers(string login, string password);

        //возвращает список пользователей по странично 
        [OperationContract]
        List<User> GetAllUsers(int page, int pageRowsCount, string operatorLogin, string operatorPass);

        [OperationContract]
        User GetUser(string userEmail, string userPass);

        [OperationContract]
        bool Register(string userEmail, string userPass);

        [OperationContract]
        bool Delete(string userEmail, string userPass);

        

    }
}
