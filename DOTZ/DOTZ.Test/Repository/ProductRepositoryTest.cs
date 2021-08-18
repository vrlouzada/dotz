using DOTZ.CrossCutting.IoC;
using DOTZ.Domain.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DOTZ.Test.Repository
{
    public class ProductRepositoryTest
    {

        private readonly IProductRepository _productRepository;

        public ProductRepositoryTest()
        {
            var ioc = Startup.IoC();
            _productRepository = ioc.GetInstance<IProductRepository>();
        }


        [Fact]
        public void GetAll()
        {
            var result = _productRepository.GetAll();

            Assert.NotEmpty(result);
        }


        [Theory]
        [InlineData(1)]
        public void Get(int id)
        {
            var result = _productRepository.Get(id);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Theory]
        [InlineData(1)]
        public void UpdateStock(int id)
        {
            var product = _productRepository.Get(id);

           if(product.Stock > 0)
           {
                product.Stock = product.Stock - 10;

                var result = _productRepository.UpdateStock(id, product.Stock);

                Assert.True(result);
            }

        }
        

    }
}
