using DbMock1G4.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbMock1G4.DataAccess
{
   public interface IDispenseChain
    {
        void SetNextChain(IDispenseChain nextChain);

        int Dispense(Currency cur);
       
    }
}
