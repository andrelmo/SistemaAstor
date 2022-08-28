using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormListarAtividadeDesenvolvida : Form
    {
        private readonly IListaAtividadeDesenvolvidaDal _listaAtividadeDesenvolvidaDal;
        private readonly ServiceProvider _serviceProvider;
        private ListaAtividadeDesenvolvidaModel _registroAtual;

        public FormListarAtividadeDesenvolvida()
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._listaAtividadeDesenvolvidaDal = this._serviceProvider.GetService<IListaAtividadeDesenvolvidaDal>();
            this.dataGridViewTipoBeneficios.AutoGenerateColumns = false;
            this.CarregarListaAtividadeDesenvolvida();
        }

        private void CarregarListaAtividadeDesenvolvida()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                this.dataGridViewTipoBeneficios.DataSource = this._listaAtividadeDesenvolvidaDal.BuscarTodos();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            using var _formAdicionar = new FormEditarListaAtividadeDesenvolvida();

            try
            {
                _formAdicionar.ShowDialog();
                this.CarregarListaAtividadeDesenvolvida();
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
                using var _formUsuario = new FormEditarListaAtividadeDesenvolvida(this._registroAtual.CodAtividadeDesenvolvida);

                try
                {
                    _formUsuario.ShowDialog();
                    this.CarregarListaAtividadeDesenvolvida();
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
                        var _resultadoExclusao = this._listaAtividadeDesenvolvidaDal.Excluir(this._registroAtual.CodAtividadeDesenvolvida);

                        if (_resultadoExclusao.IsErro)
                            MessageBox.Show(_resultadoExclusao.MensagemErro, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            if (_resultadoExclusao.IsExcluido)
                            {
                                MessageBox.Show("Lista de Atividade Desenvolvida Excluída!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.CarregarListaAtividadeDesenvolvida();
                            }
                            else
                                MessageBox.Show("Lista de Atividade Desenvolvida não foi Excluída!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                var _listaUsuarios = (List<ListaAtividadeDesenvolvidaModel>)this.dataGridViewTipoBeneficios.DataSource;

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