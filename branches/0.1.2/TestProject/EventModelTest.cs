using Server.Service.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Server.Service;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///Это класс теста для EventModelTest, в котором должны
    ///находиться все модульные тесты EventModelTest
    ///</summary>
    [TestClass()]
    public class EventModelTest
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
        ///Тест для CreateEvent
        ///</summary>
        [TestMethod()]
        public void CreateEventTest()
        {
            EventModel target = new EventModel(); 
            int userId = 2; 
            string description = "sdasdassadasddas"; 
            int fileId = 1033; 
            target.CreateEvent(userId, description, fileId);
        }

        /// <summary>
        ///A test for GetEvents
        ///</summary>
        [TestMethod()]
        public void GetEventsTest()
        {
            EventModel target = new EventModel(); // TODO: Initialize to an appropriate value
            int userId = 2; // TODO: Initialize to an appropriate value
            List<EventInfo> actual;
            actual = target.GetEvents(userId);
        }
    }
}
