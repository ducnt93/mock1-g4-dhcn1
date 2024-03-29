﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using log4net;

namespace WebApplication1.UC5.CashTransfer
{
    public partial class CashTranfer : System.Web.UI.Page
    {
        readonly AccountBL AccountBusinessLogic = new AccountBL();
        Account account = new Account();
        Account accountReceive = new Account();
        readonly LogBL LogBusinessLogic = new LogBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            account = AccountBusinessLogic.GetByAccountId(Convert.ToInt32(Session["AccountId"].ToString()));
            if (!IsPostBack)
            {
                contenPlace.Controls.Clear();
                contenPlace.Controls.Add(UcHelloCashTransfer);
                Session["ViewState"] = "InputAccountReceive_Accept";
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            if (Session["ViewState"].ToString() == "InputAmount_Accept")
            {
                contenPlace.Controls.Clear();
                contenPlace.Controls.Add(UcInputAccountReceive);
                Session["ViewState"] = "DisplayAccountReceive_Enter";
            }

            else if (Session["ViewState"].ToString() == "PrintPeceipt_Accept")
            {
                contenPlace.Controls.Clear();
                contenPlace.Controls.Add(UcInputMoneyTransfer);
                Session["ViewState"] = "DisplayTransferCashInfomation_Enter";
            }
            else if (Session["ViewState"].ToString() == "")
            {
                ResetSession();
                Response.Redirect("~/InsertCardMain.aspx");
            }
            else
            {
                contenPlace.Controls.Clear();
            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            if (Session["ViewState"].ToString() == "")//Thoát ra
            {
                ResetSession();
                Response.Redirect("~/InsertCardMain.aspx");
            }
            else if (Session["ViewState"].ToString() == "InputAccountReceive_Accept")//Chuyển qua màn hình InputAccountReceive
            {
                contenPlace.Controls.Clear();
                contenPlace.Controls.Add(UcInputAccountReceive);
                Session["ViewState"] = "DisplayAccountReceive_Enter";
            }
            else if (Session["ViewState"].ToString() == "PrintPeceipt_Accept")//Chuyển qua màn hình In
            {
                account = AccountBusinessLogic.GetByAccountId(Convert.ToInt32(Session["AccountId"].ToString()));
                accountReceive = AccountBusinessLogic.GetByAccountId(Convert.ToInt32(Session["AccountReceiveId"].ToString()));
                account.Balance = account.Balance - Convert.ToInt32(Session["Amount"].ToString());
                accountReceive.Balance = accountReceive.Balance + Convert.ToInt32(Session["Amount"].ToString());
                int i = AccountBusinessLogic.UpdateBalance(account);
                int j = AccountBusinessLogic.UpdateBalance(accountReceive);
                WriteLog(Convert.ToInt32(Session["Amount"].ToString()));
                contenPlace.Controls.Clear();
                contenPlace.Controls.Add(UcPrintPeceiptCT);
                Session["ViewState"] = "";
            }
            else if (Session["ViewState"].ToString() == "InputAmount_Accept") //Chuyển qua màn hình InputMoneyTransfer
            {
                contenPlace.Controls.Clear();
                contenPlace.Controls.Add(UcInputMoneyTransfer);
                Session["ViewState"] = "DisplayTransferCashInfomation_Enter";
            }
            else
            {
                contenPlace.Controls.Clear();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetSession();
            Response.Redirect("~/InsertCardMain.aspx");
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            if (Session["ViewState"].ToString() == "DisplayAccountReceive_Enter")//Chuyển qua màn hình hiển thị thông tin tài khoản nhận tiền
            {
                var txtAccountReceive = UcInputAccountReceive.FindControl("txtAccountReceiveID") as TextBox;//Lấy control txtAccountReceiveID
                Session["AccountReceiveId"] = txtAccountReceive.Text;//Gán giá trị của control txtAccountReceiveID cho session
                if (Session["AccountReceiveId"].ToString() != "")
                {
                    if (AccountBusinessLogic.CheckAcc(Convert.ToInt32(Session["AccountReceiveId"].ToString())) == null)//Nếu không tìm thấy account trong DB thì hiển thị màn hình nhập lại account receive
                    {
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(UcErrorAccount);
                        Session["ViewState"] = "ReDisplayAccountReceive_Enter";
                    }
                    else //Nếu có tìm thấy account receive trong DB thì hiển thị màn hình nhập tiền chuyển
                    {
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(LoadControl("~/UC5.CashTransfer/UcController/UcDisplayInfomationAccount.ascx"));
                        Session["ViewState"] = "InputAmount_Accept";
                    }
                }
                else //Nếu chưa nhập txtAccountReceive thì hiển thị màn hình nhập lại account receive
                {
                    contenPlace.Controls.Clear();
                    contenPlace.Controls.Add(UcErrorAccount);
                    Session["ViewState"] = "ReDisplayAccountReceive_Enter";
                }
            }
            else if (Session["ViewState"].ToString() == "DisplayTransferCashInfomation_Enter")//Chuyển qua màn hình hiển thị người nhận tiền và số tiền được nhận
            {
                var txtMoney = UcInputMoneyTransfer.FindControl("txtAmount") as TextBox;//Lấy tiền từ textbox txtAmount
                if (txtMoney != null)
                {
                    Session["Amount"] = txtMoney.Text;
                    var money = Convert.ToDecimal(txtMoney.Text);
                    var checkBalance = AccountBusinessLogic.CheckBalance(account.Balance, money);
                    if (checkBalance)//Kiểm tra số tiền nếu kiểm tra trong tài khoản còn đủ thì cho phép hiển thị
                    {
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(LoadControl("~/UC5.CashTransfer/UcController/UcDisplayAccountReceiveAndAmount.ascx"));
                        Session["ViewState"] = "PrintPeceipt_Accept";
                    }
                    else // Nếu số tiền lớn hơn số dư thì hiển thị màn hình thông báo lỗi
                    {
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(UcErrorAmount);
                        Session["ViewState"] = "DisplayMoneyTranfer_Enter";
                    }
                }
            }
            else if (Session["ViewState"].ToString() == "ReDisplayAccountReceive_Enter")//
            {
                var txtAccountReceive = UcErrorAccount.FindControl("txtReAccountReceiveId") as TextBox;
                if (txtAccountReceive.Text != "")
                {
                    Session["AccountReceiveId"] = txtAccountReceive.Text;
                    if (AccountBusinessLogic.CheckAcc(Convert.ToInt32(Session["AccountReceiveId"].ToString())) != null)
                    {
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(LoadControl("~/UC5.CashTransfer/UcController/UcDisplayInfomationAccount.ascx"));
                        Session["ViewState"] = "InputAmount_Accept";
                    }
                    else
                    {
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(UcErrorAccount);
                        Session["ViewState"] = "ReDisplayAccountReceive_Enter";
                    }
                }
                else
                {
                    contenPlace.Controls.Clear();
                    contenPlace.Controls.Add(UcErrorAccount);
                    Session["ViewState"] = "ReDisplayAccountReceive_Enter";
                }
            }
            else if (Session["ViewState"].ToString() == "DisplayMoneyTranfer_Enter")//Chuyển qua màn hình hiển thị tài khoản nhận và số tiền nhận
            {
                 var txtMoney = UcErrorAmount.FindControl("txtReAmount") as TextBox;//Lấy tiền từ textbox txtAmount
                if (txtMoney.Text != "")
                {
                    Session["Amount"] = txtMoney.Text;
                    var money = Convert.ToDecimal(txtMoney.Text);
                    var checkBalance = AccountBusinessLogic.CheckBalance(account.Balance, money);
                    if(checkBalance == true)
                    {
                        contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(LoadControl("~/UC5.CashTransfer/UcController/UcDisplayAccountReceiveAndAmount.ascx"));
                        Session["ViewState"] = "PrintPeceipt_Accept";
                    }
                    else
                    {
                         contenPlace.Controls.Clear();
                        contenPlace.Controls.Add(UcErrorAmount);
                        Session["ViewState"] = "DisplayMoneyTranfer_Enter";
                    }
                }
                else
                {
                    UcErrorAmount.Dispose();
                    contenPlace.Controls.Clear();                        
                    contenPlace.Controls.Add(UcErrorAmount);
                    Session["ViewState"] = "DisplayMoneyTranfer_Enter";
                }
            }
            else if (Session["ViewState"].ToString() == "")
            {
                ResetSession();
                Response.Redirect("~/InsertCardMain.aspx");
            }
            else
            {
                contenPlace.Controls.Clear();
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
                log.Details = Session["AccountReceiveId"].ToString();
                log.LogTypeId = 2;
                LogBusinessLogic.Add(log);
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(ex.Message);
            }

        }
    }
}