using Sololearn.entity;
using System.Collections.ObjectModel;

namespace Sololearn.repository.contract
{
    public interface IRepository<E, ID>
    {
        E Save(E entity);
        bool Delete(E entity);
        bool DeleteById(ID id);
        E? FindById(ID id);
        IList<E> FindAll();
    }
}