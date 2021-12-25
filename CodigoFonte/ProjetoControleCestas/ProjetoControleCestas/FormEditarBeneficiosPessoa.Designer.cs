
namespace ProjetoControleCestas
{
    partial class FormEditarBeneficiosPessoa
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
            this.comboBoxTipoBeneficio = new System.Windows.Forms.ComboBox();
            this.textBoxValorBeneficio = new System.Windows.Forms.TextBox();
            this.labelValorBeneficio = new System.Windows.Forms.Label();
            this.labelTipoBeneficio = new System.Windows.Forms.Label();
            this.panelRodape = new System.Windows.Forms.Panel();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.panelFundo.SuspendLayout();
            this.panelEdicao.SuspendLayout();
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
            this.panelFundo.Size = new System.Drawing.Size(800, 162);
            this.panelFundo.TabIndex = 0;
            // 
            // panelEdicao
            // 
            this.panelEdicao.Controls.Add(this.comboBoxTipoBeneficio);
            this.panelEdicao.Controls.Add(this.textBoxValorBeneficio);
            this.panelEdicao.Controls.Add(this.labelValorBeneficio);
            this.panelEdicao.Controls.Add(this.labelTipoBeneficio);
            this.panelEdicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdicao.Location = new System.Drawing.Point(0, 0);
            this.panelEdicao.Name = "panelEdicao";
            this.panelEdicao.Size = new System.Drawing.Size(800, 97);
            this.panelEdicao.TabIndex = 1;
            // 
            // comboBoxTipoBeneficio
            // 
            this.comboBoxTipoBeneficio.DisplayMember = "Beneficio";
            this.comboBoxTipoBeneficio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoBeneficio.FormattingEnabled = true;
            this.comboBoxTipoBeneficio.Location = new System.Drawing.Point(13, 38);
            this.comboBoxTipoBeneficio.Name = "comboBoxTipoBeneficio";
            this.comboBoxTipoBeneficio.Size = new System.Drawing.Size(398, 23);
            this.comboBoxTipoBeneficio.TabIndex = 1;
            this.comboBoxTipoBeneficio.ValueMember = "CodTipoBeneficio";
            // 
            // textBoxValorBeneficio
            // 
            this.textBoxValorBeneficio.Location = new System.Drawing.Point(444, 39);
            this.textBoxValorBeneficio.MaxLength = 10;
            this.textBoxValorBeneficio.Name = "textBoxValorBeneficio";
            this.textBoxValorBeneficio.Size = new System.Drawing.Size(121, 23);
            this.textBoxValorBeneficio.TabIndex = 3;
            this.textBoxValorBeneficio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValorBeneficio_KeyPress);
            // 
            // labelValorBeneficio
            // 
            this.labelValorBeneficio.AutoSize = true;
            this.labelValorBeneficio.Location = new System.Drawing.Point(444, 20);
            this.labelValorBeneficio.Name = "labelValorBeneficio";
            this.labelValorBeneficio.Size = new System.Drawing.Size(36, 15);
            this.labelValorBeneficio.TabIndex = 2;
            this.labelValorBeneficio.Text = "Valor:";
            // 
            // labelTipoBeneficio
            // 
            this.labelTipoBeneficio.AutoSize = true;
            this.labelTipoBeneficio.Location = new System.Drawing.Point(13, 20);
            this.labelTipoBeneficio.Name = "labelTipoBeneficio";
            this.labelTipoBeneficio.Size = new System.Drawing.Size(101, 15);
            this.labelTipoBeneficio.TabIndex = 0;
            this.labelTipoBeneficio.Text = "Tipo de Benefício:";
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.buttonCancelar);
            this.panelRodape.Controls.Add(this.buttonSalvar);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 97);
            this.panelRodape.Name = "panelRodape";
            this.panelRodape.Size = new System.Drawing.Size(800, 65);
            this.panelRodape.TabIndex = 4;
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
            // FormEditarBeneficiosPessoa
            // 
            this.AcceptButton = this.buttonSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(800, 162);
            this.Controls.Add(this.panelFundo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditarBeneficiosPessoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Benefício";
            this.panelFundo.ResumeLayout(false);
            this.panelEdicao.ResumeLayout(false);
            this.panelEdicao.PerformLayout();
            this.panelRodape.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFundo;
        private System.Windows.Forms.Panel panelRodape;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Panel panelEdicao;
        private System.Windows.Forms.Label labelTipoBeneficio;
        private System.Windows.Forms.TextBox textBoxValorBeneficio;
        private System.Windows.Forms.Label labelValorBeneficio;
        private System.Windows.Forms.ComboBox comboBoxTipoBeneficio;
    }
}