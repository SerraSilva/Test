using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Types.IncentiveTypes;
using Smartwyre.DeveloperTest.Types.IncentiveTypes.Support;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.Types
{
    public class AmountPerUomTests
    {
        [Fact]
        public void RebateIsInvalid()
        {
            CalculateRebateRequest request = new CalculateRebateRequest(100);
            Rebate rebate = new Rebate
            {
                Identifier = request.RebateIdentifier,
                Incentive = IncentiveType.FixedCashAmount,
                Amount = 0,
                Percentage = 5
            };
            Product product = new Product
            {
                Identifier = request.ProductIdentifier,
                Price = 25m,
                Uom = "",
                SupportedIncentives = SupportedIncentiveType.FixedCashAmount
            };
            IncentiveTypeFactory incentiveTypeFactory = new IncentiveTypeFactory();
            AmountPerUom amountPerUom = (AmountPerUom)incentiveTypeFactory.Create(IncentiveType.AmountPerUom);

            bool isValidRequest = amountPerUom.IsValidRequest(product, rebate, request.Volume);

            Assert.False(isValidRequest);
        }

        [Fact]
        public void VolumeIsInvalid()
        {
            CalculateRebateRequest request = new CalculateRebateRequest(0);
            Rebate rebate = new Rebate
            {
                Identifier = request.RebateIdentifier,
                Incentive = IncentiveType.FixedCashAmount,
                Amount = 100,
                Percentage = 5
            };
            Product product = new Product
            {
                Identifier = request.ProductIdentifier,
                Price = 25m,
                Uom = "",
                SupportedIncentives = SupportedIncentiveType.FixedCashAmount
            };
            IncentiveTypeFactory incentiveTypeFactory = new IncentiveTypeFactory();
            AmountPerUom amountPerUom = (AmountPerUom)incentiveTypeFactory.Create(IncentiveType.AmountPerUom);

            bool isValidRequest = amountPerUom.IsValidRequest(product, rebate, request.Volume);

            Assert.False(isValidRequest);
        }

        [Fact]
        public void ProductIsInvalid()
        {
            CalculateRebateRequest request = new CalculateRebateRequest(100);
            Rebate rebate = new Rebate
            {
                Identifier = request.RebateIdentifier,
                Incentive = IncentiveType.FixedCashAmount,
                Amount = 50,
                Percentage = 5
            };
            Product product = new Product
            {
                Identifier = request.ProductIdentifier,
                Price = 25m,
                Uom = "",
                SupportedIncentives = SupportedIncentiveType.None
            };
            IncentiveTypeFactory incentiveTypeFactory = new IncentiveTypeFactory();
            AmountPerUom amountPerUom = (AmountPerUom)incentiveTypeFactory.Create(IncentiveType.AmountPerUom);

            bool isValidRequest = amountPerUom.IsValidRequest(product, rebate, request.Volume);

            Assert.False(isValidRequest);
        }

        [Fact]
        public void RebateIsValid_Success()
        {
            CalculateRebateRequest request = new CalculateRebateRequest(100);
            Rebate rebate = new Rebate
            {
                Identifier = request.RebateIdentifier,
                Incentive = IncentiveType.FixedCashAmount,
                Amount = 50,
                Percentage = 5
            };
            Product product = new Product
            {
                Identifier = request.ProductIdentifier,
                Price = 25m,
                Uom = "",
                SupportedIncentives = SupportedIncentiveType.AmountPerUom
            };
            IncentiveTypeFactory incentiveTypeFactory = new IncentiveTypeFactory();
            AmountPerUom amountPerUom = (AmountPerUom)incentiveTypeFactory.Create(IncentiveType.AmountPerUom);

            bool isValidRequest = amountPerUom.IsValidRequest(product, rebate, request.Volume);

            Assert.True(isValidRequest);
        }
    }
}
