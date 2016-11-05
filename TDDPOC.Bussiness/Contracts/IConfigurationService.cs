using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPOC.Bussiness.Contracts
{
    public interface IConfigurationService
    {
        string Get(string key);
    }
}
