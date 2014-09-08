using System;
using System.Collections.Generic;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApplication1.UnitTest
{
    [TestClass]
    public class TestViewHistory
    {
        [TestMethod]
        public void TestViewHistory_1WeekAgo()
        {
            string cardNo = "1234567890";
            LogBL logbl = new LogBL();
            List<Log> list = logbl.GetListPaged( 7, cardNo);
            int number= list.Count;
            Assert.AreEqual(0,number);
        }
        [TestMethod]
        public void TestViewHistory_1MonthAgo()
        {
            string cardNo = "1234567890";
            LogBL logbl = new LogBL();
            List<Log> list = logbl.GetListPaged( 30, cardNo);
            int number = list.Count;
            Assert.AreEqual(2,number);
        }
        [TestMethod]
        public void TestViewHistory_4MonthAgo()
        {
            string cardNo = "1234567890";
            LogBL logbl = new LogBL();
            List<Log> list = logbl.GetListPaged(120, cardNo);
            int number = list.Count;
            Assert.AreEqual(7, number);
        }
        [TestMethod]
        public void TestViewHistory_6MonthAgo()
        {
            string cardNo = "1234567890";
            LogBL logbl = new LogBL();
            List<Log> list = logbl.GetListPaged(180, cardNo);
            int number = list.Count;
            Assert.AreEqual(7, number);
        }

        [TestMethod]
        public void TestViewHistory_1YearAgo()
        {
            string cardNo = "1234567890";
            LogBL logbl = new LogBL();
            List<Log> list = logbl.GetListPaged(365, cardNo);
            int number = list.Count;
            Assert.AreEqual(8, number);
        }

        [TestMethod]
        public void TestViewHistory_2YearAgo()
        {
            string cardNo = "1234567890";
            LogBL logbl = new LogBL();
            List<Log> list = logbl.GetListPaged(700, cardNo);
            int number = list.Count;
            Assert.AreEqual(10, number);
        }
    }
}
