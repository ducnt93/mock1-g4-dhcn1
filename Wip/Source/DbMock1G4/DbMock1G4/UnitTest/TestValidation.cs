using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApplication1.UnitTest
{
    [TestClass]
    class TestMethodValidation
    {
		private string cardNo;
		private string pin;
		
		private CardBL cardBl;
		private Card card;
		
     
        public void TestMethodValidate()
        {
			cardBl= new CardBL();
			card=new Card();
        }

        [TestMethod]
        public void TestMethodReadCard1()
        {
            Assert.AreEqual(null, cardBl.GetByCardNo(""));
        }

        [TestMethod]
        public void TestMethodReadCard2()
        {
            Assert.AreEqual("1234567890", cardBl.GetByCardNo("1234567890"));
        }
		
		[TestMethod]
		public void TestMethodAcceptCard1()
        {
            Assert.AreEqual(false, cardBl.AcceptCard(""));
		}

        [TestMethod]
        public void TestMethodAcceptCard2()
        {
            Assert.AreEqual(false, cardBl.AcceptCard("'"));
        }

        [TestMethod]
        public void TestMethodAcceptCard3()
        {
            Assert.AreEqual(false, cardBl.AcceptCard("."));
        }

        [TestMethod]
        public void TestMethodAcceptCard4()
        {
            Assert.AreEqual(false, cardBl.AcceptCard(","));
        }

        [TestMethod]
        public void TestMethodAcceptCard5()
        {
            Assert.AreEqual(true, cardBl.AcceptCard("1234567890"));
        }

        [TestMethod]
        public void TestMethodValidateCard1()
        {
            cardNo = "1234567890";
            card = cardBl.GetByCardNo(cardNo);
            Assert.AreEqual(true, cardBl.ValidateCard(card));
        }

        [TestMethod]
        public void TestMethodValidateCard2()
        {
            cardNo = "0641060097";
            card = cardBl.GetByCardNo(cardNo);
            Assert.AreEqual(false, cardBl.ValidateCard(card));
        }

        [TestMethod]
        public void TestMethodValidateCard3()
        {
            cardNo = "0641060097";
            card = cardBl.GetByCardNo(cardNo);
            Assert.AreEqual(false, cardBl.ValidateCard(card));
        }
    }
}
