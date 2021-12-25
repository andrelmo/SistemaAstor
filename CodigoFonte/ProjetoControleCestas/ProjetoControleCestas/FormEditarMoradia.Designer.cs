
namespace ProjetoControleCestas
{
    partial class FormEditarMoradia
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
            this.groupBoxBanheiro = new System.Windows.Forms.GroupBox();
            this.radioButtonBanheiroNaoPossui = new System.Windows.Forms.RadioButton();
            this.radioButtonBanheiroColetivo = new System.Windows.Forms.RadioButton();
            this.radioButtonBanheiroProprio = new System.Windows.Forms.RadioButton();
            this.groupBoxTipoCondicaoMoradia = new System.Windows.Forms.GroupBox();
            this.radioButtonCondicaoMoradiaCedida = new System.Windows.Forms.RadioButton();
            this.radioButtonCondicaoMoradiaAlugada = new System.Windows.Forms.RadioButton();
            this.radioButtonCondicaoMoradiaPropria = new System.Windows.Forms.RadioButton();
            this.textBoxNumeroQuartos = new System.Windows.Forms.TextBox();
            this.labelNumeroQuartos = new System.Windows.Forms.Label();
            this.textBoxNumeroComodos = new System.Windows.Forms.TextBox();
            this.labelNumeroComodos = new System.Windows.Forms.Label();
            this.panelRodape = new System.Windows.Forms.Panel();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.panelFundo.SuspendLayout();
            this.panelEdicao.SuspendLayout();
            this.groupBoxBanheiro.SuspendLayout();
            this.groupBoxTipoCondicaoMoradia.SuspendLayout();
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
            this.panelFundo.Size = new System.Drawing.Size(800, 275);
            this.panelFundo.TabIndex = 0;
            // 
            // panelEdicao
            // 
            this.panelEdicao.Controls.Add(this.groupBoxBanheiro);
            this.panelEdicao.Controls.Add(this.groupBoxTipoCondicaoMoradia);
            this.panelEdicao.Controls.Add(this.textBoxNumeroQuartos);
            this.panelEdicao.Controls.Add(this.labelNumeroQuartos);
            this.panelEdicao.Controls.Add(this.textBoxNumeroComodos);
            this.panelEdicao.Controls.Add(this.labelNumeroComodos);
            this.panelEdicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdicao.Location = new System.Drawing.Point(0, 0);
            this.panelEdicao.Name = "panelEdicao";
            this.panelEdicao.Size = new System.Drawing.Size(800, 210);
            this.panelEdicao.TabIndex = 1;
            // 
            // groupBoxBanheiro
            // 
            this.groupBoxBanheiro.Controls.Add(this.radioButtonBanheiroNaoPossui);
            this.groupBoxBanheiro.Controls.Add(this.radioButtonBanheiroColetivo);
            this.groupBoxBanheiro.Controls.Add(this.radioButtonBanheiroProprio);
            this.groupBoxBanheiro.Location = new System.Drawing.Point(369, 84);
            this.groupBoxBanheiro.Name = "groupBoxBanheiro";
            this.groupBoxBanheiro.Size = new System.Drawing.Size(327, 78);
            this.groupBoxBanheiro.TabIndex = 5;
            this.groupBoxBanheiro.TabStop = false;
            this.groupBoxBanheiro.Text = "Banheiro";
            // 
            // radioButtonBanheiroNaoPossui
            // 
            this.radioButtonBanheiroNaoPossui.AutoSize = true;
            this.radioButtonBanheiroNaoPossui.Location = new System.Drawing.Point(195, 35);
            this.radioButtonBanheiroNaoPossui.Name = "radioButtonBanheiroNaoPossui";
            this.radioButtonBanheiroNaoPossui.Size = new System.Drawing.Size(84, 19);
            this.radioButtonBanheiroNaoPossui.TabIndex = 3;
            this.radioButtonBanheiroNaoPossui.TabStop = true;
            this.radioButtonBanheiroNaoPossui.Text = "Não Possui";
            this.radioButtonBanheiroNaoPossui.UseVisualStyleBackColor = true;
            // 
            // radioButtonBanheiroColetivo
            // 
            this.radioButtonBanheiroColetivo.AutoSize = true;
            this.radioButtonBanheiroColetivo.Location = new System.Drawing.Point(101, 35);
            this.radioButtonBanheiroColetivo.Name = "radioButtonBanheiroColetivo";
            this.radioButtonBanheiroColetivo.Size = new System.Drawing.Size(69, 19);
            this.radioButtonBanheiroColetivo.TabIndex = 2;
            this.radioButtonBanheiroColetivo.Text = "Coletivo";
            this.radioButtonBanheiroColetivo.UseVisualStyleBackColor = true;
            // 
            // radioButtonBanheiroProprio
            // 
            this.radioButtonBanheiroProprio.AutoSize = true;
            this.radioButtonBanheiroProprio.Checked = true;
            this.radioButtonBanheiroProprio.Location = new System.Drawing.Point(15, 35);
            this.radioButtonBanheiroProprio.Name = "radioButtonBanheiroProprio";
            this.radioButtonBanheiroProprio.Size = new System.Drawing.Size(64, 19);
            this.radioButtonBanheiroProprio.TabIndex = 1;
            this.radioButtonBanheiroProprio.TabStop = true;
            this.radioButtonBanheiroProprio.Text = "Próprio";
            this.radioButtonBanheiroProprio.UseVisualStyleBackColor = true;
            // 
            // groupBoxTipoCondicaoMoradia
            // 
            this.groupBoxTipoCondicaoMoradia.Controls.Add(this.radioButtonCondicaoMoradiaCedida);
            this.groupBoxTipoCondicaoMoradia.Controls.Add(this.radioButtonCondicaoMoradiaAlugada);
            this.groupBoxTipoCondicaoMoradia.Controls.Add(this.radioButtonCondicaoMoradiaPropria);
            this.groupBoxTipoCondicaoMoradia.Location = new System.Drawing.Point(13, 84);
            this.groupBoxTipoCondicaoMoradia.Name = "groupBoxTipoCondicaoMoradia";
            this.groupBoxTipoCondicaoMoradia.Size = new System.Drawing.Size(327, 78);
            this.groupBoxTipoCondicaoMoradia.TabIndex = 4;
            this.groupBoxTipoCondicaoMoradia.TabStop = false;
            this.groupBoxTipoCondicaoMoradia.Text = "Condição Moradia";
            // 
            // radioButtonCondicaoMoradiaCedida
            // 
            this.radioButtonCondicaoMoradiaCedida.AutoSize = true;
            this.radioButtonCondicaoMoradiaCedida.Location = new System.Drawing.Point(195, 35);
            this.radioButtonCondicaoMoradiaCedida.Name = "radioButtonCondicaoMoradiaCedida";
            this.radioButtonCondicaoMoradiaCedida.Size = new System.Drawing.Size(62, 19);
            this.radioButtonCondicaoMoradiaCedida.TabIndex = 3;
            this.radioButtonCondicaoMoradiaCedida.TabStop = true;
            this.radioButtonCondicaoMoradiaCedida.Text = "Cedida";
            this.radioButtonCondicaoMoradiaCedida.UseVisualStyleBackColor = true;
            // 
            // radioButtonCondicaoMoradiaAlugada
            // 
            this.radioButtonCondicaoMoradiaAlugada.AutoSize = true;
            this.radioButtonCondicaoMoradiaAlugada.Location = new System.Drawing.Point(98, 35);
            this.radioButtonCondicaoMoradiaAlugada.Name = "radioButtonCondicaoMoradiaAlugada";
            this.radioButtonCondicaoMoradiaAlugada.Size = new System.Drawing.Size(69, 19);
            this.radioButtonCondicaoMoradiaAlugada.TabIndex = 2;
            this.radioButtonCondicaoMoradiaAlugada.Text = "Alugada";
            this.radioButtonCondicaoMoradiaAlugada.UseVisualStyleBackColor = true;
            // 
            // radioButtonCondicaoMoradiaPropria
            // 
            this.radioButtonCondicaoMoradiaPropria.AutoSize = true;
            this.radioButtonCondicaoMoradiaPropria.Checked = true;
            this.radioButtonCondicaoMoradiaPropria.Location = new System.Drawing.Point(15, 35);
            this.radioButtonCondicaoMoradiaPropria.Name = "radioButtonCondicaoMoradiaPropria";
            this.radioButtonCondicaoMoradiaPropria.Size = new System.Drawing.Size(63, 19);
            this.radioButtonCondicaoMoradiaPropria.TabIndex = 1;
            this.radioButtonCondicaoMoradiaPropria.TabStop = true;
            this.radioButtonCondicaoMoradiaPropria.Text = "Própria";
            this.radioButtonCondicaoMoradiaPropria.UseVisualStyleBackColor = true;
            // 
            // textBoxNumeroQuartos
            // 
            this.textBoxNumeroQuartos.Location = new System.Drawing.Point(176, 39);
            this.textBoxNumeroQuartos.MaxLength = 2;
            this.textBoxNumeroQuartos.Name = "textBoxNumeroQuartos";
            this.textBoxNumeroQuartos.Size = new System.Drawing.Size(115, 23);
            this.textBoxNumeroQuartos.TabIndex = 3;
            this.textBoxNumeroQuartos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumeroQuartos_KeyPress);
            // 
            // labelNumeroQuartos
            // 
            this.labelNumeroQuartos.AutoSize = true;
            this.labelNumeroQuartos.Location = new System.Drawing.Point(176, 20);
            this.labelNumeroQuartos.Name = "labelNumeroQuartos";
            this.labelNumeroQuartos.Size = new System.Drawing.Size(115, 15);
            this.labelNumeroQuartos.TabIndex = 2;
            this.labelNumeroQuartos.Text = "Número de Quartos:";
            // 
            // textBoxNumeroComodos
            // 
            this.textBoxNumeroComodos.Location = new System.Drawing.Point(13, 39);
            this.textBoxNumeroComodos.MaxLength = 2;
            this.textBoxNumeroComodos.Name = "textBoxNumeroComodos";
            this.textBoxNumeroComodos.Size = new System.Drawing.Size(125, 23);
            this.textBoxNumeroComodos.TabIndex = 1;
            this.textBoxNumeroComodos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumeroComodos_KeyPress);
            // 
            // labelNumeroComodos
            // 
            this.labelNumeroComodos.AutoSize = true;
            this.labelNumeroComodos.Location = new System.Drawing.Point(13, 20);
            this.labelNumeroComodos.Name = "labelNumeroComodos";
            this.labelNumeroComodos.Size = new System.Drawing.Size(125, 15);
            this.labelNumeroComodos.TabIndex = 0;
            this.labelNumeroComodos.Text = "Número de Cômodos:";
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.buttonCancelar);
            this.panelRodape.Controls.Add(this.buttonSalvar);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 210);
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
            // FormEditarMoradia
            // 
            this.AcceptButton = this.buttonSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(800, 275);
            this.Controls.Add(this.panelFundo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditarMoradia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Moradia";
            this.panelFundo.ResumeLayout(false);
            this.panelEdicao.ResumeLayout(false);
            this.panelEdicao.PerformLayout();
            this.groupBoxBanheiro.ResumeLayout(false);
            this.groupBoxBanheiro.PerformLayout();
            this.groupBoxTipoCondicaoMoradia.ResumeLayout(false);
            this.groupBoxTipoCondicaoMoradia.PerformLayout();
            this.panelRodape.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFundo;
        private System.Windows.Forms.Panel panelRodape;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Panel panelEdicao;
        private System.Windows.Forms.TextBox textBoxNumeroComodos;
        private System.Windows.Forms.Label labelNumeroComodos;
        private System.Windows.Forms.TextBox textBoxNumeroQuartos;
        private System.Windows.Forms.Label labelNumeroQuartos;
        private System.Windows.Forms.GroupBox groupBoxTipoCondicaoMoradia;
        private System.Windows.Forms.RadioButton radioButtonCondicaoMoradiaPropria;
        private System.Windows.Forms.RadioButton radioButtonCondicaoMoradiaAlugada;
        private System.Windows.Forms.RadioButton radioButtonCondicaoMoradiaCedida;
        private System.Windows.Forms.GroupBox groupBoxBanheiro;
        private System.Windows.Forms.RadioButton radioButtonBanheiroNaoPossui;
        private System.Windows.Forms.RadioButton radioButtonBanheiroColetivo;
        private System.Windows.Forms.RadioButton radioButtonBanheiroProprio;
    }
}