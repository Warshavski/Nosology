using System.Web;
using System.Web.Optimization;

namespace Escyug.Nosology.Web.App
{
    public sealed class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/mdl").Include(
                        "~/Content/mdl-v1.1.2/material.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modal").Include(
                        "~/Content/jDialog/jDialog.min.js",
                        "~/Content/jDialog/modal.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/mdl-v1.1.2/material.min.css",
                      "~/Content/mdl-v1.1.2/material-cyan-teal.min.css",
                      "~/Content/Site.min.css",
                      "~/Content/jDialog/jDialog.css"));
        }
    }
}
