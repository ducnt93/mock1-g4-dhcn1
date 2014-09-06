using System;

namespace DbMock1G4.BusinessObjects
{
	public class Config
	{
		#region ***** Fields & Properties ***** 

	    public DateTime DateModified { get; set; }

	    public decimal MinWithdraw { get; set; }

	    public decimal MaxWithdraw { get; set; }

	    public int NumPerPage { get; set; }

	    #endregion

		#region ***** Init Methods ***** 
		public Config()
		{
		}
		public Config(DateTime datemodified, decimal minwithdraw, decimal maxwithdraw, int numperpage)
		{
			this.DateModified = datemodified;
			this.MinWithdraw = minwithdraw;
			this.MaxWithdraw = maxwithdraw;
			this.NumPerPage = numperpage;
		}
		#endregion
	}
}
