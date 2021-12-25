using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using System;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormEditarFaltas : Form
    {
        private readonly IFaltasDal _faltasDal;
        private readonly IAberturaFamiliaDal _aberturaFamiliaDal;
        private readonly ServiceProvider _serviceProvider;
        private FaltasModel _faltasEdicao;
        private bool _desabilitarControles;
        private bool _alterandoRegistro;
        private int _codigoFaltasAtual;
        private int _codigoAberturaFamiliaAtual;

        public FormEditarFaltas(int codigoAberturaFamilia, int codigoFaltas = -1)
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._faltasDal = this._serviceProvider.GetService<IFaltasDal>();
            this._aberturaFamiliaDal = this._serviceProvider.GetService<IAberturaFamiliaDal>();
            this._desabilitarControles = false;
            this._codigoFaltasAtual = codigoFaltas;
            this._codigoAberturaFamiliaAtual = codigoAberturaFamilia;

            if (codigoFaltas != -1)
            {
                this._alterandoRegistro = true;
                this.CarregarFalta(codigoFaltas);
            }
            else
            {
                this._alterandoRegistro = false;
                this.dateTimePickerDataFalta.Value = DateTime.Today;
                this.LimparControles();
            }
        }

        private void CarregarFalta(int codigoFaltas)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Buscar a falta que irá ser editada
                this._faltasEdicao = this._faltasDal.Buscar(codigoFaltas);

                //Verificar se a falta não foi encontrada
                if (this._faltasEdicao == null)
                {
                    MessageBox.Show("A Falta que você quer editar não foi encontrada!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this._desabilitarControles = true;
                    this.LimparControles();
                }
                else
                    this.PreencherControles();

                this.HabilitarControles();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void PreencherControles()
        {
            this.dateTimePickerDataFalta.Value = this._faltasEdicao.DataFalta;
            this.textBoxJustificativa.Text = this._faltasEdicao.Justificativa;
        }

        private void LimparControles()
        {
            this.dateTimePickerDataFalta.Value = DateTime.Today;
            this.textBoxJustificativa.Text = string.Empty;
        }

        private void HabilitarControles()
        {
            var _habilitarControle = !this._desabilitarControles;

            this.dateTimePickerDataFalta.Enabled = _habilitarControle;
            this.textBoxJustificativa.Enabled = _habilitarControle;
        }

        private void buttonSalvar_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Confirma a gravação das informações?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    //Verificar se está sendo feita uma inserção
                    if (!this._alterandoRegistro)
                    {
                        //Realizar a inserção do registro
                        var _faltaCriada = this._faltasDal.Adicionar(this.CriarFaltasModel());

                        MessageBox.Show("Falta Adicionada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Obtém o número total de faltas
                        var _numeroTotalFaltas = this._faltasDal.BuscarTodos(this._codigoAberturaFamiliaAtual).Count;

                        //Verificar se existem pelo menos 3 faltas
                        if (_numeroTotalFaltas >= 3)
                        {
                            //Buscar o cadastro de abertura da família
                            var _registroAberturaFamilia = this._aberturaFamiliaDal.Buscar(this._codigoAberturaFamiliaAtual);

                            //Verificar se o cadastro foi encontrado
                            if (_registroAberturaFamilia != null)
                            {
                                //Atualizar o status do cadastro para Inativo
                                _registroAberturaFamilia.Status = Constantes.ConstantesGlobais.STATUS_ABERTURA_FAMILIA_INATIVO;

                                //Colocar a data de fechamento da o cadastro
                                _registroAberturaFamilia.DataFechamento = DateTime.Now;

                                //Criar a conexão
                                using var _conexao = this._aberturaFamiliaDal.CriarConexao();

                                try
                                {
                                    //Criar a transação
                                    using var _transacao = _conexao.BeginTransaction();

                                    try
                                    {
                                        //Atualizar no Banco de Dados
                                        this._aberturaFamiliaDal.Atualizar(_registroAberturaFamilia, _transacao);

                                        //Confirma a transação
                                        _transacao.Commit();

                                        //Avisar ao usuário
                                        MessageBox.Show("Essa família completou 3 faltas.O seu cadastro de Abertura de Famíla foi Inativado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch (Exception)
                                    {
                                        _transacao.Rollback();
                                        throw;
                                    }
                                }
                                finally
                                {
                                    _conexao.Close(); //Fechar a conexão
                                }
                            }
                        }

                        this.Close();
                    }
                    else
                    {
                        //Realizar a alteração do registro
                        var _faltaAlterado = this._faltasDal.Atualizar(this.CriarFaltasModelAlteracao());

                        MessageBox.Show("Falta Alterada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private FaltasModel CriarFaltasModelAlteracao()
        {
            var _falta = this.CriarFaltasModel();

            _falta.CodigoFaltas = this._codigoFaltasAtual;

            return (_falta);
        }

        private FaltasModel CriarFaltasModel()
        {
            return (new FaltasModel()
            {
                CodigoAberturaFamilia = this._codigoAberturaFamiliaAtual,
                DataFalta = this.dateTimePickerDataFalta.Value,
                Justificativa = this.textBoxJustificativa.Text
            });
        }

        private void buttonCancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}