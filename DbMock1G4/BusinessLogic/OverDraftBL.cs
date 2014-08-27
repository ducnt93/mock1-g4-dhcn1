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
	public class OverDraftBL
	{

		#region ***** Init Methods ***** 

	    readonly OverDraftDA objOverDraftDA;
		public OverDraftBL()
		{
			objOverDraftDA = new OverDraftDA();
		}
		#endregion

		#region ***** Get Methods ***** 
		// Lấy overDraft theo Id
		public OverDraft GetByOdId(int odid)
		{
			return objOverDraftDA.GetByOdId(odid);
		}

		//Lấy ra danh sách OverDraft
		public List<OverDraft> GetList()
		{
			const string cacheName = "lstOverDraft";
			if( ServerCache.Get(cacheName) == null )
			{
				ServerCache.Insert(cacheName, objOverDraftDA.GetList(), "OverDraft");
			}
			return (List<OverDraft>) ServerCache.Get(cacheName);
		}

		// Lấy danh sách theo phân trang
		public List<OverDraft> GetListPaged(int recperpage, int pageindex)
		{
			return objOverDraftDA.GetListPaged(recperpage, pageindex);
		}

		#endregion

		#region ***** Add Update Delete Methods ***** 
		// Thêm
		public int Add(OverDraft objOverdraft)
		{
			ServerCache.Remove("OverDraft", true);
			return objOverDraftDA.Add(objOverdraft);
		}

		// Sửa
		public void Update(OverDraft objOverdraft)
		{
			ServerCache.Remove("OverDraft", true);
			objOverDraftDA.Update(objOverdraft);
		}

		// Xóa
		public void Delete(int odid)
		{
			ServerCache.Remove("OverDraft", true);
			objOverDraftDA.Delete(odid);
		}
		#endregion
	}
}
