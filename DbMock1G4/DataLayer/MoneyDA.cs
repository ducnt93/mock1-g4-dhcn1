using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;

namespace DbMock1G4.DataAccess
{
	public class MoneyDA
	{

		#region ***** Init Methods ***** 
		public MoneyDA()
		{
		}
		#endregion

		#region ***** Get Methods ***** 
		
		public Money Populate(IDataReader myReader)
		{
			Money obj = new Money();
			obj.MoneyId = (int) myReader["MoneyId"];
			obj.MoneyValue = (decimal) myReader["MoneyValue"];
			obj.Address = (string) myReader["Address"];
			return obj;
		}


		public Money GetByMoneyId(int moneyid)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Money_GetByMoneyId", Data.CreateParameter("MoneyId", moneyid)))
			{
				if (reader.Read())
				{
					return Populate(reader);
				}
				return null;
			}
		}

		
		public List<Money> GetList()
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Money_Get"))
			{
				List<Money> list = new List<Money>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}

	
	
		public List<Money> GetListPaged(int recperpage, int pageindex)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Money_GetPaged"
							,Data.CreateParameter("recperpage", recperpage)
							,Data.CreateParameter("pageindex", pageindex)))
			{
				List<Money> list = new List<Money>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}

		#endregion

		#region ***** Add Update Delete Methods ***** 
		
		public int Add(Money obj)
		{
			DbParameter parameterItemID = Data.CreateParameter("MoneyId", obj.MoneyId);
			parameterItemID.Direction = ParameterDirection.Output;
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Money_Add"
							,parameterItemID
							,Data.CreateParameter("MoneyValue", obj.MoneyValue)
							,Data.CreateParameter("Address", obj.Address)
			);
			return (int)parameterItemID.Value;
		}

	
		public void Update(Money obj)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Money_Update"
							,Data.CreateParameter("MoneyId", obj.MoneyId)
							,Data.CreateParameter("MoneyValue", obj.MoneyValue)
							,Data.CreateParameter("Address", obj.Address)
			);
		}

		
		public void Delete(int moneyid)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Money_Delete", Data.CreateParameter("MoneyId", moneyid));
		}
		#endregion
	}
}
