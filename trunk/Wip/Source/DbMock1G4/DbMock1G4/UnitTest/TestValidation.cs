 using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApplication1.UnitTest
{
    [TestClass]
    public class TestMethodValidation
    {
        public string cardNo;
        public CardBL cardBl = new CardBL();
        public Card card = new Card();
        
        #region Test Method Validation
        [TestMethod]
        public void TestMethodReadCard1()
        {
            Assert.AreEqual(null, cardBl.ReadCard(""));
        }

        [TestMethod]
        public void TestMethodReadCard2()
        {
            string exp = "1234567890";
            string card = cardBl.ReadCard(exp);
            Assert.AreEqual(exp, card);
        }

        [TestMethod]
        public void TestMethodReadCard3()
        {
            string exp = null;
            string card = cardBl.ReadCard("0");
            Assert.AreEqual(exp, card);
        }

        [TestMethod]
        public void TestMethodReadCard4()
        {
            Assert.AreEqual(null, cardBl.ReadCard("abc123"));
        }

        [TestMethod]
        public void TestMethodReadCard5()
        {
            Assert.AreEqual(null, cardBl.ReadCard("."));
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
            cardNo = "1";
            card = cardBl.GetByCardNo(cardNo);
            Assert.AreEqual(false, cardBl.ValidateCard(card));
        }
        #endregion
    }
}
