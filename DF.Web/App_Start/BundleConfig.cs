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
                    "~/Scripts/ui-bootstrap-tpls-0.13.0.js",
                    "~/Scripts/jquery.validate.min.js",
                      "~/Scripts/jquery.validate.unobtrusive.js"
                )
                );

            bundles.Add(new ScriptBundle("~/scripts/app")
              .Include(
                  "~/app/app.js",
                  "~/app/modules.js",
                  "~/app/config/auth.interceptor.js",
                  "~/app/config/http.interceptor.js",
                  "~/app/config/config.dev.js"
              )
              );

            bundles.Add(new ScriptBundle("~/scripts/modules")
                .Include(
                    "~/app/core/*.js"
                ));

            System.Web.Optimization.BundleTable.EnableOptimizations = false;
        }
    }
}