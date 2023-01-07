using Sololearn.entity;
using SoloLearn.payload;

namespace Sololearn.mapper;

public class QuestionMapper : IEntityMapper<Question, QuestionDto, QuestionAddDto>
{
    public Question FromAddDto(QuestionAddDto dto)
    {
        throw new NotImplementedException();
    }

    public Question FromAddDto(Question e, QuestionAddDto dto)
    {
        throw new NotImplementedException();
    }

    public QuestionDto ToDto(Question e)
    {
        throw new NotImplementedException();
    }

    public IList<QuestionDto> ToDto(IEnumerable<Question> e)
    {
        throw new NotImplementedException();
    }
}
