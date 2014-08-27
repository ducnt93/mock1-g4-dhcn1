using System;

namespace DbMock1G4.BusinessObjects
{
	public class Money
	{
		#region ***** Fields & Properties ***** 

	    public int MoneyId { get; set; }

	    public decimal MoneyValue { get; set; }

	    public string Address { get; set; }

	    #endregion

		#region ***** Init Methods ***** 
		public Money()
		{
		}
		public Money(int moneyid)
		{
			this.MoneyId = moneyid;
		}
		public Money(int moneyid, decimal moneyvalue, string address)
		{
			this.MoneyId = moneyid;
			this.MoneyValue = moneyvalue;
			this.Address = address;
		}
		#endregion
	}
}
