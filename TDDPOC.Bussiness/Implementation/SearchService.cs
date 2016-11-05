using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TDDPOC.Bussiness.Contracts;

namespace TDDPOC.Bussiness.Implementation
{
    public class SearchService : ISearchService
    {

        #region Properties
        private IConfigurationService _configurationService;
        #endregion Properties
        #region Constructors
        public SearchService(IConfigurationService configurationService)
        {
            if (configurationService == null) throw new ArgumentNullException("Dependency not met (IConfigurationService)");
            _configurationService = configurationService;
        }
        #endregion Constructors
        
        public string Search(string searchedSentence, string searchTerm)
        {
            if (searchedSentence.ToUpper().Contains(searchTerm.ToUpper()))
            {
                int firstmatch = searchedSentence.ToUpper().IndexOf(searchTerm.ToUpper());
                string searchedFoundTerm = searchedSentence.Substring(firstmatch, searchTerm.Length);
                string spanSentence = string.Format("{0}{1}{0}", _configurationService.Get("SerachSentenceSplitter"),searchedFoundTerm);
                string returnString = Regex.Replace(searchedSentence, searchTerm, spanSentence, RegexOptions.IgnoreCase);

                return returnString;
            }
            else
            {
                return searchedSentence;
            }
        }
    }
}
