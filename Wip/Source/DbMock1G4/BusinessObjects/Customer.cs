using System;

namespace DbMock1G4.BusinessObjects
{
	public class Customer
	{
		#region ***** Fields & Properties ***** 
		private int _CusId;
		public int CusId
		{ 
			get 
			{ 
				return _CusId;
			}
			set 
			{ 
				_CusId = value;
			}
		}
		private string _Name;
		public string Name
		{ 
			get 
			{ 
				return _Name;
			}
			set 
			{ 
				_Name = value;
			}
		}
		private string _Phone;
		public string Phone
		{ 
			get 
			{ 
				return _Phone;
			}
			set 
			{ 
				_Phone = value;
			}
		}
		private string _Email;
		public string Email
		{ 
			get 
			{ 
				return _Email;
			}
			set 
			{ 
				_Email = value;
			}
		}
		private string _Addr;
		public string Addr
		{ 
			get 
			{ 
				return _Addr;
			}
			set 
			{ 
				_Addr = value;
			}
		}
		#endregion

		#region ***** Init Methods ***** 
		public Customer()
		{
		}
		public Customer(int cusid)
		{
			this.CusId = cusid;
		}
		public Customer(int cusid, string name, string phone, string email, string addr)
		{
			this.CusId = cusid;
			this.Name = name;
			this.Phone = phone;
			this.Email = email;
			this.Addr = addr;
		}
		#endregion
	}
}
