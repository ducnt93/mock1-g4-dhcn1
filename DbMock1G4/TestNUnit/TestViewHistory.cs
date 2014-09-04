using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using NUnit.Framework;

namespace TestNUnit
{
    [TestFixture]
    class TestViewHistory
    {
        [Test]
        public void TestViewHistory_1WeekAgo()
        {
            string cardNo = "1234567890";
            LogBL logbl=new LogBL();
            List<Log> list = logbl.GetListPaged(1, 5, 7, cardNo);
            Assert.IsNotNull(list);
        }
        [Test]
        public void TestViewHistory_1MonthAgo()
        {
            string cardNo = "1234567890";
            LogBL logbl = new LogBL();
            List<Log> list = logbl.GetListPaged(1, 5, 30, cardNo);
            Assert.IsNotNull(list);
        }
        [Test]
        public void TestViewHistory_4MonthAgo()
        {
            string cardNo = "1234567890";
            LogBL logbl = new LogBL();
            List<Log> list = logbl.GetListPaged(1, 5, 120, cardNo);
            Assert.IsNotNull(list);
        }
        [Test]
        public void TestViewHistory_6MonthAgo()
        {
            string cardNo = "1234567890";
            LogBL logbl = new LogBL();
            List<Log> list = logbl.GetListPaged(1, 5, 180, cardNo);
            Assert.IsNotNull(list);
        }

        [Test]
        public void TestViewHistory_1YearAgo()
        {
            string cardNo = "1234567890";
            LogBL logbl = new LogBL();
            List<Log> list = logbl.GetListPaged(1, 5, 365, cardNo);
            Assert.IsNotNull(list);
        }

        [Test]
        public void TestViewHistory_2YearAgo()
        {
            string cardNo = "1234567890";
            LogBL logbl = new LogBL();
            List<Log> list = logbl.GetListPaged(1, 5, 700, cardNo);
            Assert.IsNotNull(list);
        }
    }
}
