using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;

namespace DbMock1G4.DataAccess
{
	public class LogTypeDA
	{

		#region ***** Init Methods ***** 
		public LogTypeDA()
		{
		}
		#endregion

		#region ***** Get Methods ***** 
		
		public LogType Populate(IDataReader myReader)
		{
			LogType obj = new LogType();
			obj.LogTypeId = (int) myReader["LogTypeId"];
			obj.Description = (string) myReader["Description"];
			return obj;
		}

		
		public LogType GetByLogTypeId(int logtypeid)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_LogType_GetByLogTypeId", Data.CreateParameter("LogTypeId", logtypeid)))
			{
				if (reader.Read())
				{
					return Populate(reader);
				}
				return null;
			}
		}

		
		public List<LogType> GetList()
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_LogType_Get"))
			{
				List<LogType> list = new List<LogType>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}

		

		
		public List<LogType> GetListPaged(int recperpage, int pageindex)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_LogType_GetPaged"
							,Data.CreateParameter("recperpage", recperpage)
							,Data.CreateParameter("pageindex", pageindex)))
			{
				List<LogType> list = new List<LogType>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}

		


		#endregion

		#region ***** Add Update Delete Methods ***** 
		
		public int Add(LogType obj)
		{
			DbParameter parameterItemID = Data.CreateParameter("LogTypeId", obj.LogTypeId);
			parameterItemID.Direction = ParameterDirection.Output;
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_LogType_Add"
							,parameterItemID
							,Data.CreateParameter("Description", obj.Description)
			);
			return (int)parameterItemID.Value;
		}

		
		public void Update(LogType obj)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_LogType_Update"
							,Data.CreateParameter("LogTypeId", obj.LogTypeId)
							,Data.CreateParameter("Description", obj.Description)
			);
		}

		
		public void Delete(int logtypeid)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_LogType_Delete", Data.CreateParameter("LogTypeId", logtypeid));
		}
		#endregion
	}
}
