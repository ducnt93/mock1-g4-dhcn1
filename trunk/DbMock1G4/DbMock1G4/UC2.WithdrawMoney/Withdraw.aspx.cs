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
        readonly LogBL logBl = new LogBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["ViewState"].ToString() == "Error")
                    {
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcErrorScreen.ascx"));
                    }
                    else
                    {
                        if (Session["ViewState"].ToString() == "PrintPeceipt")
                        {
                            contenPlace.Controls.Clear();
                            contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcPrintPeceipt.ascx"));
                        }
                        else
                        {
                            contenPlace.Controls.Clear();
                            contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcWithdraw.ascx"));
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
                    bool check = accountBl.CheckBalanceWithDraw(accId, money);
                    if (check == false)
                    {
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcErrorScreen.ascx"));
                    }
                    else
                    {
                        Session["ViewState"] = "PrintPeceipt";
                        WriteLog(money);
                        ResetSession();
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcPrintPeceipt.ascx"));
                    }
                }
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
                    bool check = accountBl.CheckBalanceWithDraw(accId, money);
                    if (check == false)
                    {
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcErrorScreen.ascx"));
                    }
                    else
                    {
                        Session["ViewState"] = "PrintPeceipt";
                        WriteLog(money);
                        ResetSession();
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcPrintPeceipt.ascx"));
                    }
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
                    bool check = accountBl.CheckBalanceWithDraw(accId, money);
                    if (check == false)
                    {
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcErrorScreen.ascx"));
                    }
                    else
                    {
                        Session["ViewState"] = "PrintPeceipt";
                        WriteLog(money);
                        ResetSession();
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcPrintPeceipt.ascx"));
                    }
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
                    bool check = accountBl.CheckBalanceWithDraw(accId, money);
                    if (check == false)
                    {
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcErrorScreen.ascx"));
                    }
                    else
                    {
                        Session["ViewState"] = "PrintPeceipt";
                        WriteLog(money);
                        ResetSession();
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcPrintPeceipt.ascx"));
                    }
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
                    bool check = accountBl.CheckBalanceWithDraw(accId, money);
                    if (check == false)
                    {
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcErrorScreen.ascx"));
                    }
                    else
                    {
                        Session["ViewState"] = "PrintPeceipt";
                        WriteLog(money);
                        ResetSession();
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(LoadControl("~/UC2.WithdrawMoney/UcController/UcPrintPeceipt.ascx"));
                    }
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
                            Session["ViewState"] = "Withdraw";
                            Response.Redirect("~/MainATM.aspx");
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
            if (Session["ViewState"].ToString() == "Withdraw")
            {
                Response.Redirect("~/MainATM.aspx");
            }
        }
    }
}