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
            //Login
            bundles.Add(new ScriptBundle("~/bundles/style/login").Include(
                        "~/Public/CSS/Login/log_cdGENCY1.css"
                        ));
            //Home
            bundles.Add(new ScriptBundle("~/bundles/style/index").Include(
                        "~/Public/CSS/Index/index.css"
                        ));
            //About
            bundles.Add(new ScriptBundle("~/bundles/style/about").Include(
                        "~/Public/CSS/About/about.css"
                        ));
            //Mantenimiento
            bundles.Add(new ScriptBundle("~/bundles/style/mante").Include(
                        "~/Public/CSS/Admin/admin.css",
                        "~/Public/CSS/Admin/Mante/mantenimiento.css"
                        ));
            //Seguridad
            bundles.Add(new ScriptBundle("~/bundles/style/sec").Include(
                        "~/Public/CSS/Admin/admin.css",
                        "~/Public/CSS/Admin/Sec/seguridad.css"
                        ));

            //Empleados
            bundles.Add(new ScriptBundle("~/bundles/style/empleado").Include(
                        "~/Public/CSS/Admin/admin.css",
                        "~/Public/CSS/Admin/Empleado/empleado.css"
                        ));

            //Paciente
            bundles.Add(new ScriptBundle("~/bundles/style/paciente").Include(
                        "~/Public/CSS/Admin/admin.css",
                        "~/Public/CSS/Paciente/paciente.css"
                        ));
            #endregion

        }
    }
}
