using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;

namespace DbMock1G4.DataAccess
{
	public class OverDraftDA
	{

		#region ***** Init Methods ***** 
		public OverDraftDA()
		{
		}
		#endregion

		#region ***** Get Methods ***** 
		
		public OverDraft Populate(IDataReader myReader)
		{
			OverDraft obj = new OverDraft();
			obj.OdId = (int) myReader["OdId"];
			obj.Value = (string) myReader["Value"];
			return obj;
		}

	
		public OverDraft GetByOdId(int odid)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_OverDraft_GetByOdId", Data.CreateParameter("OdId", odid)))
			{
				if (reader.Read())
				{
					return Populate(reader);
				}
				return null;
			}
		}

	
		public List<OverDraft> GetList()
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_OverDraft_Get"))
			{
				List<OverDraft> list = new List<OverDraft>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}

	
	
		public List<OverDraft> GetListPaged(int recperpage, int pageindex)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_OverDraft_GetPaged"
							,Data.CreateParameter("recperpage", recperpage)
							,Data.CreateParameter("pageindex", pageindex)))
			{
				List<OverDraft> list = new List<OverDraft>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}



		#endregion

		#region ***** Add Update Delete Methods ***** 
		
		public int Add(OverDraft obj)
		{
			DbParameter parameterItemID = Data.CreateParameter("OdId", obj.OdId);
			parameterItemID.Direction = ParameterDirection.Output;
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_OverDraft_Add"
							,parameterItemID
							,Data.CreateParameter("Value", obj.Value)
			);
			return (int)parameterItemID.Value;
		}

	
		public void Update(OverDraft obj)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_OverDraft_Update"
							,Data.CreateParameter("OdId", obj.OdId)
							,Data.CreateParameter("Value", obj.Value)
			);
		}

		
		public void Delete(int odid)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_OverDraft_Delete", Data.CreateParameter("OdId", odid));
		}
		#endregion
	}
}
