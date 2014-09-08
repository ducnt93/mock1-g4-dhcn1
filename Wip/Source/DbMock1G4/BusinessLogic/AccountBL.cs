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
        public bool CheckBalanceWithDraw(int accId, decimal money)
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
                    if ((money % 50000) != 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public bool CheckBalance(decimal balance, decimal money)
        {
            if (balance < money)
            {
                return false;
            }
            return true;
        }

        public Account CheckAcc(int ID)
        {
            Account Account = GetByAccountId(ID);
            return Account;
        }

        public Account GetBalance(int accId)
        {
            Account account = GetByAccountId(accId);
            return account;
        }
        public int DispenserMoney(int accId, decimal balance)
        {
            int num = 0;
            Account acc = new Account();
            acc.Balance = Convert.ToDecimal(balance);
            acc.AccountId = accId;
            num = UpdateBalance(acc);
            return num;
        }

        public int UpdateBalance(Account acc)
        {
            return _objAccountDa.UpdateBalance(acc);
        }
        #region ***** Get Methods *****
        //Lấy Account theo Id
        public Account GetByAccountId(int accountid)
        {
            return _objAccountDa.GetByAccountId(accountid);
        }
        #endregion

        #region ***** Add Update Delete Methods *****
    
        // Update Account
        public void Update(Account obj_account)
        {
            ServerCache.Remove("Account", true);
            _objAccountDa.Update(obj_account);
        }

       
        #endregion
    }
}
