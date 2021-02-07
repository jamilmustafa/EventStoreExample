using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreExample.DTO
{
    public class CashDepositCommandDTO : Command
    {
        public double Amount { get; set; }
    }
}
