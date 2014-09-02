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
                string s = Session["ViewSate"].ToString();
                if (Session["ViewSate"].Equals("EjectCard") || Session["ViewSate"].Equals("Block"))
                {
                    Response.Redirect("~/InsertCardMain.aspx");
                }
                if (Session["ViewSate"].Equals("InsertedCard"))
                {
                    Response.Redirect("~/UC1.Validation/EnterPIN.aspx");
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
                    Session["ViewSate"] = "NoAccept";
                }
                else
                {
                    Session["ViewSate"] = "Accepted";
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
                if (Session["ViewSate"].Equals("Accepted"))
                {
                    string cardNo = Session["CardNo"].ToString();
                    Card card = cardBl.GetByCardNo(cardNo);
                    if (cardBl.ValidateCard(card) == false)
                    {
                        Session["ViewSate"] = "InValidCard";
                    }
                    else
                    {
                        Session["ViewSate"] = "InsertedCard";
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
                if (Session["ViewSate"].Equals("NoAccept"))
                {
                    contenValidate.Controls.Clear();
                    contenValidate.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcValidatingError.ascx"));
                    Session["ViewSate"] = "EjectCard";
                }
                else
                {

                    if (Session["ViewSate"].Equals("InValidCard"))
                    {
                        contenValidate.Controls.Clear();
                        contenValidate.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcCardInvalid.ascx"));
                        Session["ViewSate"] = "EjectCard";
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
                if (Session["ViewSate"].Equals("Accepted"))
                {
                    if (card.Status.Equals("Block"))
                    {
                        contenValidate.Controls.Clear();
                        contenValidate.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcCardBlocked.ascx"));
                        Session["ViewSate"] = "Block";
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