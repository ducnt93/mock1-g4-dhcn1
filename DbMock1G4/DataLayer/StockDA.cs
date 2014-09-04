using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;

namespace DbMock1G4.DataAccess
{
	public class StockDA
	{

		#region ***** Init Methods ***** 
		public StockDA()
		{
		}
		#endregion

		#region ***** Get Methods ***** 
		
		public Stock Populate(IDataReader myReader)
		{
			Stock obj = new Stock();
			obj.StockId = (int) myReader["StockId"];
			obj.MoneyId = (int) myReader["MoneyId"];
			obj.AtmId = (int) myReader["AtmId"];
			obj.QuanlityId = (int) myReader["QuanlityId"];
			return obj;
		}

		public Stock GetByStockId(int stockId)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Stock_GetByStockId", Data.CreateParameter("StockId", stockId)))
			{
				if (reader.Read())
				{
					return Populate(reader);
				}
				return null;
			}
		}
        public List<Stock> GetByAtmId(int atmId)
        {
            using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Stock_GetByAtmId",Data.CreateParameter("AtmId",atmId)))
            {
                List<Stock> list = new List<Stock>();
                while (reader.Read())
                {
                    list.Add(Populate(reader));
                }
                return list;
            }
        }
	
		public List<Stock> GetList()
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Stock_Get"))
			{
				List<Stock> list = new List<Stock>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}

	
		
		public List<Stock> GetListPaged(int recperpage, int pageindex)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Stock_GetPaged"
							,Data.CreateParameter("recperpage", recperpage)
							,Data.CreateParameter("pageindex", pageindex)))
			{
				List<Stock> list = new List<Stock>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}


		#endregion

		#region ***** Add Update Delete Methods ***** 
		
		public int Add(Stock obj)
		{
			DbParameter parameterItemID = Data.CreateParameter("StockId", obj.StockId);
			parameterItemID.Direction = ParameterDirection.Output;
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Stock_Add"
							,parameterItemID
							,Data.CreateParameter("MoneyId", obj.MoneyId)
							,Data.CreateParameter("AtmId", obj.AtmId)
							,Data.CreateParameter("QuanlityId", obj.QuanlityId)
			);
			return (int)parameterItemID.Value;
		}

		public void Update(Stock obj)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Stock_Update"
							,Data.CreateParameter("StockId", obj.StockId)
							,Data.CreateParameter("MoneyId", obj.MoneyId)
							,Data.CreateParameter("AtmId", obj.AtmId)
							,Data.CreateParameter("QuanlityId", obj.QuanlityId)
			);
		}

		
		public void Delete(int stockid)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Stock_Delete", Data.CreateParameter("StockId", stockid));
		}
		#endregion

     
    }
}
