using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;

namespace WebApplication1.UC5.CashTransfer.UcController
{
    public partial class InfomationAccount : System.Web.UI.UserControl
    {
        readonly AccountBL accBl = new AccountBL();
        readonly CustomerBL cusBl = new CustomerBL();
        Account account = new Account();
        Customer customer = new Customer();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Gan o day thi lai duoc
            Session["AccountIdR"] = 2;
        }

        protected void LoadName(object sender, EventArgs e)
        {
            // cái này 
            if (Session["AccountIdR"].ToString()!="")
            {
                account = accBl.GetByAccountId(Convert.ToInt32(Session["AccountIdR"].ToString()));
                customer = cusBl.GetByCusId(Convert.ToInt32(account.CusId));
                lblAccountName.Text = customer.Name;
            }
            else
            {
                lblAccountName.Text = "";
            }
        }

        protected void LoadID(object sender, EventArgs e)
        {
            if (Session["AccountIdR"].ToString() != "")
            {
                lblAccountID.Text = Session["AccountIdR"].ToString();
            }
            else
            {
                lblAccountID.Text = "";
            }
        }
    }
}