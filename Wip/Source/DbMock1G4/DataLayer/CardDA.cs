using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;
using System.Security.Cryptography;

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
        public string  ReadCard(string cardno)
        {
            using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "[sproc_Card_GetCardNo]", Data.CreateParameter("CardNo", cardno)))
            {
                if (reader.Read())
                {
                    return (string)reader["CardNo"];
                }
                return null;
            }
        }
        #endregion

        #region ***** AcceptCard Methods *****
        public bool AcceptCard(string cardno)
        {
            if (ReadCard(cardno) != null)
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
        public void CheckAttempt(Card cardByCardNo, string hashpin)
        {
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(cardByCardNo.Pin.ToString(), hashpin))
            {
                cardByCardNo.Attempt = 0;
            }
            else
            {
                cardByCardNo.Attempt += 1;
            }
        }
        #endregion

        #region ***** GetHashPinMD5 Methods *****
        public string GetHashPinMD5(string pin)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(pin));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        #endregion

	    public Card GetByCardNo(string cardno)
	    {
	        using (
	            IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure,
	                "[sproc_Card_GetByCardNo]", Data.CreateParameter("CardNo", cardno)))
	        {
	            if (reader.Read())
	            {
	                return Populate(reader);
	            }
	            return null;
	        }
	    }

	    #endregion

		#region ***** Add Update Delete Methods ***** 

	    public void UpdateStatus(Card obj)
	    {
	        SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Card_UpdateStatus"
	            , Data.CreateParameter("CardNo", obj.CardNo)
	            , Data.CreateParameter("Status", obj.Status)
	            , Data.CreateParameter("Attempt", obj.Attempt)
	            );
	    }

	    #endregion
	}
}
