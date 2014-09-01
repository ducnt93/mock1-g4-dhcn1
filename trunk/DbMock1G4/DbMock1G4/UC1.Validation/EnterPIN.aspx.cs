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
    public partial class EnterPIN : System.Web.UI.Page
    {
        CardBL cardBl = new CardBL();
        Card card;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckAttempt()
        {
            string pin = txtPIN.Text;
            string CardNo = Session["CardNo"].ToString();
            card = cardBl.GetByCardNo(CardNo);
            cardBl.CheckAttempt(card, pin);
            if (card.Attempt == 0)
            {
                card.Attempt = 0;
                card.Status = "UnBlock";
                cardBl.Update(card);
                Session["PIN"] = pin;
                Session["AccountId"] = card.AccountId;
                Session["ViewSate"] = "Authentication";
                Response.Redirect("~/MainATM.aspx");
            }
            else if (card.Attempt >= 1 && card.Attempt < 3)
            {
                cardBl.Update(card);
                Session["ViewSate"] = "ErrorPIN";
                txtPIN.Text = "";
                contenEnterPIN.Controls.Clear();
                contenEnterPIN.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcRe-EnterPIN.ascx"));
            }
            else
            {
                Session["ViewSate"] = "BlockCard";
                contenBlockCard.Controls.Clear();
                contenBlockCard.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcBlockCard.ascx"));
                card.Status = "Block";
                cardBl.Update(card);
            }
        }

        #region ***** button number *****
        protected void btnNum1_Click(object sender, EventArgs e)
        {
            txtPIN.Text += "1";
        }

        protected void btnNum2_Click(object sender, EventArgs e)
        {
            txtPIN.Text += "2";
        }

        protected void btnNum3_Click(object sender, EventArgs e)
        {
            txtPIN.Text += "3";
        }

        protected void btnNum4_Click(object sender, EventArgs e)
        {
            txtPIN.Text += "4";
        }

        protected void btnNum5_Click(object sender, EventArgs e)
        {
            txtPIN.Text += "5";
        }

        protected void btnNum6_Click(object sender, EventArgs e)
        {
            txtPIN.Text += "6";
        }

        protected void btnNum7_Click(object sender, EventArgs e)
        {
            txtPIN.Text += "7";
        }

        protected void btnNum8_Click(object sender, EventArgs e)
        {
            txtPIN.Text += "8";
        }

        protected void btnNum9_Click(object sender, EventArgs e)
        {
            txtPIN.Text += "9";
        }

        protected void btnDot_Click(object sender, EventArgs e)
        {
            txtPIN.Text += ".";
        }

        protected void btnNum0_Click(object sender, EventArgs e)
        {
            txtPIN.Text += "0";
        }
        int count = 0;
        protected void btnComma_Click(object sender, EventArgs e)
        {
            count = 1;
            txtPIN.Text += ",";
            if (count == 1)
            {
                txtPIN.Text += "";
            }
        }
        #endregion

        #region ***** button Enter Cancel and Clear *****
        protected void btnClear_Click(object sender, EventArgs e)
        {
            if(Session["ViewSate"].Equals("ErrorPIN"))
            {
                txtPIN.Text = "";
                contenEnterPIN.Controls.Clear();
                contenEnterPIN.Controls.Add(LoadControl("~/UC1.Validation/UcController/UcRe-EnterPIN.ascx"));
            }
            else
            {
                txtPIN.Text = "";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Session["ViewSate"].Equals("ErrorPIN"))
            {
                card.Attempt = 0;
                card.Status = "UnBlock";
                cardBl.Update(card);
            }
            Session["PIN"] = "";
            Response.Redirect("~/InsertCardMain.aspx");
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            contenEnterPIN.Controls.Clear();
            contenEnterPIN.Controls.Add(LoadControl("~/UC1.Validation/UcController/ValidatingPIN.ascx"));
            CheckAttempt();
        }
        #endregion

        #region ***** button OK Cancel and Clear *****
        protected void Button5_Click(object sender, EventArgs e)
        {
            contenEnterPIN.Controls.Clear();
            contenEnterPIN.Controls.Add(LoadControl("~/UC1.Validation/UcController/ValidatingPIN.ascx"));
            CheckAttempt();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (Session["ViewSate"].Equals("ErrorPIN"))
            {
                card.Attempt = 0;
                card.Status = "UnBlock";
                cardBl.Update(card);
            }
            Session["PIN"] = "";
            Response.Redirect("~/InsertCardMain.aspx");
        }
        #endregion

    }
}