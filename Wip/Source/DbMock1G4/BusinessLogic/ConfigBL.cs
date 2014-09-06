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
	public class ConfigBL
	{

		#region ***** Init Methods ***** 

	    readonly ConfigDA objConfigDA;
		public ConfigBL()
		{
			objConfigDA = new ConfigDA();
		}
		#endregion

		#region ***** Get Methods ***** 

		//Lấy dánh sách Config
		public List<Config> GetList()
		{
			const string cacheName = "lstConfig";
			if( ServerCache.Get(cacheName) == null )
			{
				ServerCache.Insert(cacheName, objConfigDA.GetList(), "Config");
			}
			return (List<Config>) ServerCache.Get(cacheName);
		}
		// Lấy danh sách theo trang
		public List<Config> GetListPaged(int recperpage, int pageindex)
		{
			return objConfigDA.GetListPaged(recperpage, pageindex);
		}

		#endregion

		#region ***** Add Update Delete Methods ***** 
		// Thêm Config
		public int Add(Config objConfig)
		{
			ServerCache.Remove("Config", true);
			return objConfigDA.Add(objConfig);
		}

    
		#endregion
	}
}
