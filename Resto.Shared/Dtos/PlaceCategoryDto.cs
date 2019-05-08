using System;

namespace Resto.Shared.Dtos
{
    public class PlaceCategoryDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}