using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Executor;

namespace Padron {
    public partial class FormCargar : Form {

        private double lit;

        public FormCargar() {
            InitializeComponent();
        }

        public void Validar(bool type) {
            if (type) {
                //Before press Cargar
                if (chInternet.Checked) {
                    btnCargar.Enabled = true;
                    btnBuscar.Enabled = false;
                    jtArchivo.Text = String.Empty;
                } else {
                    btnBuscar.Enabled = true;
                    btnCargar.Enabled = jtArchivo.Text != String.Empty;
                }
            } else {
                //After press Cargar
                if (File.Exists(jtArchivo.Text)) {
                    if (!bgwCargarArchivo.IsBusy) {
                        btnCargar.Visible = false;
                        bgwCargarArchivo.RunWorkerAsync();
                    } else {
                        MessageBox.Show("El servicio no se puede usar en este momento");
                    }
                } else {
                    MessageBox.Show("El archivo solicitado no existe");
                }
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e) {
            ofDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult r = ofDialog.ShowDialog();
            if (r == DialogResult.OK) {
                jtArchivo.Text = ofDialog.FileName;
            }
        }

        private void CargarArchivo(object sender, DoWorkEventArgs e) {
            try {
                string[] personas = File.ReadAllLines(jtArchivo.Text);
                lit = personas.Length + 1;
                int act = 1;
                PadronRUN padron = PadronRUN.GetInstance();
                foreach (string persona in personas) {
                    bool agregado = padron.AgregarPersona(persona);
                    if (agregado) {
                        bgwCargarArchivo.ReportProgress(act);
                        e.Result = null;
                        act++;
                    } else {
                        bgwCargarArchivo.CancelAsync();
                        e.Result = "Error";
                        break;
                    }
                }
                padron.ManejoActivos();
                bgwCargarArchivo.ReportProgress(act);
                padron.Destroy();
            } catch (IOException ioe) {
                bgwCargarArchivo.CancelAsync();
                MessageBox.Show("Error al leer el archivo");
            }
        }

        private void CambiarProgreso(object sender, ProgressChangedEventArgs e) {
            double a = e.ProgressPercentage, c = 100;
            int b = Convert.ToInt32(((a / lit) * c));
            pgCarga.Value = b;
            string v = $"Progreso actual {e.ProgressPercentage}/{lit}";
            lblInfomativo.Text = v;
        }

        private void CargaCompleta(object sender, RunWorkerCompletedEventArgs e) {
            string v;
            try {
                if (e.Result == null) {
                    v = "Carga de datos completada";
                } else {
                    v = "Hubo un error durante la carga de la informacion";
                }
            } catch (Exception ex) {
                v = "Hubo un error durante la carga de la informacion";
            }
            MessageBox.Show(v);

            btnCargar.Visible = true;
        }

        private void BtnCargar_Click(object sender, EventArgs e) {
            Validar(false);
        }

        private void JtArchivoTextChange(object sender, EventArgs e) {
            Validar(true);
        }

        private void ChArchivo_CheckedChanged(object sender, EventArgs e) {
            Validar(true);
        }

        private void ChInternet_CheckedChanged(object sender, EventArgs e) {
            Validar(true);
        }
    }
}
