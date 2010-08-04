using System;
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
