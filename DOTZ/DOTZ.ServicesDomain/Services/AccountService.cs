using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.ServicesDomain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly ICostumerRepository _costumerRepository;

        public AccountService(IUserRepository userRepository, ITokenService tokenService, ICostumerRepository costumerRepository)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _costumerRepository = costumerRepository;
        }


        public AuthResponse Authenticate(AuthRequest request)
        {
            var user = _userRepository.Get(request.Username, request.Password);

            if (user == null)
               return null;

            var costumer = _costumerRepository.Get(user.Id);

            var token = _tokenService.GenerateToken(costumer);

            return new AuthResponse(costumer, token);
        }
    }
}
