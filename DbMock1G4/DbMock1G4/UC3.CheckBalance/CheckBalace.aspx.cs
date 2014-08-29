using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using  DbMock1G4.BusinessLogic;
using  DbMock1G4.BusinessObjects;

namespace WebApplication1.UC3.CheckBalance
{
    public partial class CheckBalace : System.Web.UI.Page
    {
        AccountBL accountBl = new AccountBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int accountId = int.Parse(Session["AccountId"].ToString());
                Account account = accountBl.GetBalance(accountId);
                if (account != null)
                {
                    lblAccount.Text = account.Balance.ToString();
                }

            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session["CardNo"] = "";
            Session["PIN"] = "";
            Session["AccountId"] = "";
            Response.Redirect("~/InsertCardMain.aspx");
        }
    }
}