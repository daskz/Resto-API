using System;
using System.Linq;
using System.Threading.Tasks;

namespace Resto.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            var categoryPub = new PlaceCategory
            {
                Id = Guid.NewGuid(),
                Name = "Бар/Паб",
                PublicCode = "Pub"
            };

            var categoryCafe = new PlaceCategory
            {
                Id = Guid.NewGuid(),
                Name = "Кафе",
                PublicCode = "Cafe"
            };

            context.PlaceCategories.AddRange(
                categoryPub,
                categoryCafe);

            context.HangoutPlaces.AddRange(
                new HangoutPlace
                {
                    Id = Guid.NewGuid(),
                    Name = "Happy Pub",
                    Category = categoryPub
                },
                new HangoutPlace
                {
                    Id = Guid.NewGuid(),
                    Name = "ComiXcafe",
                    Category = categoryCafe
                }
            );

            context.SaveChanges();
        }
    }
}