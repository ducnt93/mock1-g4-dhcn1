using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using log4net;
using WebApplication1.UC5.CashTransfer.UcController;

namespace WebApplication1.UC5.CashTransfer
{
    public partial class CashTranfer : System.Web.UI.Page
    {
        readonly AccountBL accountBl = new AccountBL();
        Account account = new Account();
        readonly Account accountR = new Account();
        readonly LogBL logBl = new LogBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["AccountId"] = "1";
            account = accountBl.GetByAccountId(Convert.ToInt32(Session["AccountId"].ToString()));
            if (!IsPostBack)
            {
               //Khi ở màn hình chào thì gán ViewState là InputAccountR
                contenPlace.Controls.Clear();
                //contenPlace.Controls.Add(LoadControl("~/UC5.CashTransfer/UcController/UcHelloCashTransfer.ascx"));
                contenPlace.Controls.Add(UcHelloCashTransfer);
                Session["ViewState"] = "InputAccountR";
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            ResetSession();
            Response.Redirect("InsertCardMain.aspx");
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            //Step1 chọn nút Accept thì Chuyển qua màn hình InputAccountR
            if (Session["ViewState"].ToString() == "InputAccountR")
            {
                contenPlace.Controls.Clear();
                //contenPlace.Controls.Add(LoadControl("~/UC5.CashTransfer/UcController/UcInputAccountReceive.ascx"));
                contenPlace.Controls.Add(UcInputAccountReceive);
                Session["ViewState"] = "DisplayAccountR";
            }

            //Step3 
            else if (Session["ViewState"].ToString() == "InputAmount")
            {
                contenPlace.Controls.Clear();
                //contenPlace.Controls.Add(LoadControl("~/UC5.CashTransfer/UcController/UcDisplayAccountReceiveAndAmount.ascx"));
                contenPlace.Controls.Add(UcDisplayInfomationAccount);
                Session["ViewState"] = "DisplayTransferCashInfomation";
            }

            //Step5
            else if (Session["ViewState"].ToString() == "PrintPeceipt")
            {
                contenPlace.Controls.Clear();
                //contenPlace.Controls.Add(LoadControl("~/UC5.CashTransfer/UcController/UcPrintPeceiptCT.ascx"));
                contenPlace.Controls.Add(UcPrintPeceiptCT);
                Session["ViewState"] = "";
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetSession();
            Response.Redirect("InsertCardMain.aspx");
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            //Step2 
            TextBox txtAccIdR = (TextBox)UcInputAccountReceive.FindControl("txtAccountReceiveID");
            Response.Write(txtAccIdR.Text);
            Session["AccountIdR"] = txtAccIdR.Text;
            if (Session["ViewState"].ToString() == "DisplayAccountR")
            {
                if (Session["AccountIdR"].ToString() != "")
                {
                    if (accountBl.CheckAcc(Convert.ToInt32(Session["AccountIdR"].ToString())) == null)
                    {
                        contenPlace.Controls.Clear();
                        //contenPlace.Controls.Add(LoadControl("~/UC5.CashTransfer/UcController/UcErrorAccount.ascx"));
                        contenPlace.Controls.Add(UcErrorAccount);
                        Session["ViewState"] = "ErrorAccount";
                    }
                    else
                    {
                        contenPlace.Controls.Clear();
                        //contenPlace.Controls.Add(LoadControl("~/UC5.CashTransfer/UcController/UcDisplayInfomationAccount.ascx"));
                        contenPlace.Controls.Add(UcDisplayInfomationAccount);
                        Session["ViewState"] = "InputAmount";
                    }
                }
                else
                {
                    contenPlace.Controls.Clear();
                    //contenPlace.Controls.Add(LoadControl("~/UC5.CashTransfer/UcController/UcErrorAccount.ascx"));
                    contenPlace.Controls.Add(UcErrorAccount);
                    Session["ViewState"] = "ErrorAccount";
                }
            }

              //Step4
            else if (Session["ViewState"].ToString() == "InputAmount")
            {
                var txtmoney = contenPlace.FindControl("txtAmount") as TextBox;
                var money = Convert.ToDecimal(txtmoney.Text);
                var checkBalance = accountBl.CheckBalance(accountR, money);
                if (checkBalance)
                {
                    contenPlace.Controls.Clear();
                    //contenPlace.Controls.Add(LoadControl("~/UC5.CashTransfer/UcController/UcDisplayAccountReceiveAndAmount.ascx"));
                    contenPlace.Controls.Add(UcDisplayAccountReceiveAndAmount);
                    Session["ViewState"] = "PrintPeceiptCT";
                }
                else
                {
                    contenPlace.Controls.Clear();
                    //contenPlace.Controls.Add(LoadControl("~/UC5.CashTransfer/UcController/UcErrorAmount.ascx"));
                    contenPlace.Controls.Add(UcErrorAmount);
                    Session["ViewState"] = "ErrorAmount";
                }
            }

            //Step 6 error account
            else if (Session["ViewState"].ToString() == "ErrorAccount")
            {
                contenPlace.Controls.Clear();
                //contenPlace.Controls.Add(LoadControl("~/UC5.CashTransfer/UcController/UcDisplayInfomationAccount.ascx"));
                contenPlace.Controls.Add(UcDisplayInfomationAccount);
                Session["ViewState"] = "DisplayAccountR";
            }

            //Step 7 error amount
            else if (Session["ViewState"].ToString() == "ErrorAmount")
            {
                contenPlace.Controls.Clear();
                //contenPlace.Controls.Add(LoadControl("~/UC5.CashTransfer/UcController/UcPrintPeceiptCT.ascx"));
                contenPlace.Controls.Add(UcPrintPeceiptCT);
                Session["ViewState"] = "PrintPeceiptCT";
            }
        }

        private void ResetSession()
        {
            Session["CardNo"] = "";
            Session["PIN"] = "";
            Session["AccountId"] = "";
        }

        private void WriteLog(decimal money)
        {
            try
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
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(ex.Message);
            }

        }
    }
}