using Microsoft.Data.SqlClient;
using Sololearn.entity;
using Sololearn.exception;
using Sololearn.repository.config;
using Sololearn.repository.contract;
using Sololearn.utils;

namespace Sololearn.repository.impls
{
    public class UserRepository : IUserRepository
    {

        #region Singletone
        private static IUserRepository? instance;
        internal static IUserRepository Instance()
        {
            if (instance == null)
            {
                instance ??= new UserRepository();
            }
            return instance;
        }
        #endregion

        private static readonly IRoleRepository roleRepository = AppBeans.Get<IRoleRepository>();

        public User Save(User entity)
        {
            SqlConnection sqlConnection = ConnectionPool.GetConnection();
            sqlConnection.Open();

            string query;

            Dictionary<string, string> dictionary = new()
            {
                { "fullname", entity.Name },
                { "email", entity.Email },
                { "password", entity.Password },
                { "role_id", entity.Role.Id.ToString() }
            };

            if (entity.Id != 0)
            {
                dictionary.Add("id", entity.Id.ToString());
                query = QueryGenerator.GenerateUpdateQuery("users", dictionary);
            }
            else
            {
                query = QueryGenerator.GenerateInsertQuery("users", dictionary);
            }

            Console.WriteLine(query);

            SqlCommand sqlCommand = new(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return entity;
        }

        public bool Delete(User entity)
        {
            return DeleteById(entity.Id);
        }

        public bool DeleteById(long id)
        {
            Dictionary<string, string> dictionary = new()
            {
                { "id", id.ToString() }
            };
            string query = QueryGenerator.GenerateDeleteQuery("users", dictionary);
            SqlConnection sqlConnection = ConnectionPool.GetConnection();
            sqlConnection.Open();
            SqlCommand sqlCommand = new(query, sqlConnection);
            int deleted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return deleted > 0;
        }

        public User? FindById(long id)
        {
            Dictionary<string, string> dictionary = new()
            {
                { "id", id.ToString() }
            };
            string query = QueryGenerator.GenerateSelectByQuery("users", dictionary);
            SqlConnection sqlConnection = ConnectionPool.GetConnection();
            sqlConnection.Open();
            SqlCommand sqlCommand = new(query, sqlConnection);

            User? user = null;

            using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                user = GetEntity(sqlDataReader);
            }
            return user;
        }

        private static User GetEntity(SqlDataReader sqlDataReader)
        {
            Int64 _id = sqlDataReader.GetInt64(0);
            DateTime dateTime = sqlDataReader.GetDateTime(1);
            bool isActive = sqlDataReader.GetBoolean(2);
            bool deleted = sqlDataReader.GetBoolean(4);
            string fullname = sqlDataReader.GetString(5);
            string email = sqlDataReader.GetString(6);
            string password = sqlDataReader.GetString(7);
            long roleId = sqlDataReader.GetInt64(8);
            Role? role = roleRepository.FindById(roleId);
            
            if (role == null)
                throw new ServiceException($"Role not with id {roleId}");

            return new User(_id, dateTime, isActive, deleted, 0, fullname, email, password, role);
        }

        public IList<User> FindAll()
        {
            string query = QueryGenerator.GenerateSelectAllQuery("users");
            SqlConnection sqlConnection = ConnectionPool.GetConnection();
            sqlConnection.Open();
            SqlCommand sqlCommand = new(query, sqlConnection);

            IList<User> users = new List<User>();

            using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                users.Add(GetEntity(sqlDataReader));
            }
            return users;
        }

        public User? FindByEmail(string email)
        {
            Dictionary<string, string> dictionary = new()
            {
                { "email", email }
            };
            string query = QueryGenerator.GenerateSelectByQuery("users", dictionary);
            Console.WriteLine(query);
            SqlConnection sqlConnection = ConnectionPool.GetConnection();
            sqlConnection.Open();
            SqlCommand sqlCommand = new(query, sqlConnection);

            User? user = null;

            using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                user = GetEntity(sqlDataReader);
            }
            return user;
        }

        private UserRepository() { }

    }

}
