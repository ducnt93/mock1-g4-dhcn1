using System;
using NUnit.Framework;
using NUnit.Framework;
using NUnit.Mocks;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using DbMock1G4.DataAccess;
namespace TestNUnit
{
    [TestFixture]
    public class TestWithdraw
    {
        private AccountBL accountBl;
        private LogBL logBl;
        private StockBL stockBl;
        [SetUp]
        protected void SetUp()
        {

            logBl = new LogBL();
            accountBl = new AccountBL();
            stockBl = new StockBL();
        }
        #region CheckBalance
        // Checkbalance when money > balance
        [Test]
        public void CheckBalance()
        {
            int AccId = 2;
            decimal money = 1000000000;
            bool checkBalance = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsFalse(checkBalance);
        }

        // Checkbalance when money < balance but money < 50.000
        [Test]
        public void CheckBalance1()
        {
            int AccId = 2;
            decimal money = 5000;
            bool checkBalance = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsFalse(checkBalance);
        }
        // Checkbalance when money > balance and money > 50.000 but money != 50.000 <> 0
        [Test]
        public void CheckBalance2()
        {
            int AccId = 2;
            decimal money = 500002;
            bool checkBalance = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsFalse(checkBalance);
        }
        // Checkbalance when money > balance and money > 50.000 and money = 50.000 <> 0
        [Test]
        public void CheckBalance3()
        {
            int AccId = 2;
            decimal money = 500000;
            bool checkBalance = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsTrue(checkBalance);
        }

        #endregion

        //[Test]
        //public void UpdateBalance()
        //{
        //    Account account = new Account();
        //    account.AccountId = 2;
        //    account.Balance = 100000000;
        //    bool check = accountBl.UpdateBalance(account)
        //}
        #region Withdraw
        // With money = 500.000
        [Test]
        public void Withdraw50()
        {
            int AccId = 2;
            decimal money = 500000;
            bool check = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsTrue(check);
        }
        [Test]
        public void Withdraw100()
        {
            int AccId = 2;
            decimal money = 1000000;
            bool check = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsTrue(check);
        }
        [Test]
        public void Withdraw200()
        {
            int AccId = 2;
            decimal money = 2000000;
            bool check = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsTrue(check);
        }
        [Test]
        public void Withdraw250()
        {
            int AccId = 2;
            decimal money = 2500000;
            bool check = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsTrue(check);
        }
        [Test]
        public void Withdraw300()
        {
            int AccId = 2;
            decimal money = 3000000;
            bool check = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsTrue(check);
        }
        // input money div to 50.000
        [Test]
        public void WithdrawOrther()
        {
            int AccId = 2;
            decimal money = 3500000;
            bool check = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsTrue(check);
        }
        // input money not div to 50.000
        [Test]
        public void WithdrawOrther1()
        {
            int AccId = 2;
            decimal money = 3500005;
            bool check = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsFalse(check);
        }
        #endregion
        #region SaveLog
        // Save log success
         [Test]
        public void SaveLog()
        {
            Log log = new Log();
            log.Amount = 500000;
            log.AtmLocation = "";
            log.CardNo = "1234567890";
            log.Details = "Rut tien";
            log.LogDate = DateTime.Now;
            log.LogTypeId = 1;
            int num = logBl.Add(log);
            Assert.AreEqual(1, num);
        }
        // Save log unsuccess
        [Test]
        public void SaveLog1()
        {
            Log log = new Log();
            log.Amount = 500000;
            log.AtmLocation = "";
            log.CardNo = "";
            log.Details = "Rut tien";
            log.LogDate = DateTime.Now;
            log.LogTypeId = 1;
            int num = logBl.Add(log);
            Assert.AreEqual(0, num);
        }
        #endregion
        #region CheckMoneyATM
        // Check money Atm when total money Atm < amount
        public AccountBL AccountBl
        {
            get { return accountBl; }
            set { accountBl = value; }
        }
        [Test]
        public void CheckMoneyAtm()
        {
            int AtmId = 1;
            decimal amount = 100000000;
            int accId = 2;
            int checkNum = stockBl.CheckMoneyAtm(AtmId,accId, amount);
            Assert.AreEqual(2, checkNum);
        }
        
        // When amount not div to 50.000
        [Test]
        public void CheckMoneyAtm1()
        {
            int AtmId = 1;
            decimal amount = 1000005;
            int accId = 2;
            int checkNum = stockBl.CheckMoneyAtm(AtmId, accId, amount);
            Assert.AreEqual(1, checkNum);
        }

        // TH1: So tien trong CSDL có 500.000 : 10 tờ. 200.000 : 10 tờ, 100.000: 10 tờ, 50.000: 10 tờ
        // Luôn đử tiền cho khách hàng rút. Khách rút: 2.950.000
        // Số tiền sẽ rút được là: 5 tờ 500.000, 2 tờ 200.000, 0 tờ 100.000 và 1 tờ 50.000
        // Giá trị cần so sánh đúng đầu ra là checkNum = 3
        [Test]
        public void CheckMoneyAtm2()
        {
            int AtmId = 1;
            decimal amount = 2950000;
            int accId = 2;
            int checkNum = stockBl.CheckMoneyAtm(AtmId, accId, amount);
            Assert.AreEqual(3, checkNum);
        }
        // TH1: So tien trong CSDL có 500.000 : 10 tờ. 200.000 : 1 tờ, 100.000: 10 tờ, 50.000: 10 tờ
        // Luôn đử tiền cho khách hàng rút. Khách rút: 2.950.000
        // Số tiền sẽ rút được là: 5 tờ 500.000, 2 tờ 200.000, 0 tờ 100.000 và 1 tờ 50.000
        // Giá trị cần so sánh đúng đầu ra là checkNum = 3
        [Test]
        public void CheckMoneyAtm3()
        {
            int AtmId = 1;
            decimal amount = 2950000;
            int accId = 2;
            int checkNum = stockBl.CheckMoneyAtm(AtmId, accId, amount);
            Assert.AreEqual(3, checkNum);
        }
        #endregion
    }
}
