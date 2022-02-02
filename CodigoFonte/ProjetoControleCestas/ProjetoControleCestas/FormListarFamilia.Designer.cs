
namespace ProjetoControleCestas
{
    partial class FormListarFamilia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelFundo = new System.Windows.Forms.Panel();
            this.panelListagem = new System.Windows.Forms.Panel();
            this.dataGridViewFamilias = new System.Windows.Forms.DataGridView();
            this.ColumnTipoLogradouro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLogradouro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBairro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnResponsavelFamilia = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnNomeResponsavel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelCabecalho = new System.Windows.Forms.Panel();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.buttonFechar = new System.Windows.Forms.Button();
            this.buttonAlterar = new System.Windows.Forms.Button();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.labelPesquisar = new System.Windows.Forms.Label();
            this.buttonPesquisar = new System.Windows.Forms.Button();
            this.maskedTextBoxPesquisar = new System.Windows.Forms.MaskedTextBox();
            this.groupBoxTipoPesquisa = new System.Windows.Forms.GroupBox();
            this.radioButtonPesqNome = new System.Windows.Forms.RadioButton();
            this.radioButtonPesqCpf = new System.Windows.Forms.RadioButton();
            this.panelFundo.SuspendLayout();
            this.panelListagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFamilias)).BeginInit();
            this.panelCabecalho.SuspendLayout();
            this.groupBoxTipoPesquisa.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFundo
            // 
            this.panelFundo.Controls.Add(this.panelListagem);
            this.panelFundo.Controls.Add(this.panelCabecalho);
            this.panelFundo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFundo.Location = new System.Drawing.Point(0, 0);
            this.panelFundo.Name = "panelFundo";
            this.panelFundo.Size = new System.Drawing.Size(926, 528);
            this.panelFundo.TabIndex = 0;
            // 
            // panelListagem
            // 
            this.panelListagem.Controls.Add(this.dataGridViewFamilias);
            this.panelListagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelListagem.Location = new System.Drawing.Point(0, 78);
            this.panelListagem.Name = "panelListagem";
            this.panelListagem.Size = new System.Drawing.Size(926, 450);
            this.panelListagem.TabIndex = 1;
            // 
            // dataGridViewFamilias
            // 
            this.dataGridViewFamilias.AllowUserToAddRows = false;
            this.dataGridViewFamilias.AllowUserToDeleteRows = false;
            this.dataGridViewFamilias.AllowUserToOrderColumns = true;
            this.dataGridViewFamilias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewFamilias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFamilias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTipoLogradouro,
            this.ColumnLogradouro,
            this.ColumnNumero,
            this.ColumnBairro,
            this.ColumnResponsavelFamilia,
            this.ColumnNomeResponsavel,
            this.ColumnCpf});
            this.dataGridViewFamilias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFamilias.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewFamilias.Name = "dataGridViewFamilias";
            this.dataGridViewFamilias.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFamilias.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewFamilias.RowHeadersVisible = false;
            this.dataGridViewFamilias.RowHeadersWidth = 50;
            this.dataGridViewFamilias.RowTemplate.Height = 25;
            this.dataGridViewFamilias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFamilias.Size = new System.Drawing.Size(926, 450);
            this.dataGridViewFamilias.TabIndex = 0;
            this.dataGridViewFamilias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFamilias_CellClick);
            this.dataGridViewFamilias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFamilias_CellContentClick);
            // 
            // ColumnTipoLogradouro
            // 
            this.ColumnTipoLogradouro.DataPropertyName = "TipoLogradouro";
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnTipoLogradouro.DefaultCellStyle = dataGridViewCellStyle13;
            this.ColumnTipoLogradouro.HeaderText = "Tipo de Logradouro";
            this.ColumnTipoLogradouro.Name = "ColumnTipoLogradouro";
            this.ColumnTipoLogradouro.ReadOnly = true;
            this.ColumnTipoLogradouro.Width = 124;
            // 
            // ColumnLogradouro
            // 
            this.ColumnLogradouro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnLogradouro.DataPropertyName = "Logradouro";
            this.ColumnLogradouro.HeaderText = "Logradouro";
            this.ColumnLogradouro.Name = "ColumnLogradouro";
            this.ColumnLogradouro.ReadOnly = true;
            // 
            // ColumnNumero
            // 
            this.ColumnNumero.DataPropertyName = "Numero";
            this.ColumnNumero.HeaderText = "Número";
            this.ColumnNumero.Name = "ColumnNumero";
            this.ColumnNumero.ReadOnly = true;
            this.ColumnNumero.Width = 76;
            // 
            // ColumnBairro
            // 
            this.ColumnBairro.DataPropertyName = "Bairro";
            this.ColumnBairro.HeaderText = "Bairro";
            this.ColumnBairro.Name = "ColumnBairro";
            this.ColumnBairro.ReadOnly = true;
            this.ColumnBairro.Width = 63;
            // 
            // ColumnResponsavelFamilia
            // 
            this.ColumnResponsavelFamilia.DataPropertyName = "IsResponsavelFamilia";
            this.ColumnResponsavelFamilia.HeaderText = "Responsavel";
            this.ColumnResponsavelFamilia.Name = "ColumnResponsavelFamilia";
            this.ColumnResponsavelFamilia.ReadOnly = true;
            this.ColumnResponsavelFamilia.Width = 78;
            // 
            // ColumnNomeResponsavel
            // 
            this.ColumnNomeResponsavel.DataPropertyName = "NomeResponsavel";
            this.ColumnNomeResponsavel.HeaderText = "Responsável";
            this.ColumnNomeResponsavel.Name = "ColumnNomeResponsavel";
            this.ColumnNomeResponsavel.ReadOnly = true;
            this.ColumnNomeResponsavel.Width = 97;
            // 
            // ColumnCpf
            // 
            this.ColumnCpf.DataPropertyName = "CpfResponsavel";
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnCpf.DefaultCellStyle = dataGridViewCellStyle14;
            this.ColumnCpf.HeaderText = "Cpf";
            this.ColumnCpf.Name = "ColumnCpf";
            this.ColumnCpf.ReadOnly = true;
            this.ColumnCpf.Width = 51;
            // 
            // panelCabecalho
            // 
            this.panelCabecalho.Controls.Add(this.groupBoxTipoPesquisa);
            this.panelCabecalho.Controls.Add(this.maskedTextBoxPesquisar);
            this.panelCabecalho.Controls.Add(this.buttonPesquisar);
            this.panelCabecalho.Controls.Add(this.labelPesquisar);
            this.panelCabecalho.Controls.Add(this.buttonExcluir);
            this.panelCabecalho.Controls.Add(this.buttonFechar);
            this.panelCabecalho.Controls.Add(this.buttonAlterar);
            this.panelCabecalho.Controls.Add(this.buttonAdicionar);
            this.panelCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabecalho.Location = new System.Drawing.Point(0, 0);
            this.panelCabecalho.Name = "panelCabecalho";
            this.panelCabecalho.Size = new System.Drawing.Size(926, 78);
            this.panelCabecalho.TabIndex = 0;
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.Location = new System.Drawing.Point(186, 27);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(75, 23);
            this.buttonExcluir.TabIndex = 2;
            this.buttonExcluir.Text = "Excluir";
            this.buttonExcluir.UseVisualStyleBackColor = true;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // buttonFechar
            // 
            this.buttonFechar.Location = new System.Drawing.Point(838, 30);
            this.buttonFechar.Name = "buttonFechar";
            this.buttonFechar.Size = new System.Drawing.Size(75, 23);
            this.buttonFechar.TabIndex = 7;
            this.buttonFechar.Text = "Fechar";
            this.buttonFechar.UseVisualStyleBackColor = true;
            this.buttonFechar.Click += new System.EventHandler(this.buttonFechar_Click);
            // 
            // buttonAlterar
            // 
            this.buttonAlterar.Location = new System.Drawing.Point(104, 27);
            this.buttonAlterar.Name = "buttonAlterar";
            this.buttonAlterar.Size = new System.Drawing.Size(75, 23);
            this.buttonAlterar.TabIndex = 1;
            this.buttonAlterar.Text = "Alterar";
            this.buttonAlterar.UseVisualStyleBackColor = true;
            this.buttonAlterar.Click += new System.EventHandler(this.buttonAlterar_Click);
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Location = new System.Drawing.Point(23, 27);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(75, 23);
            this.buttonAdicionar.TabIndex = 0;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // labelPesquisar
            // 
            this.labelPesquisar.AutoSize = true;
            this.labelPesquisar.Location = new System.Drawing.Point(299, 31);
            this.labelPesquisar.Name = "labelPesquisar";
            this.labelPesquisar.Size = new System.Drawing.Size(60, 15);
            this.labelPesquisar.TabIndex = 3;
            this.labelPesquisar.Text = "Pesquisar:";
            // 
            // buttonPesquisar
            // 
            this.buttonPesquisar.Location = new System.Drawing.Point(757, 30);
            this.buttonPesquisar.Name = "buttonPesquisar";
            this.buttonPesquisar.Size = new System.Drawing.Size(75, 23);
            this.buttonPesquisar.TabIndex = 6;
            this.buttonPesquisar.Text = "Pesquisar";
            this.buttonPesquisar.UseVisualStyleBackColor = true;
            this.buttonPesquisar.Click += new System.EventHandler(this.buttonPesquisar_Click);
            // 
            // maskedTextBoxPesquisar
            // 
            this.maskedTextBoxPesquisar.Location = new System.Drawing.Point(365, 31);
            this.maskedTextBoxPesquisar.Name = "maskedTextBoxPesquisar";
            this.maskedTextBoxPesquisar.Size = new System.Drawing.Size(186, 23);
            this.maskedTextBoxPesquisar.TabIndex = 3;
            this.maskedTextBoxPesquisar.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // groupBoxTipoPesquisa
            // 
            this.groupBoxTipoPesquisa.Controls.Add(this.radioButtonPesqCpf);
            this.groupBoxTipoPesquisa.Controls.Add(this.radioButtonPesqNome);
            this.groupBoxTipoPesquisa.Location = new System.Drawing.Point(557, 12);
            this.groupBoxTipoPesquisa.Name = "groupBoxTipoPesquisa";
            this.groupBoxTipoPesquisa.Size = new System.Drawing.Size(178, 49);
            this.groupBoxTipoPesquisa.TabIndex = 5;
            this.groupBoxTipoPesquisa.TabStop = false;
            // 
            // radioButtonPesqNome
            // 
            this.radioButtonPesqNome.AutoSize = true;
            this.radioButtonPesqNome.Checked = true;
            this.radioButtonPesqNome.Location = new System.Drawing.Point(21, 23);
            this.radioButtonPesqNome.Name = "radioButtonPesqNome";
            this.radioButtonPesqNome.Size = new System.Drawing.Size(58, 19);
            this.radioButtonPesqNome.TabIndex = 0;
            this.radioButtonPesqNome.TabStop = true;
            this.radioButtonPesqNome.Text = "Nome";
            this.radioButtonPesqNome.UseVisualStyleBackColor = true;
            this.radioButtonPesqNome.CheckedChanged += new System.EventHandler(this.radioButtonPesqNome_CheckedChanged);
            // 
            // radioButtonPesqCpf
            // 
            this.radioButtonPesqCpf.AutoSize = true;
            this.radioButtonPesqCpf.Location = new System.Drawing.Point(98, 24);
            this.radioButtonPesqCpf.Name = "radioButtonPesqCpf";
            this.radioButtonPesqCpf.Size = new System.Drawing.Size(44, 19);
            this.radioButtonPesqCpf.TabIndex = 1;
            this.radioButtonPesqCpf.Text = "Cpf";
            this.radioButtonPesqCpf.UseVisualStyleBackColor = true;
            this.radioButtonPesqCpf.CheckedChanged += new System.EventHandler(this.radioButtonPesqCpf_CheckedChanged);
            // 
            // FormListarFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonFechar;
            this.ClientSize = new System.Drawing.Size(926, 528);
            this.Controls.Add(this.panelFundo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormListarFamilia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Família";
            this.panelFundo.ResumeLayout(false);
            this.panelListagem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFamilias)).EndInit();
            this.panelCabecalho.ResumeLayout(false);
            this.panelCabecalho.PerformLayout();
            this.groupBoxTipoPesquisa.ResumeLayout(false);
            this.groupBoxTipoPesquisa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFundo;
        private System.Windows.Forms.Panel panelListagem;
        private System.Windows.Forms.Panel panelCabecalho;
        private System.Windows.Forms.Button buttonFechar;
        private System.Windows.Forms.Button buttonAlterar;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.DataGridView dataGridViewFamilias;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTipoLogradouro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLogradouro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBairro;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnResponsavelFamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNomeResponsavel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCpf;
        private System.Windows.Forms.GroupBox groupBoxTipoPesquisa;
        private System.Windows.Forms.RadioButton radioButtonPesqCpf;
        private System.Windows.Forms.RadioButton radioButtonPesqNome;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPesquisar;
        private System.Windows.Forms.Button buttonPesquisar;
        private System.Windows.Forms.Label labelPesquisar;
    }
}