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

        #endregion
    }
}
