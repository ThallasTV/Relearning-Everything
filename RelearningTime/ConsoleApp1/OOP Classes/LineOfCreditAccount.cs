using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LineOfCreditAccount : BankAccount
    {
        public override void PerformMonthEndTransactions()
        {
            if(Balance < 0)
            {
                decimal interest = -Balance * 0.07m;
                MakeWithdrawl(interest, DateTime.Now, "Charging monthly interest");
            }
        }
    }
}
