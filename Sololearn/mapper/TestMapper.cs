using Sololearn.entity;
using Sololearn.mapper;
using SoloLearn.payload;
using System.Linq;

namespace Sololearn.mapper
{
    public class TestMapper : IEntityMapper<Test, TestDto, TestAddDto>
    {
        private readonly QuestionMapper questionMapper = new();
        public Test FromAddDto(TestAddDto dto)
        {
            return new Test(dto.Name, dto.Description);
        }

        public Test FromAddDto(Test e, TestAddDto dto)
        {
           e.Name= dto.Name;
           e.Description= dto.Description;
           return e;
        }

        public TestDto ToDto(Test e)
        {
            IList<QuestionDto> questionDtos = questionMapper.ToDto(e.Questions);
            return new TestDto(e.Name, e.Description, questionDtos);
        }

        public IList<TestDto> ToDto(IEnumerable<Test> e)
        {
            return e.Select(ToDto).ToList();
        }
    }

}