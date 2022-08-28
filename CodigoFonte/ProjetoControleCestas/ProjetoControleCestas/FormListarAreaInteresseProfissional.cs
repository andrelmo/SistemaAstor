using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormListarAreaInteresseProfissional : Form
    {
        private readonly IListaAreaInteresseProfissionalDal _listaAreaInteresseProfissinalDal;
        private readonly ServiceProvider _serviceProvider;
        private ListaAreaInteresseProfissionalModel _registroAtual;

        public FormListarAreaInteresseProfissional()
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._listaAreaInteresseProfissinalDal = this._serviceProvider.GetService<IListaAreaInteresseProfissionalDal>();
            this.dataGridViewTipoBeneficios.AutoGenerateColumns = false;
            this.CarregarListaAreaInteresseProfissinal();
        }

        private void CarregarListaAreaInteresseProfissinal()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                this.dataGridViewTipoBeneficios.DataSource = this._listaAreaInteresseProfissinalDal.BuscarTodos();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            using var _formAdicionar = new FormEditarListaAreaInteresseProfissional();

            try
            {
                _formAdicionar.ShowDialog();
                this.CarregarListaAreaInteresseProfissinal();
            }
            finally
            {
                _formAdicionar.Close();
            }
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            if (this._registroAtual == null)
                MessageBox.Show("Você deve primeiro selecionar uma linha no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                using var _formUsuario = new FormEditarListaAreaInteresseProfissional(this._registroAtual.CodAreaInteresseProfissional);

                try
                {
                    _formUsuario.ShowDialog();
                    this.CarregarListaAreaInteresseProfissinal();
                }
                finally
                {
                    _formUsuario.Close();
                }
            }
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
                        var _resultadoExclusao = this._listaAreaInteresseProfissinalDal.Excluir(this._registroAtual.CodAreaInteresseProfissional);

                        if (_resultadoExclusao.IsErro)
                            MessageBox.Show(_resultadoExclusao.MensagemErro, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            if (_resultadoExclusao.IsExcluido)
                            {
                                MessageBox.Show("Lista de Área de Interesse Profissinal Excluída!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.CarregarListaAreaInteresseProfissinal();
                            }
                            else
                                MessageBox.Show("Lista de Área de Interessse Profissinal não foi Excluída!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void buttonFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelecionarRegistroGrid(int linha)
        {
            if (linha >= 0)
            {
                var _listaUsuarios = (List<ListaAreaInteresseProfissionalModel>)this.dataGridViewTipoBeneficios.DataSource;

                this._registroAtual = _listaUsuarios[linha];
            }
            else
                this._registroAtual = null;
        }

        private void dataGridViewTipoBeneficios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGrid(e.RowIndex);
        }

        private void dataGridViewTipoBeneficios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGrid(e.RowIndex);
        }
    }
}