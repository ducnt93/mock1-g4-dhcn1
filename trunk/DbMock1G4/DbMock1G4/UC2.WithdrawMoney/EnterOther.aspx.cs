using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using  DbMock1G4.BusinessLogic;
using  DbMock1G4.BusinessObjects;

namespace WebApplication1.UC2.WithdrawMoney
{
    public partial class EnterOrther : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNum1_Click(object sender, EventArgs e)
        {
            txtEnterCash.Text += "1";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtEnterCash.Text = "";
        }

        protected void btnNum2_Click(object sender, EventArgs e)
        {
            txtEnterCash.Text += "2";
        }

        protected void btnNum3_Click(object sender, EventArgs e)
        {
            txtEnterCash.Text += "3";
        }

        protected void btnNum4_Click(object sender, EventArgs e)
        {
            txtEnterCash.Text += "4";
        }

        protected void btnNum5_Click(object sender, EventArgs e)
        {
            txtEnterCash.Text += "5";
        }

        protected void btnNum6_Click(object sender, EventArgs e)
        {
            txtEnterCash.Text += "6";
        }

        protected void btnNum7_Click(object sender, EventArgs e)
        {
            txtEnterCash.Text += "7";
        }

        protected void btnNum8_Click(object sender, EventArgs e)
        {
            txtEnterCash.Text += "8";
        }

        protected void btnNum9_Click(object sender, EventArgs e)
        {
            txtEnterCash.Text += "9";
        }

        protected void btnDot_Click(object sender, EventArgs e)
        {
            txtEnterCash.Text += ".";
        }

        protected void btnNum0_Click(object sender, EventArgs e)
        {
            txtEnterCash.Text += "0";
        }
        int count = 0;
        protected void btnComma_Click(object sender, EventArgs e)
        {
            count = 1;
            txtEnterCash.Text += ",";
            if (count == 1)
            {
                txtEnterCash.Text += "";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["CardNo"] = "";
            Session["PIN"] = "";
            Page_Load(sender, e);
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {

        }
        AccountBL accountBl = new AccountBL();
        protected void btnOk_Click(object sender, EventArgs e)
        {
            decimal money = Convert.ToDecimal(txtEnterCash.Text);
            int accId = Convert.ToInt32(Session["AccountId"]);
            bool check = accountBl.CheckBalance(accId, money);
            if (check == false)
            {
                Response.Redirect("~/UC2.WithdrawMoney/ErrorScreen.aspx");
            }
            else
            {
                Response.Redirect("~/UC2.WithdrawMoney/PrintReceipt.aspx");
            }
        }
    }
}