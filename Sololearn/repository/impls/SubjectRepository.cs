namespace Sololearn.repository.impls;

using Sololearn.entity;
using Sololearn.repository.contract;

public class SubjectRepository : GenericRepository<Subject, long>, ISubjectRepository
{
    private static ISubjectRepository? instance;
    internal static ISubjectRepository Instance()
    {
        if (instance == null)
        {
            instance ??= new SubjectRepository();
        }
        return instance;
    }

    private SubjectRepository() { }
}
