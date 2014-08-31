using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbMock1G4.BusinessLogic;

namespace WebApplication1.UC4.ViewHistory
{
    public partial class ShowResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {          
            LogBL logbl = new LogBL();
            string thoigian=Session["ViewState"].ToString();
            if (!Page.IsPostBack)
            {
                if (thoigian == "1 Week ago")
                {
                    grViewhistory.DataSource = logbl.GetListPaged(1, 1, 7);
                    grViewhistory.DataBind();
                }
                if (thoigian == "1 Month ago")
                {
                    grViewhistory.DataSource = logbl.GetListPaged(1, 1, 30);
                    grViewhistory.DataBind();
                }
                if (thoigian == "4 Month ago")
                {
                    grViewhistory.DataSource = logbl.GetListPaged(1, 1, 120);
                    grViewhistory.DataBind();
                }
                if (thoigian == "6 Month ago")
                {
                    grViewhistory.DataSource = logbl.GetListPaged(1, 1, 180);
                    grViewhistory.DataBind();
                }
                if (thoigian == "1 Year ago")
                {
                    grViewhistory.DataSource = logbl.GetListPaged(1, 1, 365);
                    grViewhistory.DataBind();
                }
                if (thoigian == "2 Year ago")
                {
                    grViewhistory.DataSource = logbl.GetListPaged(1, 1, 700);
                    grViewhistory.DataBind();
                }
            }
        }

        protected void btn250_Click(object sender, EventArgs e)
        {
           // Response.Redirect("~/UC4.ViewHistory/CriteriasChoose.aspx");
        }
    }
}