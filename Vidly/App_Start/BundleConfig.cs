using System.Web;
using System.Web.Optimization;

namespace Vidly
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/datatables/jquery.datatables.js", 
                        "~/Scripts/datatables/datatables.bootstrap.js"));

            bundles.Add(new Bundle("~/bundles/lib").Include(
                        "~/Scripts/umd/popper.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/bootstrap-datepicker.js",
                        "~/Scripts/DatePickerReady.js",
                        "~/Scripts/typeahead.bundle.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/styles").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/typeahead.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css",
                      "~/content/datatables/css/datatables.bootstrap.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/font-awesome.css"
                      ));
        }
    }
}
