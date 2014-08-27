using System;

namespace DbMock1G4.BusinessObjects
{
	public class Account
	{
		#region ***** Fields & Properties ***** 

	    public int AccountId { get; set; }

	    public int CusId { get; set; }

	    public string AccountNo { get; set; }

	    public int OdId { get; set; }

	    public int WdId { get; set; }

	    public decimal Balance { get; set; }

	    #endregion

		#region ***** Init Methods ***** 
		public Account()
		{
		}
		public Account(int accountid)
		{
			this.AccountId = accountid;
		}
		public Account(int accountid, int cusid, string accountno, int odid, int wdid, decimal balance)
		{
			this.AccountId = accountid;
			this.CusId = cusid;
			this.AccountNo = accountno;
			this.OdId = odid;
			this.WdId = wdid;
			this.Balance = balance;
		}
		#endregion
	}
}
