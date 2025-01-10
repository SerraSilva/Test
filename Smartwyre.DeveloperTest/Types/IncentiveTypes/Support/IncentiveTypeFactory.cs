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
        public IEnumerable<IIncentiveType> _incentiveType;
        public IncentiveTypeFactory(IEnumerable<IIncentiveType> incentiveTypes) 
        {  
            _incentiveType = incentiveTypes;
        }
        public IIncentiveType Create(IncentiveType incentiveType)
        {
            return _incentiveType.Where(x => x.selectedIncentiveType == incentiveType).FirstOrDefault();
        }
    }
}
