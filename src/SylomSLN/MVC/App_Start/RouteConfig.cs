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

            //Rol
            routes.MapRoute(
                name: "RolAgregar",
                url: "seguridad/rol/add",
                defaults: new { controller = "Seguridad", action = "CreateRol" }
            );

            routes.MapRoute(
                name: "RolEliminar",
                url: "seguridad/rol/delete",
                defaults: new { controller = "Seguridad", action = "DeleteRol" }
            );

            routes.MapRoute(
                name: "RolConsultar",
                url: "seguridad/rol/read",
                defaults: new { controller = "Seguridad", action = "ReadRol" }
            );

            //RolUsuarios

            #endregion

            #region Empleado
            routes.MapRoute(
                name: "Empleado",
                url: "empleado",
                defaults: new { controller = "Empleado", action = "Index" }
            );

            routes.MapRoute(
                name: "EmpleadoCreate",
                url: "empleado/create",
                defaults: new { controller = "Empleado", action = "Create" }
            );

            routes.MapRoute(
                name: "EmpleadoUpdate",
                url: "empleado/update",
                defaults: new { controller = "Empleado", action = "Update" }
            );

            routes.MapRoute(
                name: "EmpleadoDelete",
                url: "empleado/delete",
                defaults: new { controller = "Empleado", action = "Delete" }
            );

            routes.MapRoute(
                name: "EmpleadoRead",
                url: "empleado/read",
                defaults: new { controller = "Empleado", action = "Read" }
            );

            routes.MapRoute(
                name: "EmpleadoTipoRead",
                url: "empleado/tipo/read",
                defaults: new { controller = "Empleado", action = "ReadTipoEmpleado" }
            );
            #endregion

            #region Paciente
            routes.MapRoute(
                name: "Paciente",
                url: "paciente",
                defaults: new { controller = "Paciente", action = "Index" }
            );

            routes.MapRoute(
                name: "PacienteForm1",
                url: "paciente/crear",
                defaults: new { controller = "Paciente", action = "Form" }
            );

            routes.MapRoute(
                name: "PacienteForm2",
                url: "paciente/editar",
                defaults: new { controller = "Paciente", action = "Form2" }
            );

            #endregion

            #endregion

            //Default /error
            routes.MapRoute(
                name: "Error",
                url: "error",
                defaults: new { controller = "Error", action = "Index" }
            );

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
