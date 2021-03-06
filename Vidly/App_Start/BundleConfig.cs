﻿using System.Web;
using System.Web.Optimization;

namespace Vidly
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
                      "~/Scripts/bootbox.js",
                      "~/Scripts/respond.js"));


            // bundle for jquery Datatable, and  add it to _layout.cshtml  @Scripts.Render()
            bundles.Add(new StyleBundle("~/bundles/datatables").Include(
                      "~/Scripts/datatables/jquery.dataTables.js",
                      "~/Scripts/datatables/dataTables.bootstrap.js"));

            // bundle for twitter.typeahead, and  add it to _layout.cshtml  @Scripts.Render()
            bundles.Add(new StyleBundle("~/bundles/typeahead").Include(
                      "~/Scripts/typeahead.bundle.js"));

            // bundle for toastr, and  add it to _layout.cshtml  @Scripts.Render()
            bundles.Add(new StyleBundle("~/bundles/toastr").Include(
                      "~/Scripts/toastr.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/typeahead.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"));

        }
    }
}
