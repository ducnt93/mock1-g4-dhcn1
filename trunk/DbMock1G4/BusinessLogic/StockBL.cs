using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;
using DbMock1G4.DataAccess;
using log4net.Filter;

namespace DbMock1G4.BusinessLogic
{
    public class StockBL
    {

        #region ***** Init Methods *****
        StockDA objStockDA;
        public StockBL()
        {
            objStockDA = new StockDA();
        }
        #endregion

        #region ***** Get Methods *****
        public Stock GetByStockId(int stockid)
        {
            return objStockDA.GetByStockId(stockid);
        }

        public List<Stock> GetList()
        {
            const string cacheName = "lstStock";
            if (ServerCache.Get(cacheName) == null)
            {
                ServerCache.Insert(cacheName, objStockDA.GetList(), "Stock");
            }
            return (List<Stock>)ServerCache.Get(cacheName);
        }


        public List<Stock> GetListPaged(int recperpage, int pageindex)
        {
            return objStockDA.GetListPaged(recperpage, pageindex);
        }

        #endregion

        #region CheckMoneyAtm
        private Money money;
        private MoneyDA moneyDa;
        private CardBL cardBl;
        public int CheckMoneyAtm(int atmId,int accId, decimal amount)
        {
            int check = 0;
            moneyDa = new MoneyDA();
            cardBl = new CardBL();
            // tổng tiền của cả cây Atm
            decimal totalMoney = 0;
            // Kiểm tra nếu số tiền muốn rút ko phải là bội của 50000 thì giao dịch thất bại
            if (amount % 50000 != 0)
            {
                // trả về 1 thì tiền nhập vào không phải là bội của 50000
                check = 1;
            }
            else
            {
                List<Stock> list = objStockDA.GetByAtmId(atmId);
                // duyệt danh sách tính ra tổng tiền trong cây atm còn lại.
                foreach (var item in list)
                {
                    Money money1 = moneyDa.GetByMoneyId(item.MoneyId);
                    totalMoney = totalMoney + money1.MoneyValue * item.QuanlityId;
                }
                // Lấy số dư tài khoản của khách hàng đang giao dịch
               AccountBL accountBl = new AccountBL();
               Account account = accountBl.GetBalance(accId);
               decimal balance = account.Balance;
                // trường hợp cây atm không đáp ứng đủ số tiền khách muốn rút. Giao dịch thất bại
                if ((totalMoney < amount) || (balance < amount))
                {
                    // Số tiền trong máy rút tiền không đử để rút
                    check = 2;
                }
                // trường hợp atm đủ tiền đáp ứng khách hàng muốn rút
                else
                {
                    // lấy ra thông tin đối tượng Money M1
                    money = moneyDa.GetByMoneyId(list[0].MoneyId);
                    // Lấy ra số tờ tiền có mệnh giá của M1
                    decimal x1 = ((amount / money.MoneyValue) - ((amount / money.MoneyValue) % 1));
                    // khi ma so to tiền của M1 can rut it hơn số tiền có trong Atm
                    if (x1 <= list[0].QuanlityId)
                    {
                        // số dư bằng tiền nhập vào trừ đi số tờ tiền * giá tiền
                        decimal soDu = amount - x1 * money.MoneyValue;
                        // lấy ra thông tin đối tượng Money M2
                        money = moneyDa.GetByMoneyId(list[1].MoneyId);
                        // Tính số lượng tờ tiền có mệnh giá của M2 trong số tiền dư còn lại
                        decimal x2 = ((soDu/money.MoneyValue) - ((soDu/money.MoneyValue)%1));
                        // Nếu số lượng tờ mệnh giá M2 muốn rút ít hơn số tiền có mệnh giá M2 trong atm
                        if (x2 <= list[1].QuanlityId)
                        {
                            // tính lại số dư bằng cách lấy số dư của lần M1 - số tờ tiền M2 * giá tiền
                            soDu = soDu - x2 * money.MoneyValue;
                            // lấy ra thông tin đối tượng Money M3
                            money = moneyDa.GetByMoneyId(list[2].MoneyId);
                            // Tính số lượng tờ tiền có mệnh giá của M3 trong số tiền còn lại
                            decimal x3 = ((soDu / money.MoneyValue) - ((soDu / money.MoneyValue) %1));
                            // Nếu số lượng tờ mệnh giá M3 muốn rút ít hơn số tiền có mệnh giá M3 trong atm
                            if (x3 <= list[2].QuanlityId)
                            {
                                // tính lại số tiền trong số dư còn lại bằng= số dư còn lại - mệnh giá tờ M3 cần rút * mệnh giá của nó
                                soDu = soDu - x3 * money.MoneyValue;
                                // lấy ra thông tin đối tượng Money M4
                                money = moneyDa.GetByMoneyId(list[3].MoneyId);
                                // Tính số lượng tờ tiền có mệnh giá của M4 trong số tiền còn lại
                                decimal x4 = ((soDu / money.MoneyValue) - ((soDu / money.MoneyValue) %1));
                                // Nếu số lượng tờ mệnh giá M4 muốn rút ít hơn số tiền có mệnh giá M4 trong atm
                                if (x4 <= list[3].QuanlityId)
                                {
                                    // Tính lai số dư 
                                    soDu = soDu - x4 * money.MoneyValue;
                                    //Nếu số dư = 0 thì có nghĩa là số tiền chia ra đủ để hợp thành tổng tiền muốn rút và có thể rút tiền.
                                    // Khi đó sẽ cập nhập lại số lượng của các lại tiền trong csdl.
                                    if (soDu == 0)
                                    {
                                        // update cac thong tin kia
                                        list[0].QuanlityId = list[0].QuanlityId - Convert.ToInt32(x1);
                                        list[1].QuanlityId = list[1].QuanlityId - Convert.ToInt32(x2);
                                        list[2].QuanlityId = list[2].QuanlityId - Convert.ToInt32(x3);
                                        list[3].QuanlityId = list[3].QuanlityId - Convert.ToInt32(x4);
                                        UpdateQuantity(list[0]);
                                        UpdateQuantity(list[1]);
                                        UpdateQuantity(list[2]);
                                        UpdateQuantity(list[3]);
                                        check = 3;
                                    }
                                    // Nếu không thì có nghĩa không thể ghép được sô tiền trong tại khoản sao cho = tổng số tiền cần rút.
                                    // Giao dịch thất bại
                                    else
                                    {
                                        check = 4;
                                    }
                                }
                                // Trường hợp số tờ tiền mệnh giá của M4 > số tờ có mệnh giá của M4 trong Atm.
                                // Nếu không đủ thì giao dịch thất bại
                                else
                                {
                                    check = 4;
                                }
                            }
                            // Nếu số lượng tờ mệnh giá M3 muốn rút lớn hơn số tiền có mệnh giá M3 trong atm
                            else
                            {
                                // Tính lại số du của số tiền muốn rút
                                soDu = soDu - list[2].QuanlityId * money.MoneyValue;
                                // Lấy thông tin của đối tượng Money M4
                                money = moneyDa.GetByMoneyId(list[3].MoneyId);
                                // Tính số lượng tờ tiền có mệnh giá của M4 trong số tiền còn lại
                                decimal x4 = ((soDu / money.MoneyValue) - ((soDu / money.MoneyValue) %1));
                                // Nếu số lượng tờ mệnh giá M4 muốn rút ít hơn số tiền có mệnh giá M4 trong atm
                                if (x4 <= list[3].QuanlityId)
                                {
                                    // Tính lai số dư 
                                    soDu = soDu - x4 * money.MoneyValue;
                                    //Nếu số dư = 0 thì có nghĩa là số tiền chia ra đủ để hợp thành tổng tiền muốn rút và có thể rút tiền.
                                    // Khi đó sẽ cập nhập lại số lượng của các lại tiền trong csdl.
                                    if (soDu == 0)
                                    {
                                        // update cac thong tin kia
                                        list[0].QuanlityId = list[0].QuanlityId - Convert.ToInt32(x1);
                                        list[1].QuanlityId = list[1].QuanlityId - Convert.ToInt32(x2);
                                        list[2].QuanlityId = 0;
                                        list[3].QuanlityId = list[3].QuanlityId - Convert.ToInt32(x4);
                                        UpdateQuantity(list[0]);
                                        UpdateQuantity(list[1]);
                                        UpdateQuantity(list[2]);
                                        UpdateQuantity(list[3]);
                                        check = 3;
                                    }
                                    // Nếu không thì có nghĩa không thể ghép được sô tiền trong tại khoản sao cho = tổng số tiền cần rút.
                                    // Giao dịch thất bại
                                    else
                                    {
                                        check = 4;
                                    }
                                }
                                // Trường hợp số tờ tiền mệnh giá của M4 > số tờ có mệnh giá của M4 trong Atm.
                                // Nếu không đủ thì giao dịch thất bại
                                else
                                {
                                    check = 4;
                                }
                            }
                        }
                        // trường hợp số tờ tiền cần rút có mệnh giá của M2 lớn hơn số lượng tiền có mệnh giá M2 trong Atm
                        else
                        {
                            soDu = soDu - list[1].QuanlityId * money.MoneyValue;
                            // lấy ra thông tin đối tượng Money M3
                            money = moneyDa.GetByMoneyId(list[2].MoneyId);
                            // Tính số lượng tờ tiền có mệnh giá của M3 trong số tiền còn lại
                            decimal x3 = ((soDu / money.MoneyValue) - ((soDu / money.MoneyValue) %1));
                            // Nếu số lượng tờ mệnh giá M3 muốn rút ít hơn số tiền có mệnh giá M3 trong atm
                            if (x3 <= list[2].QuanlityId)
                            {
                                // tính lại số tiền trong số dư còn lại bằng= số dư còn lại - mệnh giá tờ M3 cần rút * mệnh giá của nó
                                soDu = soDu - x3 * money.MoneyValue;
                                money = moneyDa.GetByMoneyId(list[3].MoneyId);
                                // lấy ra thông tin đối tượng Money M4
                                // Tính số lượng tờ tiền có mệnh giá của M4 trong số tiền còn lại
                                decimal x4 = ((soDu / money.MoneyValue) - ((soDu / money.MoneyValue) %1));
                                // Nếu số lượng tờ mệnh giá M4 muốn rút ít hơn số tiền có mệnh giá M4 trong atm
                                if (x4 <= list[3].QuanlityId)
                                {
                                    // Tính lai số dư 
                                    soDu = soDu - x4 * money.MoneyValue;
                                    //Nếu số dư = 0 thì có nghĩa là số tiền chia ra đủ để hợp thành tổng tiền muốn rút và có thể rút tiền.
                                    // Khi đó sẽ cập nhập lại số lượng của các lại tiền trong csdl.
                                    if (soDu == 0)
                                    {
                                        // update cac thong tin kia
                                        list[0].QuanlityId = list[0].QuanlityId - Convert.ToInt32(x1);
                                        list[1].QuanlityId = 0;
                                        list[2].QuanlityId = list[2].QuanlityId - Convert.ToInt32(x3);
                                        list[3].QuanlityId = list[3].QuanlityId - Convert.ToInt32(x4);
                                        UpdateQuantity(list[0]);
                                        UpdateQuantity(list[1]);
                                        UpdateQuantity(list[2]);
                                        UpdateQuantity(list[3]);
                                        check = 3;
                                    }
                                    // Nếu không thì có nghĩa không thể ghép được sô tiền trong tại khoản sao cho = tổng số tiền cần rút.
                                    // Giao dịch thất bại
                                    else
                                    {
                                        check = 4;
                                    }
                                }
                                // Trường hợp số tờ tiền mệnh giá của M4 > số tờ có mệnh giá của M4 trong Atm.
                                // Nếu không đủ thì giao dịch thất bại
                                else
                                {
                                    check = 4;
                                }
                            }
                            // Nếu số lượng tờ mệnh giá M3 muốn rút lớn hơn số tiền có mệnh giá M3 trong atm
                            else
                            {
                                // Tính lại số du của số tiền muốn rút
                                soDu = soDu - list[2].QuanlityId * money.MoneyValue;
                                // Lấy thông tin của đối tượng Money M4
                                money = moneyDa.GetByMoneyId(list[3].MoneyId);
                                // Tính số lượng tờ tiền có mệnh giá của M4 trong số tiền còn lại
                                decimal x4 = ((soDu / money.MoneyValue) - ((soDu / money.MoneyValue) %1));
                                // Nếu số lượng tờ mệnh giá M4 muốn rút ít hơn số tiền có mệnh giá M4 trong atm
                                if (x4 <= list[3].QuanlityId)
                                {
                                    // Tính lai số dư 
                                    soDu = soDu - x4 * money.MoneyValue;
                                    //Nếu số dư = 0 thì có nghĩa là số tiền chia ra đủ để hợp thành tổng tiền muốn rút và có thể rút tiền.
                                    // Khi đó sẽ cập nhập lại số lượng của các lại tiền trong csdl.
                                    if (soDu == 0)
                                    {
                                        // update cac thong tin kia
                                        list[0].QuanlityId = list[0].QuanlityId - Convert.ToInt32(x1);
                                        list[1].QuanlityId = 0;
                                        list[2].QuanlityId = 0;
                                        list[3].QuanlityId = list[3].QuanlityId - Convert.ToInt32(x4);
                                        UpdateQuantity(list[0]);
                                        UpdateQuantity(list[1]);
                                        UpdateQuantity(list[2]);
                                        UpdateQuantity(list[3]);
                                        check = 3;
                                    }
                                    // Nếu không thì có nghĩa không thể ghép được sô tiền trong tại khoản sao cho = tổng số tiền cần rút.
                                    // Giao dịch thất bại
                                    else
                                    {
                                        check = 4;
                                    }
                                }
                                // Trường hợp số tờ tiền mệnh giá của M4 > số tờ có mệnh giá của M4 trong Atm.
                                // Nếu không đủ thì giao dịch thất bại
                                else
                                {
                                    check = 4;
                                }
                            }
                        }
                    }
                    // trường hợp số tờ tiền cần rút nhiều hơn số tiền của M1 có
                    else
                    {
                        // tính số dư còn lại bằng số tiền cần rút - tổng số tờ tiền của M1 * mệnh giá của nó
                        decimal soDu = amount - list[0].QuanlityId * money.MoneyValue;
                        // lấy ra thông tin đối tượng Money M2
                        money = moneyDa.GetByMoneyId(list[1].MoneyId);
                        // Tính số lượng tờ tiền có mệnh giá của M2 trong số tiền dư còn lại
                        decimal x2 = ((soDu / money.MoneyValue) - ((soDu / money.MoneyValue) %1));
                        // Nếu số lượng tờ mệnh giá M2 muốn rút ít hơn số tiền có mệnh giá M2 trong atm
                        if (x2 <= list[1].QuanlityId)
                        {
                            // tính lại số dư bằng cách lấy số dư của lần M1 - số tờ tiền M2 * giá tiền
                            soDu = soDu - x2 * money.MoneyValue;
                            // lấy ra thông tin đối tượng Money M3
                            money = moneyDa.GetByMoneyId(list[2].MoneyId);
                            // Tính số lượng tờ tiền có mệnh giá của M3 trong số tiền còn lại
                            decimal x3 = ((soDu / money.MoneyValue) - ((soDu / money.MoneyValue) %1));
                            // Nếu số lượng tờ mệnh giá M3 muốn rút ít hơn số tiền có mệnh giá M3 trong atm
                            if (x3 <= list[2].QuanlityId)
                            {
                                // tính lại số tiền trong số dư còn lại bằng= số dư còn lại - mệnh giá tờ M3 cần rút * mệnh giá của nó
                                soDu = soDu - x3 * money.MoneyValue;
                                // lấy ra thông tin đối tượng Money M4
                                money = moneyDa.GetByMoneyId(list[3].MoneyId);
                                // Tính số lượng tờ tiền có mệnh giá của M4 trong số tiền còn lại
                                decimal x4 = ((soDu / money.MoneyValue) - ((soDu / money.MoneyValue) %1));
                                // Nếu số lượng tờ mệnh giá M4 muốn rút ít hơn số tiền có mệnh giá M4 trong atm
                                if (x4 <= list[3].QuanlityId)
                                {
                                    // Tính lai số dư 
                                    soDu = soDu - x4 * money.MoneyValue;
                                    //Nếu số dư = 0 thì có nghĩa là số tiền chia ra đủ để hợp thành tổng tiền muốn rút và có thể rút tiền.
                                    // Khi đó sẽ cập nhập lại số lượng của các lại tiền trong csdl.
                                    if (soDu == 0)
                                    {
                                        // update cac thong tin kia
                                        list[0].QuanlityId = 0;
                                        list[1].QuanlityId = list[1].QuanlityId - Convert.ToInt32(x2);
                                        list[2].QuanlityId = list[2].QuanlityId - Convert.ToInt32(x3);
                                        list[3].QuanlityId = list[3].QuanlityId - Convert.ToInt32(x4);
                                        UpdateQuantity(list[0]);
                                        UpdateQuantity(list[1]);
                                        UpdateQuantity(list[2]);
                                        UpdateQuantity(list[3]);
                                        check = 3;
                                    }
                                    // Nếu không thì có nghĩa không thể ghép được sô tiền trong tại khoản sao cho = tổng số tiền cần rút.
                                    // Giao dịch thất bại
                                    else
                                    {
                                        check = 4;
                                    }
                                }
                                // Trường hợp số tờ tiền mệnh giá của M4 > số tờ có mệnh giá của M4 trong Atm.
                                // Nếu không đủ thì giao dịch thất bại
                                else
                                {
                                    check = 4;
                                }
                            }
                            // Nếu số lượng tờ mệnh giá M3 muốn rút lớn hơn số tiền có mệnh giá M3 trong atm
                            else
                            {
                                // Tính lại số du của số tiền muốn rút
                                soDu = soDu - list[2].QuanlityId * money.MoneyValue;
                                // Lấy thông tin của đối tượng Money M4
                                money = moneyDa.GetByMoneyId(list[3].MoneyId);
                                // Tính số lượng tờ tiền có mệnh giá của M4 trong số tiền còn lại
                                decimal x4 = ((soDu / money.MoneyValue) - ((soDu / money.MoneyValue) %1));
                                // Nếu số lượng tờ mệnh giá M4 muốn rút ít hơn số tiền có mệnh giá M4 trong atm
                                if (x4 <= list[3].QuanlityId)
                                {
                                    // Tính lai số dư 
                                    soDu = soDu - x4 * money.MoneyValue;
                                    //Nếu số dư = 0 thì có nghĩa là số tiền chia ra đủ để hợp thành tổng tiền muốn rút và có thể rút tiền.
                                    // Khi đó sẽ cập nhập lại số lượng của các lại tiền trong csdl.
                                    if (soDu == 0)
                                    {
                                        // update cac thong tin kia
                                        list[0].QuanlityId = 0;
                                        list[1].QuanlityId = list[1].QuanlityId - Convert.ToInt32(x2);
                                        list[2].QuanlityId = 0;
                                        list[3].QuanlityId = list[3].QuanlityId - Convert.ToInt32(x4);
                                        UpdateQuantity(list[0]);
                                        UpdateQuantity(list[1]);
                                        UpdateQuantity(list[2]);
                                        UpdateQuantity(list[3]);
                                        check = 3;
                                    }
                                    // Nếu không thì có nghĩa không thể ghép được sô tiền trong tại khoản sao cho = tổng số tiền cần rút.
                                    // Giao dịch thất bại
                                    else
                                    {
                                        check = 4;
                                    }
                                }
                                // Trường hợp số tờ tiền mệnh giá của M4 > số tờ có mệnh giá của M4 trong Atm.
                                // Nếu không đủ thì giao dịch thất bại
                                else
                                {
                                    check = 4;
                                }
                            }
                        }
                        // trường hợp số tờ tiền cần rút có mệnh giá của M2 lớn hơn số lượng tiền có mệnh giá M2 trong Atm
                        else
                        {
                            soDu = soDu - list[1].QuanlityId * money.MoneyValue;
                            // lấy ra thông tin đối tượng Money M3
                            money = moneyDa.GetByMoneyId(list[2].MoneyId);
                            // Tính số lượng tờ tiền có mệnh giá của M3 trong số tiền còn lại
                            decimal x3 = ((soDu / money.MoneyValue) - ((soDu / money.MoneyValue) %1));
                            // Nếu số lượng tờ mệnh giá M3 muốn rút ít hơn số tiền có mệnh giá M3 trong atm
                            if (x3 <= list[2].QuanlityId)
                            {
                                // tính lại số tiền trong số dư còn lại bằng= số dư còn lại - mệnh giá tờ M3 cần rút * mệnh giá của nó
                                soDu = soDu - x3 * money.MoneyValue;
                                money = moneyDa.GetByMoneyId(list[3].MoneyId);
                                // lấy ra thông tin đối tượng Money M4
                                // Tính số lượng tờ tiền có mệnh giá của M4 trong số tiền còn lại
                                decimal x4 = ((soDu / money.MoneyValue) - ((soDu / money.MoneyValue) %1));
                                // Nếu số lượng tờ mệnh giá M4 muốn rút ít hơn số tiền có mệnh giá M4 trong atm
                                if (x4 <= list[3].QuanlityId)
                                {
                                    // Tính lai số dư 
                                    soDu = soDu - x4 * money.MoneyValue;
                                    //Nếu số dư = 0 thì có nghĩa là số tiền chia ra đủ để hợp thành tổng tiền muốn rút và có thể rút tiền.
                                    // Khi đó sẽ cập nhập lại số lượng của các lại tiền trong csdl.
                                    if (soDu == 0)
                                    {
                                        // update cac thong tin kia
                                        list[0].QuanlityId = 0;
                                        list[1].QuanlityId = 0;
                                        list[2].QuanlityId = list[2].QuanlityId - Convert.ToInt32(x3);
                                        list[3].QuanlityId = list[3].QuanlityId - Convert.ToInt32(x4);
                                        UpdateQuantity(list[0]);
                                        UpdateQuantity(list[1]);
                                        UpdateQuantity(list[2]);
                                        UpdateQuantity(list[3]);
                                        check = 3;
                                    }
                                    // Nếu không thì có nghĩa không thể ghép được sô tiền trong tại khoản sao cho = tổng số tiền cần rút.
                                    // Giao dịch thất bại
                                    else
                                    {
                                        check = 4;
                                    }
                                }
                                // Trường hợp số tờ tiền mệnh giá của M4 > số tờ có mệnh giá của M4 trong Atm.
                                // Nếu không đủ thì giao dịch thất bại
                                else
                                {
                                    check = 4;
                                }
                            }
                            // Nếu số lượng tờ mệnh giá M3 muốn rút lớn hơn số tiền có mệnh giá M3 trong atm
                            else
                            {
                                // Tính lại số du của số tiền muốn rút
                                soDu = soDu - list[2].QuanlityId * money.MoneyValue;
                                // Lấy thông tin của đối tượng Money M4
                                money = moneyDa.GetByMoneyId(list[3].MoneyId);
                                // Tính số lượng tờ tiền có mệnh giá của M4 trong số tiền còn lại
                                decimal x4 = ((soDu / money.MoneyValue) - ((soDu / money.MoneyValue) %1));
                                // Nếu số lượng tờ mệnh giá M4 muốn rút ít hơn số tiền có mệnh giá M4 trong atm
                                if (x4 <= list[3].QuanlityId)
                                {
                                    // Tính lai số dư 
                                    soDu = soDu - x4 * money.MoneyValue;
                                    //Nếu số dư = 0 thì có nghĩa là số tiền chia ra đủ để hợp thành tổng tiền muốn rút và có thể rút tiền.
                                    // Khi đó sẽ cập nhập lại số lượng của các lại tiền trong csdl.
                                    if (soDu == 0)
                                    {
                                        // update cac thong tin kia
                                        list[0].QuanlityId = 0;
                                        list[1].QuanlityId = 0;
                                        list[2].QuanlityId = 0;
                                        list[3].QuanlityId = list[3].QuanlityId - Convert.ToInt32(x4);
                                        UpdateQuantity(list[0]);
                                        UpdateQuantity(list[1]);
                                        UpdateQuantity(list[2]);
                                        UpdateQuantity(list[3]);
                                        check = 3;
                                    }
                                    // Nếu không thì có nghĩa không thể ghép được sô tiền trong tại khoản sao cho = tổng số tiền cần rút.
                                    // Giao dịch thất bại
                                    else
                                    {
                                        check = 4;
                                    }
                                }
                                // Trường hợp số tờ tiền mệnh giá của M4 > số tờ có mệnh giá của M4 trong Atm.
                                // Nếu không đủ thì giao dịch thất bại
                                else
                                {
                                    check = 4;
                                }
                            }
                        }
                    }
                }
            }
            return check;
        }
        #endregion

        #region ***** Add Update Delete Methods *****

        public int Add(Stock objStock)
        {
            ServerCache.Remove("Stock", true);
            return objStockDA.Add(objStock);
        }


        public void Update(Stock objStock)
        {
            ServerCache.Remove("Stock", true);
            objStockDA.Update(objStock);
        }

        public void UpdateQuantity(Stock objStock)
        {
            ServerCache.Remove("Stock", true);
            objStockDA.Update(objStock);
        }

        public void Delete(int stockid)
        {
            ServerCache.Remove("Stock", true);
            objStockDA.Delete(stockid);
        }
        #endregion
    }
}
