using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;

namespace Server.Service
{
   [ServiceContract]
   public interface IUserEvents
    {
       [OperationContract]
       List<EventInfo> GetEvents(string userEmail, string userPass);

       [OperationContract]
       int TempFunction(string userEmail, string userPass);

    }
}
