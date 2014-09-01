using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;
using DbMock1G4.DataAccess;
using log4net;

namespace DbMock1G4.BusinessLogic
{
    public class AccountBL
    {

        #region ***** Init Methods *****

        readonly AccountDA _objAccountDa;
        public AccountBL()
        {
            _objAccountDa = new AccountDA();
        }
        #endregion

        // check balance
        public bool CheckBalance(int accId, decimal money)
        {
                Account account = GetByAccountId(accId);
                decimal balance = account.Balance;
                if (money > balance)
                {

                    return false;
                }
                else
                {
                    if (money < 50000)
                    {
                        return false;
                    }
                    else
                    {
                        if ((money%50000) != 0)
                        {
                            return false;
                        }
                        else
                        {
                            balance = balance - money;
                            DispenserMoney(accId, balance);
                            return true;
                        }
                    }
                }
    }

        public Account GetBalance(int accId)
        {
                Account account = GetByAccountId(accId);
                return account;
        }
        public void DispenserMoney(int accId, decimal balance)
        {
            Account acc = new Account();
            acc.Balance = Convert.ToDecimal(balance);
            acc.AccountId = accId;
            UpdateBalance(acc);
        }

        private void UpdateBalance(Account acc)
        {
            _objAccountDa.UpdateBalance(acc);
        }
        #region ***** Get Methods *****
        //Lấy Account theo Id
        public Account GetByAccountId(int accountid)
        {
            return _objAccountDa.GetByAccountId(accountid);
        }

        // Lấy danh sách các Account
        public List<Account> GetList()
        {
            const string cacheName = "lstAccount";
            if (ServerCache.Get(cacheName) == null)
            {
                ServerCache.Insert(cacheName, _objAccountDa.GetList(), "Account");
            }
            return (List<Account>)ServerCache.Get(cacheName);
        }


        // Lấy dánh sách các Account theo phân trang
        public List<Account> GetListPaged(int recperpage, int pageindex)
        {
            return _objAccountDa.GetListPaged(recperpage, pageindex);
        }

        #endregion

        #region ***** Add Update Delete Methods *****
        //Thêm Account
        public int Add(Account obj_account)
        {
            ServerCache.Remove("Account", true);
            return _objAccountDa.Add(obj_account);
        }

        // Update Account
        public void Update(Account obj_account)
        {
            ServerCache.Remove("Account", true);
            _objAccountDa.Update(obj_account);
        }

        // Xóa Account
        public void Delete(int accountid)
        {
            ServerCache.Remove("Account", true);
            _objAccountDa.Delete(accountid);
        }
        #endregion
    }
}
