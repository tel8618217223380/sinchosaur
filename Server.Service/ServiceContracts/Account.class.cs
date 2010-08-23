﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.ServiceModel;
using Server.Service.Models;
using NLog;


namespace Server.Service
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Account : IAccount
    {
        
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public bool Exist(string userEmail, string userPass)
        {
            return UserModel.Instance.Exist(userEmail, userPass);
        }


        public bool ExistOperator(string login, string password)
        {
            logger.Info("Проверка сущуствания оператора: {0}", login);
            return OperatorModel.Instance.Exist(login, password);
        }


        //возвращает список пользователей
        public List<User> GetAllUsers(int page, int pageRowsCount, string operatorLogin, string operatorPass)
        {
            return UserModel.Instance.GetAllUsers(page, pageRowsCount);
        }


        public bool Register(string userEmail, string userPass)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string userEmail, string userPass)
        {
            throw new NotImplementedException();
        }


        public User GetUser(string userEmail, string userPass)
        {
            throw new NotImplementedException();
        }
    }
}
