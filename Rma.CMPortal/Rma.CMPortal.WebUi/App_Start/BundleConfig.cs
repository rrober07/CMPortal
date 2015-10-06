using System.Web;
using System.Web.Optimization;

namespace Rma.CMPortal.WebUi
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            //bundles.Add(new StyleBundle("~/Content/all.css")
            //    .Include("~/font-awesome/css/font-awesome.css")
            //    .Include("~/Content/bootstrap.css")
            //    //.Include("~/css/sb-admin.css")
            //    .Include("~/Content/bootstrap-superhero.css")
            //    .Include("~/Content/layout.css")
            //    .Include("~/Content/site.css")
            //    .Include("~/Content/ui-grid.css")
            //    );

            bundles.Add(new ScriptBundle("~/Scripts/all.js")
                .Include("~/Scripts/jquery-1.10.2.min.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/respond.js")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angular-animate.js")
                .Include("~/Scripts/angular-ui/ui-bootstrap.js")
                .Include("~/Scripts/ui-grid.js")
                .Include("~/Scripts/app/app.js")
                .IncludeDirectory("~/Scripts/app/", "*.js", true)
                );

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/font-awesome/css/font-awesome.css",
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-spacelab.min.css",
                      "~/Content/site.css",
                      "~/Content/ui-grid.css"));

            //bundles.Add(new ScriptBundle("~/bundles/angular").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

        }
    }
}
