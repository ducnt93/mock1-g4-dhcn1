using DbMock1G4.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbMock1G4.DataAccess
{
    public class Money200Dispenser : IDispenseChain
    {
        private IDispenseChain chain;
        public void SetNextChain(IDispenseChain nextChain)
        {
            this.chain = nextChain;
        }

        public int Dispense(Currency cur)
        {
            int num = 0;
            if (cur.GetAmount() >= 200000)
            {
                 num = Convert.ToInt32(cur.GetAmount() / 200000);
                int remainder = Convert.ToInt32(cur.GetAmount() % 200000);
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
