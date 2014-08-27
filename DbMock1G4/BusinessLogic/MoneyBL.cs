using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;
using DbMock1G4.DataAccess;

namespace DbMock1G4.BusinessLogic
{
	public class MoneyBL
	{

		#region ***** Init Methods ***** 

	    readonly MoneyDA objMoneyDA;
		public MoneyBL()
		{
			objMoneyDA = new MoneyDA();
		}
		#endregion

		#region ***** Get Methods ***** 
		// lấy Money theo Id
		public Money GetByMoneyId(int moneyid)
		{
			return objMoneyDA.GetByMoneyId(moneyid);
		}

		// Lấy danh sách
		public List<Money> GetList()
		{
			string cacheName = "lstMoney";
			if( ServerCache.Get(cacheName) == null )
			{
				ServerCache.Insert(cacheName, objMoneyDA.GetList(), "Money");
			}
			return (List<Money>) ServerCache.Get(cacheName);
		}

		

		// Lấy dánh sách theo phân trang
		public List<Money> GetListPaged(int recperpage, int pageindex)
		{
			return objMoneyDA.GetListPaged(recperpage, pageindex);
		}

	
		#endregion

		#region ***** Add Update Delete Methods ***** 
		// Thêm mới
		public int Add(Money objMoney)
		{
			ServerCache.Remove("Money", true);
			return objMoneyDA.Add(objMoney);
		}

		//  Sửa
		public void Update(Money objMoney)
		{
			ServerCache.Remove("Money", true);
			objMoneyDA.Update(objMoney);
		}

		// Xóa
		public void Delete(int moneyid)
		{
			ServerCache.Remove("Money", true);
			objMoneyDA.Delete(moneyid);
		}
		#endregion
	}
}
