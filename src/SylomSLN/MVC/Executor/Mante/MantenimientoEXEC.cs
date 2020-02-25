using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using BLL.Executor;
using MVC.Models;

namespace MVC.Executor.Mante {

    public class MantenimientoEXEC {

        private MantenimientoRUN Mantenimiento;

        public MantenimientoEXEC(string usuario) {
            Mantenimiento = new MantenimientoRUN(usuario);
        }

        public object ObtenerDatos(string mode) {
            switch (mode) {
                case "tipoempleado":
                    return ObtenerTipoEmpleado();
                case "medicinas":
                    return ObtenerMedicinas();
                case "tipopaciente":
                    return ObtenerTipoPacientes();
                default:
                    return null;
            }
        }

        #region Paciente
        private List<obtenerTipoPacientesResult> ObtenerTipoPacientes() {
            List<obtenerTipoPacientesResult> listaTipo = Mantenimiento.ObtenerTipoPacientes();
            return listaTipo != null ? listaTipo : new List<obtenerTipoPacientesResult>();
        }

        //TODO Hacer el create,delete and update de cada uno
        #endregion

        #region Empleado
        private List<obtenerTipoEmpleadosResult> ObtenerTipoEmpleado() {
            List<obtenerTipoEmpleadosResult> listaTipo = Mantenimiento.ObtenerTipoEmpleados();
            return listaTipo != null ? listaTipo : new List<obtenerTipoEmpleadosResult>();
        }
        #endregion

        #region Medicina
        private List<obtenerMedicinasResult> ObtenerMedicinas() {
            List<obtenerMedicinasResult> listaTipo = Mantenimiento.ObtenerMedicinas();
            return listaTipo != null ? listaTipo : new List<obtenerMedicinasResult>();
        }
        #endregion


    }

}