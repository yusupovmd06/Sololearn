using Microsoft.Data.SqlClient;
using Sololearn.entity.templates;
using Sololearn.repository.contract;
using System.Text.Json;

namespace Sololearn.repository.impls
{
    public abstract class GenericRepository<E, ID> : IRepository<E, ID> where E : AbsLongEntity
    {
        public List<E> Entities { get; private set; }

        public bool Delete(E entity)
        {
            return true;
        }

        public bool DeleteById(ID id)
        {
            return Entities.RemoveAll(e => e.Id.Equals(id)) > 0;
        }

        public IList<E> FindAll()
        {
            return Entities;
        }

        public E FindById(ID id)
        {
            return Entities.Where(e => e.Id.Equals(id)).First();
        }

        public E Save(E entity)
        {
            Entities.Add(entity);
            return Entities[Entities.Count - 1];
        }

        public void ShutDownHook()
        {
            writeToFile();
        }

        private void writeToFile()
        {
            var path = Path.Combine("C:\\Java\\Studio\\Sololearn\\Sololearn\\utils\\", "");
            string json = JsonSerializer.Serialize(Entities);
            File.WriteAllText(path, json);
        }

    }
}