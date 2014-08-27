using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;

namespace DbMock1G4.DataAccess
{
	public class ConfigDA
	{

		#region ***** Init Methods ***** 
		public ConfigDA()
		{
		}
		#endregion

		#region ***** Get Methods ***** 
	
		public Config Populate(IDataReader myReader)
		{
			Config obj = new Config();
            obj.DateModified = (DateTime)myReader["DateModified"];
			obj.MinWithdraw = (decimal) myReader["MinWithdraw"];
			obj.MaxWithdraw = (decimal) myReader["MaxWithdraw"];
			obj.NumPerPage = (int) myReader["NumPerPage"];
			return obj;
		}


	
		public List<Config> GetList()
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Config_Get"))
			{
				List<Config> list = new List<Config>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}

		public List<Config> GetListPaged(int recperpage, int pageindex)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Config_GetPaged"
							,Data.CreateParameter("recperpage", recperpage)
							,Data.CreateParameter("pageindex", pageindex)))
			{
				List<Config> list = new List<Config>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}

		

		#endregion

		#region ***** Add Update Delete Methods ***** 
		
		public int Add(Config obj)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Config_Add"
							,Data.CreateParameter("DateModified", obj.DateModified)
							,Data.CreateParameter("MinWithdraw", obj.MinWithdraw)
							,Data.CreateParameter("MaxWithdraw", obj.MaxWithdraw)
							,Data.CreateParameter("NumPerPage", obj.NumPerPage)
			);
			return 0;
		}
		#endregion
	}
}
