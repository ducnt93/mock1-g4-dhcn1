using System.Globalization;
using DbMock1G4.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbMock1G4.DataAccess
{
    public class Money50Dispenser : IDispenseChain
    {
        private IDispenseChain chain;
        public void SetNextChain(IDispenseChain nextChain)
        {
            this.chain = nextChain;
        }

        public int Dispense(Currency cur)
        {
            int num = 0;
            if (cur.GetAmount() >= 50000)
            {

                num = Convert.ToInt32(cur.GetAmount() / 50000);
                int remainder = Convert.ToInt32(cur.GetAmount()%50000);
                if (remainder != 0)
                {
                    chain.Dispense(new Currency(remainder));
                
                }

            }
            else
            {
                chain.Dispense(cur);
            }
            return num;
        }
    }
}
