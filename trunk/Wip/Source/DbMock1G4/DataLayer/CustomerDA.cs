using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;

namespace DbMock1G4.DataAccess
{
	public class CustomerDA
	{

		#region ***** Init Methods ***** 
		public CustomerDA()
		{
		}
		#endregion

		#region ***** Get Methods ***** 
		
		public Customer Populate(IDataReader myReader)
		{
			Customer obj = new Customer();
			obj.CusId = (int) myReader["CusId"];
			obj.Name = (string) myReader["Name"];
			obj.Phone = (string) myReader["Phone"];
			obj.Email = (string) myReader["Email"];
			obj.Addr = (string) myReader["Addr"];
			return obj;
		}

		
		public Customer GetByCusId(int cusid)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Customer_GetByCusId", Data.CreateParameter("CusId", cusid)))
			{
				if (reader.Read())
				{
					return Populate(reader);
				}
				return null;
			}
		}

		
		public List<Customer> GetList()
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Customer_Get"))
			{
				List<Customer> list = new List<Customer>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}

		

		
		public List<Customer> GetListPaged(int recperpage, int pageindex)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Customer_GetPaged"
							,Data.CreateParameter("recperpage", recperpage)
							,Data.CreateParameter("pageindex", pageindex)))
			{
				List<Customer> list = new List<Customer>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}

	


		#endregion

		#region ***** Add Update Delete Methods ***** 
		
		public int Add(Customer obj)
		{
			DbParameter parameterItemID = Data.CreateParameter("CusId", obj.CusId);
			parameterItemID.Direction = ParameterDirection.Output;
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Customer_Add"
							,parameterItemID
							,Data.CreateParameter("Name", obj.Name)
							,Data.CreateParameter("Phone", obj.Phone)
							,Data.CreateParameter("Email", obj.Email)
							,Data.CreateParameter("Addr", obj.Addr)
			);
			return (int)parameterItemID.Value;
		}

		
		public void Update(Customer obj)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Customer_Update"
							,Data.CreateParameter("CusId", obj.CusId)
							,Data.CreateParameter("Name", obj.Name)
							,Data.CreateParameter("Phone", obj.Phone)
							,Data.CreateParameter("Email", obj.Email)
							,Data.CreateParameter("Addr", obj.Addr)
			);
		}

		
		public void Delete(int cusid)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Customer_Delete", Data.CreateParameter("CusId", cusid));
		}
		#endregion
	}
}
