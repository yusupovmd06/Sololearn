using Microsoft.Data.SqlClient;
using Sololearn.entity;
using Sololearn.repository.config;
using Sololearn.repository.contract;
using Sololearn.utils;

namespace Sololearn.repository.impls
{
    public class RoleRepository : IRoleRepository
    {

        #region Singletone
        private static IRoleRepository? instance;
        internal static IRoleRepository Instance()
        {
            if (instance == null)
            {
                instance ??= new RoleRepository();
            }
            return instance;
        }
        #endregion

        
        public Role? Save(Role entity)
        {
            SqlConnection sqlConnection = ConnectionPool.GetConnection();
            sqlConnection.Open();

            string query;

            Dictionary<string, string> dictionary = new()
            {
                { "name", entity.Name },
                { "description", entity.Description}
            };

            if (entity.Id != 0)
            {
                dictionary.Add("id", entity.Id.ToString());
                query = QueryGenerator.GenerateUpdateQuery("roles", dictionary);
            }
            else
            {
                query = QueryGenerator.GenerateInsertQuery("roles", dictionary);
            }

            Console.WriteLine(query);

            SqlCommand sqlCommand = new(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return entity;
        }

        public bool Delete(Role entity)
        {
            return DeleteById(entity.Id);
        }

        public bool DeleteById(long id)
        {
            Dictionary<string, string> dictionary = new()
            {
                { "id", id.ToString() }
            };
            string query = QueryGenerator.GenerateDeleteQuery("roles", dictionary);
            SqlConnection sqlConnection = ConnectionPool.GetConnection();
            sqlConnection.Open();
            SqlCommand sqlCommand = new(query, sqlConnection);
            int deleted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return deleted > 0;
        }

        public Role? FindById(long id)
        {
            Dictionary<string, string> dictionary = new()
            {
                { "id", id.ToString() }
            };
            string query = QueryGenerator.GenerateSelectByQuery("roles", dictionary);
            SqlConnection sqlConnection = ConnectionPool.GetConnection();
            sqlConnection.Open();
            SqlCommand sqlCommand = new(query, sqlConnection);

            Role? role = null;

            using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                role = GetEntity(sqlDataReader);
            }
            return role;
        }

        private static Role GetEntity(SqlDataReader sqlDataReader)
        {
            long _id = sqlDataReader.GetInt64(0);
            string name = sqlDataReader.GetString(1);
            string description = sqlDataReader.GetString(2);
            return new Role(_id, name, description);
        }

        public IList<Role>? FindAll()
        {
            string query = QueryGenerator.GenerateSelectAllQuery("roles");
            SqlConnection sqlConnection = ConnectionPool.GetConnection();
            sqlConnection.Open();
            SqlCommand sqlCommand = new(query, sqlConnection);

            IList<Role> roles = new List<Role>();

            using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                roles.Add(GetEntity(sqlDataReader));
            }
            return roles;
        }


        private RoleRepository() { }

    }
}
