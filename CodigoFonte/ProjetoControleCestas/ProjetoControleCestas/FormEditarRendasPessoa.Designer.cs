
namespace ProjetoControleCestas
{
    partial class FormEditarRendasPessoa
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
            this.groupBoxTipoRenda = new System.Windows.Forms.GroupBox();
            this.radioButtonTipoRendaInformal = new System.Windows.Forms.RadioButton();
            this.radioButtonTipoRendaFormal = new System.Windows.Forms.RadioButton();
            this.textBoxValorRenda = new System.Windows.Forms.TextBox();
            this.labelValorRenda = new System.Windows.Forms.Label();
            this.panelRodape = new System.Windows.Forms.Panel();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.panelFundo.SuspendLayout();
            this.panelEdicao.SuspendLayout();
            this.groupBoxTipoRenda.SuspendLayout();
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
            this.panelFundo.Size = new System.Drawing.Size(780, 266);
            this.panelFundo.TabIndex = 0;
            // 
            // panelEdicao
            // 
            this.panelEdicao.Controls.Add(this.groupBoxTipoRenda);
            this.panelEdicao.Controls.Add(this.textBoxValorRenda);
            this.panelEdicao.Controls.Add(this.labelValorRenda);
            this.panelEdicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdicao.Location = new System.Drawing.Point(0, 0);
            this.panelEdicao.Name = "panelEdicao";
            this.panelEdicao.Size = new System.Drawing.Size(780, 201);
            this.panelEdicao.TabIndex = 1;
            // 
            // groupBoxTipoRenda
            // 
            this.groupBoxTipoRenda.Controls.Add(this.radioButtonTipoRendaInformal);
            this.groupBoxTipoRenda.Controls.Add(this.radioButtonTipoRendaFormal);
            this.groupBoxTipoRenda.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTipoRenda.Name = "groupBoxTipoRenda";
            this.groupBoxTipoRenda.Size = new System.Drawing.Size(219, 78);
            this.groupBoxTipoRenda.TabIndex = 0;
            this.groupBoxTipoRenda.TabStop = false;
            this.groupBoxTipoRenda.Text = "Tipo de Renda";
            // 
            // radioButtonTipoRendaInformal
            // 
            this.radioButtonTipoRendaInformal.AutoSize = true;
            this.radioButtonTipoRendaInformal.Location = new System.Drawing.Point(120, 35);
            this.radioButtonTipoRendaInformal.Name = "radioButtonTipoRendaInformal";
            this.radioButtonTipoRendaInformal.Size = new System.Drawing.Size(70, 19);
            this.radioButtonTipoRendaInformal.TabIndex = 2;
            this.radioButtonTipoRendaInformal.Text = "Informal";
            this.radioButtonTipoRendaInformal.UseVisualStyleBackColor = true;
            // 
            // radioButtonTipoRendaFormal
            // 
            this.radioButtonTipoRendaFormal.AutoSize = true;
            this.radioButtonTipoRendaFormal.Checked = true;
            this.radioButtonTipoRendaFormal.Location = new System.Drawing.Point(15, 35);
            this.radioButtonTipoRendaFormal.Name = "radioButtonTipoRendaFormal";
            this.radioButtonTipoRendaFormal.Size = new System.Drawing.Size(62, 19);
            this.radioButtonTipoRendaFormal.TabIndex = 1;
            this.radioButtonTipoRendaFormal.TabStop = true;
            this.radioButtonTipoRendaFormal.Text = "Formal";
            this.radioButtonTipoRendaFormal.UseVisualStyleBackColor = true;
            // 
            // textBoxValorRenda
            // 
            this.textBoxValorRenda.Location = new System.Drawing.Point(12, 134);
            this.textBoxValorRenda.MaxLength = 100;
            this.textBoxValorRenda.Name = "textBoxValorRenda";
            this.textBoxValorRenda.Size = new System.Drawing.Size(124, 23);
            this.textBoxValorRenda.TabIndex = 2;
            this.textBoxValorRenda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValorRenda_KeyPress);
            // 
            // labelValorRenda
            // 
            this.labelValorRenda.AutoSize = true;
            this.labelValorRenda.Location = new System.Drawing.Point(12, 115);
            this.labelValorRenda.Name = "labelValorRenda";
            this.labelValorRenda.Size = new System.Drawing.Size(88, 15);
            this.labelValorRenda.TabIndex = 1;
            this.labelValorRenda.Text = "Valor da Renda:";
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.buttonCancelar);
            this.panelRodape.Controls.Add(this.buttonSalvar);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 201);
            this.panelRodape.Name = "panelRodape";
            this.panelRodape.Size = new System.Drawing.Size(780, 65);
            this.panelRodape.TabIndex = 0;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(676, 21);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 1;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Location = new System.Drawing.Point(595, 21);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(75, 23);
            this.buttonSalvar.TabIndex = 0;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = true;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // FormEditarRendasPessoa
            // 
            this.AcceptButton = this.buttonSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(780, 266);
            this.Controls.Add(this.panelFundo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditarRendasPessoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Renda";
            this.panelFundo.ResumeLayout(false);
            this.panelEdicao.ResumeLayout(false);
            this.panelEdicao.PerformLayout();
            this.groupBoxTipoRenda.ResumeLayout(false);
            this.groupBoxTipoRenda.PerformLayout();
            this.panelRodape.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFundo;
        private System.Windows.Forms.Panel panelRodape;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Panel panelEdicao;
        private System.Windows.Forms.TextBox textBoxValorRenda;
        private System.Windows.Forms.Label labelValorRenda;
        private System.Windows.Forms.GroupBox groupBoxTipoRenda;
        private System.Windows.Forms.RadioButton radioButtonTipoRendaFormal;
        private System.Windows.Forms.RadioButton radioButtonTipoRendaInformal;
    }
}