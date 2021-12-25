using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Enums;
using ProjetoControleCestas.Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormEditarFamilia : Form
    {
        private readonly IFamiliaDal _familiaDal;
        private readonly IUsuarioDal _usuarioDal;
        private readonly IMoradiaDal _moradiaDal;
        private readonly IVisitaDal _visitaDal;
        private readonly IPessoasDal _pessoaDal;
        private readonly IFaltasDal _faltasDal;
        private readonly IAberturaFamiliaDal _aberturaFamiliaDal;
        private readonly ServiceProvider _serviceProvider;
        private FamiliaModel _familiaEdicao;
        private AberturaFamiliaModel _aberturaFamiliaEdicao;
        private bool _desabilitarControles;
        private bool _alterandoRegistro;
        private int _codigoFamiliaoAtual;
        private MoradiaModel _registroAtualMoradia;
        private VisitaModel _registroAtualVisita;
        private PessoasModel _registroAtualPessoa;
        private FaltasModel _registroAtualFaltas;

        public FormEditarFamilia(int codigoFamilia = -1)
        {
            InitializeComponent();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                this.dataGridViewFaltas.AutoGenerateColumns = false;
                this.dataGridViewMoradias.AutoGenerateColumns = false;
                this.dataGridViewPessoas.AutoGenerateColumns = false;
                this.dataGridViewVisitas.AutoGenerateColumns = false;
                this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
                this._familiaDal = this._serviceProvider.GetService<IFamiliaDal>();
                this._usuarioDal = this._serviceProvider.GetService<IUsuarioDal>();
                this._moradiaDal = this._serviceProvider.GetService<IMoradiaDal>();
                this._visitaDal = this._serviceProvider.GetService<IVisitaDal>();
                this._pessoaDal = this._serviceProvider.GetService<IPessoasDal>();
                this._faltasDal = this._serviceProvider.GetService<IFaltasDal>();
                this._aberturaFamiliaDal = this._serviceProvider.GetService<IAberturaFamiliaDal>();
                this._desabilitarControles = false;
                this._codigoFamiliaoAtual = codigoFamilia;
                this.CarregarVoluntarios();

                if (codigoFamilia != -1)
                {
                    this._alterandoRegistro = true;
                    this.CarregarFamilia(codigoFamilia);
                }
                else
                {
                    this._alterandoRegistro = false;
                    this.HabilitarAbas(false);
                    this.LimparControles();
                    this.radioButtonStatusAberturaFamiliaAtivo.Checked = true;
                    this.textBoxDataAbertura.Text = DateTime.Now.ToString(Constantes.ConstantesGlobais.FORMATAR_DATA);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CarregarVoluntarios()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Carregar a lista de voluntários
                var _listaVoluntarios = this._usuarioDal.BuscarTodos(TipoUsuario.Voluntario);

                this.comboBoxVoluntario.DataSource = _listaVoluntarios;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CarregarVisitas()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Carregar a lista de visitas da família atual
                var _listaVisitas = this._visitaDal.BuscarTodos(this._codigoFamiliaoAtual);

                this.dataGridViewVisitas.DataSource = _listaVisitas;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CarregarMoradias()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Carregar a lista de moradias da família atual
                var _listaMoradias = this._moradiaDal.BuscarTodos(this._codigoFamiliaoAtual);

                this.dataGridViewMoradias.DataSource = _listaMoradias;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CarregarPessoas()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Carregar a lista de pessoas
                var _listaPessoas = this._pessoaDal.BuscarTodos(this._codigoFamiliaoAtual);

                this.dataGridViewPessoas.DataSource = _listaPessoas;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CarregarFaltas()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Carregar a lista de Faltas
                var _listaFaltas = this._faltasDal.BuscarTodos(this.GetCodigoAberturaFamilia());

                this.dataGridViewFaltas.DataSource = _listaFaltas;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CarregarFamilia(int codigoFamilia)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Buscar a familia que irá ser editada
                this._familiaEdicao = this._familiaDal.Buscar(codigoFamilia);

                //Verificar se a família não foi encontrado
                if (this._familiaEdicao == null)
                {
                    MessageBox.Show("A Família que você quer editar não foi encontrada!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this._desabilitarControles = true;
                    this.LimparControles();
                }
                else
                {
                    //Buscar as informações da abertura da Familia
                    this._aberturaFamiliaEdicao = this._aberturaFamiliaDal.BuscarPorCodigoFamilia(this._codigoFamiliaoAtual);
                    this.PreencherControles();

                    //Verificar se o cadastro da família está Inativo
                    if (this._aberturaFamiliaEdicao.Status == Constantes.ConstantesGlobais.STATUS_ABERTURA_FAMILIA_INATIVO)
                    {
                        this._desabilitarControles = true;
                        this.HabilitarAbas(false);

                        MessageBox.Show("O Cadastro da Família está Inativado.Você poderá somente visualizar as informãções!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this._desabilitarControles = false;

                        //Habilitar as abas
                        this.HabilitarAbas(true);
                    }
                }

                this.HabilitarControles();

                //Carregar a lista de moradias
                this.CarregarMoradias();

                //Carregar a lista de visitas
                this.CarregarVisitas();

                //Carregar a lista de Pessoas
                this.CarregarPessoas();

                //Carregar a lista de faltas
                this.CarregarFaltas();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void PreencherControles()
        {
            //Preenche os controles da aba de abertura
            this.textBoxDataAbertura.Text = this._aberturaFamiliaEdicao.DataAbertura.ToString(Constantes.ConstantesGlobais.FORMATAR_DATA);

            if (this._aberturaFamiliaEdicao.DataFechamento.HasValue)
                this.textBoxDataFechamento.Text = this._aberturaFamiliaEdicao.DataFechamento.Value.ToString(Constantes.ConstantesGlobais.FORMATAR_DATA);
            else
                this.textBoxDataFechamento.Text = string.Empty;

            this.textBoxCorCesta.Text = this._aberturaFamiliaEdicao.CorCesta;
            this.textBoxObservacao.Text = this._aberturaFamiliaEdicao.Observacao;

            if (this._aberturaFamiliaEdicao.TipoCesta == Constantes.ConstantesGlobais.TIPO_CESTA_1)
                this.radioButtonCestaTipo1.Checked = true;
            else
                this.radioButtonCestaTipo2.Checked = true;

            if (this._aberturaFamiliaEdicao.Status == Constantes.ConstantesGlobais.STATUS_ABERTURA_FAMILIA_ATIVO)
                this.radioButtonStatusAberturaFamiliaAtivo.Checked = true;
            else if (this._aberturaFamiliaEdicao.Status == Constantes.ConstantesGlobais.STATUS_ABERTURA_FAMILIA_INATIVO)
                this.radioButtonStatusAberturaFamilaInativo.Checked = true;
            else
                this.radioButtonStatusAberturaFamiliaCancelado.Checked = true;

            this.comboBoxVoluntario.SelectedValue = this._aberturaFamiliaEdicao.CodVoluntario;

            //Preencher os controles da aba endereco
            this.textBoxTipoLogradouro.Text = this._familiaEdicao.TipoLogradouro;
            this.textBoxLogradouro.Text = this._familiaEdicao.Logradouro;
            this.textBoxNumero.Text = this._familiaEdicao.Numero.ToString();
            this.textBoxComplento.Text = this._familiaEdicao.Complemento;
            this.textBoxBairro.Text = this._familiaEdicao.Bairro;
            this.maskedTextBoxCep.Text = this._familiaEdicao.Cep;
            this.textBoxMunicipio.Text = this._familiaEdicao.Municipio;
            this.textBoxRerefencia.Text = this._familiaEdicao.Referencia;
            this.textBoxOnibus.Text = this._familiaEdicao.Onibus;

            this.CalcularTotaisRecebidosFamilia();

            //Carregar a lista de moradias
            this.CarregarMoradias();

            //Carregar a lista de visitas
            this.CarregarVisitas();

            //Carregar a lista de pessoas
            this.CarregarPessoas();

            //Carregar a lista de faltas
            this.CarregarFaltas();
        }

        private void CalcularTotaisRecebidosFamilia()
        {
            //Exibir o valor Total das rendas da família
            this.textBoxTotalRendas.Text = this._familiaDal.GetTotalRendas(this._codigoFamiliaoAtual).ToString("C");

            //Exibir o valor total dos benefícios da família
            this.textBoxTotalBeneficiosRecebidos.Text = this._familiaDal.GetTotalBeneficiosRecebidos(this._codigoFamiliaoAtual).ToString("C");
        }

        private void LimparControles()
        {
            //Limpar os controles da aba abertura
            this.textBoxDataAbertura.Text = string.Empty;
            this.textBoxDataFechamento.Text = string.Empty;
            this.textBoxCorCesta.Text = string.Empty;
            this.textBoxObservacao.Text = string.Empty;
            this.radioButtonCestaTipo1.Checked = true;
            this.radioButtonStatusAberturaFamiliaAtivo.Checked = true;
            this.comboBoxVoluntario.SelectedIndex = -1;

            //Limpar os controles da aba endereco
            this.textBoxTipoLogradouro.Text = string.Empty;
            this.textBoxLogradouro.Text = string.Empty;
            this.textBoxNumero.Text = string.Empty;
            this.textBoxComplento.Text = string.Empty;
            this.textBoxBairro.Text = string.Empty;
            this.maskedTextBoxCep.Text = string.Empty;
            this.textBoxMunicipio.Text = string.Empty;
            this.textBoxRerefencia.Text = string.Empty;
            this.textBoxOnibus.Text = string.Empty;
        }

        private void HabilitarControles()
        {
            var _habilitarControle = !this._desabilitarControles;

            //Controlar os controles da aba abertura
            this.textBoxCorCesta.Enabled = _habilitarControle;
            this.textBoxObservacao.Enabled = _habilitarControle;
            this.groupBoxTipoCesta.Enabled = _habilitarControle;
            this.comboBoxVoluntario.Enabled = _habilitarControle;

            //Controlar os controles da aba endereco
            this.textBoxTipoLogradouro.Enabled = _habilitarControle;
            this.textBoxLogradouro.Enabled = _habilitarControle;
            this.textBoxNumero.Enabled = _habilitarControle;
            this.textBoxComplento.Enabled = _habilitarControle;
            this.textBoxBairro.Enabled = _habilitarControle;
            this.maskedTextBoxCep.Enabled = _habilitarControle;
            this.textBoxMunicipio.Enabled = _habilitarControle;
            this.textBoxRerefencia.Enabled = _habilitarControle;
            this.textBoxOnibus.Enabled = _habilitarControle;

            //Controlar os controles da aba de moradia
            this.buttonAdicionarMoradia.Enabled = _habilitarControle;
            this.buttonAlterarMoradia.Enabled = _habilitarControle;
            this.buttonExcluirMoradia.Enabled = _habilitarControle;

            //Controlar os controles da aba de visitas
            this.buttonAdicionarVisita.Enabled = _habilitarControle;
            this.buttonAlterarVisita.Enabled = _habilitarControle;
            this.buttonExcluirVisita.Enabled = _habilitarControle;

            //Controlar os controles da aba de pessoas
            this.buttonAdicionarPessoa.Enabled = _habilitarControle;
            this.buttonAlterarPessoa.Enabled = _habilitarControle;
            this.buttonExcluirPessoa.Enabled = _habilitarControle;

            //Controlar os controles da aba de faltas
            this.buttonAdicionarFalta.Enabled = _habilitarControle;
            this.buttonAlterarFalta.Enabled = _habilitarControle;
            this.buttonExcluirPessoa.Enabled = _habilitarControle;
        }

        private void HabilitarAbas(bool habilitar)
        {
            this.panelFundoMoradias.Enabled = habilitar;
            this.panelFundoVisitas.Enabled = habilitar;
            this.panelFundoPessoas.Enabled = habilitar;
            this.panelFundoFaltas.Enabled = habilitar;
        }

        private void buttonSalvar_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Confirma a gravação das informações?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    //Verificar se as informações obrigatórias foram preenchidas
                    if (this.VerificarInformacoesObrigatorias())
                    {
                        //Verificar se está sendo feita uma inserção
                        if (!this._alterandoRegistro)
                        {
                            //Criar a conexão
                            using var _conexao = this._familiaDal.CriarConexao();

                            try
                            {
                                //Criar uma transação
                                using var _transacao = _conexao.BeginTransaction();

                                try
                                {
                                    //Realizar a inserção do registro da familia
                                    var _familiaCriado = this._familiaDal.Adicionar(this.CriarFamiliaModel(), _transacao);

                                    //Guardar o identificador da família que acabou de ser inserida
                                    this._codigoFamiliaoAtual = _familiaCriado.CodFamilia;

                                    //Guardar o objeto de familia
                                    this._familiaEdicao = _familiaCriado;

                                    //Realizar a inserção do registro de abertura de família
                                    var _aberturaFamiliaCriado = this._aberturaFamiliaDal.Adicionar(this.CriarAberturaFamiliaModel(), _transacao);

                                    //Guardar o objeto da abertura de família
                                    this._aberturaFamiliaEdicao = _aberturaFamiliaCriado;

                                    //Confirma a transação
                                    _transacao.Commit();

                                    MessageBox.Show("Família Adicionada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    //Habilitar as abas
                                    this.HabilitarAbas(true);

                                    this._alterandoRegistro = true; //Configura o controle para alteração
                                }
                                catch (Exception)
                                {
                                    _transacao.Rollback(); //Aborta a transação
                                    throw;
                                }
                            }
                            finally
                            {
                                _conexao.Close(); //Fecha a conexão
                            }
                        }
                        else
                        {
                            //Criar a conexão
                            using var _conexao = this._familiaDal.CriarConexao();

                            try
                            {
                                //Criar uma transação
                                using var _transacao = _conexao.BeginTransaction();

                                try
                                {
                                    //Realizar a alteração do registro de família
                                    var _familiaAlterado = this._familiaDal.Atualizar(this.CriarFamiliaModelAlteracao(), _transacao);

                                    //Atualizar a alteraçao do registro de abertura de família
                                    var _aberturaFamiliaAlterado = this._aberturaFamiliaDal.Atualizar(this.CriarAberturaFamiliaModelAlteracao(), _transacao);

                                    //Confirma a transação
                                    _transacao.Commit();

                                    MessageBox.Show("Família Alterada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                catch (Exception)
                                {
                                    _transacao.Rollback(); //Abortar a transação
                                    throw;
                                }
                            }
                            finally
                            {
                                _conexao.Close(); //Fechar a conexão
                            }
                        }
                    }
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private AberturaFamiliaModel CriarAberturaFamiliaModel()
        {
            var _aberturaModel = new AberturaFamiliaModel()
            {
                CodFamilia = this._codigoFamiliaoAtual,
                CodVoluntario = Convert.ToInt32(this.comboBoxVoluntario.SelectedValue),
                CorCesta = this.textBoxCorCesta.Text,
                DataAbertura = Convert.ToDateTime(this.textBoxDataAbertura.Text),
                Observacao = this.textBoxObservacao.Text,
                Status = this.GetStatus(),
                TipoCesta = this.GetTipoCesta()
            };

            return (_aberturaModel);
        }

        private AberturaFamiliaModel CriarAberturaFamiliaModelAlteracao()
        {
            var _aberturaModel = this.CriarAberturaFamiliaModel();

            _aberturaModel.CodigoAberturaFamilia = this._aberturaFamiliaEdicao.CodigoAberturaFamilia;
            _aberturaModel.DataFechamento = this._aberturaFamiliaEdicao.DataFechamento;

            return (_aberturaModel);
        }

        private string GetTipoCesta()
        {
            if (this.radioButtonCestaTipo1.Checked)
                return (Constantes.ConstantesGlobais.TIPO_CESTA_1);

            return (Constantes.ConstantesGlobais.TIPO_CESTA_2);
        }

        private string GetStatus()
        {
            if (this.radioButtonStatusAberturaFamiliaAtivo.Checked)
                return (Constantes.ConstantesGlobais.STATUS_ABERTURA_FAMILIA_ATIVO);
            else if (this.radioButtonStatusAberturaFamilaInativo.Checked)
                return (Constantes.ConstantesGlobais.STATUS_ABERTURA_FAMILIA_INATIVO);
            else
                return (Constantes.ConstantesGlobais.STATUS_ABERTURA_FAMILIA_CANCELADO);
        }

        private FamiliaModel CriarFamiliaModelAlteracao()
        {
            var _familia = this.CriarFamiliaModel();

            _familia.CodFamilia = this._codigoFamiliaoAtual;

            return (_familia);
        }

        private FamiliaModel CriarFamiliaModel()
        {
            var _familia = new FamiliaModel()
            {
                TipoLogradouro = this.textBoxTipoLogradouro.Text,
                Logradouro = this.textBoxLogradouro.Text,
                Bairro = this.textBoxBairro.Text,
                Cep = this.maskedTextBoxCep.Text,
                Complemento = this.textBoxComplento.Text,
                Municipio = this.textBoxMunicipio.Text,
                Onibus = this.textBoxOnibus.Text,
                Referencia = this.textBoxRerefencia.Text
            };

            if (!string.IsNullOrEmpty(this.textBoxNumero.Text))
                _familia.Numero = Convert.ToInt32(this.textBoxNumero.Text);

            return (_familia);
        }

        private bool VerificarInformacoesObrigatorias()
        {
            //Verificar os campos que são obrigatórias da abertura de família
            if (string.IsNullOrEmpty(this.textBoxCorCesta.Text))
            {
                MessageBox.Show("Você deve informar a cor da cesta!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            if (this.comboBoxVoluntario.SelectedIndex == -1)
            {
                MessageBox.Show("Você deve informar o voluntário!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            return (true);
        }

        private void buttonCancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewFaltas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroFaltasGrid(e.RowIndex);
        }

        private void buttonExcluirMoradia_Click(object sender, System.EventArgs e)
        {
            if (this._registroAtualMoradia == null)
                MessageBox.Show("Você deve primeiro selecionar uma linha no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (MessageBox.Show("Confirma a Exclusão?", "Confirma?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;

                    try
                    {
                        //Exclui a moradia
                        this._moradiaDal.Excluir(this._registroAtualMoradia.CodCaracteristicasMoradia);
                        MessageBox.Show("Moradia Excluída!","Atenção",MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Carregar a lista de moradias
                        this.CarregarMoradias();
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void buttonAdicionarMoradia_Click(object sender, System.EventArgs e)
        {
            using var _formMoradia = new FormEditarMoradia(this._codigoFamiliaoAtual);

            try
            {
                _formMoradia.ShowDialog();

                //Carregar a lista de moradias
                this.CarregarMoradias();
            }
            finally
            {
                _formMoradia.Close();
            }
        }

        private void buttonAlterarMoradia_Click(object sender, System.EventArgs e)
        {
            if (this._registroAtualMoradia == null)
                MessageBox.Show("Você deve primeiro selecionar uma linha no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                using var _formMoradia = new FormEditarMoradia(this._codigoFamiliaoAtual, this._registroAtualMoradia.CodCaracteristicasMoradia);

                try
                {
                    _formMoradia.ShowDialog();

                    //Carregar a lista de moradias
                    this.CarregarMoradias();
                }
                finally
                {
                    _formMoradia.Close();
                }
            }
        }

        private void dataGridViewMoradias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroMoradiaGrid(e.RowIndex);
        }

        private void dataGridViewMoradias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroMoradiaGrid(e.RowIndex);
        }

        private void SelecionarRegistroMoradiaGrid(int linha)
        {
            if (linha >= 0)
            {
                //Salva numa variável de memória a moradia selecionada no grid
                var _listaMoradias = (List<MoradiaModel>)this.dataGridViewMoradias.DataSource;

                this._registroAtualMoradia = _listaMoradias[linha];
            }
            else
                this._registroAtualMoradia = null;
        }

        private void SelecionarRegistroVisitaGrid(int linha)
        {
            if (linha >= 0)
            {
                //Salva numa variável em memória a visita selecionada no grid de visitas
                var _listaVisitas = (List<VisitaModel>)this.dataGridViewVisitas.DataSource;

                this._registroAtualVisita = _listaVisitas[linha];
            }
            else
                this._registroAtualVisita = null;
        }

        private void SelecionarRegistroPessoaGrid(int linha)
        {
            if (linha >= 0)
            {
                //Salva numa variável em memória a pessoa selecionada no grid de pessoas
                var _listaPessoas = (List<PessoasModel>)this.dataGridViewPessoas.DataSource;

                this._registroAtualPessoa = _listaPessoas[linha];
            }
            else
                this._registroAtualPessoa = null;
        }

        private void SelecionarRegistroFaltasGrid(int linha)
        {
            if (linha >= 0)
            {
                //Salva numa variável em memória a falta selecionado no grid de faltas
                var _listaFaltas = (List<FaltasModel>)this.dataGridViewFaltas.DataSource;

                this._registroAtualFaltas = _listaFaltas[linha];
            }
            else
                this._registroAtualFaltas = null;
        }

        private void buttonAdicionarVisita_Click(object sender, System.EventArgs e)
        {
            using var _formVisita = new FormEditarVisita(this._codigoFamiliaoAtual);

            try
            {
                _formVisita.ShowDialog();

                //Carregar a lista de visitas
                this.CarregarVisitas();
            }
            finally
            {
                _formVisita.Close();
            }
        }

        private void dataGridViewVisitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroVisitaGrid(e.RowIndex);
        }

        private void dataGridViewVisitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroVisitaGrid(e.RowIndex);
        }

        private void buttonAlterarVisita_Click(object sender, System.EventArgs e)
        {
            if (this._registroAtualVisita == null)
                MessageBox.Show("Você deve primeiro selecionar uma linha no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                using var _formVisita = new FormEditarVisita(this._codigoFamiliaoAtual, this._registroAtualVisita.CodigoVisita);

                try
                {
                    _formVisita.ShowDialog();

                    //Carregar a lista de visitas
                    this.CarregarVisitas();
                }
                finally
                {
                    _formVisita.Close();
                }
            }
        }

        private void buttonExcluirVisita_Click(object sender, System.EventArgs e)
        {
            if (this._registroAtualVisita == null)
                MessageBox.Show("Você deve primeiro selecionar uma linha no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (MessageBox.Show("Confirma a Exclusão?", "Confirma?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;

                    try
                    {
                        //Exclui a visita
                        this._visitaDal.Excluir(this._registroAtualVisita.CodigoVisita);
                        MessageBox.Show("Visita Excluída!","Atenção!",MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Carregar a lista de visitas
                        this.CarregarVisitas();
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void buttonAdicionarPessoa_Click(object sender, System.EventArgs e)
        {
            using var _formPessoa = new FormEditarPessoa(this._codigoFamiliaoAtual);

            try
            {
                _formPessoa.ShowDialog();

                //Carregar a lista de pessoas
                this.CarregarPessoas();

                //Atualizar os totais recebidos pela família
                this.CalcularTotaisRecebidosFamilia();
            }
            finally
            {
                _formPessoa.Close();
            }
        }

        private void buttonAlterarPessoa_Click(object sender, System.EventArgs e)
        {
            if (this._registroAtualPessoa == null)
                MessageBox.Show("Você deve primeiro selecionar uma linha no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                using var _formPessoa = new FormEditarPessoa(this._codigoFamiliaoAtual, this._registroAtualPessoa.CodPessoas);

                try
                {
                    _formPessoa.ShowDialog();

                    //Carregar a lista de pessoas
                    this.CarregarPessoas();

                    //Atualizar os totais recebidos pela família
                    this.CalcularTotaisRecebidosFamilia();
                }
                finally
                {
                    _formPessoa.Close();
                }
            }
        }

        private void dataGridViewPessoas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroPessoaGrid(e.RowIndex);
        }

        private void dataGridViewPessoas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroPessoaGrid(e.RowIndex);
        }

        private void buttonExcluirPessoa_Click(object sender, System.EventArgs e)
        {
            if (this._registroAtualPessoa == null)
                MessageBox.Show("Você deve primeiro selecionar uma linha no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (MessageBox.Show("Confirma a Exclusão?", "Confirma?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;

                    try
                    {
                        //Exclui a pessoa
                        this._pessoaDal.Excluir(this._registroAtualPessoa.CodPessoas);
                        MessageBox.Show("Pessoa Excluída!", "Atenção!",MessageBoxButtons.OK,MessageBoxIcon.Information);

                        //Carregar a lista de pessoas
                        this.CarregarPessoas();

                        //Atualizar os totais recebidos pela família
                        this.CalcularTotaisRecebidosFamilia();
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void dataGridViewFaltas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroFaltasGrid(e.RowIndex);
        }

        private void buttonAdicionarFalta_Click(object sender, System.EventArgs e)
        {
            using var _formFaltas = new FormEditarFaltas(this.GetCodigoAberturaFamilia());

            try
            {
                _formFaltas.ShowDialog();

                //Carregar a lista de faltas
                this.CarregarFaltas();

                //Carregar o registro novamente da família
                this.CarregarFamilia(this._codigoFamiliaoAtual);
            }
            finally
            {
                _formFaltas.Close();
            }
        }

        private int GetCodigoAberturaFamilia()
        {
            //Obtém o código de abertura da família atual
            var _aberturaFamiliaModel = this._aberturaFamiliaDal.BuscarPorCodigoFamilia(this._codigoFamiliaoAtual);

            if (_aberturaFamiliaModel == null)
                throw new Exception("Não foi encontrado nenhuma abertura de Família para a Família Atual!");

            return (_aberturaFamiliaModel.CodigoAberturaFamilia);
        }

        private void buttonAlterarFalta_Click(object sender, EventArgs e)
        {
            if (this._registroAtualFaltas == null)
                MessageBox.Show("Você deve primeiro selecionar uma linha no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                using var _formFaltas = new FormEditarFaltas(this.GetCodigoAberturaFamilia(), this._registroAtualFaltas.CodigoFaltas);

                try
                {
                    _formFaltas.ShowDialog();

                    //Carregar a lista de faltas
                    this.CarregarFaltas();

                    //Carregar o registro novamente da família
                    this.CarregarFamilia(this._codigoFamiliaoAtual);
                }
                finally
                {
                    _formFaltas.Close();
                }
            }
        }

        private void buttonExcluirFalta_Click(object sender, EventArgs e)
        {
            if (this._registroAtualFaltas == null)
                MessageBox.Show("Você deve primeiro selecionar uma linha no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (MessageBox.Show("Confirma a Exclusão?", "Confirma?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;

                    try
                    {
                        //Exclui a falta
                        this._faltasDal.Excluir(this._registroAtualFaltas.CodigoFaltas);
                        MessageBox.Show("Falta Excluída!","Atenção!",MessageBoxButtons.OK,MessageBoxIcon.Information);

                        //Carregar a lista de faltas
                        this.CarregarFaltas();

                        //Carregar o registro novamente da família
                        this.CarregarFamilia(this._codigoFamiliaoAtual);
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