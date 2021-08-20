using DOTZ.Domain.Contracts.Helper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.ServicesDomain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserSession _userSession;


        public ProductService(IProductRepository productRepository, IUserSession userSession)
        {
            _productRepository = productRepository;
            _userSession = userSession;
        }


        public List<ProductDTO> GetAvailabeProducts() => _productRepository.GetAvailableList();


    }
}
