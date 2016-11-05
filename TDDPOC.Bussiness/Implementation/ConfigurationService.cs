using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDPOC.Bussiness.Contracts;

namespace TDDPOC.Bussiness.Implementation
{
    public class ConfigurationService : IConfigurationService
    {

        #region Properties
        private IDictionary<string,string> _configDictionary;
        #endregion Properties
        #region Constructors
        public ConfigurationService(IDictionary<string,string> configDictionary)
        {
            if (configDictionary == null) throw new ArgumentNullException("Dependency not met (IDictionary<string,string>)");
            _configDictionary = configDictionary;
        }
        #endregion Constructors


        public string Get(string key)
        {
            return _configDictionary[key];
        }
    }
}
