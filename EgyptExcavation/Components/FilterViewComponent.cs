using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EgyptExcavation.Models;

namespace EgyptExcavation.Components
{
    public class FilterViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var filteringData = new Filters();

            //gets this from the URL
            //allows us to change the css style if it was selected
            ViewBag.SelectedType = RouteData?.Values["age"];
            ViewBag.SelectedType = RouteData?.Values["haircolor"];
            ViewBag.SelectedType = RouteData?.Values["headdirection"];
            ViewBag.SelectedType = RouteData?.Values["artifacts"];
            ViewBag.SelectedType = RouteData?.Values["gender"];

            return View(filteringData);
        }

    }
}
