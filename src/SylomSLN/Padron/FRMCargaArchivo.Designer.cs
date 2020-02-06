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
            this.pgCarga = new System.Windows.Forms.ProgressBar();
            this.jtInternet = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.chArchivo = new System.Windows.Forms.RadioButton();
            this.chInternet = new System.Windows.Forms.RadioButton();
            this.ofDialog = new System.Windows.Forms.OpenFileDialog();
            this.bgwCargarArchivo = new System.ComponentModel.BackgroundWorker();
            this.lblInfomativo = new System.Windows.Forms.Label();
            this.grbPrin.SuspendLayout();
            this.SuspendLayout();
            // 
            // jtArchivo
            // 
            this.jtArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jtArchivo.Location = new System.Drawing.Point(43, 141);
            this.jtArchivo.Name = "jtArchivo";
            this.jtArchivo.Size = new System.Drawing.Size(295, 20);
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
            this.lblInstruccion.Size = new System.Drawing.Size(277, 13);
            this.lblInstruccion.TabIndex = 1;
            this.lblInstruccion.Text = "Escoge la manera en la que deseas cargar la informacion";
            // 
            // grbPrin
            // 
            this.grbPrin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbPrin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.grbPrin.Controls.Add(this.lblInfomativo);
            this.grbPrin.Controls.Add(this.pgCarga);
            this.grbPrin.Controls.Add(this.jtInternet);
            this.grbPrin.Controls.Add(this.btnBuscar);
            this.grbPrin.Controls.Add(this.btnCargar);
            this.grbPrin.Controls.Add(this.chArchivo);
            this.grbPrin.Controls.Add(this.jtArchivo);
            this.grbPrin.Controls.Add(this.lblInstruccion);
            this.grbPrin.Controls.Add(this.chInternet);
            this.grbPrin.ForeColor = System.Drawing.Color.White;
            this.grbPrin.Location = new System.Drawing.Point(12, 12);
            this.grbPrin.Name = "grbPrin";
            this.grbPrin.Size = new System.Drawing.Size(451, 311);
            this.grbPrin.TabIndex = 2;
            this.grbPrin.TabStop = false;
            this.grbPrin.Text = "Actualiza la informacion del padron electoral";
            // 
            // pgCarga
            // 
            this.pgCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCarga.Location = new System.Drawing.Point(26, 215);
            this.pgCarga.Name = "pgCarga";
            this.pgCarga.Size = new System.Drawing.Size(394, 23);
            this.pgCarga.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgCarga.TabIndex = 8;
            // 
            // jtInternet
            // 
            this.jtInternet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jtInternet.Enabled = false;
            this.jtInternet.Location = new System.Drawing.Point(43, 87);
            this.jtInternet.Name = "jtInternet";
            this.jtInternet.ReadOnly = true;
            this.jtInternet.Size = new System.Drawing.Size(377, 20);
            this.jtInternet.TabIndex = 7;
            this.jtInternet.Text = "https://www.tse.go.cr/zip/padron/padron_completo.zip";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.btnBuscar.Enabled = false;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(344, 139);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(76, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.btnCargar.Enabled = false;
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.ForeColor = System.Drawing.Color.White;
            this.btnCargar.Location = new System.Drawing.Point(320, 254);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(100, 40);
            this.btnCargar.TabIndex = 3;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.BtnCargar_Click);
            // 
            // chArchivo
            // 
            this.chArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chArchivo.AutoSize = true;
            this.chArchivo.ForeColor = System.Drawing.Color.White;
            this.chArchivo.Location = new System.Drawing.Point(26, 118);
            this.chArchivo.Name = "chArchivo";
            this.chArchivo.Size = new System.Drawing.Size(77, 17);
            this.chArchivo.TabIndex = 5;
            this.chArchivo.Text = "Un archivo";
            this.chArchivo.UseVisualStyleBackColor = true;
            this.chArchivo.CheckedChanged += new System.EventHandler(this.ChArchivo_CheckedChanged);
            // 
            // chInternet
            // 
            this.chInternet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chInternet.AutoSize = true;
            this.chInternet.Checked = true;
            this.chInternet.ForeColor = System.Drawing.Color.White;
            this.chInternet.Location = new System.Drawing.Point(26, 64);
            this.chInternet.Name = "chInternet";
            this.chInternet.Size = new System.Drawing.Size(61, 17);
            this.chInternet.TabIndex = 4;
            this.chInternet.TabStop = true;
            this.chInternet.Text = "Internet";
            this.chInternet.UseVisualStyleBackColor = true;
            this.chInternet.CheckedChanged += new System.EventHandler(this.ChInternet_CheckedChanged);
            // 
            // ofDialog
            // 
            this.ofDialog.FileName = "openFileDialog1";
            // 
            // bgwCargarArchivo
            // 
            this.bgwCargarArchivo.WorkerReportsProgress = true;
            this.bgwCargarArchivo.WorkerSupportsCancellation = true;
            this.bgwCargarArchivo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CargarArchivo);
            this.bgwCargarArchivo.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.CambiarProgreso);
            this.bgwCargarArchivo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.CargaCompleta);
            // 
            // lblInfomativo
            // 
            this.lblInfomativo.AutoSize = true;
            this.lblInfomativo.Location = new System.Drawing.Point(28, 252);
            this.lblInfomativo.Name = "lblInfomativo";
            this.lblInfomativo.Size = new System.Drawing.Size(0, 13);
            this.lblInfomativo.TabIndex = 9;
            // 
            // FormCargar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(477, 333);
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
        private System.Windows.Forms.TextBox jtInternet;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.RadioButton chArchivo;
        private System.Windows.Forms.RadioButton chInternet;
        private System.Windows.Forms.ProgressBar pgCarga;
        private System.Windows.Forms.OpenFileDialog ofDialog;
        private System.ComponentModel.BackgroundWorker bgwCargarArchivo;
        private System.Windows.Forms.Label lblInfomativo;
    }
}

