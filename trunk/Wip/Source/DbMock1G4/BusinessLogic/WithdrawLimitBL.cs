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
	}
}
