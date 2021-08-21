using DOTZ.Domain.Contracts.Helper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.DTO;
using DOTZ.Domain.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOTZ.ServicesDomain.Services
{
    public class ExtractService : IExtractService
    {

        private readonly IUserSession _userSession;
        private readonly IAwardRepository _awardRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public ExtractService(IUserSession userSession, IAwardRepository awardRepository, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _userSession = userSession;
            _awardRepository = awardRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }


        public BalanceDTO GetExtract()
        {
            var costumerId = _userSession.UserId;

            var awards = _awardRepository.GetList(costumerId);

            var orders = _orderRepository.GetList(costumerId);

            var balance = awards.Sum(a => a.Amount) - orders.Sum(a => a.Amount);

            var response = new BalanceDTO
            {
                Balance = balance,
                Extracts = new List<ExtractDTO>()
            };

            foreach (var a in awards)
            {
                var extract = new ExtractDTO { Amount = a.Amount, Description = a.Description, Date = a.Date, Type = ExtractValue.IN };
                response.Extracts.Add(extract);
            }

            foreach (var o in orders)
            {
                var product = _productRepository.Get(o.ProductId);
                var extract = new ExtractDTO { Amount = o.Amount, Description = product.Name, Date = o.Date, Type = ExtractValue.OUT };
                response.Extracts.Add(extract);
            }

            return response;

        }
    }
}
