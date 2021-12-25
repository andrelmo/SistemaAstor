
namespace ProjetoControleCestas
{
    partial class FormEditarUsuario
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
            this.panelEdicao = new System.Windows.Forms.Panel();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.radioButtonStatusInativo = new System.Windows.Forms.RadioButton();
            this.radioButtonStatusAtivo = new System.Windows.Forms.RadioButton();
            this.groupBoxTipoUsuario = new System.Windows.Forms.GroupBox();
            this.radioButtonTipoUsuarioSistema = new System.Windows.Forms.RadioButton();
            this.radioButtonTipoUsuarioVoluntario = new System.Windows.Forms.RadioButton();
            this.radioButtonTipoUsuarioColaborador = new System.Windows.Forms.RadioButton();
            this.textBoxSenha = new System.Windows.Forms.TextBox();
            this.labelSenha = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxTelefone = new System.Windows.Forms.TextBox();
            this.labelTelefone = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.labelCep = new System.Windows.Forms.Label();
            this.textBoxCidade = new System.Windows.Forms.TextBox();
            this.labelCidade = new System.Windows.Forms.Label();
            this.textBoxBairro = new System.Windows.Forms.TextBox();
            this.labelBairro = new System.Windows.Forms.Label();
            this.textBoxEndereco = new System.Windows.Forms.TextBox();
            this.labelEndereco = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.panelRodape = new System.Windows.Forms.Panel();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.textBoxCep = new System.Windows.Forms.MaskedTextBox();
            this.panelFundo.SuspendLayout();
            this.panelEdicao.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.groupBoxTipoUsuario.SuspendLayout();
            this.panelRodape.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFundo
            // 
            this.panelFundo.Controls.Add(this.panelEdicao);
            this.panelFundo.Controls.Add(this.panelRodape);
            this.panelFundo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFundo.Location = new System.Drawing.Point(0, 0);
            this.panelFundo.Name = "panelFundo";
            this.panelFundo.Size = new System.Drawing.Size(800, 450);
            this.panelFundo.TabIndex = 0;
            // 
            // panelEdicao
            // 
            this.panelEdicao.Controls.Add(this.textBoxCep);
            this.panelEdicao.Controls.Add(this.groupBoxStatus);
            this.panelEdicao.Controls.Add(this.groupBoxTipoUsuario);
            this.panelEdicao.Controls.Add(this.textBoxSenha);
            this.panelEdicao.Controls.Add(this.labelSenha);
            this.panelEdicao.Controls.Add(this.textBoxLogin);
            this.panelEdicao.Controls.Add(this.labelLogin);
            this.panelEdicao.Controls.Add(this.textBoxTelefone);
            this.panelEdicao.Controls.Add(this.labelTelefone);
            this.panelEdicao.Controls.Add(this.textBoxEmail);
            this.panelEdicao.Controls.Add(this.labelEmail);
            this.panelEdicao.Controls.Add(this.comboBoxEstado);
            this.panelEdicao.Controls.Add(this.labelEstado);
            this.panelEdicao.Controls.Add(this.labelCep);
            this.panelEdicao.Controls.Add(this.textBoxCidade);
            this.panelEdicao.Controls.Add(this.labelCidade);
            this.panelEdicao.Controls.Add(this.textBoxBairro);
            this.panelEdicao.Controls.Add(this.labelBairro);
            this.panelEdicao.Controls.Add(this.textBoxEndereco);
            this.panelEdicao.Controls.Add(this.labelEndereco);
            this.panelEdicao.Controls.Add(this.textBoxNome);
            this.panelEdicao.Controls.Add(this.labelNome);
            this.panelEdicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdicao.Location = new System.Drawing.Point(0, 0);
            this.panelEdicao.Name = "panelEdicao";
            this.panelEdicao.Size = new System.Drawing.Size(800, 385);
            this.panelEdicao.TabIndex = 1;
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.radioButtonStatusInativo);
            this.groupBoxStatus.Controls.Add(this.radioButtonStatusAtivo);
            this.groupBoxStatus.Location = new System.Drawing.Point(365, 209);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(200, 78);
            this.groupBoxStatus.TabIndex = 17;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Status";
            // 
            // radioButtonStatusInativo
            // 
            this.radioButtonStatusInativo.AutoSize = true;
            this.radioButtonStatusInativo.Location = new System.Drawing.Point(88, 35);
            this.radioButtonStatusInativo.Name = "radioButtonStatusInativo";
            this.radioButtonStatusInativo.Size = new System.Drawing.Size(61, 19);
            this.radioButtonStatusInativo.TabIndex = 1;
            this.radioButtonStatusInativo.TabStop = true;
            this.radioButtonStatusInativo.Text = "Inativo";
            this.radioButtonStatusInativo.UseVisualStyleBackColor = true;
            // 
            // radioButtonStatusAtivo
            // 
            this.radioButtonStatusAtivo.AutoSize = true;
            this.radioButtonStatusAtivo.Checked = true;
            this.radioButtonStatusAtivo.Location = new System.Drawing.Point(21, 35);
            this.radioButtonStatusAtivo.Name = "radioButtonStatusAtivo";
            this.radioButtonStatusAtivo.Size = new System.Drawing.Size(53, 19);
            this.radioButtonStatusAtivo.TabIndex = 0;
            this.radioButtonStatusAtivo.TabStop = true;
            this.radioButtonStatusAtivo.Text = "Ativo";
            this.radioButtonStatusAtivo.UseVisualStyleBackColor = true;
            // 
            // groupBoxTipoUsuario
            // 
            this.groupBoxTipoUsuario.Controls.Add(this.radioButtonTipoUsuarioSistema);
            this.groupBoxTipoUsuario.Controls.Add(this.radioButtonTipoUsuarioVoluntario);
            this.groupBoxTipoUsuario.Controls.Add(this.radioButtonTipoUsuarioColaborador);
            this.groupBoxTipoUsuario.Location = new System.Drawing.Point(13, 209);
            this.groupBoxTipoUsuario.Name = "groupBoxTipoUsuario";
            this.groupBoxTipoUsuario.Size = new System.Drawing.Size(346, 78);
            this.groupBoxTipoUsuario.TabIndex = 16;
            this.groupBoxTipoUsuario.TabStop = false;
            this.groupBoxTipoUsuario.Text = "Tipo de Usuário";
            // 
            // radioButtonTipoUsuarioSistema
            // 
            this.radioButtonTipoUsuarioSistema.AutoSize = true;
            this.radioButtonTipoUsuarioSistema.Enabled = false;
            this.radioButtonTipoUsuarioSistema.Location = new System.Drawing.Point(215, 35);
            this.radioButtonTipoUsuarioSistema.Name = "radioButtonTipoUsuarioSistema";
            this.radioButtonTipoUsuarioSistema.Size = new System.Drawing.Size(66, 19);
            this.radioButtonTipoUsuarioSistema.TabIndex = 3;
            this.radioButtonTipoUsuarioSistema.TabStop = true;
            this.radioButtonTipoUsuarioSistema.Text = "Sistema";
            this.radioButtonTipoUsuarioSistema.UseVisualStyleBackColor = true;
            // 
            // radioButtonTipoUsuarioVoluntario
            // 
            this.radioButtonTipoUsuarioVoluntario.AutoSize = true;
            this.radioButtonTipoUsuarioVoluntario.Location = new System.Drawing.Point(120, 35);
            this.radioButtonTipoUsuarioVoluntario.Name = "radioButtonTipoUsuarioVoluntario";
            this.radioButtonTipoUsuarioVoluntario.Size = new System.Drawing.Size(79, 19);
            this.radioButtonTipoUsuarioVoluntario.TabIndex = 2;
            this.radioButtonTipoUsuarioVoluntario.Text = "Voluntário";
            this.radioButtonTipoUsuarioVoluntario.UseVisualStyleBackColor = true;
            // 
            // radioButtonTipoUsuarioColaborador
            // 
            this.radioButtonTipoUsuarioColaborador.AutoSize = true;
            this.radioButtonTipoUsuarioColaborador.Checked = true;
            this.radioButtonTipoUsuarioColaborador.Location = new System.Drawing.Point(15, 35);
            this.radioButtonTipoUsuarioColaborador.Name = "radioButtonTipoUsuarioColaborador";
            this.radioButtonTipoUsuarioColaborador.Size = new System.Drawing.Size(91, 19);
            this.radioButtonTipoUsuarioColaborador.TabIndex = 1;
            this.radioButtonTipoUsuarioColaborador.TabStop = true;
            this.radioButtonTipoUsuarioColaborador.Text = "Colaborador";
            this.radioButtonTipoUsuarioColaborador.UseVisualStyleBackColor = true;
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.Location = new System.Drawing.Point(228, 325);
            this.textBoxSenha.MaxLength = 30;
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.PasswordChar = '*';
            this.textBoxSenha.Size = new System.Drawing.Size(152, 23);
            this.textBoxSenha.TabIndex = 21;
            // 
            // labelSenha
            // 
            this.labelSenha.AutoSize = true;
            this.labelSenha.Location = new System.Drawing.Point(228, 306);
            this.labelSenha.Name = "labelSenha";
            this.labelSenha.Size = new System.Drawing.Size(42, 15);
            this.labelSenha.TabIndex = 20;
            this.labelSenha.Text = "Senha:";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(13, 325);
            this.textBoxLogin.MaxLength = 30;
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(152, 23);
            this.textBoxLogin.TabIndex = 19;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(13, 306);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(40, 15);
            this.labelLogin.TabIndex = 18;
            this.labelLogin.Text = "Login:";
            // 
            // textBoxTelefone
            // 
            this.textBoxTelefone.Location = new System.Drawing.Point(13, 164);
            this.textBoxTelefone.MaxLength = 30;
            this.textBoxTelefone.Name = "textBoxTelefone";
            this.textBoxTelefone.Size = new System.Drawing.Size(185, 23);
            this.textBoxTelefone.TabIndex = 13;
            // 
            // labelTelefone
            // 
            this.labelTelefone.AutoSize = true;
            this.labelTelefone.Location = new System.Drawing.Point(13, 146);
            this.labelTelefone.Name = "labelTelefone";
            this.labelTelefone.Size = new System.Drawing.Size(54, 15);
            this.labelTelefone.TabIndex = 12;
            this.labelTelefone.Text = "Telefone:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(253, 163);
            this.textBoxEmail.MaxLength = 200;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(508, 23);
            this.textBoxEmail.TabIndex = 15;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(253, 145);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(44, 15);
            this.labelEmail.TabIndex = 14;
            this.labelEmail.Text = "E-mail:";
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Items.AddRange(new object[] {
            "AC",
            "AL",
            "AM",
            "AP",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MG",
            "MS",
            "MT",
            "PA",
            "PB",
            "PE",
            "PI",
            "PR",
            "RJ",
            "RN",
            "RO",
            "RR",
            "RS",
            "SC",
            "SE",
            "SP",
            "TO"});
            this.comboBoxEstado.Location = new System.Drawing.Point(444, 100);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(121, 23);
            this.comboBoxEstado.Sorted = true;
            this.comboBoxEstado.TabIndex = 9;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(444, 81);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(45, 15);
            this.labelEstado.TabIndex = 8;
            this.labelEstado.Text = "Estado:";
            // 
            // labelCep
            // 
            this.labelCep.AutoSize = true;
            this.labelCep.Location = new System.Drawing.Point(661, 81);
            this.labelCep.Name = "labelCep";
            this.labelCep.Size = new System.Drawing.Size(31, 15);
            this.labelCep.TabIndex = 10;
            this.labelCep.Text = "Cep:";
            // 
            // textBoxCidade
            // 
            this.textBoxCidade.Location = new System.Drawing.Point(253, 99);
            this.textBoxCidade.MaxLength = 50;
            this.textBoxCidade.Name = "textBoxCidade";
            this.textBoxCidade.Size = new System.Drawing.Size(158, 23);
            this.textBoxCidade.TabIndex = 7;
            // 
            // labelCidade
            // 
            this.labelCidade.AutoSize = true;
            this.labelCidade.Location = new System.Drawing.Point(253, 81);
            this.labelCidade.Name = "labelCidade";
            this.labelCidade.Size = new System.Drawing.Size(47, 15);
            this.labelCidade.TabIndex = 6;
            this.labelCidade.Text = "Cidade:";
            // 
            // textBoxBairro
            // 
            this.textBoxBairro.Location = new System.Drawing.Point(13, 100);
            this.textBoxBairro.MaxLength = 50;
            this.textBoxBairro.Name = "textBoxBairro";
            this.textBoxBairro.Size = new System.Drawing.Size(185, 23);
            this.textBoxBairro.TabIndex = 5;
            // 
            // labelBairro
            // 
            this.labelBairro.AutoSize = true;
            this.labelBairro.Location = new System.Drawing.Point(13, 81);
            this.labelBairro.Name = "labelBairro";
            this.labelBairro.Size = new System.Drawing.Size(41, 15);
            this.labelBairro.TabIndex = 4;
            this.labelBairro.Text = "Bairro:";
            // 
            // textBoxEndereco
            // 
            this.textBoxEndereco.Location = new System.Drawing.Point(444, 39);
            this.textBoxEndereco.MaxLength = 200;
            this.textBoxEndereco.Name = "textBoxEndereco";
            this.textBoxEndereco.Size = new System.Drawing.Size(317, 23);
            this.textBoxEndereco.TabIndex = 3;
            // 
            // labelEndereco
            // 
            this.labelEndereco.AutoSize = true;
            this.labelEndereco.Location = new System.Drawing.Point(444, 20);
            this.labelEndereco.Name = "labelEndereco";
            this.labelEndereco.Size = new System.Drawing.Size(59, 15);
            this.labelEndereco.TabIndex = 2;
            this.labelEndereco.Text = "Endereço:";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(13, 39);
            this.textBoxNome.MaxLength = 100;
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(359, 23);
            this.textBoxNome.TabIndex = 1;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(13, 20);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(43, 15);
            this.labelNome.TabIndex = 0;
            this.labelNome.Text = "Nome:";
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.buttonCancelar);
            this.panelRodape.Controls.Add(this.buttonSalvar);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 385);
            this.panelRodape.Name = "panelRodape";
            this.panelRodape.Size = new System.Drawing.Size(800, 65);
            this.panelRodape.TabIndex = 0;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(686, 21);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 1;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Location = new System.Drawing.Point(605, 21);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(75, 23);
            this.buttonSalvar.TabIndex = 0;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = true;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // textBoxCep
            // 
            this.textBoxCep.Location = new System.Drawing.Point(661, 99);
            this.textBoxCep.Mask = "00000-000";
            this.textBoxCep.Name = "textBoxCep";
            this.textBoxCep.Size = new System.Drawing.Size(100, 23);
            this.textBoxCep.TabIndex = 11;
            // 
            // FormEditarUsuario
            // 
            this.AcceptButton = this.buttonSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelFundo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Usuario";
            this.panelFundo.ResumeLayout(false);
            this.panelEdicao.ResumeLayout(false);
            this.panelEdicao.PerformLayout();
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxStatus.PerformLayout();
            this.groupBoxTipoUsuario.ResumeLayout(false);
            this.groupBoxTipoUsuario.PerformLayout();
            this.panelRodape.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFundo;
        private System.Windows.Forms.Panel panelRodape;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Panel panelEdicao;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox textBoxEndereco;
        private System.Windows.Forms.Label labelEndereco;
        private System.Windows.Forms.TextBox textBoxBairro;
        private System.Windows.Forms.Label labelBairro;
        private System.Windows.Forms.Label labelCep;
        private System.Windows.Forms.TextBox textBoxCidade;
        private System.Windows.Forms.Label labelCidade;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxTelefone;
        private System.Windows.Forms.Label labelTelefone;
        private System.Windows.Forms.TextBox textBoxSenha;
        private System.Windows.Forms.Label labelSenha;
        private System.Windows.Forms.GroupBox groupBoxTipoUsuario;
        private System.Windows.Forms.RadioButton radioButtonTipoUsuarioColaborador;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.RadioButton radioButtonStatusAtivo;
        private System.Windows.Forms.RadioButton radioButtonTipoUsuarioVoluntario;
        private System.Windows.Forms.RadioButton radioButtonStatusInativo;
        private System.Windows.Forms.RadioButton radioButtonTipoUsuarioSistema;
        private System.Windows.Forms.MaskedTextBox textBoxCep;
    }
}