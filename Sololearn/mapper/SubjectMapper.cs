using Sololearn.entity;
using Sololearn.payload;
using SoloLearn.payload;

namespace Sololearn.mapper
{
    public class SubjectMapper : IEntityMapper<Subject, SubjectDto, SubjectAddDto>
    {
        public Subject FromAddDto(SubjectAddDto dto)
        {
            return new Subject(dto.Name, dto.Description);
        }

        public Subject FromAddDto(Subject e, SubjectAddDto dto)
        {
            e.Name = dto.Name;
            e.Description = dto.Description;
            return e;
        }

        public SubjectDto ToDto(Subject e)
        {
            return new SubjectDto(e.Id, e.Name, e.Description, e.Tests.Count);
        }

        public IList<SubjectDto> ToDto(IEnumerable<Subject> e)
        {
            return e.Select(ToDto).ToList();
        }
    }
}