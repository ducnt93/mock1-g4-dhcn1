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
	public class LogBL
	{
	    

        #region ***** Init Methods *****

        readonly LogDA objLogDA;
        public LogBL()
        {
            objLogDA = new LogDA();
        }
        #endregion
		#region ***** Get Methods ***** 
		// Lấy Log theo Id
		public Log GetByLogId(int logid)
		{
			return objLogDA.GetByLogId(logid);
		}

		// Lấy danh sách 
		public List<Log> GetList()
		{
			const string cacheName = "lstLog";
			if( ServerCache.Get(cacheName) == null )
			{
				ServerCache.Insert(cacheName, objLogDA.GetList(), "Log");
			}
			return (List<Log>) ServerCache.Get(cacheName);
		}

		// Lấy danh theo phân trang
        public List<Log> GetListPaged(int recperpage, int pageindex, int time)
        {
            return objLogDA.GetListPaged(recperpage, pageindex, time);
        }

		#endregion

		#region ***** Add Update Delete Methods ***** 
		// Thêm 1 log
		public int Add(Log objLog)
		{
			ServerCache.Remove("Log", true);
			return objLogDA.Add(objLog);
		}

		// Sửa 1 log
		public void Update(Log objLog)
		{
			ServerCache.Remove("Log", true);
			objLogDA.Update(objLog);
		}

		// Xóa 1 log
		public void Delete(int logid)
		{
			ServerCache.Remove("Log", true);
			objLogDA.Delete(logid);
		}
		#endregion
	}
}
