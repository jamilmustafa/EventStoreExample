using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreExample.DTO
{
    class CashWithdrawalCommandDTO :Command
    {
        public double Amount { get; set; }
    }
}
