using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using DbMock1G4.BusinessObjects;
using DbMock1G4.DataAccess;

namespace DbMock1G4.BusinessLogic
{
    public class CustomerBL
    {

        #region ***** Init Methods *****

        readonly CustomerDA objCustomerDA;
        public CustomerBL()
        {
            objCustomerDA = new CustomerDA();
        }
        #endregion

        #region ***** Get Methods *****
        // Lấy Customer theo Id
        public Customer GetByCusId(int cusid)
        {
            return objCustomerDA.GetByCusId(cusid);
        }

        //Lấy danh sách Customer
        public List<Customer> GetList()
        {
            const string cacheName = "lstCustomer";
            if (ServerCache.Get(cacheName) == null)
            {
                ServerCache.Insert(cacheName, objCustomerDA.GetList(), "Customer");
            }
            return (List<Customer>)ServerCache.Get(cacheName);
        }

        // Lấy danh sách theo phân trang
        public List<Customer> GetListPaged(int recperpage, int pageindex)
        {
            return objCustomerDA.GetListPaged(recperpage, pageindex);
        }

        #endregion

        #region ***** Add Update Delete Methods *****
        // Thêm mới Customer
        public int Add(Customer objCustomer)
        {
            ServerCache.Remove("Customer", true);
            return objCustomerDA.Add(objCustomer);
        }

        // Sửa thông tin Customer
        public void Update(Customer objCustomer)
        {
            ServerCache.Remove("Customer", true);
            objCustomerDA.Update(objCustomer);
        }

        // Xóa 1 customer
        public void Delete(int cusid)
        {
            ServerCache.Remove("Customer", true);
            objCustomerDA.Delete(cusid);
        }
        #endregion
    }
}
