using System;
using Moq;
using Xunit;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types.Interfaces;
using Smartwyre.DeveloperTest.Services.Interfaces;
using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Types.IncentiveTypes;
using Smartwyre.DeveloperTest.Types.IncentiveTypes.Support;

namespace Smartwyre.DeveloperTest.Tests.Services;

public class RebateServiceTests
{
    [Fact]
    public void Calculate_RebateIsNull()
    {
        Mock<IRebateDataStore> mockRebateStore = new Mock<IRebateDataStore>();
        Mock<IProductDataStore> mockProductStore = new Mock<IProductDataStore>();
        Mock<IIncentiveTypeFactory> mockIncentiveTypeFactory = new Mock<IIncentiveTypeFactory>();
        Product product = new Product();
        mockRebateStore.Setup(x => x.GetRebate(It.IsAny<string>())).Returns<Rebate>(null);
        mockProductStore.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(product);
        IRebateService rebateService = new RebateService(mockRebateStore.Object, mockProductStore.Object, mockIncentiveTypeFactory.Object);
        CalculateRebateRequest request = new CalculateRebateRequest(100);

        CalculateRebateResult result = rebateService.Calculate(request);

        Assert.NotNull(result);
        Assert.False(result.Success);
    }
    [Fact]
    public void Calculate_ProductIsNull()
    {
        Mock<IRebateDataStore> mockRebateStore = new Mock<IRebateDataStore>();
        Mock<IProductDataStore> mockProductStore = new Mock<IProductDataStore>();
        Mock<IIncentiveTypeFactory> mockIncentiveTypeFactory = new Mock<IIncentiveTypeFactory>();
        Rebate rebate = new Rebate();
        mockProductStore.Setup(x => x.GetProduct(It.IsAny<string>())).Returns<Product>(null);
        mockRebateStore.Setup(x => x.GetRebate(It.IsAny<string>())).Returns(rebate);
        IRebateService rebateService = new RebateService(mockRebateStore.Object, mockProductStore.Object, mockIncentiveTypeFactory.Object);
        CalculateRebateRequest request = new CalculateRebateRequest(100);

        CalculateRebateResult result = rebateService.Calculate(request);

        Assert.NotNull(result);
        Assert.False(result.Success);
    }

    [Fact]
    public void Calculate_AmountPerUom_Success()
    {
        Mock<IRebateDataStore> mockRebateStore = new Mock<IRebateDataStore>();
        Mock<IProductDataStore> mockProductStore = new Mock<IProductDataStore>();
        Mock<IIncentiveTypeFactory> mockIncentiveTypeFactory = new Mock<IIncentiveTypeFactory>();
        CalculateRebateRequest request = new CalculateRebateRequest(100);
        Rebate rebate = new Rebate
        {
            Identifier = request.RebateIdentifier,
            Incentive = IncentiveType.AmountPerUom,
            Amount = 100,
            Percentage = 5
        };
        Product product = new Product
        {
            Identifier = request.ProductIdentifier,
            Price = 25m,
            Uom = "",
            SupportedIncentives = SupportedIncentiveType.AmountPerUom
        };
        AmountPerUom amountPerUom = new AmountPerUom();
        mockProductStore.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(product);
        mockRebateStore.Setup(x => x.GetRebate(It.IsAny<string>())).Returns(rebate);
        mockIncentiveTypeFactory.Setup(x => x.Create(IncentiveType.AmountPerUom)).Returns(amountPerUom);
        IRebateService rebateService = new RebateService(mockRebateStore.Object, mockProductStore.Object, mockIncentiveTypeFactory.Object);

        CalculateRebateResult result = rebateService.Calculate(request);

        Assert.NotNull(result);
        Assert.True(result.Success);
    }

    [Fact]
    public void Calculate_FixedCashAmount_Success()
    {
        Mock<IRebateDataStore> mockRebateStore = new Mock<IRebateDataStore>();
        Mock<IProductDataStore> mockProductStore = new Mock<IProductDataStore>();
        Mock<IIncentiveTypeFactory> mockIncentiveTypeFactory = new Mock<IIncentiveTypeFactory>();
        CalculateRebateRequest request = new CalculateRebateRequest(100);
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
        FixedCashAmount fixedCashAmount = new FixedCashAmount();
        mockProductStore.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(product);
        mockRebateStore.Setup(x => x.GetRebate(It.IsAny<string>())).Returns(rebate);
        mockIncentiveTypeFactory.Setup(x => x.Create(IncentiveType.FixedCashAmount)).Returns(fixedCashAmount);
        IRebateService rebateService = new RebateService(mockRebateStore.Object, mockProductStore.Object, mockIncentiveTypeFactory.Object);

        CalculateRebateResult result = rebateService.Calculate(request);

        Assert.NotNull(result);
        Assert.True(result.Success);
    }

