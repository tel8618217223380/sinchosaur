using Server.Service.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Server.Service;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///Это класс теста для FileModelTest, в котором должны
    ///находиться все модульные тесты FileModelTest
    ///</summary>
    [TestClass()]
    public class FileModelTest
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
        ///Тест для CreateFile
        ///</summary>
        [TestMethod()]
        public void CreateFileTest()
        {
            FileModel target = new FileModel();
            
            int userId = 2; 
            string name = "text3.txt";
            string physicalPath = @"\7d9cf1d0\8deb\4218\a455\6526947ecdda\73725d2c-7209-4bd0-8542-57d83ecd5edb.file"; 
            int directoryId = 1; 
            bool isPublic = false;
            long size = 4;
            if (target.Exist(directoryId, name, userId))
            {
                File fileInfo = target.GetFile(directoryId, name, userId);
                target.DeleteFile(fileInfo.FileId, userId);
            }
            target.CreateFile(userId, name, physicalPath, directoryId, isPublic, size);
        }

        /// <summary>
        ///Тест для DeleteFile
        ///</summary>
        [TestMethod()]
        public void DeleteFileTest()
        {
            FileModel target = new FileModel(); 
            int fileId = 0; 
            int userId = 0; 
            target.DeleteFile(fileId, userId);
        }

        /// <summary>
        ///Тест для Exist
        ///</summary>
        [TestMethod()]
        public void ExistTest()
        {
            FileModel target = new FileModel(); 
            int directoryId = 3;
            string fileName = "text2.txt"; 
            int userId = 2; 
            bool expected = true; 
            bool actual = target.Exist(directoryId, fileName, userId);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Тест для GetDirectoryFiles
        ///</summary>
        [TestMethod()]
        public void GetDirectoryFilesTest()
        {
            FileModel target = new FileModel(); 
            int directoryId = 3; 
            int userId = 2; 
            List<File> actual = target.GetDirectoryFiles(directoryId, userId);
            if (actual.Count != 2)
                Assert.Fail();
            
        }

        /// <summary>
        ///Тест для GetFile
        ///</summary>
        [TestMethod()]
        public void GetFileTest()
        {
            FileModel target = new FileModel(); 
            int directoryId = 3; 
            string fileName = "text2.txt"; 
            int userId = 2; 
            
            File actual = target.GetFile(directoryId, fileName, userId);
            if (actual.Name != fileName)
                Assert.Fail();
        }

        /// <summary>
        ///A test for IsCanUploadFile
        ///</summary>
        [TestMethod()]
        public void IsCanUploadFileTest()
        {
            FileModel target = new FileModel(); 
            int userId = 2; 
            long spaceLimit = 90000000; 
            long fileSize = 91000000; 
            bool expected = true; 
            bool actual;
            actual = target.IsCanUploadFile(userId, spaceLimit, fileSize);
            Assert.AreEqual(expected, actual);
        }
    }
}
