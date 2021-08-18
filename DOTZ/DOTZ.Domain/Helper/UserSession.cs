using DOTZ.Domain.Contracts.Helper;
using DOTZ.Domain.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace DOTZ.Domain.Helper
{

    public class UserSession : IUserSession
    {

        private readonly IHttpContextAccessor _context;

        public UserSession(IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor;
        }

        public Costumer GetCostumer() {

            if (_context == null)
                return null;

            var result = _context?.HttpContext.Items.FirstOrDefault(a => a.Key.Equals("User")).Value;

            if (result == null)
                return null;

            return (Costumer)result;
        }
    }
}
