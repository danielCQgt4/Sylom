using System.Web;
using System.Web.Optimization;

namespace MVC {
    public class BundleConfig {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {

            #region Scripts
            bundles.Add(new ScriptBundle("~/bundles/sylomScript").Include(
                        "~/Public/JS/Sylom/SylomInit.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/cycScript").Include(
                        "~/Public/JS/General/cdGENCY1.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/sripts").Include(
                        "~/Public/JS/General/jsFBBw411.slim.min.js",
                        "~/Public/JS/General/jsPFBw411.min.js",
                        "~/Public/JS/General/jsBBFBw411.min.js"));
            #endregion

            #region Modernizr
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Public/JS/modernizr-*"));
            #endregion

            #region Styles
            bundles.Add(new ScriptBundle("~/bundles/styles").Include(
                        "~/Public/CSS/General/bootstrap.min.css",
                        "~/Public/CSS/General/cdGENCY1.css",
                        "~/Public/CSS/General/cdGENCY1_img.css",
                        "~/Public/CSS/General/cycStylesFW.min.css"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/style/login").Include(
                        "~/Public/CSS/Login/log_cdGENCY1.css"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/style/index").Include(
                        "~/Public/CSS/Index/index.css"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/style/about").Include(
                        "~/Public/CSS/About/about.css"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/style/mante").Include(
                        "~/Public/CSS/Mante/mantenimiento.css"
                        ));
            #endregion

#if DEBUG
            //BunddleTable.EnableOptimization = false;
#else
            BunddleTable.EnableOptimization = trues;
#endif
        }
    }
}
