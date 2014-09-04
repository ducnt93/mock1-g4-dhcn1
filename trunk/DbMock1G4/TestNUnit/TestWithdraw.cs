using NUnit.Framework;
using NUnit.Framework;
using NUnit.Mocks;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using  DbMock1G4.DataAccess;
namespace TestNUnit
{
    [TestFixture]
    public class TestWithdraw
    {
        private int a;
        [SetUp]
        protected void SetUp()
        {
            int a = 0;
        }
        [Test]
        public void Test()
        {
            Assert.AreEqual(0, a);
        }
        AccountBL accountBl = new AccountBL();
        #region CheckBalance
        // Checkbalance when money > balance
        [Test]
        public void CheckBalance()
        {
            AccountDA accountDa = new AccountDA();
            int AccId = 2;
            decimal money = 1000000000;
            bool check = false;
            bool checkBalance = accountBl.CheckBalanceWithDraw(AccId, money);
            // Assert.IsFalse(checkBalance);
        }

        // Checkbalance when money < balance but money < 50.000
        [Test]
        public void CheckBalance1()
        {

        }
        // Checkbalance when money > balance and money > 50.000 but money != 50.000 <> 0
        [Test]
        public void CheckBalance2()
        {

        }
        // Checkbalance when money > balance and money > 50.000 but money = 50.000 <> 0
        [Test]
        public void CheckBalance3()
        {

        }

        #endregion
      
        [Test]
        public void UpdateBalance()
        {

        }
        #region Withdraw
        // With money = 500.000
        [Test]
        public void Withdraw50()
        {

        }
        [Test]
        public void Withdraw100()
        {

        }
        [Test]
        public void Withdraw200()
        {

        }
        [Test]
        public void Withdraw250()
        {

        }
        [Test]
        public void Withdraw300()
        {

        }
        // input money div to 50.000
        [Test]
        public void WithdrawOrther()
        {

        }
        // input money not div to 50.000
        [Test]
        public void WithdrawOrther1()
        {

        }
        #endregion

        public void SaveLog()
        {
            
        }
    }
}
