using DOTZ.CrossCutting.IoC;
using DOTZ.Domain.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DOTZ.Test.Service
{
    public class ExtractServiceTest
    {

        private readonly IExtractService _extractService;


        public ExtractServiceTest()
        {
            var ioc = Startup.IoC();
            _extractService = ioc.GetInstance<IExtractService>();
        }


        [Fact]
        public void GetBalanceAndExtract()
        {
            var result = _extractService.GetExtract();

            Assert.NotNull(result);
            Assert.NotEmpty(result.Extracts);
        }
    }
}
