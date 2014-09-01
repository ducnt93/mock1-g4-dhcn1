using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.UC1.Validation
{
    public partial class Validate : System.Web.UI.Page
    {
        CardBL cardBl = new CardBL();
        string cardNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            contenValidate.Controls.Clear();
            contenValidate.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcValidating.ascx"));
            if (!IsPostBack)
            {
                CheckStatus();
                if (Session["ViewSate"].Equals("Block"))
                {
                    contenValidate.Controls.Clear();
                    contenValidate.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcCardBlocked.ascx"));
                }
                else
                {
                    AcceptCard();
                    if (Session["AcceptCard"].Equals("NoAccept"))
                    {
                        EjectCard();
                        if (Session["ViewSate"].Equals("EjectCard"))
                        {
                            //Response.Redirect("~/InsertCardMain.aspx");
                        }
                    }
                    else
                    {
                        ValidCard();
                    }
                }
            }
        }

        #region ***** Validate Methods *****
        protected void AcceptCard()
        {
            cardNo = Session["CardNo"].ToString();
            if (cardBl.AcceptCard(cardNo) == false)
            {
                Session["AcceptCard"] = "NoAccept";
            }
            else
            {
                Session["AcceptCard"] = "Accepted";
            }
        }

        protected void ValidCard()
        {
            if (Session["AcceptCard"].Equals("Accepted"))
            {
                cardNo = Session["CardNo"].ToString();
                Card card = cardBl.GetByCardNo(cardNo);
                if (cardBl.ValidateCard(card) == false)
                {
                    Session["ValidCard"] = "InValidCard";
                    EjectCard();
                    if (Session["ViewSate"].Equals("EjectCard"))
                    {
                        //Response.Redirect("~/InsertCardMain.aspx");
                    }
                }
                else
                {
                    Session["ValidCard"] = "Validated";
                    Session["ViewSate"] = "InsertedCard";
                    Response.Redirect("~/UC1.Validation/EnterPIN.aspx");
                }
            }
        }

        protected void EjectCard()
        {
            if (Session["AcceptCard"].Equals("NoAccept"))
            {
                contenValidate.Controls.Clear();
                contenValidate.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcValidatingError.ascx"));
                Session["ViewSate"] = "EjectCard";
            }
            else
            {

                if (Session["ValidCard"].Equals("InValidCard"))
                {
                    contenValidate.Controls.Clear();
                    contenValidate.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcCardInvalid.ascx"));
                    Session["ViewSate"] = "EjectCard";
                }
            }
        }
        protected void CheckStatus()
        {
            cardNo = Session["CardNo"].ToString();
            Card card = cardBl.GetByCardNo(cardNo);
            if (card != null)
            {
                if (card.Status.Equals("Block"))
                {
                    Session["ViewSate"] = "Block";
                }
            }
        }
        #endregion
    }
}