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
    public partial class EnterPIN : System.Web.UI.Page
    {
        CardBL cardBl = new CardBL();
        Card card;
        protected static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].Equals("BlockCard"))
                {
                    Response.Redirect("~/InsertCardMain.aspx", false);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }

        protected void CheckAttempt()
        {
            try
            {
                string hashpin = cardBl.GetHashPinMD5(txtPIN.Text);
                string CardNo = Session["CardNo"].ToString();
                card = cardBl.GetByCardNo(CardNo);
                cardBl.CheckAttempt(card, hashpin);
                if (card.Attempt == 0)
                {
                    card.Attempt = 0;
                    cardBl.UpdateStatus(card);
                    Session["PIN"] = hashpin;
                    Session["AccountId"] = card.AccountId;
                    Session["ViewState"] = "Authentication";
                    Response.Redirect("~/MainATM.aspx", false);
                }
                else if (card.Attempt >= 1 && card.Attempt < 3)
                {
                    cardBl.UpdateStatus(card);
                    Session["ViewState"] = "ErrorPIN";
                    txtPIN.Attributes["value"] = "";
                    contenEnterPIN.Controls.Clear();
                    contenEnterPIN.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcRe-EnterPIN.ascx"));
                }
                else
                {
                    Session["ViewState"] = "BlockCard";
                    contenBlockCard.Controls.Clear();
                    contenBlockCard.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcBlockCard.ascx"));
                    card.Status = "Block";
                    cardBl.UpdateStatus(card);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }

        #region ***** button number *****
        protected void btnNum1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].Equals("ErrorPIN"))
                {
                    contenEnterPIN.Controls.Clear();
                    contenEnterPIN.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcRe-EnterPIN.ascx"));
                    txtPIN.Attributes["value"] += "1";
                }
                else
                {
                    txtPIN.Attributes["value"] += "1";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }

        protected void btnNum2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].Equals("ErrorPIN"))
                {
                    contenEnterPIN.Controls.Clear();
                    contenEnterPIN.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcRe-EnterPIN.ascx"));
                    txtPIN.Attributes["value"] += "2";
                }
                else
                {
                    txtPIN.Attributes["value"] += "2";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }

        protected void btnNum3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].Equals("ErrorPIN"))
                {
                    contenEnterPIN.Controls.Clear();
                    contenEnterPIN.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcRe-EnterPIN.ascx"));
                    txtPIN.Attributes["value"] += "3";
                }
                else
                {
                    txtPIN.Attributes["value"] += "3";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }

        protected void btnNum4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].Equals("ErrorPIN"))
                {
                    contenEnterPIN.Controls.Clear();
                    contenEnterPIN.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcRe-EnterPIN.ascx"));
                    txtPIN.Attributes["value"] += "4";
                }
                else
                {
                    txtPIN.Attributes["value"] += "4";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }

        protected void btnNum5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].Equals("ErrorPIN"))
                {
                    contenEnterPIN.Controls.Clear();
                    contenEnterPIN.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcRe-EnterPIN.ascx"));
                    txtPIN.Attributes["value"] += "5";
                }
                else
                {
                    txtPIN.Attributes["value"] += "5";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }

        protected void btnNum6_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].Equals("ErrorPIN"))
                {
                    contenEnterPIN.Controls.Clear();
                    contenEnterPIN.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcRe-EnterPIN.ascx"));
                    txtPIN.Attributes["value"] += "6";
                }
                else
                {
                    txtPIN.Attributes["value"] += "6";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }

        protected void btnNum7_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].Equals("ErrorPIN"))
                {
                    contenEnterPIN.Controls.Clear();
                    contenEnterPIN.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcRe-EnterPIN.ascx"));
                    txtPIN.Attributes["value"] += "7";
                }
                else
                {
                    txtPIN.Attributes["value"] += "7";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }

        protected void btnNum8_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].Equals("ErrorPIN"))
                {
                    contenEnterPIN.Controls.Clear();
                    contenEnterPIN.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcRe-EnterPIN.ascx"));
                    txtPIN.Attributes["value"] += "8";
                }
                else
                {
                    txtPIN.Attributes["value"] += "8";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }

        protected void btnNum9_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].Equals("ErrorPIN"))
                {
                    contenEnterPIN.Controls.Clear();
                    contenEnterPIN.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcRe-EnterPIN.ascx"));
                    txtPIN.Attributes["value"] += "9";
                }
                else
                {
                    txtPIN.Attributes["value"] += "9";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }

        protected void btnDot_Click(object sender, EventArgs e)
        {

        }

        protected void btnNum0_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].Equals("ErrorPIN"))
                {
                    contenEnterPIN.Controls.Clear();
                    contenEnterPIN.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcRe-EnterPIN.ascx"));
                    txtPIN.Attributes["value"] += "0";
                }
                else
                {
                    txtPIN.Attributes["value"] += "0";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }
        int count = 0;
        protected void btnComma_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region ***** button Enter Cancel and Clear *****
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].Equals("ErrorPIN"))
                {
                    txtPIN.Attributes["value"] = "";
                    contenEnterPIN.Controls.Clear();
                    contenEnterPIN.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcRe-EnterPIN.ascx"));
                }
                else
                {
                    txtPIN.Attributes["value"] = "";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].Equals("ErrorPIN"))
                {
                    string CardNo = Session["CardNo"].ToString();
                    card = cardBl.GetByCardNo(CardNo);
                    card.Attempt = 0;
                    cardBl.UpdateStatus(card);
                }
                Session["PIN"] = "";
                Response.Redirect("~/InsertCardMain.aspx", false);
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
                CheckAttempt();
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }
        #endregion

        #region ***** button OK and Cancel*****
        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
                CheckAttempt();
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].Equals("ErrorPIN"))
                {
                    string CardNo = Session["CardNo"].ToString();
                    card = cardBl.GetByCardNo(CardNo);
                    card.Attempt = 0;
                    cardBl.UpdateStatus(card);
                }
                Session["PIN"] = "";
                Response.Redirect("~/InsertCardMain.aspx", false);
            }
            catch (Exception ex)
            {
                lblError.Text = "error:" + ex.Message;
                logger.Debug(ex.Message);
            }
        }
        #endregion

    }
}