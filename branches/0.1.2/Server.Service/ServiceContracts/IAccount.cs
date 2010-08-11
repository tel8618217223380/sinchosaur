using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;

namespace Server.Service
{
    [ServiceContract]
   public interface IAccount
    {
        [OperationContract]
        bool Exist(string userEmail, string userPass);

        [OperationContract]
        User GetUser(string userEmail, string userPass);

        [OperationContract]
        bool Register(string userEmail, string userPass);

        [OperationContract]
        bool Delete(string userEmail, string userPass);

        

    }
}
