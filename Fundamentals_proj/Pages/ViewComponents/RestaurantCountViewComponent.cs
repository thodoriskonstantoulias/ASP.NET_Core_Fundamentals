using Food.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fundamentals_proj.Pages.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetRestaurantCount();
            return View(count);
        }
    }
}
