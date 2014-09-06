using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using log4net;
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
        protected static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                contenValidate.Controls.Clear();
                contenValidate.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcValidating.ascx"));
                if (Session["ViewState"].Equals("EjectCard") || Session["ViewState"].Equals("Block"))
                {
                    Response.Redirect("~/InsertCardMain.aspx",false);
                }
                if (Session["ViewState"].Equals("InsertedCard"))
                {
                    Response.Redirect("~/UC1.Validation/EnterPIN.aspx",false);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }

        #region ***** Validate Methods *****
        protected void AcceptCard()
        {
            try
            {
                string cardNo = Session["CardNo"].ToString();
                if (cardBl.AcceptCard(cardNo) == false)
                {
                    Session["ViewState"] = "NoAccept";
                }
                else
                {
                    Session["ViewState"] = "Accepted";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }

        protected void ValidCard()
        {
            try
            {
                if (Session["ViewState"].Equals("Accepted"))
                {
                    string cardNo = Session["CardNo"].ToString();
                    Card card = cardBl.GetByCardNo(cardNo);
                    if (cardBl.ValidateCard(card) == false)
                    {
                        Session["ViewState"] = "InValidCard";
                    }
                    else
                    {
                        Session["ViewState"] = "InsertedCard";
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }

        protected void EjectCard()
        {
            try
            {
                if (Session["ViewState"].Equals("NoAccept"))
                {
                    contenValidate.Controls.Clear();
                    contenValidate.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcValidatingError.ascx"));
                    Session["ViewState"] = "EjectCard";
                }
                else
                {

                    if (Session["ViewState"].Equals("InValidCard"))
                    {
                        contenValidate.Controls.Clear();
                        contenValidate.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcCardInvalid.ascx"));
                        Session["ViewState"] = "EjectCard";
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }

        protected void CheckStatus()
        {
            try
            {
                string cardNo = Session["CardNo"].ToString();
                Card card = cardBl.GetByCardNo(cardNo);
                if (Session["ViewState"].Equals("Accepted"))
                {
                    if (card.Status.Equals("Block"))
                    {
                        contenValidate.Controls.Clear();
                        contenValidate.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcCardBlocked.ascx"));
                        Session["ViewState"] = "Block";
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }
        #endregion

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            AcceptCard();
            CheckStatus();
            ValidCard();
            EjectCard();
        }
    }
}