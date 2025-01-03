using Smartwyre.DeveloperTest.Types.IncentiveTypes.Support;
using Smartwyre.DeveloperTest.Types.Interfaces;

namespace Smartwyre.DeveloperTest.Types.IncentiveTypes
{
    public class AmountPerUom : IIncentiveType
    {
        private decimal _rebateAmount = 0m;
        public bool IsValidRequest(Product product, Rebate rebate, decimal volume)
        {
            if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom))
            {
                return false;
            }
            else if (rebate.Amount == 0 || volume == 0)
            {
                return false;
            }
            return true;
        }

        public decimal CalculateRebateAmount(Rebate rebate, decimal volume)
        {
            _rebateAmount += rebate.Amount * volume;
            return _rebateAmount;
        }

        public decimal CalculateRebateAmount(Product product, Rebate rebate, decimal volume) => throw new System.NotImplementedException();

        public decimal CalculateRebateAmount(Rebate rebate) => throw new System.NotImplementedException();

        public bool IsValidRequest(Product product, Rebate rebate) => throw new System.NotImplementedException();
    }
}
