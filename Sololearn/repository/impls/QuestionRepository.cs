using Microsoft.Data.SqlClient;
using Sololearn.entity;
using Sololearn.exception;
using Sololearn.repository.config;
using Sololearn.repository.contract;
using Sololearn.utils;

namespace Sololearn.repository.impls
{
    public class QuestionRepository : IQuestionRepository
    {

        #region Singletone
        private static IQuestionRepository? instance;
        internal static IQuestionRepository Instance()
        {
            if (instance == null)
            {
                instance ??= new QuestionRepository();
            }
            return instance;
        }
        #endregion

        private static readonly ITestRepository testRepository = AppBeans.Get<ITestRepository>();
        public Question Save(Question entity)
        {
            SqlConnection sqlConnection = ConnectionPool.GetConnection();
            sqlConnection.Open();

            string query;

            Dictionary<string, string> dictionary = new()
            {
                { "body", entity.Body },
                { "type", entity.Type.ToString() },
                { "difficulty", entity.Difficulty.ToString() },
                { "added_by", entity.AddedBy.ToString() },
                { "test_id", entity.Test.Id.ToString() }
            };

            if (entity.Id != 0)
            {
                dictionary.Add("id", entity.Id.ToString());
                query = QueryGenerator.GenerateUpdateQuery("question", dictionary);
            }
            else
            {
                query = QueryGenerator.GenerateInsertQuery("question", dictionary);
            }

            Console.WriteLine(query);

            SqlCommand sqlCommand = new(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return entity;
        }

        public bool Delete(Question entity)
        {
            return DeleteById(entity.Id);
        }

        public bool DeleteById(long id)
        {
            Dictionary<string, string> dictionary = new()
            {
                { "id", id.ToString() }
            };
            string query = QueryGenerator.GenerateDeleteQuery("question", dictionary);
            SqlConnection sqlConnection = ConnectionPool.GetConnection();
            sqlConnection.Open();
            SqlCommand sqlCommand = new(query, sqlConnection);
            int deleted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return deleted > 0;
        }

        public Question? FindById(long id)
        {
            Dictionary<string, string> dictionary = new()
            {
                { "id", id.ToString() }
            };
            string query = QueryGenerator.GenerateSelectByQuery("question", dictionary);
            SqlConnection sqlConnection = ConnectionPool.GetConnection();
            sqlConnection.Open();
            SqlCommand sqlCommand = new(query, sqlConnection);

            Question? user = null;

            using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                user = GetEntity(sqlDataReader);
            }
            return user;
        }

        private static Question GetEntity(SqlDataReader sqlDataReader)
        {
            long _id = (long)sqlDataReader.GetInt32(0);
            DateTime dateTime = sqlDataReader.GetDateTime(1);
            bool isActive = sqlDataReader.GetBoolean(2);
            long addedBy = sqlDataReader.GetInt64(3);
            bool deleted = sqlDataReader.GetBoolean(4);
            string body = sqlDataReader.GetString(5);
            string type = sqlDataReader.GetString(6);
            int difficulty = sqlDataReader.GetInt32(7);
            long testId = sqlDataReader.GetInt64(8);
            Test? test = testRepository.FindById(testId);

            if (test == null)
                throw new ServiceException($"Test not found with id : {testId}");

            return new Question(_id, dateTime, isActive,  deleted, addedBy, body, type.GetQuestionType(), difficulty, test);
        }

        public IList<Question> FindAll()
        {
            string query = QueryGenerator.GenerateSelectAllQuery("question");
            SqlConnection sqlConnection = ConnectionPool.GetConnection();
            sqlConnection.Open();
            SqlCommand sqlCommand = new(query, sqlConnection);

            IList<Question> question = new List<Question>();

            using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                question.Add(GetEntity(sqlDataReader));
            }
            return question;
        }

       

        private QuestionRepository() { }

    }
}
