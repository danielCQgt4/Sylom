namespace Padron {
    partial class FormCargar {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.jtArchivo = new System.Windows.Forms.TextBox();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.grbPrin = new System.Windows.Forms.GroupBox();
            this.lblInfomativo = new System.Windows.Forms.Label();
            this.pgCarga = new System.Windows.Forms.ProgressBar();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.ofDialog = new System.Windows.Forms.OpenFileDialog();
            this.bgwCargarArchivo = new System.ComponentModel.BackgroundWorker();
            this.grbPrin.SuspendLayout();
            this.SuspendLayout();
            // 
            // jtArchivo
            // 
            this.jtArchivo.Location = new System.Drawing.Point(26, 65);
            this.jtArchivo.Name = "jtArchivo";
            this.jtArchivo.ReadOnly = true;
            this.jtArchivo.Size = new System.Drawing.Size(312, 20);
            this.jtArchivo.TabIndex = 0;
            this.jtArchivo.TextChanged += new System.EventHandler(this.JtArchivoTextChange);
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.ForeColor = System.Drawing.Color.White;
            this.lblInstruccion.Location = new System.Drawing.Point(23, 41);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(213, 13);
            this.lblInstruccion.TabIndex = 1;
            this.lblInstruccion.Text = "Elige la ruta del archivo del padron electoral";
            // 
            // grbPrin
            // 
            this.grbPrin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.grbPrin.Controls.Add(this.lblInfomativo);
            this.grbPrin.Controls.Add(this.pgCarga);
            this.grbPrin.Controls.Add(this.btnBuscar);
            this.grbPrin.Controls.Add(this.btnCargar);
            this.grbPrin.Controls.Add(this.jtArchivo);
            this.grbPrin.Controls.Add(this.lblInstruccion);
            this.grbPrin.ForeColor = System.Drawing.Color.White;
            this.grbPrin.Location = new System.Drawing.Point(12, 12);
            this.grbPrin.Name = "grbPrin";
            this.grbPrin.Size = new System.Drawing.Size(451, 246);
            this.grbPrin.TabIndex = 2;
            this.grbPrin.TabStop = false;
            this.grbPrin.Text = "Actualiza la informacion del padron electoral";
            // 
            // lblInfomativo
            // 
            this.lblInfomativo.AutoSize = true;
            this.lblInfomativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfomativo.Location = new System.Drawing.Point(23, 165);
            this.lblInfomativo.Name = "lblInfomativo";
            this.lblInfomativo.Size = new System.Drawing.Size(0, 20);
            this.lblInfomativo.TabIndex = 9;
            // 
            // pgCarga
            // 
            this.pgCarga.Location = new System.Drawing.Point(26, 117);
            this.pgCarga.Name = "pgCarga";
            this.pgCarga.Size = new System.Drawing.Size(394, 29);
            this.pgCarga.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgCarga.TabIndex = 8;
            this.pgCarga.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(344, 65);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(76, 20);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.btnCargar.Enabled = false;
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.ForeColor = System.Drawing.Color.White;
            this.btnCargar.Location = new System.Drawing.Point(320, 185);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(100, 38);
            this.btnCargar.TabIndex = 3;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.BtnCargar_Click);
            // 
            // ofDialog
            // 
            this.ofDialog.FileName = "openFileDialog1";
            // 
            // bgwCargarArchivo
            // 
            this.bgwCargarArchivo.WorkerReportsProgress = true;
            this.bgwCargarArchivo.WorkerSupportsCancellation = true;
            this.bgwCargarArchivo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CargarArchivo_DoWork);
            this.bgwCargarArchivo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.CargaCompleta_Completed);
            // 
            // FormCargar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(477, 266);
            this.Controls.Add(this.grbPrin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormCargar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargar informacion de personas";
            this.grbPrin.ResumeLayout(false);
            this.grbPrin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox jtArchivo;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.GroupBox grbPrin;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.ProgressBar pgCarga;
        private System.Windows.Forms.OpenFileDialog ofDialog;
        private System.ComponentModel.BackgroundWorker bgwCargarArchivo;
        private System.Windows.Forms.Label lblInfomativo;
    }
}

