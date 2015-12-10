﻿using System.Web.Optimization;

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
                    "~/black-tie/css/black-tie.css",
                    "~/Content/site.css"
                )
                );

            // Angular Modules
            bundles.Add(new ScriptBundle("~/scripts/g")
                .Include(
                    "~/Scripts/jquery-1.9.1.min.js",
                    "~/Scripts/angular.js",
                    "~/Scripts/angular-touch.js",
                    "~/Scripts/angular-cookies.js",
                    "~/Scripts/angular-resource.js",
                    "~/Scripts/angular-sanitize.js",
                    "~/Scripts/angular-ui-router.js",
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/ui-bootstrap-tpls-0.13.0.js"
                )
                );
        }
    }
}