using Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Client.ServiceReference;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///Это класс теста для ClientFileSystemTest, в котором должны
    ///находиться все модульные тесты ClientFileSystemTest
    ///</summary>
    [TestClass()]
    public class ClientFileSystemTest
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
        ///Тест для GetDirectoryFiles
        ///</summary>
        [TestMethod()]
        public void GetDirectoryFilesTest()
        {
            ClientFileSystem target = new ClientFileSystem(); // TODO: инициализация подходящего значения
            string DirectoryName = "\\"; // TODO: инициализация подходящего значения
            List<MyFile> expected = null; // TODO: инициализация подходящего значения
            List<MyFile> actual;
            actual = target.GetDirectoryFiles(DirectoryName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }
    }
}
