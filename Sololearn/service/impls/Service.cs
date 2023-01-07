using Sololearn.exception;
using Sololearn.mapper;
using Sololearn.repository.contract;
using Sololearn.service.contract;

namespace Sololearn.service.impls
{
    public class Service<M, R, E, Dto, AddDto, ID> : IService<Dto, AddDto, ID> 

        where M : IEntityMapper<E, Dto, AddDto> 
        where R : IRepository<E,ID>

    {
        protected readonly M mapper;
        protected readonly R repository;

        public Service(M mapper, R repo)
        {
            this.mapper = mapper;
            this.repository = repo;
        }

        public Dto Add(AddDto dto)
        {
            E e = mapper.FromAddDto(dto);
            return mapper.ToDto(repository.Save(e));
        }

        public bool DeleteById(ID id)
        {
            return repository.DeleteById(id);
        }

        public Dto Edit(ID id, AddDto dto)
        {
            E? e = repository.FindById(id);

            if (e==null)
                throw new ServiceException($"Entity not found with id : {id}");
            E? e1 = mapper.FromAddDto(e, dto);

            return mapper.ToDto(repository.Save(e1));
        }

        public IList<Dto> FindAll()
        {
           return repository.FindAll().Select(mapper.ToDto).ToList();
        }

        public Dto FindById(ID id)
        {
            E? e = repository.FindById(id);

            if (e == null)
                throw new ServiceException($"Entity not found with id : {id}");

            return mapper.ToDto(e);
        }
    }
}
