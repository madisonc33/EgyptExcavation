using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace EgyptExcavation.Components
{
    public class FilterViewComponent : ViewComponent
    {
        public List<string> filteringCriteria { get; set; } = new List<string>();


        public IViewComponentResult Invoke()
        {
            filteringCriteria.Add("depthMin");
            filteringCriteria.Add("depthMax");
            filteringCriteria.Add("age");
            filteringCriteria.Add("hairColor");
            filteringCriteria.Add("headDirection");
            filteringCriteria.Add("artifacts");
            filteringCriteria.Add("gender");
            //gets this from the URL
            //allows us to change the css style if it was selected
            ViewBag.SelectedType = RouteData?.Values["age"];
            ViewBag.SelectedType = RouteData?.Values["hairColor"];
            ViewBag.SelectedType = RouteData?.Values["headDirection"];
            ViewBag.SelectedType = RouteData?.Values["artifacts"];
            ViewBag.SelectedType = RouteData?.Values["gender"];

            return View(filteringCriteria);
        }

    }
}
