using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using log4net;

namespace WebApplication1.UC2.WithdrawMoney
{
    public partial class Withdraw1 : System.Web.UI.Page
    {
        readonly AccountBL accountBl = new AccountBL();
        StockBL stockBl = new StockBL();
        readonly LogBL logBl = new LogBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    switch (Session["ViewState"].ToString())
                    {
                        case "Error":
                            contenPlace.Controls.Clear();
                            contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcErrorScreen.ascx"));
                            break;
                        case "PrintPeceipt":
                            contenPlace.Controls.Clear();
                            contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcPrintPeceipt.ascx"));
                            break;
                        case "Test":
                            contenPlace.Controls.Clear();
                            contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcTest.ascx"));
                            break;
                        default:
                            contenPlace.Controls.Clear();
                            contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcWithdraw.ascx"));
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(ex.Message);
            }

        }
        public void UpdateBalance(int accId, decimal money)
        {
            Account account = accountBl.GetByAccountId(accId);
            decimal balance = account.Balance;
            balance = balance - money;
            accountBl.DispenserMoney(accId, balance);
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
        protected void btn50_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].ToString() == "Withdraw")
                {
                    const decimal money = 500000;
                    int accId = Convert.ToInt32(Session["AccountId"]);
                    int AtmId = 1;
                    CheckWithdraw(AtmId, accId, money);
                }
                //else
                //{
                //    if (Session["ViewState"].ToString() == "PrintPeceipt")
                //    {
                //        contenPlace.Controls.Clear();
                //        contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcTest.ascx"));
                //    }
                //    else
                //    {
                //        contenPlace.Controls.Clear();
                //        contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcWithdraw.ascx"));
                //    }
                //}
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(ex.Message);
            }
        }

        protected void btn200_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].ToString() == "Withdraw")
                {
                    const decimal money = 2000000;
                    int accId = Convert.ToInt32(Session["AccountId"]);
                    int AtmId = 1;
                    CheckWithdraw(AtmId, accId, money);
                }
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(ex.Message);
            }
        }

        protected void btn300_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].ToString() == "Withdraw")
                {
                    const decimal money = 3000000;
                    int accId = Convert.ToInt32(Session["AccountId"]);
                    int AtmId = 1;
                    CheckWithdraw(AtmId, accId, money);
                }
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(ex.Message);
            }
        }

        protected void btn100_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].ToString() == "Withdraw")
                {
                    const decimal money = 1000000;
                    int accId = Convert.ToInt32(Session["AccountId"]);
                    int AtmId = 1;
                    CheckWithdraw(AtmId, accId, money);
                }
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(ex.Message);
            }
        }

        protected void btn250_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].ToString() == "Withdraw")
                {
                    const decimal money = 2500000;
                    int accId = Convert.ToInt32(Session["AccountId"]);
                    int AtmId = 1;
                    CheckWithdraw(AtmId, accId, money);
                }
                else
                {
                    if (Session["ViewState"].ToString() == "PrintPeceipt")
                    {
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcTest.ascx"));
                    }
                }
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(ex.Message);
            }
        }

        private void CheckWithdraw(int atmId, int accId, decimal money)
        {
            if (Session["ViewState"].ToString() == "Withdraw")
            {

                bool check = accountBl.CheckBalanceWithDraw(accId, money);
                int checkAtm = stockBl.CheckMoneyAtm(atmId, accId, money);
                if (check == false)
                {
                    contenPlace.Controls.Clear();
                    contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcErrorScreen.ascx"));
                }
                else
                {
                    if (checkAtm == 1)
                    {
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcErrorScreen.ascx"));
                    }
                    else
                    {
                        if (checkAtm == 2)
                        {
                            contenPlace.Controls.Clear();
                            contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcErrorScreen.ascx"));
                        }
                        else
                        {
                            if (checkAtm == 4)
                            {
                                contenPlace.Controls.Clear();
                                contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcErrorScreen.ascx"));
                            }
                            else
                            {
                                Session["ViewState"] = "PrintPeceipt";
                                UpdateBalance(accId, money);
                                WriteLog(money);
                                ResetSession();
                                contenPlace.Controls.Clear();
                                contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcPrintPeceipt.ascx"));
                            }
                        }
                    }
                }
            }
            else
            {
                if (Session["ViewState"].ToString() == "Test")
                {
                    contenPlace.Controls.Clear();
                    contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcTest.ascx"));
                }
                else
                {
                    contenPlace.Controls.Clear();
                    contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcErrorScreen.ascx"));
                }
            }
        }
        protected void btnOrther_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ViewState"].ToString() == "Withdraw")
                {

                    Response.Redirect("~/UC2.WithdrawMoney/EnterOrther.aspx");
                }
                else
                {
                    if (Session["ViewState"].ToString() == "EnterOrther")
                    {
                        Session["ViewState"] = "PrintPeciept";
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcPrintPeceipt.ascx"));
                    }
                    else
                    {
                        if (Session["ViewState"].ToString() == "PrintPeceipt")
                        {
                            ResetSession();
                            //Session["ViewState"] = "Withdraw";
                            Response.Redirect("~/InsertCardMain.aspx");
                        }
                        else
                        {
                            ResetSession();
                            //Session["ViewState"] = "Withdraw";
                            Response.Redirect("~/InsertCardMain.aspx");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(ex.Message);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
                Response.Redirect("~/MainATM.aspx");
        }
    }
}