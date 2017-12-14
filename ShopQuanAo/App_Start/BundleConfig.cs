using System.Web.Optimization;

namespace ShopQuanAo
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            #region GiaoDien

            bundles.Add(new ScriptBundle("~/bundles/theme/theme_js").Include(
                "~/Scripts/theme/js/jquery.min.js",
                "~/Scripts/theme/js/jquery.ui.custom.js",
                "~/Scripts/theme/js/bootstrap.min.js",
                "~/Scripts/theme/js/jquery.uniform.js",
                "~/Scripts/theme/js/select2.min.js",
                "~/Scripts/theme/js/jquery.dataTables.min.js",
                "~/Scripts/theme/js/maruti.js",
                "~/Scripts/theme/js/maruti.tables.js"));


            bundles.Add(new StyleBundle("~/Content/theme/css").Include(
               "~/Content/theme/css/bootstrap.css",
               "~/Content/theme/css/bootstrap.min.css",
               "~/Content/theme/css/bootstrap-responsive.min.css",
               "~/Content/theme/css/uniform.css",
               "~/Content/theme/css/select2.css",
               "~/Content/theme/css/maruti-style.css",
               "~/Content/theme/css/maruti-media.css"));

            #endregion

            BundleTable.EnableOptimizations = false;
        }
    }
}
