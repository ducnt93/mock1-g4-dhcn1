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
	public class LogTypeBL
	{

		#region ***** Init Methods ***** 

	    readonly LogTypeDA objLogTypeDA;
		public LogTypeBL()
		{
			objLogTypeDA = new LogTypeDA();
		}
		#endregion

		#region ***** Get Methods ***** 
		//Lấy LogType theo Id
		public LogType GetByLogTypeId(int logtypeid)
		{
			return objLogTypeDA.GetByLogTypeId(logtypeid);
		}

		// Lấy danh sách 
		public List<LogType> GetList()
		{
			const string cacheName = "lstLogType";
			if( ServerCache.Get(cacheName) == null )
			{
				ServerCache.Insert(cacheName, objLogTypeDA.GetList(), "LogType");
			}
			return (List<LogType>) ServerCache.Get(cacheName);
		}

		//Lấy danh sách theo phân trang 
	    public List<LogType> GetListPaged(int recperpage, int pageindex)
	    {
	        return objLogTypeDA.GetListPaged(recperpage, pageindex);
	    }

	    #endregion

		#region ***** Add Update Delete Methods ***** 
		//Thêm mới 1 LogType
		public int Add(LogType objLogtype)
		{
			ServerCache.Remove("LogType", true);
			return objLogTypeDA.Add(objLogtype);
		}

		// Sửa 1 TypeLog
		public void Update(LogType obj_logtype)
		{
			ServerCache.Remove("LogType", true);
			objLogTypeDA.Update(obj_logtype);
		}

		// Xóa 1 typeLog
		public void Delete(int logtypeid)
		{
			ServerCache.Remove("LogType", true);
			objLogTypeDA.Delete(logtypeid);
		}
		#endregion
	}
}
