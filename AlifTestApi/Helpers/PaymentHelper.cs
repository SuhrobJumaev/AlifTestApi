using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlifTestApi.Interfaces;

namespace AlifTestApi.Helpers
{
    public class PaymentHelper : IPaymentHelper
    {
        public  decimal CalculateTotalRangePercent(int creditRange, decimal productPercent, int maxCreditRange)
        {
            decimal result = creditRange / maxCreditRange;
            return Math.Ceiling(result) * productPercent;
        }

        public  decimal CalculateTotalProductPrice(decimal price, decimal percent)
        {
            var PrecentSum = price * percent / 100;
            return PrecentSum + price;
        }
    }
}
