using System.Linq;
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

    public class PlaceCategoryMapper : IMapper<PlaceCategoryDto, PlaceCategory>
    {
        private readonly ApplicationDbContext _context;

        public PlaceCategoryMapper(ApplicationDbContext context)
        {
            _context = context;
        }

        public PlaceCategoryDto GetDto(PlaceCategory entity)
        {
            return new PlaceCategoryDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public PlaceCategory GetEntity(PlaceCategoryDto dto)
        {
            var entity = _context.PlaceCategories.SingleOrDefault(p => p.Id == dto.Id) ?? new PlaceCategory();
            entity.Name = dto.Name;

            return entity;
        }
    }
}
