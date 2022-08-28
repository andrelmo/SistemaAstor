namespace ProjetoControleCestas
{
    partial class FormListarAtividadeDesenvolvida
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
            this.panelFundo = new System.Windows.Forms.Panel();
            this.panelListagem = new System.Windows.Forms.Panel();
            this.dataGridViewTipoBeneficios = new System.Windows.Forms.DataGridView();
            this.panelCabecalho = new System.Windows.Forms.Panel();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.buttonFechar = new System.Windows.Forms.Button();
            this.buttonAlterar = new System.Windows.Forms.Button();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.ColumnAtividadeDesenvolvida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelFundo.SuspendLayout();
            this.panelListagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTipoBeneficios)).BeginInit();
            this.panelCabecalho.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFundo
            // 
            this.panelFundo.Controls.Add(this.panelListagem);
            this.panelFundo.Controls.Add(this.panelCabecalho);
            this.panelFundo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFundo.Location = new System.Drawing.Point(0, 0);
            this.panelFundo.Name = "panelFundo";
            this.panelFundo.Size = new System.Drawing.Size(800, 450);
            this.panelFundo.TabIndex = 2;
            // 
            // panelListagem
            // 
            this.panelListagem.Controls.Add(this.dataGridViewTipoBeneficios);
            this.panelListagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelListagem.Location = new System.Drawing.Point(0, 56);
            this.panelListagem.Name = "panelListagem";
            this.panelListagem.Size = new System.Drawing.Size(800, 394);
            this.panelListagem.TabIndex = 1;
            // 
            // dataGridViewTipoBeneficios
            // 
            this.dataGridViewTipoBeneficios.AllowUserToAddRows = false;
            this.dataGridViewTipoBeneficios.AllowUserToDeleteRows = false;
            this.dataGridViewTipoBeneficios.AllowUserToOrderColumns = true;
            this.dataGridViewTipoBeneficios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTipoBeneficios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAtividadeDesenvolvida});
            this.dataGridViewTipoBeneficios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTipoBeneficios.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTipoBeneficios.Name = "dataGridViewTipoBeneficios";
            this.dataGridViewTipoBeneficios.ReadOnly = true;
            this.dataGridViewTipoBeneficios.RowHeadersVisible = false;
            this.dataGridViewTipoBeneficios.RowTemplate.Height = 25;
            this.dataGridViewTipoBeneficios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTipoBeneficios.Size = new System.Drawing.Size(800, 394);
            this.dataGridViewTipoBeneficios.TabIndex = 0;
            this.dataGridViewTipoBeneficios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTipoBeneficios_CellClick);
            this.dataGridViewTipoBeneficios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTipoBeneficios_CellContentClick);
            // 
            // panelCabecalho
            // 
            this.panelCabecalho.Controls.Add(this.buttonExcluir);
            this.panelCabecalho.Controls.Add(this.buttonFechar);
            this.panelCabecalho.Controls.Add(this.buttonAlterar);
            this.panelCabecalho.Controls.Add(this.buttonAdicionar);
            this.panelCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabecalho.Location = new System.Drawing.Point(0, 0);
            this.panelCabecalho.Name = "panelCabecalho";
            this.panelCabecalho.Size = new System.Drawing.Size(800, 56);
            this.panelCabecalho.TabIndex = 0;
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.Location = new System.Drawing.Point(552, 12);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(75, 23);
            this.buttonExcluir.TabIndex = 2;
            this.buttonExcluir.Text = "Excluir";
            this.buttonExcluir.UseVisualStyleBackColor = true;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // buttonFechar
            // 
            this.buttonFechar.Location = new System.Drawing.Point(634, 11);
            this.buttonFechar.Name = "buttonFechar";
            this.buttonFechar.Size = new System.Drawing.Size(75, 23);
            this.buttonFechar.TabIndex = 3;
            this.buttonFechar.Text = "Fechar";
            this.buttonFechar.UseVisualStyleBackColor = true;
            this.buttonFechar.Click += new System.EventHandler(this.buttonFechar_Click);
            // 
            // buttonAlterar
            // 
            this.buttonAlterar.Location = new System.Drawing.Point(471, 12);
            this.buttonAlterar.Name = "buttonAlterar";
            this.buttonAlterar.Size = new System.Drawing.Size(75, 23);
            this.buttonAlterar.TabIndex = 1;
            this.buttonAlterar.Text = "Alterar";
            this.buttonAlterar.UseVisualStyleBackColor = true;
            this.buttonAlterar.Click += new System.EventHandler(this.buttonAlterar_Click);
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Location = new System.Drawing.Point(390, 12);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(75, 23);
            this.buttonAdicionar.TabIndex = 0;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // ColumnAtividadeDesenvolvida
            // 
            this.ColumnAtividadeDesenvolvida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnAtividadeDesenvolvida.DataPropertyName = "Atividade";
            this.ColumnAtividadeDesenvolvida.HeaderText = "Atividade Desenvolvida";
            this.ColumnAtividadeDesenvolvida.Name = "ColumnAtividadeDesenvolvida";
            this.ColumnAtividadeDesenvolvida.ReadOnly = true;
            // 
            // FormListarAtividadeDesenvolvida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelFundo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormListarAtividadeDesenvolvida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Lista de Atividade Desenvolvida";
            this.panelFundo.ResumeLayout(false);
            this.panelListagem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTipoBeneficios)).EndInit();
            this.panelCabecalho.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFundo;
        private System.Windows.Forms.Panel panelListagem;
        private System.Windows.Forms.DataGridView dataGridViewTipoBeneficios;
        private System.Windows.Forms.Panel panelCabecalho;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.Button buttonFechar;
        private System.Windows.Forms.Button buttonAlterar;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAtividadeDesenvolvida;
    }
}