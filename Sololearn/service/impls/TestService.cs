using Sololearn.entity;
using SoloLearn.payload;
using Sololearn.repository.contract;
using Sololearn.service.contract;
using Sololearn.utils;
using Sololearn.mapper;

namespace Sololearn.service.impls
{
    public class TestService : Service<TestMapper, ITestRepository, Test, TestDto, TestAddDto, long>, ITestService
    {
        public TestService(TestMapper mapper, ITestRepository repo) : base(mapper, repo)
        {
            mapper = new();
            repo = AppBeans.Get<ITestRepository>();
        }
    }
}
