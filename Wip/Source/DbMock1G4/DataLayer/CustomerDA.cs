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
        #endregion
    }
}
