namespace Sololearn.mapper
{
    public interface IEntityMapper<TE, TDto, in TAddDto>
    {
        TDto ToDto(TE e);
        IList<TDto> ToDto(IEnumerable<TE> e);
        TE FromAddDto(TAddDto dto);
        TE FromAddDto(TE e, TAddDto dto);

    }
}