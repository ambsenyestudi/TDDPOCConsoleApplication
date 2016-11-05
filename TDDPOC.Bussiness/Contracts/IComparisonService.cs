using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPOC.Bussiness.Contracts
{
    public interface IComparisonService
    {
        int CompareNDifferentProperties(object sourceObj, object newObj);
            
    }
}
