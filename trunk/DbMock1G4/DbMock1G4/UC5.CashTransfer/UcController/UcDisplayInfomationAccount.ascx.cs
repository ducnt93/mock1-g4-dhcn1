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
        readonly AccountBL AccountBusinessLogic = new AccountBL();
        readonly CustomerBL CustomerBusinessLogic = new CustomerBL();
        Account account = new Account();
        Customer customer = new Customer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoadName(object sender, EventArgs e)
        {
            // cái này 
            if (Session["AccountReceiveId"]!=null)
            {
                account = AccountBusinessLogic.GetByAccountId(Convert.ToInt32(Session["AccountReceiveId"].ToString()));
                customer = CustomerBusinessLogic.GetByCusId(Convert.ToInt32(account.CusId));
                lblAccountName.Text = customer.Name;
            }
            else
            {
                lblAccountName.Text = "";
            }
        }

        protected void LoadID(object sender, EventArgs e)
        {
            if (Session["AccountReceiveId"]!=null)
            {
                lblAccountID.Text = Session["AccountReceiveId"].ToString();
            }
            else
            {
                lblAccountID.Text = "";
            }
        }
    }
}