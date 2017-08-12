﻿using QIQO.Business.Accounts.Data.Entities;
using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Accounts.Data.Interfaces
{
    public interface IAccountRepository : IRepository<AccountData>
    {
        string GetNextNumber(AccountData account, int entity_desc);
        IEnumerable<AccountData> GetAll(CompanyData company);
        IEnumerable<AccountData> GetAll(PersonData employee);
        IEnumerable<AccountData> FindAll(int company_key, string pattern);
    }

}
