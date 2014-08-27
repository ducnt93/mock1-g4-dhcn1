using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;

namespace WebApplication1.UC2.WithdrawMoney
{
    public partial class Withdraw1 : System.Web.UI.Page
    {
        readonly AccountBL accountBl = new AccountBL();
        readonly LogBL logBl = new LogBL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void ResetSession()
        {
            Session["CardNo"] = "";
            Session["PIN"] = "";
            Session["AccountId"] = "";
        }

        private void WriteLog(decimal money)
        {
            Log log = new Log();
            log.Amount = money;
            log.LogDate = DateTime.Now;
            log.AtmId = 1;
            log.CardNo = Session["CardNo"].ToString();
            log.Details = "";
            log.LogTypeId = 1;
            logBl.Add(log);
        }
        protected void btn50_Click(object sender, EventArgs e)
        {
            const decimal money = 500000;
            int accId = Convert.ToInt32(Session["AccountId"]);
            bool check = accountBl.CheckBalance(accId, money);
            if (check == false)
            {
              
                Response.Redirect("~/UC2.WithdrawMoney/ErrorScreen.aspx");
            }
            else
            {
                WriteLog(money);
                ResetSession();
                Response.Redirect("~/UC2.WithdrawMoney/PrintReceipt.aspx");
            }
        }

        protected void btn200_Click(object sender, EventArgs e)
        {
            const decimal money = 2000000;
            int accId = Convert.ToInt32(Session["AccountId"]);
            bool check = accountBl.CheckBalance(accId, money);
            if (check == false)
            {
               
                Response.Redirect("~/UC2.WithdrawMoney/ErrorScreen.aspx");
            }
            else
            {
                WriteLog(money);
                ResetSession();
                Response.Redirect("~/UC2.WithdrawMoney/PrintReceipt.aspx");
            }
        }

        protected void btn300_Click(object sender, EventArgs e)
        {
            const decimal money = 3000000;
            int accId = Convert.ToInt32(Session["AccountId"]);
            bool check = accountBl.CheckBalance(accId, money);
            if (check == false)
            {
              
                Response.Redirect("~/UC2.WithdrawMoney/ErrorScreen.aspx");
            }
            else
            {
                WriteLog(money);
                ResetSession();
                Response.Redirect("~/UC2.WithdrawMoney/PrintReceipt.aspx");
            }
        }

        protected void btn100_Click(object sender, EventArgs e)
        {
            const decimal money = 1000000;
            int accId = Convert.ToInt32(Session["AccountId"]);
            bool check = accountBl.CheckBalance(accId, money);
            if (check == false)
            {
                Response.Redirect("~/UC2.WithdrawMoney/ErrorScreen.aspx");
            }
            else
            {
                WriteLog(money);
                ResetSession();
                Response.Redirect("~/UC2.WithdrawMoney/PrintReceipt.aspx");
            }
        }

        protected void btn250_Click(object sender, EventArgs e)
        {
            const decimal money = 2500000;
            int accId = Convert.ToInt32(Session["AccountId"]);
            bool check = accountBl.CheckBalance(accId, money);
            if (check == false)
            {

                Response.Redirect("~/UC2.WithdrawMoney/ErrorScreen.aspx");
            }
            else
            {
                WriteLog(money);
                ResetSession();
                Response.Redirect("~/UC2.WithdrawMoney/PrintReceipt.aspx");
            }
        }
    }
}