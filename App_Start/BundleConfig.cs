using System.Web;
using System.Web.Optimization;

namespace WebJusticeIN
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                     "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));                       

            bundles.Add(new ScriptBundle("~/bundles/Customjs").Include(
                      "~/Content/assets/js/vendor.js",
                      "~/Content/assets/js/custom.js",
                      "~/Content/OwlCarousel/dist/owl.carousel.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Devscripts").Include(
                      "~/DevExtreme/jszip.min.js",
                      "~/DevExtreme/dx.all.js"));

            bundles.Add(new StyleBundle("~/Content/CustomCss").Include(
                      "~/Content/assets/css/bootstrap.css",
                      "~/Content/assets/css/LineIcons.min.css",
                      "~/Content/assets/css/swiper.css",
                      "~/Content/assets/css/style-dark.css",
                      "~/Content/assets/css/custom.css",
                      "~/Content/assets/css/Site.css"));

            bundles.Add(new StyleBundle("~/Content/OwlCarousel").Include(
                      "~/Content/OwlCarousel/dist/assets/owl.carousel.min.css",
                      "~/Content/OwlCarousel/dist/assets/owl.theme.default.min.css"));

            bundles.Add(new StyleBundle("~/Content/Devcss")
                  .Include("~/DevExtreme/dx.common.css",
                   new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/Devcss3")
                   .Include("~/DevExtreme/dx.light.css",
                    new CssRewriteUrlTransform()));           

            BundleTable.EnableOptimizations = true;
        }
    }
}
