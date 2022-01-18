using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdetoFood.Data
{
  public class InMemoryRestaurantData : IRestaurantData
  {

    readonly List<Restaurant> restaurants;

    public InMemoryRestaurantData()
    {
      restaurants = new List<Restaurant>()
      {
        new Restaurant() {Id = 1, Name = "Ant's Pizza", Location = "Forida", Cuisine = CuisineType.Mexican},
        new Restaurant() { Id = 2, Name = "Trina's Club", Location = "Philadelphia", Cuisine = CuisineType.italian },
        new Restaurant() { Id = 3, Name = "La Costa", Location = "New Jersey", Cuisine = CuisineType.Indian }
      };
    }

    public Restaurant Add(Restaurant newRestaurant)
    {
      restaurants.Add(newRestaurant);
      newRestaurant.Id = restaurants.Max(r => r.Id) + 1; // Only for testing
      return newRestaurant;
    }

    public int Commit()
    {
      return 0;
    }

    public Restaurant GetById(int id)
    {
      return restaurants.SingleOrDefault(r => r.Id == id);
    }

    public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
    {
      return from r in restaurants 
             where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
             orderby r.Name
             select r;
    }

    public Restaurant Update(Restaurant updatedRestaurant)
    {
      var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);

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
