using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartwyre.DeveloperTest.Types.IncentiveTypes.Support;

namespace Smartwyre.DeveloperTest.Types.Interfaces
{
    public interface IIncentiveType
    {
        IncentiveType selectedIncentiveType { get; }
        public bool IsValidRequest(Product product, Rebate rebate);
        public bool IsValidRequest(Product product, Rebate rebate, decimal volume);
        public decimal CalculateRebateAmount(Product product, Rebate rebate, decimal volume);
        public decimal CalculateRebateAmount(Rebate rebate, decimal volume);
        public decimal CalculateRebateAmount(Rebate rebate);
    }
}
