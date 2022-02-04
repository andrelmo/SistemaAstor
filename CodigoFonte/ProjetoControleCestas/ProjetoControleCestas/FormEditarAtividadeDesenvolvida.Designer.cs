
namespace ProjetoControleCestas
{
    partial class FormEditarAtividadeDesenvolvida
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
            this.textBoxAtividadeDesenvolvida = new System.Windows.Forms.TextBox();
            this.labelAtividadeDesenvolvida = new System.Windows.Forms.Label();
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
            this.panelFundo.Size = new System.Drawing.Size(800, 165);
            this.panelFundo.TabIndex = 1;
            // 
            // panelEdicao
            // 
            this.panelEdicao.Controls.Add(this.textBoxAtividadeDesenvolvida);
            this.panelEdicao.Controls.Add(this.labelAtividadeDesenvolvida);
            this.panelEdicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdicao.Location = new System.Drawing.Point(0, 0);
            this.panelEdicao.Name = "panelEdicao";
            this.panelEdicao.Size = new System.Drawing.Size(800, 100);
            this.panelEdicao.TabIndex = 1;
            // 
            // textBoxAtividadeDesenvolvida
            // 
            this.textBoxAtividadeDesenvolvida.Location = new System.Drawing.Point(13, 39);
            this.textBoxAtividadeDesenvolvida.MaxLength = 20;
            this.textBoxAtividadeDesenvolvida.Name = "textBoxAtividadeDesenvolvida";
            this.textBoxAtividadeDesenvolvida.Size = new System.Drawing.Size(359, 23);
            this.textBoxAtividadeDesenvolvida.TabIndex = 1;
            // 
            // labelAtividadeDesenvolvida
            // 
            this.labelAtividadeDesenvolvida.AutoSize = true;
            this.labelAtividadeDesenvolvida.Location = new System.Drawing.Point(13, 20);
            this.labelAtividadeDesenvolvida.Name = "labelAtividadeDesenvolvida";
            this.labelAtividadeDesenvolvida.Size = new System.Drawing.Size(133, 15);
            this.labelAtividadeDesenvolvida.TabIndex = 0;
            this.labelAtividadeDesenvolvida.Text = "Atividade Desenvolvida:";
            // 
            // panelRodape
            // 
            this.panelRodape.Controls.Add(this.buttonCancelar);
            this.panelRodape.Controls.Add(this.buttonSalvar);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 100);
            this.panelRodape.Name = "panelRodape";
            this.panelRodape.Size = new System.Drawing.Size(800, 65);
            this.panelRodape.TabIndex = 2;
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
            // FormEditarAtividadeDesenvolvida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 165);
            this.Controls.Add(this.panelFundo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditarAtividadeDesenvolvida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Atividade Desenvolvida";
            this.panelFundo.ResumeLayout(false);
            this.panelEdicao.ResumeLayout(false);
            this.panelEdicao.PerformLayout();
            this.panelRodape.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFundo;
        private System.Windows.Forms.Panel panelEdicao;
        private System.Windows.Forms.TextBox textBoxAtividadeDesenvolvida;
        private System.Windows.Forms.Label labelAtividadeDesenvolvida;
        private System.Windows.Forms.Panel panelRodape;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonSalvar;
    }
}