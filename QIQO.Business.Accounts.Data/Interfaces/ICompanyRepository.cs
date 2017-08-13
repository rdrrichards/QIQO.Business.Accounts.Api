using QIQO.Business.Accounts.Data.Entities;
using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Accounts.Data.Interfaces
{
    public interface ICompanyRepository : IRepository<CompanyData>
    {
        IEnumerable<CompanyData> GetAll(PersonData person);
        string GetNextNumber(CompanyData company, int number_type);
    }

}
