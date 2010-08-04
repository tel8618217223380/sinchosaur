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
    public class UserEvents : IUserEvents
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public List<EventInfo> GetEvents(string userEmail, string userPass)
        {
            User userInfo = UserModel.Instance.GetUser(userEmail, userPass);
            logger.Debug("Получение списка событий клиента: {0}", userEmail);
            return EventModel.Instance.GetEvents(userInfo.UserId);
            
        }


        public int TempFunction(string userEmail, string userPass)
        {
            return 1263;
        }
    }
}
