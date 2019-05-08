using Resto.Data;
using Resto.Shared.Dtos;

namespace Resto.Services.Mappers
{
    public interface IMapper<TDto, TEntity> 
        where TDto : IDto 
        where TEntity : IEntity
    {
        TDto GetDto(TEntity entity);
        TEntity GetEntity(TDto dto);
    }
}
