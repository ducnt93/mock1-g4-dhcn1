using System;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using System.Threading.Tasks;
using System.Threading;

namespace WebApplication1.UC1.Validation
{
    public partial class Validation : System.Web.UI.Page
    {
        CardBL cardBl = new CardBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string cardNo = Request.QueryString["CardNo"];
            Card card = cardBl.GetByCardNo(cardNo);
            if (card == null)
            {
                Response.Redirect("~/UC1.Validation/ValidationError.aspx");
            }
            else
            {
                Session["CardNo"] = cardNo;
                Response.Redirect("~/UC1.Validation/EnterPIN.aspx");
            }
        
        }
    }
}