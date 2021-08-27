using System;

namespace FarolCashBox.Domain.Repositories
{
    public interface IRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}