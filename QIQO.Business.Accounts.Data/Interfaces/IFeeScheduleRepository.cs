using QIQO.Business.Accounts.Data.Entities;
using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Accounts.Data.Interfaces
{
    public interface IFeeScheduleRepository : IRepository<FeeScheduleData>
    {
        IEnumerable<FeeScheduleData> GetAll(AccountData account);
        IEnumerable<FeeScheduleData> GetAll(CompanyData company);
        // IEnumerable<FeeScheduleData> GetAll(ProductData product);
    }

}
