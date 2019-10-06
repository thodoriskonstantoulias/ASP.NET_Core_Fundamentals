﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Core;
using Food.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Fundamentals_proj.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public ListModel(IConfiguration config, IRestaurantData  restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
            //Message = "Hello there";
            Message = config["Message"];
            Restaurants = restaurantData.GetAll();
        }
    }
}