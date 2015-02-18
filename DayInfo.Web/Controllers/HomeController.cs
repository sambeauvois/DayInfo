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
        [OutputCache(Duration=3600,VaryByParam="id")]
        public ActionResult Index(int? id)
        {
            DayInfoModel model = new DayInfoModel
            {
                Year = DateTime.Today.Year
            };

            if (id.HasValue)
            {
                if (id.Value >= DateTime.MinValue.Year && id.Value <= DateTime.MaxValue.Year)
                {
                    model.Year = id.Value;
                }
            }


            model.Luxembourg = DateInfo.Get("LU", model.Year).OrderBy(x => x.Date);
            model.Belgium = DateInfo.Get("BE", model.Year).OrderBy(x => x.Date);

            return View(model);
        }

    }
}