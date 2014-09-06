using System;

namespace DbMock1G4.BusinessObjects
{
	public class LogType
	{
		#region ***** Fields & Properties ***** 

	    public int LogTypeId { get; set; }

	    public string Description { get; set; }

	    #endregion

		#region ***** Init Methods ***** 
		public LogType()
		{
		}
		public LogType(int logtypeid)
		{
			this.LogTypeId = logtypeid;
		}
		public LogType(int logtypeid, string description)
		{
			this.LogTypeId = logtypeid;
			this.Description = description;
		}
		#endregion
	}
}
