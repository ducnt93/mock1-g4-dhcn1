using System;

namespace DbMock1G4.BusinessObjects
{
	public class Log
	{
		#region ***** Fields & Properties ***** 
		private int _LogId;
		public int LogId
		{ 
			get 
			{ 
				return _LogId;
			}
			set 
			{ 
				_LogId = value;
			}
		}
		private int _LogTypeId;
		public int LogTypeId
		{ 
			get 
			{ 
				return _LogTypeId;
			}
			set 
			{ 
				_LogTypeId = value;
			}
		}
		private int _AtmId;
		public int AtmId
		{ 
			get 
			{ 
				return _AtmId;
			}
			set 
			{ 
				_AtmId = value;
			}
		}
		private string _CardNo;
		public string CardNo
		{ 
			get 
			{ 
				return _CardNo;
			}
			set 
			{ 
				_CardNo = value;
			}
		}
		private  DateTime _LogDate;
		public DateTime  LogDate
		{ 
			get 
			{ 
				return _LogDate;
			}
			set 
			{ 
				_LogDate = value;
			}
		}
		private decimal _Amount;
		public decimal Amount
		{ 
			get 
			{ 
				return _Amount;
			}
			set 
			{ 
				_Amount = value;
			}
		}
		private string _Details;
		public string Details
		{ 
			get 
			{ 
				return _Details;
			}
			set 
			{ 
				_Details = value;
			}
		}
		#endregion

		#region ***** Init Methods ***** 
		public Log()
		{
		}
		public Log(int logid)
		{
			this.LogId = logid;
		}
		public Log(int logid, int logtypeid, int atmid, string cardno,DateTime  logdate, decimal amount, string details)
		{
			this.LogId = logid;
			this.LogTypeId = logtypeid;
			this.AtmId = atmid;
			this.CardNo = cardno;
			this.LogDate = logdate;
			this.Amount = amount;
			this.Details = details;
		}
		#endregion
	}
}
