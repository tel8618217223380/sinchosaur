using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using Server.Service;
using NLog;

namespace Server
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            ServiceHost fileSystemHost = new ServiceHost(typeof(FileSystem));
            ServiceHost accountHost = new ServiceHost(typeof(Account));
            ServiceHost userEvents = new ServiceHost(typeof(UserEvents));
            fileSystemHost.Open();
            accountHost.Open();
            userEvents.Open();

            Console.WriteLine("Sinchronize сервер запущен!");
            Console.WriteLine("Listening on " + fileSystemHost.BaseAddresses.First<Uri>().ToString());
            Console.WriteLine("Listening on " + accountHost.BaseAddresses.First<Uri>().ToString());
            Console.WriteLine("Listening on " + userEvents.BaseAddresses.First<Uri>().ToString());
            Console.WriteLine("Click any key to close...");
            Console.ReadKey();
            Console.WriteLine("Sinchronize сервер завершен!");
            fileSystemHost.Close();
            accountHost.Close();

        }
    }
}
