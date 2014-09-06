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
		
        public Card GetByCardNoPinCard(string cardno, string pin)
        {
            return objCardDA.GetByCardNoPinCard(cardno, pin);
        }

        // Lấy danh sách Card
        public List<Card> GetList()
        {
            const string cacheName = "lstCard";
            if (ServerCache.Get(cacheName) == null)
            {
                ServerCache.Insert(cacheName, objCardDA.GetList(), "Card");
            }
            return (List<Card>)ServerCache.Get(cacheName);
        }


        // Lấy danh sách theo trang
        public List<Card> GetListPaged(int recperpage, int pageindex)
        {
            return objCardDA.GetListPaged(recperpage, pageindex);
        }

        #endregion

        #region ***** Add Update Delete Methods *****
        // Thêm mới 1 card
        public int Add(Card objCard)
        {
            ServerCache.Remove("Card", true);
            return objCardDA.Add(objCard);
        }

        // Sửa card
        public void Update(Card objCard)
        {
            ServerCache.Remove("Card", true);
            objCardDA.Update(objCard);
        }

        public void UpdateStatus(Card objCard)
        {
            ServerCache.Remove("Card", true);
            objCardDA.UpdateStatus(objCard);
        }

        // Xóa card
        public void Delete(string cardno)
        {
            ServerCache.Remove("Card", true);
            objCardDA.Delete(cardno);
        }
        #endregion
    }
}
