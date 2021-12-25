using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormListarTipoBeneficios : Form
    {
        private readonly ITipoBeneficioDAl _tipoBeneficioDal;
        private readonly ServiceProvider _serviceProvider;
        private TipoBeneficioModel _registroAtual;

        public FormListarTipoBeneficios()
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._tipoBeneficioDal = this._serviceProvider.GetService<ITipoBeneficioDAl>();
            this.dataGridViewTipoBeneficios.AutoGenerateColumns = false;
            this.CarregarListaTipoBeneficios();
        }

        private void CarregarListaTipoBeneficios()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                this.dataGridViewTipoBeneficios.DataSource = this._tipoBeneficioDal.BuscarTodos();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            using var _formAdicionar = new FormEditarTipoBeneficio();

            try
            {
                _formAdicionar.ShowDialog();
                this.CarregarListaTipoBeneficios();
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
                using var _formUsuario = new FormEditarTipoBeneficio(this._registroAtual.CodTipoBeneficio);

                try
                {
                    _formUsuario.ShowDialog();
                    this.CarregarListaTipoBeneficios();
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
                var _listaUsuarios = (List<TipoBeneficioModel>)this.dataGridViewTipoBeneficios.DataSource;

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
                        var _resultadoExclusao = this._tipoBeneficioDal.Excluir(this._registroAtual.CodTipoBeneficio);

                        if (_resultadoExclusao.IsErro)
                            MessageBox.Show(_resultadoExclusao.MensagemErro, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            if (_resultadoExclusao.IsExcluido)
                            {
                                MessageBox.Show("Tipo de Benefício Excluído!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.CarregarListaTipoBeneficios();
                            }
                            else
                                MessageBox.Show("Tipo de Benefício não foi Excluído!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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