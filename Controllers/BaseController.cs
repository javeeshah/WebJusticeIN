using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebJusticeIN.Helper;

namespace WebJusticeIN.Controllers
{
    public class BaseController : Controller
    {
        protected override void ExecuteCore()
        {
            int culture = 0;
            if (this.Session == null || this.Session["CurrentCulture"] == null)
            {

                //int.TryParse(System.Configuration.ConfigurationManager.AppSettings["Culture"], out culture);
                this.Session["CurrentCulture"] = 0;
            }
            else
            {
                culture = (int)this.Session["CurrentCulture"];
            }
            // calling CultureHelper class properties for setting  
            CultureHelper.CurrentCulture = culture;

            base.ExecuteCore();
        }

        protected override bool DisableAsyncSupport
        {
            get { return true; }
        }
    }
}