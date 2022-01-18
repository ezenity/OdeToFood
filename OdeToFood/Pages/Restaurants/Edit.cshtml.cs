using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdetoFood.Data;
using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
    private readonly IRestaurantData restaurantData;
    private readonly IHtmlHelper htmlHelper;

    [BindProperty]
    public Restaurant Restaurant { get; set; }
    public IEnumerable<SelectListItem> Cuisines { get; set; }

    public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
    {
      this.restaurantData = restaurantData;
      this.htmlHelper = htmlHelper;
    }

    public IActionResult OnGet(int? restaurantId)
    {
      Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

      if (restaurantId.HasValue)
      {
        Restaurant = restaurantData.GetById(restaurantId.Value);
      }
      else
      {
        Restaurant = new Restaurant();
      }

      if (Restaurant == null)
      {
        return RedirectToPage("./NotFound");
      }

      return Page();
    }

    public IActionResult OnPost()
    {
      if (!ModelState.IsValid)
      {
        Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
        return Page();
      }

      if (Restaurant.Id > 0)
      {
        restaurantData.Update(Restaurant);
        TempData["Message"] = "Restaurant Updated!";
      }
      else
      {
        restaurantData.Add(Restaurant);
        TempData["Message"] = "Restaurant Added!";
      }

      restaurantData.Commit();
      /*TempData["Message"] = "Restaurant Saved!";*/
      return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
    }

    }
}
