using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Resto.Data;
using Resto.Services.Mappers;
using Resto.Shared.Dtos;

namespace Resto.Services.Services
{
    public class HangoutService : IHangoutService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper<HangoutPlaceDto, HangoutPlace> _mapper;

        public HangoutService(ApplicationDbContext context, IMapper<HangoutPlaceDto, HangoutPlace> mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Exists(Guid id)
        {
            return _context.HangoutPlaces.Any(h => h.Id == id);
        }

        public IEnumerable<HangoutPlaceDto> Get()
        {
            var hangoutPlaces = _context.HangoutPlaces
                .AsNoTracking()
                .Include(h => h.Category).ToList();

            return hangoutPlaces.Select(h => _mapper.GetDto(h));
        }

        public HangoutPlaceDto Get(Guid id)
        {
            var hangoutPlace = _context.HangoutPlaces
                .AsNoTracking()
                .Include(h => h.Category)
                .SingleOrDefault(h => h.Id == id);

            return _mapper.GetDto(hangoutPlace);
        }

        public Guid Save(HangoutPlaceDto dto)
        {
            var hangoutPlace = _mapper.GetEntity(dto);
            _context.HangoutPlaces.Update(hangoutPlace);
            _context.SaveChanges();

            return hangoutPlace.Id;
        }

        public void Delete(Guid id)
        {
            var hangoutPlace = _context.HangoutPlaces.Single(h => h.Id == id);
            _context.HangoutPlaces.Remove(hangoutPlace);
            _context.SaveChanges();
        }
    }
}