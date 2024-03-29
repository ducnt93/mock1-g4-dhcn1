﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;

namespace DbMock1G4.DataAccess
{
    public class AccountDA
    {

        #region ***** Init Methods *****
        public AccountDA()
        {
        }
        #endregion

        #region ***** Get Methods *****
        // Sử dụng 1 IDataReader để chứa dữ liệu
        public Account Populate(IDataReader myReader)
        {
            Account obj = new Account();
            obj.AccountId = (int)myReader["AccountId"];
            obj.CusId = (int)myReader["CusId"];
            obj.AccountNo = (string)myReader["AccountNo"];
            obj.OdId = (int)myReader["OdId"];
            obj.WdId = (int)myReader["WdId"];
            obj.Balance = (decimal)myReader["Balance"];
            return obj;
        }
        // 
        public Account GetByAccountId(int accountid)
        {
            
            using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Account_GetByAccountId", Data.CreateParameter("AccountId", accountid)))
            {
                if (reader.Read())
                {
                    return Populate(reader);
                }
                return null;
            }
        }


        public List<Account> GetList()
        {
            using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Account_Get"))
            {
                List<Account> list = new List<Account>();
                while (reader.Read())
                {
                    list.Add(Populate(reader));
                }
                return list;
            }
        }




        public List<Account> GetListPaged(int recperpage, int pageindex)
        {
            using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Account_GetPaged"
                            , Data.CreateParameter("recperpage", recperpage)
                            , Data.CreateParameter("pageindex", pageindex)))
            {
                List<Account> list = new List<Account>();
                while (reader.Read())
                {
                    list.Add(Populate(reader));
                }
                return list;
            }
        }


        #endregion

        #region ***** Add Update Delete Methods *****
        public void Update(Account obj)
        {
            SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Account_Update"
                            , Data.CreateParameter("AccountId", obj.AccountId)
                            , Data.CreateParameter("CusId", obj.CusId)
                            , Data.CreateParameter("AccountNo", obj.AccountNo)
                            , Data.CreateParameter("OdId", obj.OdId)
                            , Data.CreateParameter("WdId", obj.WdId)
                            , Data.CreateParameter("Balance", obj.Balance)
            );

        }

        public int UpdateBalance(Account obj)
        {
            DbParameter parameterItemID = Data.CreateParameter("AccountId", obj.AccountId);
            SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Account_UpdateBalance"
                              , Data.CreateParameter("AccountId", obj.AccountId)
                              , Data.CreateParameter("Balance", obj.Balance)
              );
            return (int)parameterItemID.Value;
        }

        #endregion
    }
}
