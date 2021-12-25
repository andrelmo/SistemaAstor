
namespace ProjetoControleCestas
{
    partial class FormEditarFaltas
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
            this.textBoxJustificativa = new System.Windows.Forms.TextBox();
            this.labelJustificativa = new System.Windows.Forms.Label();
            this.labelDataFalta = new System.Windows.Forms.Label();
            this.panelRodape = new System.Windows.Forms.Panel();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.dateTimePickerDataFalta = new System.Windows.Forms.DateTimePicker();
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
            this.panelFundo.Size = new System.Drawing.Size(800, 242);
            this.panelFundo.TabIndex = 0;
            // 
            // panelEdicao
            // 
            this.panelEdicao.Controls.Add(this.dateTimePickerDataFalta);
            this.panelEdicao.Controls.Add(this.textBoxJustificativa);
            this.panelEdicao.Controls.Add(this.labelJustificativa);
            this.panelEdicao.Controls.Add(this.labelDataFalta);
            this.panelEdicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdicao.Location = new System.Drawing.Point(0, 0);
            this.panelEdicao.Name = "panelEdicao";
            this.panelEdicao.Size = new System.Drawing.Size(800, 177);
            this.panelEdicao.TabIndex = 1;
            // 
            // textBoxJustificativa
            // 
            this.textBoxJustificativa.Location = new System.Drawing.Point(13, 100);
            this.textBoxJustificativa.MaxLength = 50;
            this.textBoxJustificativa.Name = "textBoxJustificativa";
            this.textBoxJustificativa.Size = new System.Drawing.Size(748, 23);
            this.textBoxJustificativa.TabIndex = 3;
            // 
            // labelJustificativa
            // 
            this.labelJustificativa.AutoSize = true;
            this.labelJustificativa.Location = new System.Drawing.Point(13, 81);
            this.labelJustificativa.Name = "labelJustificativa";
            this.labelJustificativa.Size = new System.Drawing.Size(71, 15);
            this.labelJustificativa.TabIndex = 2;
            this.labelJustificativa.Text = "Justificativa:";
            // 
            // labelDataFalta
            // 
            this.labelDataFalta.AutoSize = true;
            this.labelDataFalta.Location = new System.Drawing.Point(13, 20);
            this.labelDataFalta.Name = "labelDataFalta";
            this.labelDataFalta.Size = new System.Drawing.Size(78, 15);
            this.labelDataFalta.TabIndex = 0;
            this.labelDataFalta.Text = "Data da Falta:";
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.buttonCancelar);
            this.panelRodape.Controls.Add(this.buttonSalvar);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 177);
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
            // dateTimePickerDataFalta
            // 
            this.dateTimePickerDataFalta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataFalta.Location = new System.Drawing.Point(13, 38);
            this.dateTimePickerDataFalta.Name = "dateTimePickerDataFalta";
            this.dateTimePickerDataFalta.Size = new System.Drawing.Size(127, 23);
            this.dateTimePickerDataFalta.TabIndex = 1;
            // 
            // FormEditarFaltas
            // 
            this.AcceptButton = this.buttonSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(800, 242);
            this.Controls.Add(this.panelFundo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditarFaltas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Faltas";
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
        private System.Windows.Forms.Label labelDataFalta;
        private System.Windows.Forms.TextBox textBoxJustificativa;
        private System.Windows.Forms.Label labelJustificativa;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataFalta;
    }
}