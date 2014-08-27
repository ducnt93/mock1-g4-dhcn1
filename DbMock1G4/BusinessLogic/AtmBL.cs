using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;
using DbMock1G4.DataAccess;

namespace DbMock1G4.BusinessLogic
{
	public class AtmBL
	{

		#region ***** Init Methods ***** 

	    readonly AtmDA _objAtmDa;
		public AtmBL()
		{
			_objAtmDa = new AtmDA();
		}
		#endregion

		#region ***** Get Methods ***** 
		//Lấy Atm theo Id
		public Atm GetByAtmId(int atmid)
		{
			return _objAtmDa.GetByAtmId(atmid);
		}

		//Lấy danh sách Amt
		public List<Atm> GetList()
		{
            // Xóa danh sach cũ và trả về 1 danh sách mới
			const string cacheName = "lstAtm";
			if( ServerCache.Get(cacheName) == null )
			{
				ServerCache.Insert(cacheName, _objAtmDa.GetList(), "Atm");
			}
			return (List<Atm>) ServerCache.Get(cacheName);
		}

		

		// Lấy danh sách theo trang
		public List<Atm> GetListPaged(int recperpage, int pageindex)
		{
			return _objAtmDa.GetListPaged(recperpage, pageindex);
		}

		#endregion

		#region ***** Add Update Delete Methods ***** 
		// Thêm 1 Atm
		public int Add(Atm objAtm)
		{
			ServerCache.Remove("Atm", true);
			return _objAtmDa.Add(objAtm);
		}

		// Sửa 1 Atm
		public void Update(Atm objAtm)
		{
			ServerCache.Remove("Atm", true);
			_objAtmDa.Update(objAtm);
		}

		// Xóa 1 ATM
		public void Delete(int atmid)
		{
			ServerCache.Remove("Atm", true);
			_objAtmDa.Delete(atmid);
		}
		#endregion
	}
}
