using DOTZ.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Domain.Contracts.Service
{
    public interface IExtractService
    {
        BalanceDTO GetExtract();
    }

}
