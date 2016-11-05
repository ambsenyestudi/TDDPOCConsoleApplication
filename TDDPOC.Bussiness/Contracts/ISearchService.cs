using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPOC.Bussiness.Contracts
{
    public interface ISearchService
    {
        string Search(string searchedSentence, string searchTerm);
    }
}
