using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace WebApplication1
{
    [TestClass]
    class TestViewHistory
    {
        [TestMethod]
        public void TestViewHistory_1WeekAgo()
        {
            string cardNo = "1234567890";
            LogBL logbl = new LogBL();
            List<Log> list = logbl.GetListPaged( 7, cardNo);
            Assert.IsNotNull(list);
        }
        [TestMethod]
        public void TestViewHistory_1MonthAgo()
        {
            string cardNo = "1234567890";
            LogBL logbl = new LogBL();
            List<Log> list = logbl.GetListPaged( 30, cardNo);
            Assert.IsNotNull(list);
        }
        [TestMethod]
        public void TestViewHistory_4MonthAgo()
        {
            string cardNo = "1234567890";
            LogBL logbl = new LogBL();
            List<Log> list = logbl.GetListPaged(120, cardNo);
            Assert.IsNotNull(list);
        }
        [TestMethod]
        public void TestViewHistory_6MonthAgo()
        {
            string cardNo = "1234567890";
            LogBL logbl = new LogBL();
            List<Log> list = logbl.GetListPaged(180, cardNo);
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void TestViewHistory_1YearAgo()
        {
            string cardNo = "1234567890";
            LogBL logbl = new LogBL();
            List<Log> list = logbl.GetListPaged(365, cardNo);
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void TestViewHistory_2YearAgo()
        {
            string cardNo = "1234567890";
            LogBL logbl = new LogBL();
            List<Log> list = logbl.GetListPaged(700, cardNo);
            Assert.IsNotNull(list);
        }
    }
}
