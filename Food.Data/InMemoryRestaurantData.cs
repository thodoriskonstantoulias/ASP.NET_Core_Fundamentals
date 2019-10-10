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

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(x => x.Name);
                   
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(x => x.Id == id);
        }

        public int GetRestaurantCount()
        {
            return restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant New(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(x => x.Id) + 1 ;
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = GetById(updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
    }
}
