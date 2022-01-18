using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdetoFood.Data;
using OdeToFood.Core;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
    private readonly IRestaurantData restaurantData;

    public Restaurant Restaurant { get; set; }

    public DetailModel(IRestaurantData restaurantData)
    {
      this.restaurantData = restaurantData;
    }

    public IActionResult OnGet(int restaurantId)
    {
      Restaurant = restaurantData.GetById(restaurantId);
      if (Restaurant == null)
      {
        return RedirectToPage("./Notfound");
      }
      return Page();
    }
    }
}
