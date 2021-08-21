using DOTZ.Domain.Contracts.Helper;
using DOTZ.Domain.Contracts.Repository;
using DOTZ.Domain.Contracts.Service;
using DOTZ.Domain.DTO;
using DOTZ.Domain.Entity;
using PELEXMapper;
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
        private readonly IUserSession _userSession;

        public AccountService(IUserRepository userRepository, ITokenService tokenService, ICostumerRepository costumerRepository, IUserSession userSession)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _costumerRepository = costumerRepository;
            _userSession = userSession;
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

        public AuthResponse CreateUser(LogonRequest logonRequest)
        {
            logonRequest.Validate();

            var userEntity = MapperUtil.MapIgnoreDependences<User>(logonRequest);

            if (_userRepository.Create(userEntity))
            {
                var user = _userRepository.Get(userEntity.Login, userEntity.Pass);

                var costumerEntity = MapperUtil.MapIgnoreDependences<Costumer>(logonRequest);

                costumerEntity.UserId = user.Id;

                if (_costumerRepository.Insert(costumerEntity))
                {
                    var token = _tokenService.GenerateToken(costumerEntity);

                    return new AuthResponse(costumerEntity, token);
                }
                else
                {
                    throw new Exception("Costumer insert fail.");
                }

            }
            else
            {
                throw new Exception("User insert fail.");
            }
        }

    }
}
