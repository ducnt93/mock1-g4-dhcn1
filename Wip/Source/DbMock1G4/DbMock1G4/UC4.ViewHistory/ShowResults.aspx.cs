using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;

namespace WebApplication1.UC4.ViewHistory
{
    public partial class ShowResults : System.Web.UI.Page
    {
        LogBL logbl = new LogBL();
        
        protected void Page_Load(object sender, EventArgs e)
        {          
            if (!Page.IsPostBack)
            {
                string time = Session["CriteriasChoose"].ToString();
                string cardNo = Session["cardNo"].ToString();
                CheckViewHistory(time,cardNo);
            }
        }

        private void CheckViewHistory(string time, string cardNo)
        {
            if (time == "1 Week ago")
            {
                grViewhistory.DataSource = logbl.GetListPaged(7, cardNo);
                grViewhistory.DataBind();
            }
            if (time == "1 Month ago")
            {
                grViewhistory.DataSource = logbl.GetListPaged(30, cardNo);
                grViewhistory.DataBind();
            }
            if (time == "4 Month ago")
            {
                grViewhistory.DataSource = logbl.GetListPaged(120, cardNo);
                grViewhistory.DataBind();
            }
            if (time == "6 Month ago")
            {
                grViewhistory.DataSource = logbl.GetListPaged(180, cardNo);
                grViewhistory.DataBind();
            }
            if (time == "1 Year ago")
            {
                grViewhistory.DataSource = logbl.GetListPaged(365, cardNo);
                grViewhistory.DataBind();
            }
            if (time == "2 Year ago")
            {
                grViewhistory.DataSource = logbl.GetListPaged(700, cardNo);
                grViewhistory.DataBind();
            }
        }
        protected void grViewhistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string time = Session["CriteriasChoose"].ToString();
            string cardNo = Session["cardNo"].ToString();
            grViewhistory.PageIndex = e.NewPageIndex;
            CheckViewHistory(time, cardNo);
            grViewhistory.DataBind();
            Page_Load(sender,e);
        }

        protected void btn6_Click(object sender, EventArgs e)
        {
            //Page_Load(sender, e);
        }

        protected void btn300_Click(object sender, EventArgs e)
        {
            //Page_Load(sender, e);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainATM.aspx");
        }
    }
}