using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;

namespace DbMock1G4.DataAccess
{
	public class LogDA
	{

		#region ***** Init Methods ***** 
		public LogDA()
		{
		}
		#endregion

		#region ***** Get Methods ***** 
		
		public Log Populate(IDataReader myReader)
		{
			Log obj = new Log();
			obj.LogId = (int) myReader["LogId"];
			obj.LogTypeId = (int) myReader["LogTypeId"];
			obj.AtmId = (int) myReader["AtmId"];
			obj.CardNo = (string) myReader["CardNo"];
            obj.LogDate = (DateTime)myReader["LogDate"];
			obj.Amount = (decimal) myReader["Amount"];
			obj.Details = (string) myReader["Details"];
			return obj;
		}

        public Log Populate1(IDataReader myReader)
        {
            Log obj = new Log();
            obj.AtmLocation = (string)myReader["Address"];
            obj.Type = (string)myReader["Description"];
            obj.LogDate = (DateTime)myReader["LogDate"];
            obj.Amount = (decimal)myReader["Amount"];
            obj.Details = (string)myReader["Details"];
            return obj;
        }
		
		public Log GetByLogId(int logid)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Log_GetByLogId", Data.CreateParameter("LogId", logid)))
			{
				if (reader.Read())
				{
					return Populate(reader);
				}
				return null;
			}
		}

		
		public List<Log> GetList()
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Log_Get"))
			{
				List<Log> list = new List<Log>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}





        public List<Log> GetListPaged(int recperpage, int pageindex, int time)
        {
            using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Log_GetPaged"
                            , Data.CreateParameter("recperpage", recperpage)
                            , Data.CreateParameter("Time", time)
                            , Data.CreateParameter("pageindex", pageindex)))
            {
                List<Log> list = new List<Log>();
                while (reader.Read())
                {
                    list.Add(Populate1(reader));
                }
                return list;
            }
        }


		#endregion

		#region ***** Add Update Delete Methods ***** 
		
		public int Add(Log obj)
		{
			DbParameter parameterItemID = Data.CreateParameter("LogId", obj.LogId);
			parameterItemID.Direction = ParameterDirection.Output;
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Log_Add"
							,parameterItemID
							,Data.CreateParameter("LogTypeId", obj.LogTypeId)
							,Data.CreateParameter("AtmId", obj.AtmId)
							,Data.CreateParameter("CardNo", obj.CardNo)
							,Data.CreateParameter("LogDate", obj.LogDate)
							,Data.CreateParameter("Amount", obj.Amount)
							,Data.CreateParameter("Details", obj.Details)
			);
			return (int)parameterItemID.Value;
		}

		
		public void Update(Log obj)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Log_Update"
							,Data.CreateParameter("LogId", obj.LogId)
							,Data.CreateParameter("LogTypeId", obj.LogTypeId)
							,Data.CreateParameter("AtmId", obj.AtmId)
							,Data.CreateParameter("CardNo", obj.CardNo)
							,Data.CreateParameter("LogDate", obj.LogDate)
							,Data.CreateParameter("Amount", obj.Amount)
							,Data.CreateParameter("Details", obj.Details)
			);
		}

		
		public void Delete(int logid)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Log_Delete", Data.CreateParameter("LogId", logid));
		}
		#endregion
	}
}
