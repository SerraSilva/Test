using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Services.Interfaces;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Types.IncentiveTypes;
using Smartwyre.DeveloperTest.Types.IncentiveTypes.Support;
using Smartwyre.DeveloperTest.Types.Interfaces;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    private readonly IRebateDataStore _rebateDataStore;
    private readonly IProductDataStore _productDataStore;
    private readonly IIncentiveTypeFactory _incentiveTypeFactory;
    private decimal _rebateAmount = 0m;
    
    public RebateService(IRebateDataStore rebateDataStore,
        IProductDataStore productDataStore,
        IIncentiveTypeFactory incentiveTypeFactory)
    {
        _rebateDataStore = rebateDataStore;
        _productDataStore = productDataStore;
        _incentiveTypeFactory = incentiveTypeFactory;
    }
    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        Rebate rebate = _rebateDataStore.GetRebate(request.RebateIdentifier);
        Product product = _productDataStore.GetProduct(request.ProductIdentifier);

        var result = new CalculateRebateResult();

        var rebateAmount = 0m;

        if (rebate == null || product == null)
        {
            result.Success = false;
            return result;
        }

        switch (rebate.Incentive)
        {
            case IncentiveType.AmountPerUom:
                AmountPerUom amountPerUom = (AmountPerUom)_incentiveTypeFactory.Create(IncentiveType.AmountPerUom);
                result.Success = amountPerUom.IsValidRequest(product, rebate, request.Volume);
                if (result.Success)
                {
                    _rebateAmount = amountPerUom.CalculateRebateAmount(rebate, request.Volume);
                }
                break;
            case IncentiveType.FixedCashAmount:
                FixedCashAmount fixedCashAmount = (FixedCashAmount)_incentiveTypeFactory.Create(IncentiveType.FixedCashAmount);
                result.Success = fixedCashAmount.IsValidRequest(product, rebate);
                if (result.Success)
                {
                    _rebateAmount = fixedCashAmount.CalculateRebateAmount(rebate);
                }
                break;

            case IncentiveType.FixedRateRebate:
                FixedRateRebate fixedRateRebate = (FixedRateRebate)_incentiveTypeFactory.Create(IncentiveType.FixedRateRebate);
                result.Success = fixedRateRebate.IsValidRequest(product, rebate, request.Volume);
                if (result.Success)
                {
                    _rebateAmount = fixedRateRebate.CalculateRebateAmount(product, rebate, request.Volume);
                }
                break;
        }

        if (result.Success)
        {
            _rebateDataStore.StoreCalculationResult(rebate, rebateAmount);
        }

        return result;
    }
}
