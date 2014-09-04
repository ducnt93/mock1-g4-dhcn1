using System;
using System.Collections.Generic;
using System.Text;

namespace DbMock1G4.DataAccess
{
   public class AtmDispenseChain
    {
        public IDispenseChain c1;
        public  AtmDispenseChain()
        {
            // initialize the chain
            this.c1 = new Money500Dispenser();
            IDispenseChain c2 = new Money200Dispenser();
            IDispenseChain c3 = new Money100Dispenser();
            IDispenseChain c4 = new Money50Dispenser();

            // set the chain of responsibility
            c1.SetNextChain(c2);
            c2.SetNextChain(c3);
            c3.SetNextChain(c4);
        }
    }
}
