using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Resto.Data;
using Resto.Services.Mappers;
using Resto.Shared.Dtos;

namespace Resto.Services.Services
{
    public class PlaceCategoryService : ISimpleService<PlaceCategoryDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper<PlaceCategoryDto, PlaceCategory> _mapper;

        public PlaceCategoryService(ApplicationDbContext context, IMapper<PlaceCategoryDto, PlaceCategory> mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<PlaceCategoryDto> Get()
        {
            var placeCategories = _context.PlaceCategories
                .AsNoTracking().ToList();

            return placeCategories.Select(p => _mapper.GetDto(p));
        }

        public PlaceCategoryDto Get(Guid id)
        {
            var placeCategory = _context.PlaceCategories
                .AsNoTracking()
                .SingleOrDefault(p => p.Id == id);

            return _mapper.GetDto(placeCategory);
        }

        public Guid Save(PlaceCategoryDto dto)
        {
            var placeCategory = _mapper.GetEntity(dto);
            _context.PlaceCategories.Update(placeCategory);
            _context.SaveChanges();

            return placeCategory.Id;
        }

        public void Delete(Guid id)
        {
            var placeCategory = _context.PlaceCategories.Single(h => h.Id == id);
            _context.PlaceCategories.Remove(placeCategory);
            _context.SaveChanges();
        }

        public bool Exists(Guid id)
        {
            return _context.PlaceCategories.Any(p => p.Id == id);
        }
    }
}