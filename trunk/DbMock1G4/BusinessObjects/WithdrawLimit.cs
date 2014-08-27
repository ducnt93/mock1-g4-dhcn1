using System;

namespace DbMock1G4.BusinessObjects
{
	public class WithdrawLimit
	{
		#region ***** Fields & Properties ***** 

	    public int WdId { get; set; }

	    public string Value { get; set; }

	    #endregion

		#region ***** Init Methods ***** 
		public WithdrawLimit()
		{
		}
		public WithdrawLimit(int wdid)
		{
			this.WdId = wdid;
		}
		public WithdrawLimit(int wdid, string value)
		{
			this.WdId = wdid;
			this.Value = value;
		}
		#endregion
	}
}
