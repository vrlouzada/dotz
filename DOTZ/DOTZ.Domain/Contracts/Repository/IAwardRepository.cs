using DOTZ.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Domain.Contracts.Repository
{
    public interface IAwardRepository
    {
        List<Award> GetList(int costumerId);
    }

}
