using Sololearn.entity;
using Sololearn.mapper;
using SoloLearn.payload;
using Sololearn.repository.contract;
using Sololearn.service.contract;
using Sololearn.utils;
using Sololearn.payload;
using Sololearn.exception;
using Sololearn.repository.impls;

namespace Sololearn.service.impls
{
    public class SubjectService : Service<SubjectMapper, ISubjectRepository, Subject, SubjectDto, SubjectAddDto, long>, ISubjectService
    {
        public SubjectService(SubjectMapper mapper, ISubjectRepository repo) : base(mapper, repo)
        {
            mapper = new SubjectMapper();
            repo = AppBeans.Get<ISubjectRepository>();
        }

    }
}
