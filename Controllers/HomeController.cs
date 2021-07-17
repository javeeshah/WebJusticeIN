using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebJusticeIN.Helper;

namespace WebJusticeIN.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult ChangeCurrentCulture(int id)
        {
            CultureHelper.CurrentCulture = id;
            Session["CurrentCulture"] = id;
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}