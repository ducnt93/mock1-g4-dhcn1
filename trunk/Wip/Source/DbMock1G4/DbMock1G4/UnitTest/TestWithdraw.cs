using System;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApplication1.UnitTest
{
    [TestClass]
    public class TestMethodWithdraw
    {
        private AccountBL accountBl = new AccountBL();
        private LogBL logBl = new LogBL();
        private StockBL stockBl = new StockBL();



        #region CheckBalance
        // Checkbalance when money > balance
        [TestMethod]
        public void CheckBalance()
        {
            int AccId = 2;
            decimal money = 1000000000;
            bool checkBalance = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsFalse(checkBalance);
        }

        // Checkbalance when money < balance but money < 50.000
        [TestMethod]
        public void CheckBalance1()
        {
            int AccId = 2;
            decimal money = 5000;
            bool checkBalance = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsFalse(checkBalance);
        }
        // Checkbalance when money > balance and money > 50.000 but money != 50.000 <> 0
        [TestMethod]
        public void CheckBalance2()
        {
            int AccId = 2;
            decimal money = 500002;
            bool checkBalance = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsFalse(checkBalance);
        }
        // Checkbalance when money > balance and money > 50.000 and money = 50.000 <> 0
        [TestMethod]
        public void CheckBalance3()
        {
            int AccId = 2;
            decimal money = 500000;
            bool checkBalance = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsTrue(checkBalance);
        }

        #endregion

        //[TestMethod]
        //public void UpdateBalance()
        //{
        //    Account account = new Account();
        //    account.AccountId = 2;
        //    account.Balance = 100000000;
        //    bool check = accountBl.UpdateBalance(account)
        //}
        #region Withdraw
        // With money = 500.000
        [TestMethod]
        public void Withdraw50()
        {
            int AccId = 2;
            decimal money = 500000;
            bool check = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsTrue(check);
        }
        [TestMethod]
        public void Withdraw100()
        {
            int AccId = 2;
            decimal money = 1000000;
            bool check = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsTrue(check);
        }
        [TestMethod]
        public void Withdraw200()
        {
            int AccId = 2;
            decimal money = 2000000;
            bool check = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsTrue(check);
        }
        [TestMethod]
        public void Withdraw250()
        {
            int AccId = 2;
            decimal money = 2500000;
            bool check = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsTrue(check);
        }
        [TestMethod]
        public void Withdraw300()
        {
            int AccId = 2;
            decimal money = 3000000;
            bool check = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsTrue(check);
        }
        // input money div to 50.000
        [TestMethod]
        public void WithdrawOrther()
        {
            int AccId = 2;
            decimal money = 3500000;
            bool check = accountBl.CheckBalanceWithDraw(AccId, money);
            Assert.IsTrue(check);
        }
        // input money not div to 50.000
        [TestMethod]
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
        [TestMethod]
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
        [TestMethod]
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
        [TestMethod]
        public void CheckMoneyAtm()
        {
            int AtmId = 1;
            decimal amount = 100000000;
            int accId = 2;
            int checkNum = stockBl.CheckMoneyAtm(AtmId, accId, amount);
            Assert.AreEqual(2, checkNum);
        }

        // When amount not div to 50.000
        [TestMethod]
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
        [TestMethod]
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
        [TestMethod]
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
