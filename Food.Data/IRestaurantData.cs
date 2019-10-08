using Food.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Food.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant New(Restaurant newRestaurant);
        int Commit();
    }
}
