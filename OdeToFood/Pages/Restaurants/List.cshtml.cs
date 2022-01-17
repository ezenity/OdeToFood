using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdetoFood.Data;
using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
    private readonly IConfiguration config;
    private readonly IRestaurantData restaurantData;

    public string Message { get; set; }
    public IEnumerable<Restaurant> Restaurants { get; set; }

    public ListModel(IConfiguration config, IRestaurantData restaurantData)
    {
      this.config = config;
      this.restaurantData = restaurantData;
    }

    public void OnGet()
    {
      /*Message = "Hello, world!";*/
      Message = config["Message"];
      Restaurants = restaurantData.GetAll();
    }
    }
}
