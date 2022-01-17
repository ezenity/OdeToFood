using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdetoFood.Data
{
  public interface IRestaurantData
  {
    IEnumerable<Restaurant> GetAll();
  }

  public class InMemoryRestaurantData : IRestaurantData
  {

    List<Restaurant> restaurants;

    public InMemoryRestaurantData()
    {
      restaurants = new List<Restaurant>()
      {
        new Restaurant() {Id = 1, Name = "Ant's Pizza", Location = "Forida", Cuisine = CuisineType.Mexican},
        new Restaurant() { Id = 1, Name = "Trina's Club", Location = "Philadelphia", Cuisine = CuisineType.italian },
        new Restaurant() { Id = 1, Name = "La Costa", Location = "New Jersey", Cuisine = CuisineType.Indian }
      };
    }

    public IEnumerable<Restaurant> GetAll()
    {
      return from r in restaurants orderby r.Name select r;
    }
  }

}
