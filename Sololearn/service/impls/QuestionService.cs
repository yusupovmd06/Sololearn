using Sololearn.entity;
using Sololearn.mapper;
using Sololearn.repository.contract;
using Sololearn.service.contract;
using Sololearn.utils;
using SoloLearn.payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sololearn.service.impls
{
    public class QuestionService : Service<QuestionMapper, IQuestionRepository, Question, QuestionDto, QuestionAddDto, long>, IQuestionService
    {
        public QuestionService(QuestionMapper mapper, IQuestionRepository repo) : base(mapper, repo)
        {
            mapper = new();
            repo = AppBeans.Get<IQuestionRepository>();
        }
    }
}
