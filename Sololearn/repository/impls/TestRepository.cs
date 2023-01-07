using Sololearn.entity;
using Sololearn.repository.contract;

namespace Sololearn.repository.impls;
public class TestRepository : ITestRepository
{
    private static ITestRepository instance;
    internal static ITestRepository Instance()
    {
        if (instance == null)
        {
            lock (instance)
            {
                instance ??= new TestRepository();
            }
        }
        return instance;
    }

    public Test Save(Test entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Test entity)
    {
        throw new NotImplementedException();
    }

    public bool DeleteById(long id)
    {
        throw new NotImplementedException();
    }

    public Test FindById(long id)
    {
        throw new NotImplementedException();
    }

    public IList<Test> FindAll()
    {
        throw new NotImplementedException();
    }

    private TestRepository() { }

}
