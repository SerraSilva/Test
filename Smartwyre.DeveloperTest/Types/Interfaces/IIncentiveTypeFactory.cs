using Smartwyre.DeveloperTest.Types.IncentiveTypes.Support;

namespace Smartwyre.DeveloperTest.Types.Interfaces
{
    public interface IIncentiveTypeFactory
    {
        IIncentiveType Create(IncentiveType incentiveType);
    }
}
