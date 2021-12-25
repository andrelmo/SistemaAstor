using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormListarFamilia : Form
    {
        private readonly IFamiliaDal _familiaDal;
        private readonly ServiceProvider _serviceProvider;
        private FamiliaModel _registroAtual;

        public FormListarFamilia()
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._familiaDal = this._serviceProvider.GetService<IFamiliaDal>();
            this.dataGridViewFamilias.AutoGenerateColumns = false;
            this.CarregarListaFamilias();
        }

        private void CarregarListaFamilias()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                this.dataGridViewFamilias.DataSource = this._familiaDal.BuscarTodos();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            using var _formAdicionar = new FormEditarFamilia();

            try
            {
                _formAdicionar.ShowDialog();
                this.CarregarListaFamilias();
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

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            if (this._registroAtual == null)
                MessageBox.Show("Você deve primeiro selecionar uma linha no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                using var _formUsuario = new FormEditarFamilia(this._registroAtual.CodFamilia);

                try
                {
                    _formUsuario.ShowDialog();
                    this.CarregarListaFamilias();
                }
                finally
                {
                    _formUsuario.Close();
                }
            }
        }

        private void SelecionarRegistroGrid(int linha)
        {
            if (linha >= 0)
            {
                var _listaUsuarios = (List<FamiliaModel>)this.dataGridViewFamilias.DataSource;

                this._registroAtual = _listaUsuarios[linha];
            }
            else
                this._registroAtual = null;
        }

        private void dataGridViewFamilias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGrid(e.RowIndex);
        }

        private void dataGridViewFamilias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGrid(e.RowIndex);
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            if (this._registroAtual == null)
                MessageBox.Show("Você deve primeiro selecionar uma linha no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (MessageBox.Show("Confirma a Exclusão?", "Confirma?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;

                    try
                    {
                        //Realiza a exclusão do registro selecionado no grid
                        var _resultadoExclusao = this._familiaDal.Excluir(this._registroAtual.CodFamilia);

                        if (_resultadoExclusao.IsErro)
                            MessageBox.Show(_resultadoExclusao.MensagemErro, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            if (_resultadoExclusao.IsExcluido)
                            {
                                MessageBox.Show("Família Excluída!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.CarregarListaFamilias();
                            }
                            else
                                MessageBox.Show("Família não foi Excluída!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }
    }
}