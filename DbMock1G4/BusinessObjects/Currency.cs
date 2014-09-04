using System;
using System.Collections.Generic;
using System.Text;

namespace DbMock1G4.BusinessObjects
{
   public class Currency
   {
       private decimal amount;

       public Currency(decimal amt)
       {
           this.amount = amt;
       }

       public decimal GetAmount()
       {
           return this.amount;
       }
    }
}
