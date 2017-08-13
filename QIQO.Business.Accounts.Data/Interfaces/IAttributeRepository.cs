using QIQO.Business.Accounts.Data.Entities;
using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Accounts.Data.Interfaces
{
    public interface IAttributeRepository : IRepository<AttributeData>
    {
        IEnumerable<AttributeData> GetAll(int entity_key, int entity_type_key);
    }

}
