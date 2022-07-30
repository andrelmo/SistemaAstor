
namespace ProjetoControleCestas
{
    partial class FormEditarProblemasSaudePessoa
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
            this.textBoxPeriodicidade = new System.Windows.Forms.TextBox();
            this.labelPeriodicidade = new System.Windows.Forms.Label();
            this.textBoxLocal = new System.Windows.Forms.TextBox();
            this.labelLocal = new System.Windows.Forms.Label();
            this.textBoxMedicamento = new System.Windows.Forms.TextBox();
            this.labelMedicamento = new System.Windows.Forms.Label();
            this.textBoxProblema = new System.Windows.Forms.TextBox();
            this.labelProblema = new System.Windows.Forms.Label();
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
            this.panelFundo.Size = new System.Drawing.Size(800, 216);
            this.panelFundo.TabIndex = 0;
            // 
            // panelEdicao
            // 
            this.panelEdicao.Controls.Add(this.textBoxPeriodicidade);
            this.panelEdicao.Controls.Add(this.labelPeriodicidade);
            this.panelEdicao.Controls.Add(this.textBoxLocal);
            this.panelEdicao.Controls.Add(this.labelLocal);
            this.panelEdicao.Controls.Add(this.textBoxMedicamento);
            this.panelEdicao.Controls.Add(this.labelMedicamento);
            this.panelEdicao.Controls.Add(this.textBoxProblema);
            this.panelEdicao.Controls.Add(this.labelProblema);
            this.panelEdicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdicao.Location = new System.Drawing.Point(0, 0);
            this.panelEdicao.Name = "panelEdicao";
            this.panelEdicao.Size = new System.Drawing.Size(800, 151);
            this.panelEdicao.TabIndex = 1;
            // 
            // textBoxPeriodicidade
            // 
            this.textBoxPeriodicidade.Location = new System.Drawing.Point(444, 99);
            this.textBoxPeriodicidade.MaxLength = 45;
            this.textBoxPeriodicidade.Name = "textBoxPeriodicidade";
            this.textBoxPeriodicidade.Size = new System.Drawing.Size(158, 23);
            this.textBoxPeriodicidade.TabIndex = 7;
            // 
            // labelPeriodicidade
            // 
            this.labelPeriodicidade.AutoSize = true;
            this.labelPeriodicidade.Location = new System.Drawing.Point(444, 81);
            this.labelPeriodicidade.Name = "labelPeriodicidade";
            this.labelPeriodicidade.Size = new System.Drawing.Size(82, 15);
            this.labelPeriodicidade.TabIndex = 6;
            this.labelPeriodicidade.Text = "Periodicidade:";
            // 
            // textBoxLocal
            // 
            this.textBoxLocal.Location = new System.Drawing.Point(13, 100);
            this.textBoxLocal.MaxLength = 45;
            this.textBoxLocal.Name = "textBoxLocal";
            this.textBoxLocal.Size = new System.Drawing.Size(359, 23);
            this.textBoxLocal.TabIndex = 5;
            // 
            // labelLocal
            // 
            this.labelLocal.AutoSize = true;
            this.labelLocal.Location = new System.Drawing.Point(13, 81);
            this.labelLocal.Name = "labelLocal";
            this.labelLocal.Size = new System.Drawing.Size(105, 15);
            this.labelLocal.TabIndex = 4;
            this.labelLocal.Text = "Unidade de Saúde:";
            // 
            // textBoxMedicamento
            // 
            this.textBoxMedicamento.Location = new System.Drawing.Point(444, 39);
            this.textBoxMedicamento.MaxLength = 45;
            this.textBoxMedicamento.Name = "textBoxMedicamento";
            this.textBoxMedicamento.Size = new System.Drawing.Size(317, 23);
            this.textBoxMedicamento.TabIndex = 3;
            // 
            // labelMedicamento
            // 
            this.labelMedicamento.AutoSize = true;
            this.labelMedicamento.Location = new System.Drawing.Point(444, 20);
            this.labelMedicamento.Name = "labelMedicamento";
            this.labelMedicamento.Size = new System.Drawing.Size(84, 15);
            this.labelMedicamento.TabIndex = 2;
            this.labelMedicamento.Text = "Medicamento:";
            // 
            // textBoxProblema
            // 
            this.textBoxProblema.Location = new System.Drawing.Point(13, 39);
            this.textBoxProblema.MaxLength = 45;
            this.textBoxProblema.Name = "textBoxProblema";
            this.textBoxProblema.Size = new System.Drawing.Size(359, 23);
            this.textBoxProblema.TabIndex = 1;
            // 
            // labelProblema
            // 
            this.labelProblema.AutoSize = true;
            this.labelProblema.Location = new System.Drawing.Point(13, 20);
            this.labelProblema.Name = "labelProblema";
            this.labelProblema.Size = new System.Drawing.Size(61, 15);
            this.labelProblema.TabIndex = 0;
            this.labelProblema.Text = "Problema:";
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.buttonCancelar);
            this.panelRodape.Controls.Add(this.buttonSalvar);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 151);
            this.panelRodape.Name = "panelRodape";
            this.panelRodape.Size = new System.Drawing.Size(800, 65);
            this.panelRodape.TabIndex = 8;
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
            // FormEditarProblemasSaudePessoa
            // 
            this.AcceptButton = this.buttonSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(800, 216);
            this.Controls.Add(this.panelFundo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditarProblemasSaudePessoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Problema de Saúde";
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
        private System.Windows.Forms.TextBox textBoxProblema;
        private System.Windows.Forms.Label labelProblema;
        private System.Windows.Forms.TextBox textBoxMedicamento;
        private System.Windows.Forms.Label labelMedicamento;
        private System.Windows.Forms.TextBox textBoxLocal;
        private System.Windows.Forms.Label labelLocal;
        private System.Windows.Forms.TextBox textBoxPeriodicidade;
        private System.Windows.Forms.Label labelPeriodicidade;
    }
}