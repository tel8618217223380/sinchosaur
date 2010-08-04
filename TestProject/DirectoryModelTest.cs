using Server.Service.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Server.Service;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///Это класс теста для DirectoryModelTest, в котором должны
    ///находиться все модульные тесты DirectoryModelTest
    ///</summary>
    [TestClass()]
    public class DirectoryModelTest
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
        ///Тест для Конструктор DirectoryModel
        ///</summary>
        [TestMethod()]
        public void DirectoryModelConstructorTest()
        {
            DirectoryModel target = new DirectoryModel();
       
        }

        /// <summary>
        ///Тест для CreateDirectory
        ///</summary>
        [TestMethod()]
        public void CreateDirectoryTest()
        {
            DirectoryModel target = new DirectoryModel();
            if(target.Exist(@"\test2\test4",2))
            {
                Directory directoryInfo = target.GetDirectory(@"\test2\test4",2);
                target.DeleteDirectory(directoryInfo.DirectoryId, 2);
            }
            int userId = 2; 
            string patch = @"\test2\test4"; 
            bool isPublic = false; 
            target.CreateDirectory(userId, patch, isPublic);
        }

        /// <summary>
        ///Тест для DeleteDirectory
        ///</summary>
        [TestMethod()]
        public void DeleteDirectoryTest()
        {
            DirectoryModel target = new DirectoryModel(); 
            int direstoryId = 8; 
            int userId = 2; 
            target.DeleteDirectory(direstoryId, userId);
        }

        /// <summary>
        ///Тест для Exist
        ///</summary>
        [TestMethod()]
        public void ExistTest()
        {
            DirectoryModel target = new DirectoryModel();
            string path = @"\test1\test2"; 
            int userId = 2; 
            bool expected = true; 
            bool actual = target.Exist(path, userId);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Тест для GetChildDirectories
        ///</summary>
        [TestMethod()]
        public void GetChildDirectoriesTest()
        {
            DirectoryModel target = new DirectoryModel();
            int parentId = 2; 
            int userId = 2; 
            
            List<Directory>  actual = target.GetChildDirectories(parentId, userId);
            if (actual.Count != 2)
                Assert.Fail();
            
        }

        /// <summary>
        ///Тест для GetDirectory
        ///</summary>
        [TestMethod()]
        public void GetDirectoryTest()
        {
            DirectoryModel target = new DirectoryModel(); 
            string patch = "\\test1"; 
            int userId = 2; 

            Directory actual = target.GetDirectory(patch, userId);
            if (actual.DirectoryId !=2)
                Assert.Fail();
        }



        /// <summary>
        ///Тест для GetParentDirectory
        ///</summary>
        [TestMethod()]
        public void GetParentDirectoryTest()
        {
            DirectoryModel target = new DirectoryModel(); 
            int userId = 2; 
            string patch = @"\test2\test3";

            Directory actual = target.GetParentDirectory(patch, userId);
            if (actual.DirectoryId != 7)
                Assert.Fail();
        }

        /// <summary>
        ///Тест для GetDirectoryPath
        ///</summary>
        [TestMethod()]
        public void GetDirectoryPathTest()
        {
            DirectoryModel target = new DirectoryModel(); 
            int directoryId = 194; 
            int userId = 2; 
            string expected = string.Empty; 
            string actual;
            actual = target.GetDirectoryPath(directoryId, userId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для ExistDirectoryInMovedPath
        ///</summary>
        [TestMethod()]
        public void ExistDirectoryInMovedPathTest()
        {
            DirectoryModel target = new DirectoryModel(); 
            int directoryId = 213; 
            int outDirectoryId = 215; 
            int userId = 2; 
            
            if(!target.ExistDirectoryInMovedPath(directoryId, outDirectoryId, userId))
                Assert.Fail();

            directoryId = 214;
            outDirectoryId = 198;

            if (target.ExistDirectoryInMovedPath(directoryId, outDirectoryId, userId))
                Assert.Fail();
        }
    }
}
