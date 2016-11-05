using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDPOC.Bussiness.Contracts;
using TDDPOC.Bussiness.Implementation;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Diagnostics;

namespace TDDPOC.UT.Services
{
    [TestClass]
    public class ConfigServiceUnitTest
    {
        private IConfigurationService _configService = null;
        private string _jsonConfigRawData = null;
        private IDictionary<string, string> _configDic = null;
        [TestInitialize]
        public void InitializeMocksAndService()
        {
            using (StreamReader r = new StreamReader("./MockData/config.json"))
            {
                _jsonConfigRawData = r.ReadToEnd();
            }
            _configDic = JsonConvert.DeserializeObject<IDictionary<string, string>>(_jsonConfigRawData);
            _configService = new ConfigurationService(_configDic);
        }
        [TestMethod]
        public void ConfigService_ConfigService_TestMethod()
        {
            Trace.WriteLine(_configDic["ApplicationName"]);
            string appName = _configService.Get("ApplicationName");
            Trace.WriteLine("Application Name: " + appName);
            Assert.AreEqual(_configDic["ApplicationName"], appName);

        }
        [ExpectedException (typeof(ArgumentNullException))]
        [TestMethod]
        public void ConfigService_ExpectedException_TestMethod()
        {
            _configService = new ConfigurationService(null);
        }
        
    }
}
