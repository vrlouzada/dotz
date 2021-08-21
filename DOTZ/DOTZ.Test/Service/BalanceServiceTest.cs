using DOTZ.CrossCutting.IoC;
using DOTZ.Domain.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DOTZ.Test.Service
{
    public class BalanceServiceTest
    {
        private readonly IBalanceService _balanceService;


        public BalanceServiceTest()
        {
            var ioc = Startup.IoC();
            _balanceService = ioc.GetInstance<IBalanceService>();
        }


        [Theory]
        [InlineData(150)]
        public void PlusBalance(double amount)
        {
            var result = _balanceService.UpdateBalance(amount);

            Assert.True(result);
        }

        [Theory]
        [InlineData(150)]
        public void LessBalance(double amount)
        {
            var result = _balanceService.UpdateBalance(-amount);

            Assert.True(result);
        }

    }
}
