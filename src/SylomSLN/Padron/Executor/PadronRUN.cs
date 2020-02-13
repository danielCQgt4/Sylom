﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;
using System.ComponentModel;
using Padron;
using System.Windows.Forms;

namespace Padron.Executor {

    //Padron
    class PadronRUN {
        private static PadronRUN padronRUN;
        private LQCargaArchivoDataContext lQCargaArchivoDataContext;
        private string[] personArray;
        private Persona person;

        private PadronRUN() {
            this.lQCargaArchivoDataContext = new LQCargaArchivoDataContext();
            this.person = Persona.GetInstance();
        }

        public static PadronRUN getInstance() {
            if (padronRUN == null) {
                padronRUN = new PadronRUN();
            }
            return padronRUN;
        }

        public bool AgregarPersona(string personaString) {
            personArray = personaString.Split(',');
            if (personArray.Length == 8) {
                person.SetCedula(personArray[0]);
                person.SetDireccionPadron(personArray[1]);
                person.SetGenero(int.Parse(personArray[2]));
                person.SetNombre(personArray[5]);
                person.SetApellido1(personArray[6]);
                person.SetApellido2(personArray[7]);
                return AgregarPersonaFromObj(person);
            }
            return false;
        }

        public bool AgregarPersonaFromObj(Persona person) {
            int i = lQCargaArchivoDataContext.mantenimientoPersonas(
                person.GetCedula(),
                person.GetNombre(),
                person.GetApellido1(),
                person.GetApellido2(),
                person.GetDireccionPadron(),
                person.GetDireccion2(),
                person.GetProvincia(),
                person.GetCanton(),
                person.GetDistrito(),
                person.GetGenero(),
                person.GetFecha(person.GetFechaNamcimiento()),
                person.GetEmail(),
                person.GetTelefono(),
                true
            );
            return i != -1;
        }

        public void ManejoActivos() {
            lQCargaArchivoDataContext.manejoActivos();
        }

        public void Destroy() {
            personArray = null;
            padronRUN = null;
            lQCargaArchivoDataContext = null;
            person.Destroy();
        }

    }
}
