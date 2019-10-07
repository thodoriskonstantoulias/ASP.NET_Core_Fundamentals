using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Food.Core;

namespace Food.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1 , Name = "Ted's pizza", Location = "Athens", Cuisine = CuisineType.Italian},
                new Restaurant{Id = 2 , Name = "Kostas stake", Location = "Piraeus", Cuisine = CuisineType.Mexican},
                new Restaurant{Id = 3 , Name = "Mary's place", Location = "Patra", Cuisine = CuisineType.None}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(x => x.Name);
                   
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetRestByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
