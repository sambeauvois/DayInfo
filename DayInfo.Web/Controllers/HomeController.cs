using DayInfo.Europe;
using DayInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DayInfo.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {
            DayInfoModel model = new DayInfoModel();

            if (id.HasValue)
            {
                model.Year = id.Value;
            }
            else
            {
                model.Year = DateTime.Today.Year;
            }

            model.Luxembourg = DateInfo.Get("LU", model.Year).OrderBy(x => x.Date);
            model.Belgium = DateInfo.Get("BE", model.Year).OrderBy(x => x.Date);

            return View(model);
        }

    }
}