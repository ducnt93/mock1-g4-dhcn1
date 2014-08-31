using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbMock1G4.BusinessLogic;

namespace WebApplication1.UC4.ViewHistory
{
    public partial class CriteriasChoose : System.Web.UI.Page
    {
        LogBL log=new LogBL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn50_Click(object sender, EventArgs e)
        {
            Session["ViewState"] = ("1 Week ago");
            Response.Redirect("~/UC4.ViewHistory/WaittedScreen.aspx");
        }

        protected void btn200_Click(object sender, EventArgs e)
        {
            Session["ViewState"] = ("1 Month ago");
            Response.Redirect("~/UC4.ViewHistory/WaittedScreen.aspx");
        }

        protected void btn300_Click(object sender, EventArgs e)
        {
            Session["ViewState"] = ("4 Month ago");
            Response.Redirect("~/UC4.ViewHistory/WaittedScreen.aspx");
        }

        protected void btn100_Click(object sender, EventArgs e)
        {
            Session["ViewState"] = ("6 Month ago");
            Response.Redirect("~/UC4.ViewHistory/WaittedScreen.aspx");
        }

        protected void btn250_Click(object sender, EventArgs e)
        {
            Session["ViewState"] = ("1 Year ago");
            Response.Redirect("~/UC4.ViewHistory/WaittedScreen.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["ViewState"] = ("2 Year ago");
            Response.Redirect("~/UC4.ViewHistory/WaittedScreen.aspx");
        }

    }
}