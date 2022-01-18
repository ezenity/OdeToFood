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

    public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
    {
      return from r in restaurants 
             where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
             orderby r.Name
             select r;
    }
  }

}
