using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.UC1.Validation.UcController
{
    public partial class ValidatingPIN : System.Web.UI.UserControl
    {
        CardBL cardBl = new CardBL();
        Card card;
        protected static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAttempt();
        }

        protected void CheckAttempt()
        {
            try
            {
                string hashpin = Session["PIN"].ToString();
                //string hashpin = cardBl.GetHashPinMD5(pin);
                string CardNo = Session["CardNo"].ToString();
                card = cardBl.GetByCardNo(CardNo);
                cardBl.CheckAttempt(card, hashpin);
                if (card.Attempt == 0)
                {
                    card.Attempt = 0;
                    cardBl.UpdateStatus(card);
                    Session["AccountId"] = card.AccountId;
                    Session["ViewState"] = "Authentication";
                }
                else if (card.Attempt >= 1 && card.Attempt < 3)
                {
                    Session["PIN"] = "";
                    cardBl.UpdateStatus(card);
                    Session["ViewState"] = "ErrorPIN";
                }
                else
                {
                    Session["ViewState"] = "ThreeErrorPIN";
                    card.Status = "Block";
                    cardBl.UpdateStatus(card);
                }
            }
            catch (Exception ex)
            {
                logger.Debug(ex.Message);
            }
        }

        protected void Timer_Tick(object sender, EventArgs e)
        {

        }
    }
}