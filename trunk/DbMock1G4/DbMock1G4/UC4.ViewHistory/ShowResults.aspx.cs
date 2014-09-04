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
        LogBL logbl = new LogBL();
        
        protected void Page_Load(object sender, EventArgs e)
        {          
            if (!Page.IsPostBack)
            {
                string thoigian = Session["CriteriasChoose"].ToString();
                string CardNo = Session["CardNo"].ToString();
                if (thoigian == "1 Week ago")
                {
                    grViewhistory.DataSource = logbl.GetListPaged(1, 1, 7, CardNo);
                    grViewhistory.DataBind();
                }
                if (thoigian == "1 Month ago")
                {
                    grViewhistory.DataSource = logbl.GetListPaged(1, 1, 30, CardNo);
                    grViewhistory.DataBind();
                }
                if (thoigian == "4 Month ago")
                {
                    grViewhistory.DataSource = logbl.GetListPaged(1, 1, 120, CardNo);
                    grViewhistory.DataBind();
                }
                if (thoigian == "6 Month ago")
                {
                    grViewhistory.DataSource = logbl.GetListPaged(1, 1, 180, CardNo);
                    grViewhistory.DataBind();
                }
                if (thoigian == "1 Year ago")
                {
                    grViewhistory.DataSource = logbl.GetListPaged(1, 1, 365, CardNo);
                    grViewhistory.DataBind();
                }
                if (thoigian == "2 Year ago")
                {
                    grViewhistory.DataSource = logbl.GetListPaged(1, 1, 700, CardNo);
                    grViewhistory.DataBind();
                }
            }
        }

        protected void grViewhistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grViewhistory.PageIndex = e.NewPageIndex;
            grViewhistory.DataBind();
           
        }

        protected void btn6_Click(object sender, EventArgs e)
        {
            Page_Load(sender, e);
        }

        protected void btn300_Click(object sender, EventArgs e)
        {
            Page_Load(sender, e);
        }
    }
}