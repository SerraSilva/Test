using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartwyre.DeveloperTest.Types.IncentiveTypes.Support;
using Smartwyre.DeveloperTest.Types.IncentiveTypes;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.Types
{
    public class IncentiveTypeFactoryTests
    {
        [Fact]
        public void CreateAmountPerUom_Success()
        {
            IncentiveTypeFactory factory = new IncentiveTypeFactory();

            AmountPerUom result = (AmountPerUom)factory.Create(IncentiveType.AmountPerUom);

            Assert.NotNull(result);
        }
        [Fact]
        public void CreateFixedCashAmount_Success()
        {
            IncentiveTypeFactory factory = new IncentiveTypeFactory();

            FixedCashAmount result = (FixedCashAmount)factory.Create(IncentiveType.FixedCashAmount);

            Assert.NotNull(result);
        }
        [Fact]
        public void CreateFixedRateRebate_Success()
        {
            IncentiveTypeFactory factory = new IncentiveTypeFactory();

            FixedRateRebate result = (FixedRateRebate)factory.Create(IncentiveType.FixedRateRebate);

            Assert.NotNull(result);
        }
        [Fact]
        public void CreateUnspecifiedIncentiveType_ReturnsNull()
        {
            IncentiveTypeFactory factory = new IncentiveTypeFactory();

            var result = factory.Create(IncentiveType.Invalid);

            Assert.Null(result);
        }
    }
}
