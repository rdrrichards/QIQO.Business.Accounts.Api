using QIQO.Business.Accounts.Data.Entities;
using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Accounts.Data.Interfaces
{
    public interface IAddressRepository : IRepository<AddressData>
    {
        IEnumerable<AddressData> GetAll(int entity_key, int entity_type);
    }

}
