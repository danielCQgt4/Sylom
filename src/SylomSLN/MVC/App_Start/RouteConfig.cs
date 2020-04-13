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
                url: "mantenimientos/{mode}",
                defaults: new { controller = "Mantenimiento", action = "Index", mode = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "MantenimientoForm",
                url: "mantenimientos/c/{mode}",
                defaults: new { controller = "Mantenimiento", action = "Form" }
            );

            routes.MapRoute(
                name: "MantenimientoForm2",
                url: "mantenimientos/u/{mode}/{id}",
                defaults: new { controller = "Mantenimiento", action = "Form2" }
            );

            routes.MapRoute(
                name: "ReadMantenimiento",
                url: "mantenimientos/a/read",
                defaults: new { controller = "Mantenimiento", action = "Read" }
            );

            routes.MapRoute(
                name: "ReadOneMantenimiento",
                url: "mantenimientos/a/readone",
                defaults: new { controller = "Mantenimiento", action = "ReadOne" }
            );

            routes.MapRoute(
                name: "CreateMantenimiento",
                url: "mantenimientos/a/create",
                defaults: new { controller = "Mantenimiento", action = "Create" }
            );

            routes.MapRoute(
                name: "UpdateMantenimiento",
                url: "mantenimientos/a/update",
                defaults: new { controller = "Mantenimiento", action = "Update" }
            );

            routes.MapRoute(
                name: "DeleteMantenimiento",
                url: "mantenimientos/a/delete",
                defaults: new { controller = "Mantenimiento", action = "Delete" }
            );
            #endregion

            #region Seguridad
            routes.MapRoute(
                name: "RolControl",
                url: "cambiorol",
                defaults: new { controller = "Home", action = "CambioRol" }
            );

            routes.MapRoute(
                name: "Seguridad",
                url: "seguridad",
                defaults: new { controller = "Seguridad", action = "Index" }
            );

            //Rol
            routes.MapRoute(
                name: "RolAgregarForm",
                url: "seguridad/rol/crear",
                defaults: new { controller = "Seguridad", action = "Form" }
            );

            routes.MapRoute(
                name: "RolEditarForm",
                url: "seguridad/rol/editar/{id}",
                defaults: new { controller = "Seguridad", action = "Form", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "RolAgregar",
                url: "seguridad/rol/add",
                defaults: new { controller = "Seguridad", action = "CreateRol" }
            );

            routes.MapRoute(
                name: "RolApartadoAgregar",
                url: "seguridad/rol/apartado/add",
                defaults: new { controller = "Seguridad", action = "CreateRolApartado" }
            );

            routes.MapRoute(
                name: "RolEliminar",
                url: "seguridad/rol/delete",
                defaults: new { controller = "Seguridad", action = "DeleteRol" }
            );

            routes.MapRoute(
                name: "RolApartadoEliminar",
                url: "seguridad/rol/apartado/delete",
                defaults: new { controller = "Seguridad", action = "DeleteRolApartado" }
            );

            routes.MapRoute(
                name: "RolConsultar",
                url: "seguridad/rol/read",
                defaults: new { controller = "Seguridad", action = "ReadRoles" }
            );

            routes.MapRoute(
                name: "ApartadosConsultar",
                url: "seguridad/apartado/read",
                defaults: new { controller = "Seguridad", action = "ReadApartados" }
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

            #region Persona
            routes.MapRoute(
                name: "Provincia",
                url: "paciente/lugares/provincia",
                defaults: new { controller = "Paciente", action = "ReadProvincias" }
            );

            routes.MapRoute(
                name: "Canon",
                url: "paciente/lugares/canton",
                defaults: new { controller = "Paciente", action = "ReadCantones" }
            );

            routes.MapRoute(
                name: "Distrito",
                url: "paciente/lugares/distrito",
                defaults: new { controller = "Paciente", action = "ReadDistritos" }
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
                url: "paciente/editar/{id}",
                defaults: new { controller = "Paciente", action = "Form2", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PacienteCrear",
                url: "paciente/create",
                defaults: new { controller = "Paciente", action = "Create" }
            );

            routes.MapRoute(
                name: "PacienteLeer",
                url: "paciente/read",
                defaults: new { controller = "Paciente", action = "Read" }
            );

            routes.MapRoute(
                name: "PacienteActualizar",
                url: "paciente/update",
                defaults: new { controller = "Paciente", action = "Update" }
            );

            routes.MapRoute(
                name: "PacienteEliminar",
                url: "paciente/delete",
                defaults: new { controller = "Paciente", action = "Delete" }
            );

            routes.MapRoute(
                name: "PacienteLeerUno",
                url: "paciente/readone",
                defaults: new { controller = "Paciente", action = "ReadOne" }
            );

            routes.MapRoute(
                name: "PacienteTipoPaciente",
                url: "paciente/tipopaciente",
                defaults: new { controller = "Paciente", action = "ReadTipoCliente" }
            );

            routes.MapRoute(
                name: "PacienteInstitucion",
                url: "paciente/institucion",
                defaults: new { controller = "Paciente", action = "ReadInstituciones" }
            );

            routes.MapRoute(
                name: "PacienteAPI",
                url: "paciente/api",
                defaults: new { controller = "Paciente", action = "ReadPersonFromApi" }
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
