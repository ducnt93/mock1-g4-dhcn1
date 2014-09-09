using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApplication1.UnitTest
{
    [TestClass]
    public class TestCashTransfer
    {
        #region ***Lấy account từ cơ sở dữ liệu***
        [TestMethod]
        public void TestGetAccount1()
        {
            Account account = new Account();
            AccountBL accountbl = new AccountBL();
            account = accountbl.GetByAccountId(1);
            Assert.IsNotNull(account);
        }
        [TestMethod]
        public void TestGetAccount2()
        {
            Account account = new Account();
            AccountBL accountbl = new AccountBL();
            account = accountbl.GetByAccountId(2);
            Assert.IsNotNull(account);
        }
        [TestMethod]
        public void TestGetAccount3()
        {
            Account account = new Account();
            AccountBL accountbl = new AccountBL();
            account = accountbl.GetByAccountId(1000);
            Assert.IsNull(account);
        }
        [TestMethod]
        public void TestGetAccount4()
        {
            Account account = new Account();
            AccountBL accountbl = new AccountBL();
            account = accountbl.GetByAccountId(11231231);
            Assert.IsNull(account);
        }
        #endregion
        #region ***Kiểm tra tiền tài khoản***
        [TestMethod]
        public void CheckMoney1()
        {
            decimal money = 100000;
            Account account = new Account();
            AccountBL accountbl = new AccountBL();
            account = accountbl.GetByAccountId(1);
            Assert.IsTrue(accountbl.CheckBalance(account.Balance, money));
        }
        [TestMethod]
        public void CheckMoney2()
        {
            decimal money = 200000;
            Account account = new Account();
            AccountBL accountbl = new AccountBL();
            account = accountbl.GetByAccountId(2);
            Assert.IsTrue(accountbl.CheckBalance(account.Balance, money));
        }
        [TestMethod]
        public void CheckMoney3()
        {
            decimal money = 100000000;
            Account account = new Account();
            AccountBL accountbl = new AccountBL();
            account = accountbl.GetByAccountId(1);
            Assert.IsFalse(accountbl.CheckBalance(account.Balance, money));
        }
        #endregion
        #region ***Cập nhật tiền tài khoản***
        [TestMethod]
        public void CheckUpdateBalanceAccount1()
        {
            Account account = new Account();
            AccountBL accountbl = new AccountBL();
            account = accountbl.GetByAccountId(1);
            account.Balance = 10000000;  
            int i = accountbl.UpdateBalance(account);
            Assert.IsNotNull(i);
        }
         [TestMethod]
        public void CheckUpdateBalanceAccount2()
        {
            Account account = new Account();
            AccountBL accountbl = new AccountBL();
            account = accountbl.GetByAccountId(2);
            account.Balance = 100000;
            int i = accountbl.UpdateBalance(account);
            Assert.IsNotNull(i);
        }
        #endregion
        #region ***Ghi file log***
        [TestMethod]
        public void CheckWriteLog1()
         {
             Log log = new Log();
             LogBL logBl = new LogBL();
             log.Amount = 500000;
             log.AtmLocation = "";
             log.CardNo = "123";
             log.Details = "2";
             log.LogDate = DateTime.Now;
             log.LogTypeId = 2;
             log.AtmId = 1;
             int num = logBl.Add(log);
             Assert.IsNotNull(num);
         }
        #endregion
    }
}