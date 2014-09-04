using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;

namespace TestNUnit
{
    [TestFixture]
    public class TestGetBalance
    {
        readonly AccountBL accountBl = new AccountBL();
        #region GetBanlance
        // Get Balance is true
        [Test]
        public void GetBalance()
        {
            const int accountId = 1;
            Account account = accountBl.GetBalance(accountId);
            Assert.IsNotNull(account);
        }
        // Get Balance is false
        [Test]
        public void GetBalance1()
        {
            const int accountId = 16;
            Account account = accountBl.GetBalance(accountId);
            Assert.IsNotNull(account);
        }
        #endregion
     
    }
}
