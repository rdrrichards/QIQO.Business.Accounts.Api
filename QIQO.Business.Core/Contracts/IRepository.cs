using System.Collections.Generic;

namespace QIQO.Business.Core.Contracts
{
    public interface IRepository
    {

    }

    public interface IRepository<T> : IRepository // Think about splitting this up (LSP)
        where T : class, IEntity, new()
    {
        IEnumerable<T> GetAll();
        T GetByID(int entity_key);
        T GetByCode(string account_code, string entity_code);
        int Insert(T entity);
        void Delete(T entity);
        void DeleteByID(int entity_key);
        void DeleteByCode(string entity_code);
        int Save(T entity);
    }

}
