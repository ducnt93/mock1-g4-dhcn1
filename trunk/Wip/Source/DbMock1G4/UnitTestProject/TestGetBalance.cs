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
    public class TestGetBalance
    {
        readonly AccountBL accountBl = new AccountBL();
        #region GetBanlance
        // Get Balance is true
        [TestMethod]
        public void GetBalance()
        {
            int accountId = 1;
            Account account = accountBl.GetBalance(1);
            Assert.IsNull(account);
        }
        // Get Balance is false
        [TestMethod]
        public void GetBalance1()
        {
            const int accountId = 2;
            Account account = accountBl.GetBalance(accountId);
            Assert.IsNotNull(account);
        }
        #endregion
     
    }
}
