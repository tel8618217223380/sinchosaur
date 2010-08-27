using Server.Service.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Server.Service;

namespace TestProject
{
    
    
    /// <summary>
    ///Это класс теста для UserModelTest, в котором должны
    ///находиться все модульные тесты UserModelTest
    ///</summary>
    [TestClass()]
    public class UserModelTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты теста
        // 
        //При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        //ClassInitialize используется для выполнения кода до запуска первого теста в классе
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //TestInitialize используется для выполнения кода перед запуском каждого теста
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //TestCleanup используется для выполнения кода после завершения каждого теста
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Тест для Конструктор UserModel
        ///</summary>
        public void UserModelConstructorTest()
        {
            UserModel target = new UserModel();
            Assert.Inconclusive("TODO: реализуйте код для проверки целевого объекта");
        }

        /// <summary>
        ///Тест для AddUser
        ///</summary>
        [TestMethod()]
        public void AddUserTest()
        {
            /*UserModel target = new UserModel(); 
            string Email = string.Empty; 
            string Passwd = string.Empty; 
            target.AddUser(Email, Passwd);*/
        }

        /// <summary>
        ///Тест для DeleteUser
        ///</summary>
        [TestMethod()]
        public void DeleteUserTest()
        {
            UserModel target = new UserModel(); 
            int UserId = 0; 
            target.DeleteUser(UserId);
            Assert.Inconclusive("Невозможно проверить метод, не возвращающий значение.");
        }

        /// <summary>
        ///Тест для GetUser
        ///</summary>
        [TestMethod()]
        public void GetUserTest()
        {
            UserModel target = new UserModel(); 
            string Email = "user4@email.ru"; 
            string Passwd = "pass4"; 
            User actual;
            actual = target.GetUser(Email, Passwd);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }
    }
}
