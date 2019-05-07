using System;

namespace Resto.Data
{
    public class HangoutPlace : Entity
    {
        public string Name { get; set; }
        public PlaceCategory Category { get; set; }
    }

    public class PlaceCategory : Entity
    {
        public string Name { get; set; }
        public string PublicCode { get; set; }
    }

    public class Entity
    {
        public Guid Id { get; set; }
    }
}