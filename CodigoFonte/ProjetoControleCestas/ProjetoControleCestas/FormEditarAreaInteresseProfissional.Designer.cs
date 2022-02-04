
namespace ProjetoControleCestas
{
    partial class FormEditarAreaInteresseProfissional
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
            this.panelEdicao = new System.Windows.Forms.Panel();
            this.textBoxAreaInteresseProfissional = new System.Windows.Forms.TextBox();
            this.labelAreaInteresseProfissional = new System.Windows.Forms.Label();
            this.panelRodape = new System.Windows.Forms.Panel();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.panelEdicao.SuspendLayout();
            this.panelRodape.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEdicao
            // 
            this.panelEdicao.Controls.Add(this.textBoxAreaInteresseProfissional);
            this.panelEdicao.Controls.Add(this.labelAreaInteresseProfissional);
            this.panelEdicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdicao.Location = new System.Drawing.Point(0, 0);
            this.panelEdicao.Name = "panelEdicao";
            this.panelEdicao.Size = new System.Drawing.Size(800, 100);
            this.panelEdicao.TabIndex = 3;
            // 
            // textBoxAreaInteresseProfissional
            // 
            this.textBoxAreaInteresseProfissional.Location = new System.Drawing.Point(13, 39);
            this.textBoxAreaInteresseProfissional.MaxLength = 20;
            this.textBoxAreaInteresseProfissional.Name = "textBoxAreaInteresseProfissional";
            this.textBoxAreaInteresseProfissional.Size = new System.Drawing.Size(359, 23);
            this.textBoxAreaInteresseProfissional.TabIndex = 1;
            // 
            // labelAreaInteresseProfissional
            // 
            this.labelAreaInteresseProfissional.AutoSize = true;
            this.labelAreaInteresseProfissional.Location = new System.Drawing.Point(13, 20);
            this.labelAreaInteresseProfissional.Name = "labelAreaInteresseProfissional";
            this.labelAreaInteresseProfissional.Size = new System.Drawing.Size(163, 15);
            this.labelAreaInteresseProfissional.TabIndex = 0;
            this.labelAreaInteresseProfissional.Text = "Área de Interesse Profissional:";
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.buttonCancelar);
            this.panelRodape.Controls.Add(this.buttonSalvar);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 100);
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
            // FormEditarAreaInteresseProfissional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 165);
            this.Controls.Add(this.panelEdicao);
            this.Controls.Add(this.panelRodape);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditarAreaInteresseProfissional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Área de Interesse Profissional";
            this.panelEdicao.ResumeLayout(false);
            this.panelEdicao.PerformLayout();
            this.panelRodape.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelEdicao;
        private System.Windows.Forms.TextBox textBoxAreaInteresseProfissional;
        private System.Windows.Forms.Label labelAreaInteresseProfissional;
        private System.Windows.Forms.Panel panelRodape;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonSalvar;
    }
}