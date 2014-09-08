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
	public class LogTypeBL
	{

		#region ***** Init Methods ***** 

	    readonly LogTypeDA objLogTypeDA;
		public LogTypeBL()
		{
			objLogTypeDA = new LogTypeDA();
		}
		#endregion

	}
}