    [Fact]
    public void Calculate_FixedRateRebate_Success()
    {
        Mock<IRebateDataStore> mockRebateStore = new Mock<IRebateDataStore>();
        Mock<IProductDataStore> mockProductStore = new Mock<IProductDataStore>();
        Mock<IIncentiveTypeFactory> mockIncentiveTypeFactory = new Mock<IIncentiveTypeFactory>();
        CalculateRebateRequest request = new CalculateRebateRequest(100);
        Rebate rebate = new Rebate
        {
            Identifier = request.RebateIdentifier,
            Incentive = IncentiveType.FixedRateRebate,
            Amount = 100,
            Percentage = 5
        };
        Product product = new Product
        {
            Identifier = request.ProductIdentifier,
            Price = 25m,
            Uom = "",
            SupportedIncentives = SupportedIncentiveType.FixedRateRebate
        };
        FixedRateRebate fixedRateRebate = new FixedRateRebate();
        mockProductStore.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(product);
        mockRebateStore.Setup(x => x.GetRebate(It.IsAny<string>())).Returns(rebate);
        mockIncentiveTypeFactory.Setup(x => x.Create(IncentiveType.FixedRateRebate)).Returns(fixedRateRebate);
        IRebateService rebateService = new RebateService(mockRebateStore.Object, mockProductStore.Object, mockIncentiveTypeFactory.Object);

        CalculateRebateResult result = rebateService.Calculate(request);

        Assert.NotNull(result);
        Assert.True(result.Success);
    }

    [Fact]
    public void GetRebate_Success()
    {
        Mock<IRebateDataStore> mockRebateStore = new Mock<IRebateDataStore>();
        Mock<IProductDataStore> mockProductStore = new Mock<IProductDataStore>();
        Mock<IIncentiveTypeFactory> mockIncentiveTypeFactory = new Mock<IIncentiveTypeFactory>();
        Rebate rebate = new Rebate();
        mockRebateStore.Setup(x => x.GetRebate(It.IsAny<string>())).Returns(rebate);
        RebateService rebateService = new RebateService(mockRebateStore.Object, mockProductStore.Object, mockIncentiveTypeFactory.Object);

        Rebate result = rebateService.GetRebate("aaa");

        Assert.NotNull(result);
    }

    [Fact]
    public void GetProduct_Success()
    {
        Mock<IRebateDataStore> mockRebateStore = new Mock<IRebateDataStore>();
        Mock<IProductDataStore> mockProductStore = new Mock<IProductDataStore>();
        Mock<IIncentiveTypeFactory> mockIncentiveTypeFactory = new Mock<IIncentiveTypeFactory>();
        Product product = new Product();
        mockProductStore.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(product);
        RebateService rebateService = new RebateService(mockRebateStore.Object, mockProductStore.Object, mockIncentiveTypeFactory.Object);

        Product result = rebateService.GetProduct("aaa");

        Assert.NotNull(result);
    }

    [Fact]
    public void RebateIsInitialized()
    {
        Mock<IRebateDataStore> mockRebateStore = new Mock<IRebateDataStore>();
        Mock<IProductDataStore> mockProductStore = new Mock<IProductDataStore>();
        Mock<IIncentiveTypeFactory> mockIncentiveTypeFactory = new Mock<IIncentiveTypeFactory>();
        Rebate rebate = new Rebate();
        RebateService rebateService = new RebateService(mockRebateStore.Object, mockProductStore.Object, mockIncentiveTypeFactory.Object);

        bool result = rebateService.IsRebateInitialized(rebate);

        Assert.True(result);
    }

    [Fact]
    public void RebateIsNull()
    {
        Mock<IRebateDataStore> mockRebateStore = new Mock<IRebateDataStore>();
        Mock<IProductDataStore> mockProductStore = new Mock<IProductDataStore>();
        Mock<IIncentiveTypeFactory> mockIncentiveTypeFactory = new Mock<IIncentiveTypeFactory>();
        RebateService rebateService = new RebateService(mockRebateStore.Object, mockProductStore.Object, mockIncentiveTypeFactory.Object);

        bool result = rebateService.IsRebateInitialized(null);

        Assert.False(result);
    }

    [Fact]
    public void ProductIsInitialized()
    {
        Mock<IRebateDataStore> mockRebateStore = new Mock<IRebateDataStore>();
        Mock<IProductDataStore> mockProductStore = new Mock<IProductDataStore>();
        Mock<IIncentiveTypeFactory> mockIncentiveTypeFactory = new Mock<IIncentiveTypeFactory>();
        Product product = new Product();
        RebateService rebateService = new RebateService(mockRebateStore.Object, mockProductStore.Object, mockIncentiveTypeFactory.Object);

        bool result = rebateService.IsProductInitialized(product);

        Assert.True(result);
    }

    [Fact]
    public void ProductIsNull()
    {
        Mock<IRebateDataStore> mockRebateStore = new Mock<IRebateDataStore>();
        Mock<IProductDataStore> mockProductStore = new Mock<IProductDataStore>();
        Mock<IIncentiveTypeFactory> mockIncentiveTypeFactory = new Mock<IIncentiveTypeFactory>();
        RebateService rebateService = new RebateService(mockRebateStore.Object, mockProductStore.Object, mockIncentiveTypeFactory.Object);

        bool result = rebateService.IsProductInitialized(null);

        Assert.False(result);
    }
}
