using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdminTool.AccountServiceReference;
using System.ServiceModel;

namespace AdminTool
{
    class Account
    {
        public static Account Instance = new Account();
        private AccountClient accountManage;

        private string OperatorLogin;
        private string OperatorPassword;

        static Account() { }

        //инициализация
        public void InitProxyChannel(string serverIp)
        {
            string ServerRemoteAddress = string.Concat("http://", serverIp, "/Account/");
            accountManage = new AccountClient("BasicHttpBinding_IAccount", new EndpointAddress(ServerRemoteAddress));
        }

       
        //проверяет существование оператора
        public bool ExistOperator(string operatorLogin, string operatorPassword, string serverIp)
        {
            InitProxyChannel(serverIp);
            return accountManage.ExistOperator(operatorLogin, operatorPassword);
        }


        //сохраняет данные для подключения к серверу
        public void SaveConnectionData(string operatorLogin, string operatorPassword, string serverIp, bool storePassword )
        {
            OperatorLogin = operatorLogin;
            OperatorPassword = operatorPassword;
            Properties.Settings.Default.OperatorLogin = operatorLogin;
            Properties.Settings.Default.ServerRemoteAddress = serverIp;
            if (storePassword)
            {
                Properties.Settings.Default.OperatorPass = operatorPassword;
                Properties.Settings.Default.StoreOperatorPass = true;
            }
            else
            {
                Properties.Settings.Default.OperatorPass = "";
                Properties.Settings.Default.StoreOperatorPass = false;
            }
            Properties.Settings.Default.Save();
        }


        //возвращает пользователей постранично
        public User[] GetUsers(int page, int pageRowsCount)
        {
            return accountManage.GetAllUsers(page,  pageRowsCount, OperatorLogin, OperatorPassword);
        }


        public int GetCountUsers()
        {
            return accountManage.GetCountUsers(OperatorLogin, OperatorPassword);
        }

    }
}
