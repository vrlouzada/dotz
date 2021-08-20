using DOTZ.CrossCutting.IoC;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Entity;
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

        [Theory]
        [InlineData("Playstation 5", "Desconto de 5% na compra do console da Sony", 2000, 60, 5)]
        public void Insert(string name, string description, double amount, int stock, int categoryId)
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                Amount = amount,
                Stock = stock,
                CategoryId = categoryId
            };

            var result = _productRepository.Insert(product);

            Assert.True(result);
        }
        
        [Fact]
        public void GetAvailabeProduct()
        {
            var result = _productRepository.GetAvailableList();

            Assert.NotEmpty(result);
        }

    }
}
