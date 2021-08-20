using DOTZ.CrossCutting.IoC;
using DOTZ.Domain.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DOTZ.Test.Repository
{
    public class AwardRepositoryTest
    {

        private readonly IAwardRepository _awardRepository;

        public AwardRepositoryTest()
        {
            var ioc = Startup.IoC();
            _awardRepository = ioc.GetInstance<IAwardRepository>();
        }


        [Theory]
        [InlineData(2)]
        public void GetList(int costumerId)
        {
            var result = _awardRepository.GetList(costumerId);

            Assert.NotEmpty(result);
        }

    }
}
