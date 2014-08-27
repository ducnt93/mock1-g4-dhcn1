using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;

namespace WebApplication1.UC1.Validation
{
    public partial class ValidationPIN : System.Web.UI.Page
    {
        CardBL cardBl = new CardBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string CardNo = Session["CardNo"].ToString();
            string PIN = Session["PIN"].ToString();
            Card crCard = cardBl.GetByCardNoPinCard(CardNo, PIN);
            if (crCard == null)
            {
               
                Response.Redirect("~/UC1.Validation/EnterPIN.aspx");
            }
            else
            {
                Session["AccountId"] = crCard.AccountId;
                Response.Redirect("~/MainATM.aspx");
            }


        }
    }
}