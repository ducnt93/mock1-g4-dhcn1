using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;

namespace DbMock1G4.DataAccess
{
	public class AtmDA
	{

		#region ***** Init Methods ***** 
		public AtmDA()
		{
		}
		#endregion

		#region ***** Get Methods ***** 
		
		public Atm Populate(IDataReader myReader)
		{
			Atm obj = new Atm();
			obj.AtmId = (int) myReader["AtmId"];
			obj.Branch = (string) myReader["Branch"];
			obj.Address = (string) myReader["Address"];
			return obj;
		}

	
		public Atm GetByAtmId(int atmid)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Atm_GetByAtmId", Data.CreateParameter("AtmId", atmid)))
			{
				if (reader.Read())
				{
					return Populate(reader);
				}
				return null;
			}
		}

		
		public List<Atm> GetList()
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Atm_Get"))
			{
				List<Atm> list = new List<Atm>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}

		
		
		public List<Atm> GetListPaged(int recperpage, int pageindex)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Atm_GetPaged"
							,Data.CreateParameter("recperpage", recperpage)
							,Data.CreateParameter("pageindex", pageindex)))
			{
				List<Atm> list = new List<Atm>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}


		#endregion

		#region ***** Add Update Delete Methods ***** 
	
		public int Add(Atm obj)
		{
			DbParameter parameterItemID = Data.CreateParameter("AtmId", obj.AtmId);
			parameterItemID.Direction = ParameterDirection.Output;
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Atm_Add"
							,parameterItemID
							,Data.CreateParameter("Branch", obj.Branch)
							,Data.CreateParameter("Address", obj.Address)
			);
			return (int)parameterItemID.Value;
		}

		
		public void Update(Atm obj)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Atm_Update"
							,Data.CreateParameter("AtmId", obj.AtmId)
							,Data.CreateParameter("Branch", obj.Branch)
							,Data.CreateParameter("Address", obj.Address)
			);
		}

		
		public void Delete(int atmid)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Atm_Delete", Data.CreateParameter("AtmId", atmid));
		}
		#endregion
	}
}
