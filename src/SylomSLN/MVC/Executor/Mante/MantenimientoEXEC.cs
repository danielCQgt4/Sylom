using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using BLL.Executor;
using MVC.Models;

namespace MVC.Executor.Mante {

    public class MantenimientoEXEC {

        private readonly MantenimientoRUN Mantenimiento;

        public MantenimientoEXEC(string usuario) {
            Mantenimiento = new MantenimientoRUN(usuario);
        }

        public object ObtenerDatos(string mode) {
            object lista;
            switch (mode) {
                case "tipoempleado":
                    lista = Mantenimiento.ObtenerTipoEmpleados();
                    break;
                case "medicinas":
                    lista = Mantenimiento.ObtenerMedicinas();
                    break;
                case "tipopaciente":
                    lista = Mantenimiento.ObtenerTipoPacientes();
                    break;
                default:
                    lista = new object[0];
                    break;
            }
            return lista;
        }

        public bool AccionMantenimiento(string mode, string action, int id, string desc) {
            switch (action) {
                case "create":
                    return Agregar(mode, id, desc);
                case "update":
                    return Actualizar(mode, id, desc);
                case "delete":
                    return Eliminar(mode, id, desc);
                default:
                    return false;
            }
        }

        private bool Agregar(string mode, int id, string desc) {
            switch (mode) {
                case "tipoempleado":
                    return Mantenimiento.AgregarTipoEmpleado(desc);
                case "medicinas":
                    return Mantenimiento.AgregarMedicina(desc);
                case "tipopaciente":
                    return Mantenimiento.AgregarTipoPaciente(desc);
                default:
                    return false;
            }
        }

        private bool Actualizar(string mode, int id, string desc) {
            switch (mode) {
                case "tipoempleado":
                    return Mantenimiento.ActualizarTipoEmpleado(id, desc);
                case "medicinas":
                    return Mantenimiento.ActualizarMedicina(id, desc);
                case "tipopaciente":
                    return Mantenimiento.ActualizarTipoPaciente(id, desc);
                default:
                    return false;
            }
        }

        private bool Eliminar(string mode, int id, string desc) {
            switch (mode) {
                case "tipoempleado":
                    return Mantenimiento.EliminarTipoEmpleado(id);
                case "medicinas":
                    return Mantenimiento.EliminarMedicina(id);
                case "tipopaciente":
                    return Mantenimiento.EliminarTipoPaciente(id);
                default:
                    return false;
            }
        }
    }

}