using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbMock1G4.BusinessLogic;
using DbMock1G4.BusinessObjects;
using log4net;

namespace WebApplication1.UC2.WithdrawMoney
{
    public partial class EnterOrther : System.Web.UI.Page
    {
        readonly AccountBL accountBl = new AccountBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEnterCash.Focus();
        }
        StockBL stockBl = new StockBL();
        protected void btn250_Click(object sender, EventArgs e)
        {
            try
            {
                Session["ViewState"] = "PrintPeceipt";
                int accountId = int.Parse(Session["AccountId"].ToString());
                decimal money = Convert.ToDecimal(txtEnterCash.Text);
                bool check = accountBl.CheckBalanceWithDraw(accountId, money);
                int checkAtm = stockBl.CheckMoneyAtm(1, accountId, money);
                if (check == false)
                {
                    lblError.Text = "Number enter have to div to 50.000 or money withdraw more than balance or money withdraw < 0";
                    txtEnterCash.Text = "";
                    txtEnterCash.Focus();
                }
                else
                {
                    if (checkAtm == 1)
                    {
                        lblError.Text = "Number enter have to div to 50.000";
                    }
                    else
                    {
                        if (checkAtm == 2)
                        {
                            lblError.Text = "The total amount smaller than withdrawal ";
                        }
                        else
                        {
                            if (checkAtm == 4)
                            {
                                lblError.Text = "Error...";
                            }
                            else
                            {
                                UpdateBalance(accountId, money);
                                Response.Redirect("Withdraw.aspx");
                            }
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

        public void UpdateBalance(int accId, decimal money)
        {
            try
            {
                Account account = accountBl.GetByAccountId(accId);
                decimal balance = account.Balance;
                balance = balance - money;
                accountBl.DispenserMoney(accId, balance);
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(ex.Message);
            }
            
        }
        protected void btnOrther_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UC2.WithdrawMoney/Withdraw.aspx");
        }
    }
}