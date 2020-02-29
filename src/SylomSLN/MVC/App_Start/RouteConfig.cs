using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Public

            #region Start
            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "Home", action = "Login" }
            );
            routes.MapRoute(
                name: "About",
                url: "about",
                defaults: new { controller = "Home", action = "About" }
            );
            routes.MapRoute(
                name: "Logout",
                url: "logout",
                defaults: new { controller = "Home", action = "Logout" }
            );
            #endregion

            #endregion

            #region Private

            #region Mantenimiento
            routes.MapRoute(
                name: "Mantenimiento",
                url: "mantenimientos",
                defaults: new { controller = "Mantenimiento", action = "Index" }
            );

            routes.MapRoute(
                name: "ReadMantenimiento",
                url: "mantenimientos/read",
                defaults: new { controller = "Mantenimiento", action = "Read" }
            );

            routes.MapRoute(
                name: "CreateMantenimiento",
                url: "mantenimientos/create",
                defaults: new { controller = "Mantenimiento", action = "Create" }
            );

            routes.MapRoute(
                name: "UpdateMantenimiento",
                url: "mantenimientos/update",
                defaults: new { controller = "Mantenimiento", action = "Update" }
            );

            routes.MapRoute(
                name: "DeleteMantenimiento",
                url: "mantenimientos/delete",
                defaults: new { controller = "Mantenimiento", action = "Delete" }
            );
            #endregion

            #region Seguridad
            routes.MapRoute(
                name: "Seguridad",
                url: "seguridad",
                defaults: new { controller = "Seguridad", action = "Index" }
            );
            #endregion

            #endregion

            //Default /index
            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
