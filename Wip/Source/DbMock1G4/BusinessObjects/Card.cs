using System;

namespace DbMock1G4.BusinessObjects
{
	public class Card
	{
		#region ***** Fields & Properties ***** 

	    public string CardNo { get; set; }

	    public string Status { get; set; }

	    public int AccountId { get; set; }

	    public string Pin { get; set; }

	    public DateTime StartDate { get; set; }

	    public DateTime ExpiredDate { get; set; }

	    public int Attempt { get; set; }

	    #endregion

		#region ***** Init Methods ***** 
		public Card()
		{
		}
		public Card(string cardno)
		{
			this.CardNo = cardno;
		}
        public Card(string cardno, string status, int accountid, string pin, DateTime startdate, DateTime expireddate, int attempt)
		{
			this.CardNo = cardno;
			this.Status = status;
			this.AccountId = accountid;
			this.Pin = pin;
			this.StartDate = startdate;
			this.ExpiredDate = expireddate;
			this.Attempt = attempt;
		}
		#endregion
	}
}
