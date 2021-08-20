using DOTZ.CrossCutting.IoC;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Entity;
using Xunit;

namespace DOTZ.Test.Repository
{
    public class CostumerRepositoryTest
    {

        private ICostumerRepository _costumerRepository;


        public CostumerRepositoryTest()
        {
            var ioc = Startup.IoC();
            _costumerRepository = ioc.GetInstance<ICostumerRepository>();
        }


        [Theory]
        [InlineData(2)]
        public void Get(int userId)
        {
            var costumer = _costumerRepository.Get(userId);

            Assert.NotNull(costumer);
            Assert.Equal(userId, costumer.UserId);
        }

        [Theory]
        [InlineData(2, "Victor", "Louzada")]
        public void Create(int userId, string firstName, string lastName)
        {
            var costumer = new Costumer
            {
                UserId = userId,
                FirstName = firstName,
                LastName = lastName
            };

            var isAdded = _costumerRepository.Insert(costumer);

            Assert.True(isAdded);
        }

        [Theory]
        [InlineData(2, "Victor", "Reis Louzada")]
        public void Update(int userId, string firstName, string lastName)
        {
            var costumer = new Costumer
            {
                UserId = userId,
                FirstName = firstName,
                LastName = lastName
            };

            var result = _costumerRepository.Update(costumer);
            Assert.True(result);
        }

        [Theory]
        [InlineData(2)]
        public void GetBalance(int userId)
        {
            var result = _costumerRepository.GetBalance(userId);

            Assert.True(result != 0);
        }

        [Theory]
        [InlineData(2, 1700)]
        public void UpdateBalance(int userId, double balance)
        {
            var result = _costumerRepository.UpdateBalance(userId, balance);

            Assert.True(result);
        }

    }
}
