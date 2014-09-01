using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using DbMock1G4.BusinessLogic;
namespace WebApplication1
{
    public partial class InsertCardMain : System.Web.UI.Page
    {
        CardBL cardBl = new CardBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCardNo.Focus();
            Session["ViewSate"] = "";
            Session["AcceptCard"] = "";
            Session["ValidCard"] = "";
            Session["CardNo"] = "";

        }

        protected void btnInsertCard_Click(object sender, EventArgs e)
        {
            string cardNo = txtCardNo.Text;
            Session["CardNo"] = cardNo;
            Response.Redirect("~/UC1.Validation/Validate.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtCardNo.Text = "";
        }

        #region ***** Number button *****
        protected void btnNum1_Click(object sender, EventArgs e)
        {
            txtCardNo.Text += "1";

        }

        protected void btnNum2_Click(object sender, EventArgs e)
        {
            txtCardNo.Text += "2";
        }

        protected void btnNum3_Click(object sender, EventArgs e)
        {
            txtCardNo.Text += "3";
        }

        protected void btnNum4_Click(object sender, EventArgs e)
        {
            txtCardNo.Text += "4";
        }

        protected void btnNum5_Click(object sender, EventArgs e)
        {
            txtCardNo.Text += "5";
        }

        protected void btnNum6_Click(object sender, EventArgs e)
        {
            txtCardNo.Text += "6";
        }

        protected void btnNum7_Click(object sender, EventArgs e)
        {
            txtCardNo.Text += "7";
        }

        protected void btnNum8_Click(object sender, EventArgs e)
        {
            txtCardNo.Text += "8";
        }

        protected void btnNum9_Click(object sender, EventArgs e)
        {
            txtCardNo.Text += "9";
        }

        protected void btnDot_Click(object sender, EventArgs e)
        {
            txtCardNo.Text += ".";
        }

        protected void btnNum0_Click(object sender, EventArgs e)
        {
            txtCardNo.Text += "0";
        }
        int count = 0;
        protected void btnComma_Click(object sender, EventArgs e)
        {
            count = 1;
            txtCardNo.Text += ",";
            if (count == 1)
            {
                txtCardNo.Text += "";
            }
        }
        #endregion
    }
}