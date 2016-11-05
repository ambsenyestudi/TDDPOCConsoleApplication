using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDPOC.DAL.Contracts;
using TDDPOC.DAL.Implementations;

namespace TDDPOC.UT.Repos
{
    [TestClass]
    public class ClientInfoRepositoryUnitTest
    {
        private IClientInfoRepository _clientRepo;
        [TestInitialize]
        public void InitializeRepository()
        {
            _clientRepo = new ClientInfoInMemoryRepository();
        }
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ClientInfo_Seed_ExceptionExpected_TestMethod()
        {
            _clientRepo.Seed(null);
        }
    }
}
