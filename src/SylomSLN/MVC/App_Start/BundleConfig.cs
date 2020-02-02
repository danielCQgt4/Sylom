using System.Web;
using System.Web.Optimization;

namespace MVC {
    public class BundleConfig {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {

            #region Scripts
            bundles.Add(new ScriptBundle("~/bundles/cycScript").Include(
                        "~/Public/JS/cdGENCY1.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/sripts").Include(
                        "~/Public/JS/jsFBBw411.slim.min.js",
                        "~/Public/JS/jsPFBw411.min.js",
                        "~/Public/JS/jsBBFBw411.min.js"));
            #endregion

            #region Modernizr
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Public/JS/modernizr-*"));
            #endregion

            #region Styles
            bundles.Add(new ScriptBundle("~/bundles/styles").Include(
                        "~/Public/CSS/bootstrap.min.css",
                        "~/Public/CSS/cdGENCY1.css",
                        "~/Public/CSS/cdGENCY1_img.css",
                        "~/Public/CSS/cycStylesFW.min.css"
                        ));
            #endregion
        }
    }
}
