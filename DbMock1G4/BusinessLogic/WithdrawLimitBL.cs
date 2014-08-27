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
	public class WithdrawLimitBL
	{

		#region ***** Init Methods ***** 

	    readonly WithdrawLimitDA _objWithdrawLimitDa;
		public WithdrawLimitBL()
		{
			_objWithdrawLimitDa = new WithdrawLimitDA();
		}
		#endregion

		#region ***** Get Methods ***** 
		
		public WithdrawLimit GetByWdId(int wdid)
		{
			return _objWithdrawLimitDa.GetByWdId(wdid);
		}

	
		public List<WithdrawLimit> GetList()
		{
			const string cacheName = "lstWithdrawLimit";
			if( ServerCache.Get(cacheName) == null )
			{
				ServerCache.Insert(cacheName, _objWithdrawLimitDa.GetList(), "WithdrawLimit");
			}
			return (List<WithdrawLimit>) ServerCache.Get(cacheName);
		}

	
		public List<WithdrawLimit> GetListPaged(int recperpage, int pageindex)
		{
			return _objWithdrawLimitDa.GetListPaged(recperpage, pageindex);
		}

		#endregion

		#region ***** Add Update Delete Methods ***** 
	
		public int Add(WithdrawLimit objWithdrawlimit)
		{
			ServerCache.Remove("WithdrawLimit", true);
			return _objWithdrawLimitDa.Add(objWithdrawlimit);
		}

	
		public void Update(WithdrawLimit objWithdrawlimit)
		{
			ServerCache.Remove("WithdrawLimit", true);
			_objWithdrawLimitDa.Update(objWithdrawlimit);
		}

		
		public void Delete(int wdid)
		{
			ServerCache.Remove("WithdrawLimit", true);
			_objWithdrawLimitDa.Delete(wdid);
		}
		#endregion
	}
}
