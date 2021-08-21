using DOTZ.CrossCutting.IoC;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Entity;
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

        [Theory]
        [InlineData(2, "Amazon", 200, "2021-08-19")]
        public void Insert ( int costumerid, string description, double amount, string dateString)
        {
            var date = DateTime.Parse(dateString);

            var award = new Award
            {
                CostumerId = costumerid,
                Description = description,
                Amount = amount,
                Date = date
            };

            var result = _awardRepository.Insert(award);

            Assert.True(result);
        }

    }
}
