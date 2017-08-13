using QIQO.Business.Accounts.Data.Entities;
using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Accounts.Data.Interfaces
{
    public interface IContactRepository : IRepository<ContactData>
    {
        IEnumerable<ContactData> GetAll(int entity_key, int entity_type_key);
    }

}
