using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartwyre.DeveloperTest.Types.Interfaces;

namespace Smartwyre.DeveloperTest.Types.IncentiveTypes.Support
{
    public class IncentiveTypeFactory : IIncentiveTypeFactory
    {
        public IIncentiveType Create(IncentiveType incentiveType)
        {
            switch(incentiveType)
            {
                case IncentiveType.AmountPerUom:
                    AmountPerUom amountPerUom = new AmountPerUom();
                    return amountPerUom;
                case IncentiveType.FixedCashAmount:
                    FixedCashAmount fixedCashAmount = new FixedCashAmount();
                    return fixedCashAmount;
                case IncentiveType.FixedRateRebate:
                    FixedRateRebate fixedRateRebate = new FixedRateRebate();
                    return fixedRateRebate;
            }
            return null;
        }
    }
}
