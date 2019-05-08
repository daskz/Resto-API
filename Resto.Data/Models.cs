using System;

namespace Resto.Data
{
    public class HangoutPlace : Entity
    {
        public string Name { get; set; }
        public PlaceCategory Category { get; set; }
        public Guid CategoryId { get; set; }
    }

    public class PlaceCategory : Entity
    {
        public string Name { get; set; }
        public string PublicCode { get; set; }
    }

    public class Entity : IEntity
    {
        public Guid Id { get; set; }
    }

    public interface IEntity
    {
        Guid Id { get; set; }
    }
}