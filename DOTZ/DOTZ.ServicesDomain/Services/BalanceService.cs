using DOTZ.Domain.Contracts.Helper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.ServicesDomain.Services
{   
    public class BalanceService : IBalanceService
    {

        private readonly ICostumerRepository _costumerRepository;
        private readonly IUserSession _userSession;

        public BalanceService(ICostumerRepository costumerRepository, IUserSession userSession)
        {
            _costumerRepository = costumerRepository;
            _userSession = userSession;
        }


        public bool UpdateBalance(double amount)
        {
            var currentBalance = _costumerRepository.GetBalance(_userSession.UserId);

            var newBalance = currentBalance + amount;

            return _costumerRepository.UpdateBalance(_userSession.UserId, newBalance);
        }

    }
}
