using System;

namespace Resto.Shared.Dtos
{
    public class HangoutPlaceDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
