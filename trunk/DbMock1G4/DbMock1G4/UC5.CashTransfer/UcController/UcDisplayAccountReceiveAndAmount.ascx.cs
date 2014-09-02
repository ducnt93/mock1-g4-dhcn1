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
    public partial class UcDisplayAccountReceiveAndAmount : System.Web.UI.UserControl
    {
        AccountBL accBl = new AccountBL();
        CustomerBL cusBl = new CustomerBL();
        Account account = new Account();
        Customer customer = new Customer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoadName(object sender, EventArgs e)
        {
            account = accBl.GetByAccountId(Convert.ToInt32(Session["AccountId"].ToString()));
            customer = cusBl.GetByCusId(Convert.ToInt32(account.CusId));
            lblAccountName.Text = customer.Name;
        }

        protected void LoadID(object sender, EventArgs e)
        {
            lblAccountID.Text = Session["AccountId"].ToString();
        }


        protected void LoadAmount(object sender, EventArgs e)
        {
            lblAmount.Text = Session["Amount"].ToString();
        }
    }
}