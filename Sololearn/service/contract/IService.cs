
namespace Sololearn.service.contract
{
    public interface IService<Dto, AddDto,ID>
    {
        Dto Add(AddDto dto);
        Dto FindById(ID id);
        IList<Dto> FindAll();
        bool DeleteById(ID id);
        Dto Edit(ID id, AddDto dto);
    }
}
