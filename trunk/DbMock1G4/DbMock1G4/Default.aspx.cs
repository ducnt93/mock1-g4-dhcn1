using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Money m = new Money();
            MoneyBL moneyBl = new MoneyBL();
            m.Address = TextBox3.Text;
            //m.MoneyId = int.Parse(TextBox1.Text);
            m.MoneyValue = int.Parse(TextBox2.Text);
            moneyBl.Add(m);
        }
    }
}