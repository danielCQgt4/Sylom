﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;

namespace BLL.Executor {

    //BLL
    //TODO Delete this class
    public class PadronRUN {
        /*
        private static PadronRUN padron;
        private LQCargaArchivoDataContext lQCargaArchivoDataContext;
        private string[] personArray;
        private Persona person;
        private BackgroundWorker bgWorker;

        private PadronRUN() {
            this.lQCargaArchivoDataContext = new LQCargaArchivoDataContext();
            this.person = Persona.GetInstance();
        }

        public static PadronRUN GetInstance() {
            if (padron == null) {
                padron = new PadronRUN();
            }
            return padron;
        }

        public void setBackgroundWorker(BackgroundWorker worker) {
            this.bgWorker = worker;
        }

        public void AgregarPersona(string persona) {
            personArray = persona.Split(',');
            if (personArray.Length == 8) {
                person.SetCedula(personArray[0]);
                person.SetDireccionPadron(personArray[1]);
                person.SetGenero(int.Parse(personArray[2]));
                person.SetNombre(personArray[5]);
                person.SetApellido1(personArray[6]);
                person.SetApellido2(personArray[7]);
                bool agregado = AgregarPersonaFromObj(person);
                if (agregado) {
                    bgWorker.ReportProgress(1);
                }
            }
            bgWorker.ReportProgress(0);
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
            padron = null;
            lQCargaArchivoDataContext = null;
            person.Destroy();
        }
        */
    }
}
