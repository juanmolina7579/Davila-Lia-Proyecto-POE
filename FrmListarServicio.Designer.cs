namespace Vista
{
    partial class FrmListarServicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            this.ColNro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObsv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.numHasta = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numDesde = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtPrecio = new System.Windows.Forms.RadioButton();
            this.rbtCantidad = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDesde)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvServicios
            // 
            this.dgvServicios.AllowUserToAddRows = false;
            this.dgvServicios.AllowUserToDeleteRows = false;
            this.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNro,
            this.colTipo,
            this.colPrecio,
            this.colCantidad,
            this.colUnidad,
            this.colObsv,
            this.colTotal});
            this.dgvServicios.Location = new System.Drawing.Point(54, 148);
            this.dgvServicios.Margin = new System.Windows.Forms.Padding(4);
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.ReadOnly = true;
            this.dgvServicios.RowHeadersWidth = 51;
            this.dgvServicios.Size = new System.Drawing.Size(859, 282);
            this.dgvServicios.TabIndex = 0;
            // 
            // ColNro
            // 
            this.ColNro.HeaderText = "Nro";
            this.ColNro.MinimumWidth = 6;
            this.ColNro.Name = "ColNro";
            this.ColNro.ReadOnly = true;
            this.ColNro.Width = 125;
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.MinimumWidth = 6;
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            this.colTipo.Width = 125;
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.MinimumWidth = 6;
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            this.colPrecio.Width = 125;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cant.";
            this.colCantidad.MinimumWidth = 6;
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            this.colCantidad.Width = 125;
            // 
            // colUnidad
            // 
            this.colUnidad.HeaderText = "Unidad";
            this.colUnidad.MinimumWidth = 6;
            this.colUnidad.Name = "colUnidad";
            this.colUnidad.ReadOnly = true;
            this.colUnidad.Width = 125;
            // 
            // colObsv
            // 
            this.colObsv.HeaderText = "Observacion";
            this.colObsv.MinimumWidth = 6;
            this.colObsv.Name = "colObsv";
            this.colObsv.ReadOnly = true;
            this.colObsv.Width = 125;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.MinimumWidth = 6;
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 125;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(465, 462);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Imprimir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // numHasta
            // 
            this.numHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHasta.Location = new System.Drawing.Point(541, 61);
            this.numHasta.Margin = new System.Windows.Forms.Padding(4);
            this.numHasta.Name = "numHasta";
            this.numHasta.Size = new System.Drawing.Size(75, 22);
            this.numHasta.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(462, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Hasta:";
            // 
            // numDesde
            // 
            this.numDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDesde.Location = new System.Drawing.Point(338, 64);
            this.numDesde.Margin = new System.Windows.Forms.Padding(4);
            this.numDesde.Name = "numDesde";
            this.numDesde.Size = new System.Drawing.Size(75, 22);
            this.numDesde.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Desde";
            // 
            // rbtPrecio
            // 
            this.rbtPrecio.AutoSize = true;
            this.rbtPrecio.Location = new System.Drawing.Point(97, 43);
            this.rbtPrecio.Name = "rbtPrecio";
            this.rbtPrecio.Size = new System.Drawing.Size(67, 20);
            this.rbtPrecio.TabIndex = 15;
            this.rbtPrecio.TabStop = true;
            this.rbtPrecio.Text = "Precio";
            this.rbtPrecio.UseVisualStyleBackColor = true;
            this.rbtPrecio.CheckedChanged += new System.EventHandler(this.rbtPrecio_CheckedChanged);
            // 
            // rbtCantidad
            // 
            this.rbtCantidad.AutoSize = true;
            this.rbtCantidad.Location = new System.Drawing.Point(97, 90);
            this.rbtCantidad.Name = "rbtCantidad";
            this.rbtCantidad.Size = new System.Drawing.Size(82, 20);
            this.rbtCantidad.TabIndex = 16;
            this.rbtCantidad.TabStop = true;
            this.rbtCantidad.Text = "Cantidad";
            this.rbtCantidad.UseVisualStyleBackColor = true;
            this.rbtCantidad.CheckedChanged += new System.EventHandler(this.rbtCantidad_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(380, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Filtrar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.Location = new System.Drawing.Point(775, 107);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(138, 28);
            this.btnMostrarTodos.TabIndex = 19;
            this.btnMostrarTodos.Text = "Mostrar Todo";
            this.btnMostrarTodos.UseVisualStyleBackColor = true;
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // FrmListarServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 543);
            this.Controls.Add(this.btnMostrarTodos);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.rbtCantidad);
            this.Controls.Add(this.rbtPrecio);
            this.Controls.Add(this.numHasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvServicios);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmListarServicio";
            this.Text = "Lista de servicios registrados";
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDesde)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvServicios;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObsv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtPrecio;
        private System.Windows.Forms.RadioButton rbtCantidad;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnMostrarTodos;
    }
}