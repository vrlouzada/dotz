using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Domain.DTO
{
    public class AuthResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Token { get; set; }


        public AuthResponse(Costumer costumer, string token)
        {
            Id = costumer.UserId;
            FirstName = costumer.FirstName;
            LastName = costumer.LastName;
            Token = token;
        }
    }
}
