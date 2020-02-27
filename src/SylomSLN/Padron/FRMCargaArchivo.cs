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
using DAL;
//using BLL.Executor;

namespace Padron {
    public partial class FormCargar : Form {

        private double lit;
        private int errores = 0;
        private BitacoraRUN bitacora;

        public FormCargar() {
            InitializeComponent(); 
            bitacora = new BitacoraRUN();
        }

        public void Validar(bool type) {
            if (type) {
                btnBuscar.Enabled = true;
                btnCargar.Enabled = jtArchivo.Text != String.Empty;
            } else {
                //After press Cargar
                pgCarga.Visible = true;
                lblInfomativo.Text = String.Empty;
                if (File.Exists(jtArchivo.Text)) {
                    if (!bgwCargarArchivo.IsBusy) {
                        btnCargar.Visible = false;
                        bgwCargarArchivo.RunWorkerAsync("TXT");
                    } else {
                        MessageBox.Show("El servicio no se puede usar en este momento");
                    }
                } else {
                    MessageBox.Show("El archivo solicitado no existe");
                }
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e) {
            ofDialog.Filter = "txt files (*.txt)|*.txt";//|All files (*.*)|*.*
            DialogResult r = ofDialog.ShowDialog();
            if (r == DialogResult.OK) {
                jtArchivo.Text = ofDialog.FileName;
            }
        }

        private void BtnCargar_Click(object sender, EventArgs e) {
            Validar(false);
        }

        private void JtArchivoTextChange(object sender, EventArgs e) {
            Validar(true);
        }

        private PadronRUN padronRUN = new PadronRUN();
        private string[] persona;
        private string[] personasArchivo;

        private void CargaCompleta_Completed(object sender, RunWorkerCompletedEventArgs e) {
            pgCarga.Visible = false;
            lblInfomativo.Text = String.Empty;
            btnCargar.Visible = true;
            MessageBox.Show("Carga de datos completada", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CargarArchivo_DoWork(object sender, DoWorkEventArgs e) {
            if (string.IsNullOrEmpty(jtArchivo.Text)) {
                MessageBox.Show("Ha ocurrido un error al encontrar el archivo o este no existe");
                return;
            }
            try {
                int totalPersonas = 0, actual = 0;
                personasArchivo = File.ReadAllLines(jtArchivo.Text);
                totalPersonas = personasArchivo.Count();
                foreach (string per in personasArchivo) {
                    actual += 1;
                    persona = per.Split(',');
                    if (padronRUN.MantenimientoPersonas(
                       persona[0],
                       persona[5],
                       persona[6],
                       persona[7],
                       persona[1],
                       String.Empty,
                       Convert.ToInt32(persona[0]),
                       new DateTime(0001, 01, 01),
                       String.Empty,
                       String.Empty)) {
                    }
                    Invoke(new delActualizarStatus(ActualizarStatus), " fila " + actual, actual, totalPersonas);
                }
            } catch (Exception ex) {
                bitacora.AgregarRegistro("FormCargar", "CargarArchivo_DoWork()", ex.ToString(), 'E');
                MessageBox.Show("Ocurrio un error al cargar los datos " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Delegados
        private delegate void delActualizarStatus(string nota, int avanceReal, int totalPersonas);

        private void ActualizarStatus(string nota, int avanceReal, int totalPersonas) {
            lblInfomativo.Text = "Completado " + Convert.ToInt32(((decimal)avanceReal / (decimal)totalPersonas) * 100) + "% " + nota;
            pgCarga.Value = avanceReal;
            pgCarga.Maximum = totalPersonas;
        }

        #endregion

    }
}
