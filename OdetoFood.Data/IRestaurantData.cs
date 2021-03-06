using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OdetoFood.Data
{
  public interface IRestaurantData
  {
    IEnumerable<Restaurant> GetRestaurantsByName(string name);
    Restaurant GetById(int id);
    Restaurant Update(Restaurant restaurant);
    Restaurant Add(Restaurant newRestaurant);
    Restaurant Delete(int id);
    int GetCountOfRestaurants();
    int Commit();
  }

}
