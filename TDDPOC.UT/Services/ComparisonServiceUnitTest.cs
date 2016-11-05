using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDPOC.DAL.Contracts;
using TDDPOC.Bussiness.Contracts;
using TDDPOC.DAL.Entities;
using System.Collections.Generic;
using TDDPOC.DAL.Implementations;
using TDDPOC.Bussiness.Implementation;
using System.Diagnostics;

namespace TDDPOC.UT.Services
{
    [TestClass]
    public class ComparisonServiceUnitTest
    {
        private IClientInfoRepository _clientInfoRepository;
        private IComparisonService _comparisonService;

        private IList<ClientInfoEntity> produceMocks()
        {
            IList<ClientInfoEntity> resultClients = new List<ClientInfoEntity>
            {
                new ClientInfoEntity {ClientInfoID=1, Name="Javier", Surname="Pereira", Phone="555123555", Email="jpereira@pereiraandassociates.tk" },
                new ClientInfoEntity {ClientInfoID=2, Name="Javier", Surname="Pereira", Phone="555321555", Email="jpereira@pereiraandassociates.tk" },
            };
            return resultClients;
            
        }
        [TestInitialize]
        public void InitializeMocksAndRepo()
        {
            _clientInfoRepository = new ClientInfoInMemoryRepository();
            _clientInfoRepository.Seed(produceMocks());
            _comparisonService = new ComparisonService();
        }
        [TestMethod]
        public void ComparisonService_ExpectedNResults_TestMethod()
        {
            var clients = _clientInfoRepository.GetAll();
            int nDiff=_comparisonService.CompareNDifferentProperties(clients[0], clients[1]);
            Trace.WriteLine(string.Format("difrence between to objects is {0}",nDiff));
            Assert.IsTrue(nDiff == 2);
        }
    }
}
