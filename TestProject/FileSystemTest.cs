using Server.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///Это класс теста для FileSystemTest, в котором должны
    ///находиться все модульные тесты FileSystemTest
    ///</summary>
    [TestClass()]
    public class FileSystemTest
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
            FileSystem target = new FileSystem(); 
            int directoryId = 190; 
            bool recursive = true; 
            string userEmail = "user2@email.ru"; 
            string userPass = "pass2";

            List<MyFile> actual = target.GetDirectoryFiles(directoryId, recursive, userEmail, userPass);
           // Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для DeleteFile
        ///</summary>
        [TestMethod()]
        public void DeleteFileTest()
        {
            FileSystem target = new FileSystem(); 
            int fileId = 150;
            string userEmail ="user2@email.ru"; 
            string userPass = "pass2";
            target.DeleteFile(fileId, userEmail, userPass);
        }

        /// <summary>
        ///Тест для CreateDirectory
        ///</summary>
        [TestMethod()]
        public void CreateDirectoryTest()
        {
            FileSystem target = new FileSystem(); 
            string path = "\\folder1"; 
            string userEmail = "user2@email.ru"; 
            string userPass = "pass2"; 
            target.CreateDirectory(path, userEmail, userPass);

            path = "\\folder1\\folder1_1\\folder1_1_1";
            userEmail = "user2@email.ru";
            userPass = "pass2";
            target.CreateDirectory(path, userEmail, userPass);
        }

        /// <summary>
        ///Тест для DeleteDirectory
        ///</summary>
        [TestMethod()]
        public void DeleteDirectoryTest()
        {
            FileSystem target = new FileSystem(); 
            int directoryId = 210; 
            string userEmail = "user2@email.ru";
            string userPass = "pass2"; 
            target.DeleteDirectory(directoryId, userEmail, userPass);
        }

        /// <summary>
        ///Тест для GetAllFiles
        ///</summary>
        [TestMethod()]
        public void GetAllFilesTest()
        {
            FileSystem target = new FileSystem();
            string userEmail = "user2@email.ru";
            string userPass = "pass2"; 
            List<MyFile> expected = null; 
            List<MyFile> actual;
            actual = target.GetAllFiles(userEmail, userPass);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///Тест для Move
        ///</summary>
        [TestMethod()]
        public void MoveTest()
        {
            FileSystem target = new FileSystem(); 
            int fileId = 215; 
            int parentDirectoryId = 1; 
            int isDirectory = 1;
            string userEmail = "user2@email.ru";
            string userPass = "pass2"; 
            target.Move(fileId, parentDirectoryId, isDirectory, userEmail, userPass);
        }

        /// <summary>
        ///Тест для Move
        ///</summary>
        [TestMethod()]
        public void MoveTest1()
        {
            FileSystem target = new FileSystem(); 
            int fileId = 0; 
            int parentDirectoryId = 0; 
            int isDirectory = 0; 
            string userEmail = string.Empty; 
            string userPass = string.Empty; 
            target.Move(fileId, parentDirectoryId, isDirectory, userEmail, userPass);
            Assert.Inconclusive("Невозможно проверить метод, не возвращающий значение.");
        }

        /// <summary>
        ///Тест для Copy
        ///</summary>
        [TestMethod()]
        public void CopyTest()
        {
            FileSystem target = new FileSystem(); 
            int sourceFileId = 252; 
            int outputDirectoryId = 249; 
            int isDirectory = 1; 
            string userEmail ="user2@email.ru"; 
            string userPass = "pass2"; 
            target.Copy(sourceFileId, outputDirectoryId, isDirectory, userEmail, userPass);
            Assert.Inconclusive("Невозможно проверить метод, не возвращающий значение.");
        }

        /// <summary>
        ///Тест для CopyFile
        ///</summary>
        [TestMethod()]
        public void CopyFileTest()
        {
            FileSystem target = new FileSystem(); 
            int fileId = 1109; 
            int outputDirectoryId = 250; 
            int userId = 2; 
            target.CopyFile(fileId, outputDirectoryId, userId);
            Assert.Inconclusive("Невозможно проверить метод, не возвращающий значение.");
        }

        /// <summary>
        ///A test for GetUserDirectoryTree
        ///</summary>
        [TestMethod()]
        public void GetUserDirectoryTreeTest()
        {
            FileSystem target = new FileSystem(); 
            int userId = 2; 
            string operatorLogin = "oper1"; 
            string operatorPass = "pass1"; 
            DirectoryTree expected = new DirectoryTree(); 
            DirectoryTree actual;
            actual = target.GetUserDirectoryTree(userId, operatorLogin, operatorPass);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
