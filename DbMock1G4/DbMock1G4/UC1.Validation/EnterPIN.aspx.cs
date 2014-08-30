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
        protected void Page_Load(object sender, EventArgs e)
        {
            txtPIN.Focus();
        }
        protected void btnNum1_Click(object sender, EventArgs e)
        {
            txtPIN.Text += "1";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtPIN.Text = "";
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

        private void CancelTrans()
        {
            Session["CardNo"] = "";
            Session["PIN"] = "";
            Session["AccountId"] = "";
            Response.Redirect("~/InsertCardMain.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CancelTrans();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UC1.Validation/ValidateCard.aspx?CardNo=" + txtPIN.Text);
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            Session["PIN"] = txtPIN.Text;
            Response.Redirect("ValidationPIN.aspx");
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Session["PIN"] = txtPIN.Text;
            Response.Redirect("ValidationPIN.aspx");
        }

        protected void btnCance_Click(object sender, EventArgs e)
        {
            CancelTrans();
        }
    }
}