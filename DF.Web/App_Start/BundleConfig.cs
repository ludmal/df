using System.Web.Optimization;

namespace DF.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Uncomment to force bundles + minification
            //BundleTable.EnableOptimizations = true;

            // Styles
            bundles.Add(new StyleBundle("~/styles")
                .Include(
                    "~/Content/bootstrap.css",
                    "~/Content/site.css"
                )
                );

            // Angular Modules
            bundles.Add(new ScriptBundle("~/scripts/g")
                .Include(
                    "~/Scripts/jquery-1.9.1.min",
                    "~/Scripts/angular.js",
                    "~/Scripts/angular-touch.js",
                    "~/Scripts/angular-cookies.js",
                    "~/Scripts/angular-resource.js",
                    "~/Scripts/angular-sanitize.js",
                    "~/Scripts/angular-ui-router.js"
                )
                );

            bundles.Add(new ScriptBundle("~/scripts/app")
                .Include(
                    "~/app/app.js",
                    "~/app/config.js",
                    "~/app/modules.js",
                    "~/app/core/*.js"
                )
                );

            //bundles.Add(new ScriptBundle("~/scripts/kendo")
            //   .Include(
            //       //"~/Scripts/kendo/kendo.all.min.js"
            //   )
            //   );
        }
    }
}