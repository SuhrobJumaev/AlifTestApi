using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlifTestApi.Interfaces
{
    public interface IPaymentHelper
    {
        public decimal CalculateTotalRangePercent(decimal creditRange, decimal productPercent, int maxCreditRange);
        public decimal CalculateTotalProductPrice(decimal price, decimal percent);
    }
}
