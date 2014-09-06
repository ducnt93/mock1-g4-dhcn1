using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApplication1.UnitTest
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
