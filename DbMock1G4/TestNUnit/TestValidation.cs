using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;

namespace TestNUnit
{
    [TestFixture]
    class TestValidation
    {
		private string cardNo;
		private string pin;
		
		private CardBL cardBl;
		private Card card;
		
        [SetUp]
        public void TestValidate()
        {
			cardBl= new CardBL();
			card=new Card();
        }

        [Test]
        public void TestReadCard1()
        {
            Assert.AreEqual(null, cardBl.GetByCardNo(""));
        }

        [Test]
        public void TestReadCard2()
        {
            Assert.AreEqual("1234567890", cardBl.GetByCardNo("1234567890"));
        }
		
		[Test]
		public void TestAcceptCard1()
        {
            Assert.AreEqual(false, cardBl.AcceptCard(""));
		}

        [Test]
        public void TestAcceptCard2()
        {
            Assert.AreEqual(false, cardBl.AcceptCard("'"));
        }

        [Test]
        public void TestAcceptCard3()
        {
            Assert.AreEqual(false, cardBl.AcceptCard("."));
        }

        [Test]
        public void TestAcceptCard4()
        {
            Assert.AreEqual(false, cardBl.AcceptCard(","));
        }

        [Test]
        public void TestAcceptCard5()
        {
            Assert.AreEqual(true, cardBl.AcceptCard("1234567890"));
        }

        [Test]
        public void TestValidateCard1()
        {
            cardNo = "1234567890";
            card = cardBl.GetByCardNo(cardNo);
            Assert.AreEqual(true, cardBl.ValidateCard(card));
        }

        [Test]
        public void TestValidateCard2()
        {
            cardNo = "0641060097";
            card = cardBl.GetByCardNo(cardNo);
            Assert.AreEqual(false, cardBl.ValidateCard(card));
        }

        [Test]
        public void TestValidateCard3()
        {
            cardNo = "0641060097";
            card = cardBl.GetByCardNo(cardNo);
            Assert.AreEqual(false, cardBl.ValidateCard(card));
        }
    }
}
