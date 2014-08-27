using System;

namespace DbMock1G4.BusinessObjects
{
	public class Atm
	{
		#region ***** Fields & Properties ***** 

	    public int AtmId { get; set; }

	    public string Branch { get; set; }

	    public string Address { get; set; }

	    #endregion

		#region ***** Init Methods ***** 
		public Atm()
		{
		}
		public Atm(int atmid)
		{
			this.AtmId = atmid;
		}
		public Atm(int atmid, string branch, string address)
		{
			this.AtmId = atmid;
			this.Branch = branch;
			this.Address = address;
		}
		#endregion
	}
}
