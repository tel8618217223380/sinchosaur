using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using Server.Service;
using NLog;
using System.Data.SqlClient;

namespace Server
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            Console.WriteLine("Sinchosaur сервер запускается");
            try
            {
                ServiceHost fileSystemHost = new ServiceHost(typeof(FileSystem));
                ServiceHost accountHost = new ServiceHost(typeof(Account));
                ServiceHost userEvents = new ServiceHost(typeof(UserEvents));
                fileSystemHost.Open();
                accountHost.Open();
                userEvents.Open();
                Account account = new Account();
                account.Exist("testuser@email.ru", "somepass");
                Console.WriteLine("Sinchosaur сервер запущен!");
                Console.WriteLine("Listening on " + fileSystemHost.BaseAddresses.First<Uri>().ToString());
                Console.WriteLine("Listening on " + accountHost.BaseAddresses.First<Uri>().ToString());
                Console.WriteLine("Listening on " + userEvents.BaseAddresses.First<Uri>().ToString());
                Console.WriteLine("Press any key to close...");
                Console.ReadKey();
                Console.WriteLine("Sinchosaur сервер завершен!");
                fileSystemHost.Close();
                accountHost.Close();
            }
            catch (AddressAlreadyInUseException)
            {
                Console.WriteLine("Порты заняты, возможно сервер уже запущен!!!");
                Console.WriteLine("Press any key to close...");
                Console.ReadKey();
            }

            catch (SqlException)
            {
                Console.WriteLine("Не могу подключиться к базе данных!!!");
                Console.WriteLine("Press any key to close...");
                Console.ReadKey();
            }

           

        }
    }
}
