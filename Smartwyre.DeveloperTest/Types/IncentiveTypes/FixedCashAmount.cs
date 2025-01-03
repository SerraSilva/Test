using Smartwyre.DeveloperTest.Types.IncentiveTypes.Support;
using Smartwyre.DeveloperTest.Types.Interfaces;

namespace Smartwyre.DeveloperTest.Types.IncentiveTypes
{
    public class FixedCashAmount : IIncentiveType
    {
        public bool IsValidRequest(Product product, Rebate rebate)
        {
            if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount))
            {
                return false;
            }
            else if (rebate.Amount == 0)
            {
                return false;
            }
            return true;
        }

        public decimal CalculateRebateAmount(Rebate rebate)
        {
            return rebate.Amount;
        }

        public decimal CalculateRebateAmount(Product product, Rebate rebate, decimal volume) => throw new System.NotImplementedException();

        public decimal CalculateRebateAmount(Rebate rebate, decimal volume) => throw new System.NotImplementedException();

        public bool IsValidRequest(Product product, Rebate rebate, decimal volume) => throw new System.NotImplementedException();
    }
}
