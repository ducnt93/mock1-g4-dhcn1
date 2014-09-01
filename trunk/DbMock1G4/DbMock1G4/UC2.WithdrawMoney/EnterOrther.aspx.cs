using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using log4net;

namespace WebApplication1.UC2.WithdrawMoney
{
    public partial class EnterOrther : System.Web.UI.Page
    {
        readonly AccountBL accountBl = new AccountBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEnterCash.Focus();
        }

        protected void btn250_Click(object sender, EventArgs e)
        {
            try
            {
                Session["ViewState"] = "PrintPeceipt";
                int accountId = int.Parse(Session["AccountId"].ToString());
                decimal money = Convert.ToDecimal(txtEnterCash.Text);
                bool check = accountBl.CheckBalance(accountId, money);
                if (check == false)
                {
                    lblError.Text = "Number enter have to div to 50.000";
                    txtEnterCash.Text = "";
                    txtEnterCash.Focus();
                }
                else
                {
                    Response.Redirect("Withdraw.aspx");
                }
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(ex.Message);
            }
           
            
        }

        protected void btnOrther_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UC2.WithdrawMoney/Withdraw.aspx");
        }
    }
}