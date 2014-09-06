using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;

namespace DbMock1G4.DataAccess
{
	public class WithdrawLimitDA
	{

		#region ***** Init Methods ***** 
		public WithdrawLimitDA()
		{
		}
		#endregion

		#region ***** Get Methods ***** 

		public WithdrawLimit Populate(IDataReader myReader)
		{
			WithdrawLimit obj = new WithdrawLimit();
			obj.WdId = (int) myReader["WdId"];
			obj.Value = (string) myReader["Value"];
			return obj;
		}

		public WithdrawLimit GetByWdId(int wdid)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_WithdrawLimit_GetByWdId", Data.CreateParameter("WdId", wdid)))
			{
				if (reader.Read())
				{
					return Populate(reader);
				}
				return null;
			}
		}

		public List<WithdrawLimit> GetList()
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_WithdrawLimit_Get"))
			{
				List<WithdrawLimit> list = new List<WithdrawLimit>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}

	
		public List<WithdrawLimit> GetListPaged(int recperpage, int pageindex)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_WithdrawLimit_GetPaged"
							,Data.CreateParameter("recperpage", recperpage)
							,Data.CreateParameter("pageindex", pageindex)))
			{
				List<WithdrawLimit> list = new List<WithdrawLimit>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}

		#endregion

		#region ***** Add Update Delete Methods ***** 
		
		public int Add(WithdrawLimit obj)
		{
			DbParameter parameterItemID = Data.CreateParameter("WdId", obj.WdId);
			parameterItemID.Direction = ParameterDirection.Output;
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_WithdrawLimit_Add"
							,parameterItemID
							,Data.CreateParameter("Value", obj.Value)
			);
			return (int)parameterItemID.Value;
		}

		
		public void Update(WithdrawLimit obj)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_WithdrawLimit_Update"
							,Data.CreateParameter("WdId", obj.WdId)
							,Data.CreateParameter("Value", obj.Value)
			);
		}

	
		public void Delete(int wdid)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_WithdrawLimit_Delete", Data.CreateParameter("WdId", wdid));
		}
		#endregion
	}
}
