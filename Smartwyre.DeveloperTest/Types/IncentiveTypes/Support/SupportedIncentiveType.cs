namespace Smartwyre.DeveloperTest.Types.IncentiveTypes.Support;

public enum SupportedIncentiveType
{
    None = 0,
    FixedRateRebate = 1 << 0,
    AmountPerUom = 1 << 1,
    FixedCashAmount = 1 << 2,
}
