using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormListarUsuario : Form
    {
        private readonly IUsuarioDal _usurioDal;
        private readonly ServiceProvider _serviceProvider;
        private UsuarioModel _registroAtual;

        public FormListarUsuario()
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._usurioDal = this._serviceProvider.GetService<IUsuarioDal>();
            this.dataGridViewUsuarios.AutoGenerateColumns = false;
            this.CarregarListaUsuarios();
        }

        private void CarregarListaUsuarios()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                this.dataGridViewUsuarios.DataSource = this._usurioDal.BuscarTodos();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            using var _formAdicionar = new FormEditarUsuario();

            try
            {
                _formAdicionar.ShowDialog();
                this.CarregarListaUsuarios();
            }
            finally
            {
                _formAdicionar.Close();
            }
        }

        private void buttonFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGrid(e.RowIndex);
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            if (this._registroAtual == null)
                MessageBox.Show("Você deve primeiro selecionar uma linha no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                using var _formUsuario = new FormEditarUsuario(this._registroAtual.CodigoUsuario);

                try
                {
                    _formUsuario.ShowDialog();
                    this.CarregarListaUsuarios();
                }
                finally
                {
                    _formUsuario.Close();
                }
            }
        }

        private void dataGridViewUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGrid(e.RowIndex);
        }

        private void SelecionarRegistroGrid(int linha)
        {
            if (linha >= 0)
            {
                var _listaUsuarios = (List<UsuarioModel>)this.dataGridViewUsuarios.DataSource;

                this._registroAtual = _listaUsuarios[linha];
            }
            else
                this._registroAtual = null;
        }
    }
}