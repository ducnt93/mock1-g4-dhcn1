using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;
using DbMock1G4.DataAccess;

namespace DbMock1G4.BusinessLogic
{
    public class CardBL
    {

        #region ***** Init Methods *****

        readonly CardDA objCardDA;
        public CardBL()
        {
            objCardDA = new CardDA();
        }
        #endregion

        #region ***** Get Methods *****
        		
		#region ***** Validation Methods *****
        public string ReadCard(string cardno)
        {
            return objCardDA.ReadCard(cardno);
        }

        public bool AcceptCard(string cardno)
        {
            return objCardDA.AcceptCard(cardno);
        }

        public bool ValidateCard(Card card)
        {
            return objCardDA.ValidateCard(card);
        }

        public void CheckAttempt(Card cardByCardNo, string pin)
        {
            objCardDA.CheckAttempt(cardByCardNo, pin);
        }
		#endregion

        public string GetHashPinMD5(string pin)
        {
            return objCardDA.GetHashPinMD5(pin);
        }

		public Card GetByCardNo(string cardno)
        {
            return objCardDA.GetByCardNo(cardno);
        }
        #endregion

        #region ***** Add Update Delete Methods *****
        public void UpdateStatus(Card objCard)
        {
            ServerCache.Remove("Card", true);
            objCardDA.UpdateStatus(objCard);
        }
        #endregion
    }
}
