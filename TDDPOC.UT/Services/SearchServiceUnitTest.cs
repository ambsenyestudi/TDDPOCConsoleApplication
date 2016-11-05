using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDPOC.Bussiness.Contracts;
using TDDPOC.Bussiness.Implementation;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using TDDPOC.DAL.Contracts;
using TDDPOC.DAL.Implementations;
using TDDPOC.DAL.Entities;
using System.Diagnostics;

namespace TDDPOC.UT.Services
{
    [TestClass]
    public class SearchServiceUnitTest
    {
        private IConfigurationService _configService=null;
        private IDictionary<string, string> _configDic = null;
        private IList<ClientInfoEntity> _clientInfoList = null;
        private IClientInfoRepository _clientInfoRepository=null;
        private ISearchService _searchService = null;

        [TestInitialize]
        public void InitializeMocksAndService()
        {
            string jsonConfigRawData = null;
            using (StreamReader r = new StreamReader("./MockData/config.json"))
            {
                jsonConfigRawData = r.ReadToEnd();
            }
            _configDic = JsonConvert.DeserializeObject<IDictionary<string, string>>(jsonConfigRawData);
            string rawMockData = null;
            using (StreamReader r = new StreamReader("./MockData/mockClients.json"))
            {
                rawMockData = r.ReadToEnd();
            }
            var clients = JsonConvert.DeserializeObject <IDictionary<string,IList<ClientInfoEntity>>>(rawMockData);
            _clientInfoList = clients.FirstOrDefault().Value;
            _clientInfoRepository = new ClientInfoInMemoryRepository();
            _clientInfoRepository.Seed(_clientInfoList);
            _configService = new ConfigurationService(_configDic);
            _searchService = new SearchService(_configService);
        }
        [TestMethod]
        public void SearchService_ExpectedValue_TestMethod()
        {
            string searchTerm = "PER";
            var clients=_clientInfoRepository.GetAll();
            string splittingSentece=_searchService.Search(clients[0].Email, searchTerm);
            Trace.WriteLine(splittingSentece);
            string splitingChar = _configService.Get("SerachSentenceSplitter");
            string[] sentence = splittingSentece.Split(splitingChar.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Trace.WriteLine(string.Format("foundTerm is: {0}, searchTerm is: {1}", sentence[1],searchTerm));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(splittingSentece));
            Assert.IsTrue(sentence.Length == 5);
            Assert.IsTrue(sentence[1] == sentence[3]);
            Assert.IsTrue(sentence[1].ToUpper()== searchTerm);
            Assert.IsFalse(sentence[1] == searchTerm);
        }
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void SearchService_ExpectedException_TestMethod()
        {
            _searchService = new SearchService(null);
        }

        

    }
}
