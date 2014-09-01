using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;

namespace DbMock1G4.DataAccess
{
	public class CardDA
	{

		#region ***** Init Methods ***** 
		public CardDA()
		{
		}
		#endregion

		#region ***** Get Methods ***** 
		
		public Card Populate(IDataReader myReader)
		{
			Card obj = new Card();
			obj.CardNo = (string) myReader["CardNo"];
			obj.Status = (string) myReader["Status"];
			obj.AccountId = (int) myReader["AccountId"];
			obj.Pin = (string) myReader["Pin"];
			obj.StartDate = (DateTime) myReader["StartDate"];
            obj.ExpiredDate = (DateTime)myReader["ExpiredDate"];
			obj.Attempt = (int) myReader["Attempt"];
			return obj;
		}


        #region *****ReadCard Methods *****
        public Card GetByCardNo(string cardno)
        {
            using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "[sproc_Card_GetByCardNo]", Data.CreateParameter("CardNo", cardno)))
            {
                if (reader.Read())
                {
                    return Populate(reader);
                }
                return null;
            }
        }
        #endregion
        #region ***** AcceptCard Methods *****
        public bool AcceptCard(string cardno)
        {
            if (GetByCardNo(cardno) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ***** EjectCard Methods *****
        public void EjectCard()
        {

        }
        #endregion

        #region ***** ValidateCard Methods *****
        public bool ValidateCard(Card card)
        {
            if (card.ExpiredDate < DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        #endregion

        #region ***** CheckAttempt Methods *****
        public void CheckAttempt(Card cardByCardNo, string pin)
        {
            if (pin.Equals(cardByCardNo.Pin.ToString()))
            {
                cardByCardNo.Attempt = 0;
            }
            else
            {
                cardByCardNo.Attempt += 1;
            }
        }
        #endregion

        public Card GetByCardNoPinCard(string cardno, string pin)
        {
            using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "[sproc_Card_GetByCardNoPIN]", Data.CreateParameter("CardNo", cardno), Data.CreateParameter("Pin", pin)))
            {
                if (reader.Read())
                {
                    return Populate(reader);
                }
                return null;
            }
        }
		
		public List<Card> GetList()
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Card_Get"))
			{
				List<Card> list = new List<Card>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}

		

		public List<Card> GetListPaged(int recperpage, int pageindex)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Card_GetPaged"
							,Data.CreateParameter("recperpage", recperpage)
							,Data.CreateParameter("pageindex", pageindex)))
			{
				List<Card> list = new List<Card>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
				return list;
			}
		}



		#endregion

		#region ***** Add Update Delete Methods ***** 
		
		public int Add(Card obj)
		{
			DbParameter parameterItemID = Data.CreateParameter("CardNo", obj.CardNo);
			parameterItemID.Direction = ParameterDirection.Output;
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Card_Add"
							,parameterItemID
							,Data.CreateParameter("Status", obj.Status)
							,Data.CreateParameter("AccountId", obj.AccountId)
							,Data.CreateParameter("Pin", obj.Pin)
							,Data.CreateParameter("StartDate", obj.StartDate)
							,Data.CreateParameter("ExpiredDate", obj.ExpiredDate)
							,Data.CreateParameter("Attempt", obj.Attempt)
			);
			return 0;
		}

	
		public void Update(Card obj)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Card_Update"
							,Data.CreateParameter("CardNo", obj.CardNo)
							,Data.CreateParameter("Status", obj.Status)
							,Data.CreateParameter("AccountId", obj.AccountId)
							,Data.CreateParameter("Pin", obj.Pin)
							,Data.CreateParameter("StartDate", obj.StartDate)
							,Data.CreateParameter("ExpiredDate", obj.ExpiredDate)
							,Data.CreateParameter("Attempt", obj.Attempt)
			);
		}

	
		public void Delete(string cardno)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Card_Delete", Data.CreateParameter("CardNo", cardno));
		}
		#endregion
	}
}
