using System;

namespace DbMock1G4.BusinessObjects
{
	public class OverDraft
	{
		#region ***** Fields & Properties ***** 

	    public int OdId { get; set; }

	    public string Value { get; set; }

	    #endregion

		#region ***** Init Methods ***** 
		public OverDraft()
		{
		}
		public OverDraft(int odid)
		{
			this.OdId = odid;
		}
		public OverDraft(int odid, string value)
		{
			this.OdId = odid;
			this.Value = value;
		}
		#endregion
	}
}
