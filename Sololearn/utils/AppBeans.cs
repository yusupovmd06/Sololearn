using Sololearn.mapper;
using Sololearn.repository.impls;

namespace Sololearn.utils
{
    public class AppBeans
    {
        public static T Get<T>()
        {

            return typeof(T).Name switch
            {
                "IUserRepository" => (T)UserRepository.Instance(),
                "ICourseRepository" => (T)SubjectRepository.Instance(),
                "IRoleRepository" => (T)RoleRepository.Instance(),
                "IQuestionRepository" => (T)QuestionRepository.Instance(),
                _ => throw new Exception()
            };

        }


    }
}
