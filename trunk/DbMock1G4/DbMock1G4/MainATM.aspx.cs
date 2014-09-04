using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace WebApplication1
{
    public partial class MainATM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string cardNo = Session["CardNo"].ToString();
                string pin = Session["PIN"].ToString();
                if (cardNo == "" && pin == "")
                {
                    Session["CardNo"] = "";
                    Session["PIN"] = "";
                    Response.Redirect("~/InsertCardMain.aspx");
                }
            }
            catch (Exception ex)
            {

                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(ex.Message);
            }
            

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["CardNo"] = "";
            Session["PIN"] = "";
            Session["AccountId"] = "";
            Page_Load(sender, e);
        }

        protected void btnWithdraw_Click(object sender, EventArgs e)
        {
            try
            {
                string CardNo = Session["CardNo"].ToString();
                string PIN = Session["PIN"].ToString();
                Session["ViewState"] = "Withdraw";
                if (CardNo != "" && PIN != "")
                {
                    Response.Redirect("~/UC2.WithdrawMoney/Withdraw.aspx");
                }
                else
                {
                    Response.Redirect("~/InsertCardMain.aspx");
                }
            }
            catch (Exception ex)
            {

                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(ex.Message);
            }
          
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/UC1.Validation/ValidateCard.aspx?CardNo=" + txtCardNo.Text);
        //}

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session["CardNo"] = "";
            Session["PIN"] = "";
            Session["AccountId"] = "";
            Response.Redirect("~/InsertCardMain.aspx");
        }

        protected void btnCheckBalance_Click(object sender, EventArgs e)
        {
            Session["ViewState"] = "CheckBalance";
            Response.Redirect("~/UC3.CheckBalance/CheckBalace.aspx");
        }

        protected void btnCashTransfer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UC5.CashTransfer/CashTransfer.aspx");
        }
    }
}