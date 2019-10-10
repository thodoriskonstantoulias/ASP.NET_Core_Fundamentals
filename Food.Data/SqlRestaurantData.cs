using System;
using System.Collections.Generic;
using System.Text;
using Food.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Food.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly RestaurantDbContext context;

        public SqlRestaurantData(RestaurantDbContext context)
        {
            this.context = context;
        }
        public int Commit()
        {
            return context.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                context.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return context.Restaurants.ToList();
        }

        public Restaurant GetById(int id)
        {
            return context.Restaurants.Find(id);
        }

        public int GetRestaurantCount()
        {
            return context.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestByName(string name)
        {
            return from r in context.Restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant New(Restaurant newRestaurant)
        {
            context.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = context.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
