using System;

namespace DbMock1G4.BusinessObjects
{
	public class Stock
	{
		#region ***** Fields & Properties ***** 

	    public int StockId { get; set; }

	    public int MoneyId { get; set; }

	    public int AtmId { get; set; }

	    public int QuanlityId { get; set; }

	    #endregion

		#region ***** Init Methods ***** 
		public Stock()
		{
		}
		public Stock(int stockid)
		{
			this.StockId = stockid;
		}
		public Stock(int stockid, int moneyid, int atmid, int quanlityid)
		{
			this.StockId = stockid;
			this.MoneyId = moneyid;
			this.AtmId = atmid;
			this.QuanlityId = quanlityid;
		}
		#endregion
	}
}
