using System.Linq;
using Resto.Data;
using Resto.Shared.Dtos;

namespace Resto.Services.Mappers
{
    public class HangoutPlaceMapper : IMapper<HangoutPlaceDto, HangoutPlace>
    {
        private readonly ApplicationDbContext _context;

        public HangoutPlaceMapper(ApplicationDbContext context)
        {
            _context = context;
        }

        public HangoutPlaceDto GetDto(HangoutPlace entity)
        {
            return new HangoutPlaceDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Category = entity.Category.Name,
                CategoryId = entity.Category.Id
            };
        }

        public HangoutPlace GetEntity(HangoutPlaceDto dto)
        {
            var hangoutPlace = _context.HangoutPlaces.SingleOrDefault(h => h.Id == dto.Id) ?? new HangoutPlace();

            hangoutPlace.Name = dto.Name;
            hangoutPlace.CategoryId = dto.CategoryId;

            return hangoutPlace;
        }
    }
}