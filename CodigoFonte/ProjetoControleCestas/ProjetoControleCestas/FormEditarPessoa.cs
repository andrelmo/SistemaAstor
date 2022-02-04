using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Enums;
using ProjetoControleCestas.Modelo;
using ProjetoControleCestas.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormEditarPessoa : Form
    {
        private readonly IPessoasDal _pessoaDal;
        private readonly IProblemaSaudeDal _problemaSaudeDal;
        private readonly IDeficienciaDal _deficienciaDal;
        private readonly IBeneficioDal _beneficioDal;
        private readonly IRendaDal _rendaDal;
        private readonly IDocumentosDal _documentosDal;
        private readonly IAreaInteresseProfissionalDal _areaInteresseProfissionalDal;
        private readonly IAtividadeDesenvolvidaDal _atividadeDesenvolvidaDal;
        private readonly ServiceProvider _serviceProvider;
        private PessoasModel _pessoaEdicao;
        private bool _desabilitarControles;
        private bool _alterandoRegistro;
        private int _codigoPessoaAtual;
        private int _codigoFamiliaAtual;
        private ProblemaSaudeModel _registroAtualProblemaSaude;
        private DeficienciaModel _registroAtualDeficiencia;
        private BeneficioModel _registroAtualBeneficio;
        private RendaModel _registroAtualRenda;
        private DocumentosModel _registroAtualDocumento;
        private AreaInteresseProfissionalModel _registroAtualAreInteresseProfissional;
        private AtividadeDesenvolvidaModel _registroAtualAtividadeDesenvolvida;

        public FormEditarPessoa(int codigoFamiliaAtual, int codigoPessoa = -1)
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._pessoaDal = this._serviceProvider.GetService<IPessoasDal>();
            this._problemaSaudeDal = this._serviceProvider.GetService<IProblemaSaudeDal>();
            this._deficienciaDal = this._serviceProvider.GetService<IDeficienciaDal>();
            this._beneficioDal = this._serviceProvider.GetService<IBeneficioDal>();
            this._rendaDal = this._serviceProvider.GetService<IRendaDal>();
            this._documentosDal = this._serviceProvider.GetService<IDocumentosDal>();
            this._areaInteresseProfissionalDal = this._serviceProvider.GetService<IAreaInteresseProfissionalDal>();
            this._atividadeDesenvolvidaDal = this._serviceProvider.GetService<IAtividadeDesenvolvidaDal>();
            this._desabilitarControles = false;
            this._codigoFamiliaAtual = codigoFamiliaAtual;
            this._codigoPessoaAtual = codigoPessoa;
            this.dataGridViewProblemasSaude.AutoGenerateColumns = false;
            this.dataGridViewDeficiencias.AutoGenerateColumns = false;
            this.dataGridViewBeneficios.AutoGenerateColumns = false;
            this.dataGridViewRendas.AutoGenerateColumns = false;
            this.dataGridViewDocumentos.AutoGenerateColumns = false;
            this.dataGridViewAreaInteresseProfissional.AutoGenerateColumns = false;
            this.dataGridViewAtividadesDesenvolvidas.AutoGenerateColumns = false;

            if (codigoPessoa != -1)
            {
                this._alterandoRegistro = true;
                this.CarregarPessoa(codigoPessoa);
            }
            else
            {
                this._alterandoRegistro = false;
                this.LimparControles();
                this.HabilitarAbas(false);
            }
        }

        private void HabilitarAbas(bool habilitar)
        {
            this.panelFundoProblemasSaude.Enabled = habilitar;
            this.panelFundoDeficiencia.Enabled = habilitar;
            this.panelFundoBeneficios.Enabled = habilitar;
            this.panelFundoRendas.Enabled = habilitar;
            this.panelFundoDocumentos.Enabled = habilitar;
        }

        private void CarregarPessoa(int codigoPessoa)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                this._codigoPessoaAtual = codigoPessoa;

                //Buscar a pessoa que irá ser editada
                this._pessoaEdicao = this._pessoaDal.Buscar(codigoPessoa);

                //Verificar se a pessoa não foi encontrado
                if (this._pessoaEdicao == null)
                {
                    MessageBox.Show("A Pessoa que você quer editar não foi encontrada!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this._desabilitarControles = true;
                    this.LimparControles();
                }
                else
                {
                    this.PreencherControles();
                    this.HabilitarAbas(true);
                }

                this.HabilitarControles();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void PreencherControles()
        {
            this.textBoxNome.Text = this._pessoaEdicao.Nome;
            this.textBoxIdentidade.Text = this._pessoaEdicao.Identidade;
            this.maskedTextBoxCpf.Text = this._pessoaEdicao.Cpf;
            this.textBoxEscolaridade.Text = this._pessoaEdicao.Escolaridade;
            this.textBoxNomeMae.Text = this._pessoaEdicao.NomeMae;
            this.textBoxNomePai.Text = this._pessoaEdicao.NomePai;
            this.textBoxParentesco.Text = this._pessoaEdicao.Parentesco;
            this.textBoxNaturalidade.Text = this._pessoaEdicao.Naturalidade;
            this._desabilitarControles = false;

            //Verificar a situação civil da pessoa
            if (this._pessoaEdicao.SituacaoCivil == SituacaoCivil.Casada)
                this.radioButtonSituacaoCivilCasada.Checked = true;
            else if (this._pessoaEdicao.SituacaoCivil == SituacaoCivil.Divorciada)
                this.radioButtonSituacaoCivilDivorciada.Checked = true;
            else if (this._pessoaEdicao.SituacaoCivil == SituacaoCivil.Separada)
                this.radioButtonSituacaoCivilSeparada.Checked = true;
            else if (this._pessoaEdicao.SituacaoCivil == SituacaoCivil.Solteira)
                this.radioButtonSituacaoCivilSolteira.Checked = true;
            else if (this._pessoaEdicao.SituacaoCivil == SituacaoCivil.UniaoEstavel)
                this.radioButtonSituacaoCivilUniaoEstavel.Checked = true;
            else
                this.radioButtonSituacaoCivilViuva.Checked = true;

            //Verificar se a pessoa tem deficiência
            if (this._pessoaEdicao.Deficiencia.ToUpper() == Constantes.ConstantesGlobais.SIM)
                this.radioButtonDeficienciaSim.Checked = true;
            else
                this.radioButtonDeficienciaNao.Checked = true;

            //Verificar se a pessoa tem problema de saúde
            if (this._pessoaEdicao.ProblemaSaude.ToUpper() == Constantes.ConstantesGlobais.SIM)
                this.radioButtonProblemaSaudeSim.Checked = true;
            else
                this.radioButtonProblemaSaudeNao.Checked = true;

            //Verificar se a pessoa é um idoso
            if (this._pessoaEdicao.Idoso == Constantes.ConstantesGlobais.VERDADEIRO)
                this.radioButtonIdosoSim.Checked = true;
            else
                this.radioButtonIdosoNao.Checked = true;

            //Verifica o sexo da pessoa
            if (this._pessoaEdicao.Sexo == Constantes.ConstantesGlobais.SEXO_FEMININO)
                this.radioButtonSexoFeminino.Checked = true;
            else
                this.radioButtonSexoMasculino.Checked = true;

            //Verificar o vinculo familiar
            if (this._pessoaEdicao.VinculoFamiliar == VinculoFamiliar.Dependente)
                this.radioButtonVinculoFamiliarDependente.Checked = true;
            else
                this.radioButtonVinculoFamiliarResponsavel.Checked = true;

            //Verificar se a pessoa é o responsável da família
            if (_pessoaEdicao.IsResponsavelFamilia)
                this.checkBoxResponsavelFamilia.Checked = true;
            else
                this.checkBoxResponsavelFamilia.Checked = false;

            //Carregar a lista de problemas de saúde
            this.CarregarProblemasSaude(this._codigoPessoaAtual);

            //Carregar a lista de deficiências
            this.CarregarDeficiencias(this._codigoPessoaAtual);

            //Carregar a lista de benefícios
            this.CarregarBeneficios(this._codigoPessoaAtual);

            //Carregar a lista de rendas
            this.CarregarRendas(this._codigoPessoaAtual);

            //Carregar a lista de documentos
            this.CarregarDocumentos(this._codigoPessoaAtual);

            //Carregar a lista de áreas de interesse profissional
            this.CarregarAreasInteresseProfissional(this._codigoPessoaAtual);

            //Carregar a lista de atividades desenvolvidas
            this.CarregarAtividadesDesenvolvidas(this._codigoPessoaAtual);
        }

        private void CarregarDocumentos(int codigoPessoa)
        {
            //Carregar a lista de documentos da pessoa

            this.Cursor = Cursors.WaitCursor;

            try
            {
                var _listaDocumentos = this._documentosDal.BuscarTodos(codigoPessoa);

                this.dataGridViewDocumentos.DataSource = _listaDocumentos;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CarregarAreasInteresseProfissional(int codigoPessoa)
        {
            //Carregar a lista de áreas de interesse profissional da pessoa

            this.Cursor = Cursors.WaitCursor;

            try
            {
                var _listaAreas = this._areaInteresseProfissionalDal.BuscarTodos(codigoPessoa);

                this.dataGridViewAreaInteresseProfissional.DataSource = _listaAreas;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CarregarAtividadesDesenvolvidas(int codigoPessoa)
        {
            //Carregar a lista de atividades desenvolvidas da pessoa

            this.Cursor = Cursors.WaitCursor;

            try
            {
                var _listaAtividades = this._atividadeDesenvolvidaDal.BuscarTodos(codigoPessoa);

                this.dataGridViewAtividadesDesenvolvidas.DataSource = _listaAtividades;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CarregarRendas(int codigoPessoa)
        {
            //Carregar a lista de rendas da pessoa

            this.Cursor = Cursors.WaitCursor;

            try
            {
                var _listaRendas = this._rendaDal.BuscarTodos(codigoPessoa);

                this.dataGridViewRendas.DataSource = _listaRendas;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CarregarBeneficios(int codigoPessoa)
        {
            //Carregar a lista de benefícios da pessoa

            this.Cursor = Cursors.WaitCursor;

            try
            {
                var _listaBeneficios = this._beneficioDal.BuscarBeneficios(codigoPessoa);

                this.dataGridViewBeneficios.DataSource = _listaBeneficios;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CarregarDeficiencias(int codigoPessoa)
        {
            //Carregar a lista de deficiências da pessoa

            this.Cursor = Cursors.WaitCursor;

            try
            {
                var _listaDeficiencias = this._deficienciaDal.BuscarTodos(codigoPessoa);

                this.dataGridViewDeficiencias.DataSource = _listaDeficiencias;
            }
            finally
            {
                this.Cursor = Cursors.Default;                
            }
        }

        private void CarregarProblemasSaude(int codigoPessoa)
        {
            //Carregar a lista de problemas de saúde da pessoa

            this.Cursor = Cursors.WaitCursor;

            try
            {
                var _listaProblemas = this._problemaSaudeDal.BuscarTodos(codigoPessoa);

                this.dataGridViewProblemasSaude.DataSource = _listaProblemas;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void LimparControles()
        {
            this.textBoxNome.Text = string.Empty;
            this.textBoxIdentidade.Text = string.Empty;
            this.maskedTextBoxCpf.Text = string.Empty;
            this.textBoxEscolaridade.Text = string.Empty;
            this.textBoxNomeMae.Text = string.Empty;
            this.textBoxNomePai.Text = string.Empty;
            this.textBoxParentesco.Text = string.Empty;
            this.textBoxNaturalidade.Text = string.Empty;
            this.radioButtonSituacaoCivilSolteira.Checked = true;
            this.radioButtonDeficienciaNao.Checked = true;
            this.radioButtonProblemaSaudeNao.Checked = true;
            this.radioButtonIdosoNao.Checked = true;
            this.radioButtonSexoMasculino.Checked = true;
            this.radioButtonVinculoFamiliarDependente.Checked = true;
            this.checkBoxResponsavelFamilia.Checked = false;
        }

        private void HabilitarControles()
        {
            var _habilitarControle = !this._desabilitarControles;

            this.textBoxNome.Enabled = _habilitarControle;
            this.textBoxIdentidade.Enabled = _habilitarControle;
            this.maskedTextBoxCpf.Enabled = _habilitarControle;
            this.textBoxEscolaridade.Enabled = _habilitarControle;
            this.textBoxNomeMae.Enabled = _habilitarControle;
            this.textBoxNomePai.Enabled = _habilitarControle;
            this.textBoxParentesco.Enabled = _habilitarControle;
            this.textBoxNaturalidade.Enabled = _habilitarControle;
            this.groupBoxSituacaoCivil.Enabled = _habilitarControle;
            this.groupBoxDeficiencia.Enabled = _habilitarControle;
            this.groupBoxProblemaSaude.Enabled = _habilitarControle;
            this.groupBoxIdoso.Enabled = _habilitarControle;
            this.groupBoxSexo.Enabled = _habilitarControle;
            this.groupBoxVinculoFamiliar.Enabled = _habilitarControle;
            this.checkBoxResponsavelFamilia.Enabled = _habilitarControle;
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
                        //Verificar se o CPF informado é válido
                        
                        if (!string.IsNullOrEmpty(this.maskedTextBoxCpf.Text))
                        {
                            //Verificar se está sendo feita uma inserção
                            if (!ValidaCPF.IsCpf(this.maskedTextBoxCpf.Text))
                            {
                                MessageBox.Show("O CPF informado não é válido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                return;
                            }
                        }

                        if (!this._alterandoRegistro)
                        {
                            //Realizar a inserção do registro
                            var _pessoaCriado = this._pessoaDal.Adicionar(this.CriarPessoaModel());

                            MessageBox.Show("Pessoa Adicionada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Recarrega novamente a pessoa para atualizar os controles de abas
                            this.CarregarPessoa(_pessoaCriado.CodPessoas);

                            this._alterandoRegistro = true; //Altera a váriavel de controle para indicar uma alteração
                        }
                        else
                        {
                            //Realizar a alteração do registro
                            var _pessoaAlterado = this._pessoaDal.Atualizar(this.CriarPessoaModelAlteracao());

                            MessageBox.Show("Pessoa Alterada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private PessoasModel CriarPessoaModelAlteracao()
        {
            var _pessoa = this.CriarPessoaModel();

            _pessoa.CodPessoas = this._codigoPessoaAtual;

            return (_pessoa);
        }

        private PessoasModel CriarPessoaModel()
        {
            return (new PessoasModel()
            {
                CodFamilia = this._codigoFamiliaAtual,
                Cpf = this.maskedTextBoxCpf.Text,
                Escolaridade = this.textBoxEscolaridade.Text,
                Identidade = this.textBoxIdentidade.Text,
                Naturalidade = this.textBoxNaturalidade.Text,
                Nome = this.textBoxNome.Text,
                NomeMae = this.textBoxNomeMae.Text,
                NomePai = this.textBoxNomePai.Text,
                Parentesco = this.textBoxParentesco.Text,
                Sexo = this.GetTextoSexo(),
                SituacaoCivil = this.GetSituacaoCivil(),
                Idoso = this.GetIdoso(),
                VinculoFamiliar = this.GetVinculoFamiliar(),
                Deficiencia = this.GetTextoDeficiencia(),
                ProblemaSaude = this.GetProblemaSaude(),
                IsResponsavelFamilia = this.checkBoxResponsavelFamilia.Checked
            });
        }

        private string GetTextoDeficiencia()
        {
            if (this.radioButtonDeficienciaSim.Checked)
                return (Constantes.ConstantesGlobais.SIM);

            return (Constantes.ConstantesGlobais.NAO);
        }

        private VinculoFamiliar GetVinculoFamiliar()
        {
            if (this.radioButtonVinculoFamiliarDependente.Checked)
                return (VinculoFamiliar.Dependente);

            return (VinculoFamiliar.Responsavel);
        }

        private byte GetIdoso()
        {
            if (this.radioButtonIdosoSim.Checked)
                return (Constantes.ConstantesGlobais.VERDADEIRO);

            return (Constantes.ConstantesGlobais.FALSO);
        }

        private SituacaoCivil GetSituacaoCivil()
        {
            if (this.radioButtonSituacaoCivilSolteira.Checked)
                return (SituacaoCivil.Solteira);
            else if (this.radioButtonSituacaoCivilCasada.Checked)
                return (SituacaoCivil.Casada);
            else if (this.radioButtonSituacaoCivilViuva.Checked)
                return (SituacaoCivil.Viuva);
            else if (this.radioButtonSituacaoCivilDivorciada.Checked)
                return (SituacaoCivil.Divorciada);
            else if (this.radioButtonSituacaoCivilSeparada.Checked)
                return (SituacaoCivil.Separada);
            else
                return (SituacaoCivil.UniaoEstavel);
        }

        private string GetTextoSexo()
        {
            if (this.radioButtonSexoMasculino.Checked)
                return (Constantes.ConstantesGlobais.SEXO_MASCULINO);

            return (Constantes.ConstantesGlobais.SEXO_FEMININO);
        }

        private string GetProblemaSaude()
        {
            if (this.radioButtonProblemaSaudeSim.Checked)
                return (Constantes.ConstantesGlobais.SIM);

            return (Constantes.ConstantesGlobais.NAO);
        }

        private bool VerificarInformacoesObrigatorias()
        {
            if (string.IsNullOrEmpty(this.textBoxNome.Text))
            {
                MessageBox.Show("Você deve informar o nome!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            return (true);
        }

        private void buttonCancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewProblemasSaude_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGridProblemaSaude(e.RowIndex);
        }

        private void dataGridViewProblemasSaude_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGridProblemaSaude(e.RowIndex);
        }

        private void SelecionarRegistroGridProblemaSaude(int linha)
        {
            if (linha >= 0)
            {
                var _listaProblemas = (List<ProblemaSaudeModel>)this.dataGridViewProblemasSaude.DataSource;

                this._registroAtualProblemaSaude = _listaProblemas[linha];
            }
            else
                this._registroAtualProblemaSaude = null;
        }

        private void SelecionarRegistroGridDeficiencia(int linha)
        {
            if (linha >= 0)
            {
                var _listaDeficiencias = (List<DeficienciaModel>)this.dataGridViewDeficiencias.DataSource;

                this._registroAtualDeficiencia = _listaDeficiencias[linha];
            }
            else
                this._registroAtualDeficiencia = null;
        }

        private void dataGridViewDeficiencias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGridDeficiencia(e.RowIndex);
        }

        private void dataGridViewDeficiencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGridDeficiencia(e.RowIndex);
        }

        private void dataGridViewBeneficios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGridBeneficio(e.RowIndex);
        }

        private void dataGridViewBeneficios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGridBeneficio(e.RowIndex);
        }

        private void SelecionarRegistroGridBeneficio(int linha)
        {
            if (linha >= 0)
            {
                var _listaBeneficios = (List<BeneficioModel>)this.dataGridViewBeneficios.DataSource;

                this._registroAtualBeneficio = _listaBeneficios[linha];
            }
            else
                this._registroAtualBeneficio = null;
        }

        private void SelecionarRegistroGridRenda(int linha)
        {
            if (linha >= 0)
            {
                var _listaRendas = (List<RendaModel>)this.dataGridViewRendas.DataSource;

                this._registroAtualRenda = _listaRendas[linha];
            }
            else
                this._registroAtualRenda = null;
        }

        private void SelecionarRegistroGridDocumento(int linha)
        {
            if (linha >= 0)
            {
                var _listaDocumentos = (List<DocumentosModel>)this.dataGridViewDocumentos.DataSource;

                this._registroAtualDocumento = _listaDocumentos[linha];
            }
            else
                this._registroAtualDocumento = null;
        }

        private void SelecionarRegistroGridAreaInteresseProfissional(int linha)
        {
            if (linha >= 0)
            {
                var _listaAreas = (List<AreaInteresseProfissionalModel>)this.dataGridViewAreaInteresseProfissional.DataSource;

                this._registroAtualAreInteresseProfissional = _listaAreas[linha];
            }
            else
                this._registroAtualAreInteresseProfissional = null;
        }

        private void SelecionarRegistroGridAtividadeDesenvolvida(int linha)
        {
            if (linha >= 0)
            {
                var _listaAtividades = (List<AtividadeDesenvolvidaModel>)this.dataGridViewAtividadesDesenvolvidas.DataSource;

                this._registroAtualAtividadeDesenvolvida = _listaAtividades[linha];
            }
            else
                this._registroAtualAtividadeDesenvolvida = null;
        }

        private void dataGridViewRendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGridRenda(e.RowIndex);
        }

        private void dataGridViewRendas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGridRenda(e.RowIndex);
        }

        private void dataGridViewDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGridDocumento(e.RowIndex);
        }

        private void dataGridViewDocumentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGridDocumento(e.RowIndex);
        }

        private void buttonAdicionarProblemaSaude_Click(object sender, System.EventArgs e)
        {
            using var _formProblemas = new FormEditarProblemasSaudePessoa(this._codigoPessoaAtual);

            try
            {
                _formProblemas.ShowDialog();

                //Carregar a lista de problemas de saúde
                this.CarregarProblemasSaude(this._codigoPessoaAtual);
            }
            finally
            {
                _formProblemas.Close();
            }
        }

        private void buttonAlterarProblemaSaude_Click(object sender, System.EventArgs e)
        {
            if (this._registroAtualProblemaSaude == null)
                MessageBox.Show("Você deve primeiro selecionar um Problema de Saúde no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                using var _formProblemas = new FormEditarProblemasSaudePessoa(this._codigoPessoaAtual, this._registroAtualProblemaSaude.CodProblemaSaude);

                try
                {
                    _formProblemas.ShowDialog();

                    //Carregar a lista de problemas de saúde
                    this.CarregarProblemasSaude(this._codigoPessoaAtual);
                }
                finally
                {
                    _formProblemas.Close();
                }
            }
        }

        private void buttonExcluirProblemaSaude_Click(object sender, System.EventArgs e)
        {
            if (this._registroAtualProblemaSaude == null)
                MessageBox.Show("Você deve primeiro selecionar um Problema de Saúde no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (MessageBox.Show("Confirma a Exclusão?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        this._problemaSaudeDal.Excluir(this._registroAtualProblemaSaude.CodProblemaSaude);
                        MessageBox.Show("Problema de Saúde Excluído!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Carregar a lista de problemas de saúde
                        this.CarregarProblemasSaude(this._codigoPessoaAtual);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show($"Ocorreu o seguinte erro: {Ex.Message}", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonExcluirDeficiencia_Click(object sender, EventArgs e)
        {
            if (this._registroAtualDeficiencia == null)
                MessageBox.Show("Você deve primeiro selecionar uma Deficiência no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (MessageBox.Show("Confirma a Exclusão?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        this._deficienciaDal.Excluir(this._registroAtualDeficiencia.CodDeficiencia);
                        MessageBox.Show("Deficiência Excluída!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Carregar a lista de deficiências
                        this.CarregarDeficiencias(this._codigoPessoaAtual);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show($"Ocorreu o seguinte erro: {Ex.Message}", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonAdicionarDeficiencia_Click(object sender, EventArgs e)
        {
            using var _formDeficiencia = new FormEditarDeficienciasPessoa(this._codigoPessoaAtual);

            try
            {
                _formDeficiencia.ShowDialog();

                //Carregar a lista de deficiências
                this.CarregarDeficiencias(this._codigoPessoaAtual);
            }
            finally
            {
                _formDeficiencia.Close();
            }
        }

        private void buttonAlterarDeficiencia_Click(object sender, EventArgs e)
        {
            if (this._registroAtualDeficiencia == null)
                MessageBox.Show("Você deve primeiro selecionar uma Deficiência no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                using var _formDeficiencia = new FormEditarDeficienciasPessoa(this._codigoPessoaAtual, this._registroAtualDeficiencia.CodDeficiencia);

                try
                {
                    _formDeficiencia.ShowDialog();

                    //Carregar a lista de deficiências
                    this.CarregarDeficiencias(this._codigoPessoaAtual);
                }
                finally
                {
                    _formDeficiencia.Close();
                }
            }
        }

        private void buttonExcluirBeneficio_Click(object sender, EventArgs e)
        {
            if (this._registroAtualBeneficio == null)
                MessageBox.Show("Você deve primeiro selecionar um Benefício no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (MessageBox.Show("Confirma a Exclusão?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        this._beneficioDal.Excluir(this._registroAtualBeneficio.CodBeneficio);
                        MessageBox.Show("Benefício Excluído!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Carregar a lista de benefícios
                        this.CarregarBeneficios(this._codigoPessoaAtual);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show($"Ocorreu o seguinte erro: {Ex.Message}", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonAdicionarBeneficio_Click(object sender, EventArgs e)
        {
            using var _formBeneficio = new FormEditarBeneficiosPessoa(this._codigoPessoaAtual);

            try
            {
                _formBeneficio.ShowDialog();

                //Carregar a lista de benefícios
                this.CarregarBeneficios(this._codigoPessoaAtual);
            }
            finally
            {
                _formBeneficio.Close();
            }
        }

        private void buttonAlterarBeneficio_Click(object sender, EventArgs e)
        {
            if (this._registroAtualBeneficio == null)
                MessageBox.Show("Você deve primeiro selecionar um Benefício no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                using var _formBeneficio = new FormEditarBeneficiosPessoa(this._codigoPessoaAtual, this._registroAtualBeneficio.CodBeneficio);

                try
                {
                    _formBeneficio.ShowDialog();

                    //Carregar a lista de benefícios
                    this.CarregarBeneficios(this._codigoPessoaAtual);
                }
                finally
                {
                    _formBeneficio.Close();
                }
            }
        }

        private void buttonExcluirRenda_Click(object sender, EventArgs e)
        {
            if (this._registroAtualRenda == null)
                MessageBox.Show("Você deve primeiro selecionar uma Renda no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (MessageBox.Show("Confirma a Exclusão?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        this._rendaDal.Excluir(this._registroAtualRenda.CodRenda);
                        MessageBox.Show("Renda Excluída!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //Carregar a lista de rendas
                        this.CarregarRendas(this._codigoPessoaAtual);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show($"Ocorreu o seguinte erro: {Ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonExcluirDocumento_Click(object sender, EventArgs e)
        {
            if (this._registroAtualDocumento == null)
                MessageBox.Show("Você deve primeiro selecionar um Documento no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (MessageBox.Show("Confirma a Exclusão?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        this._documentosDal.Excluir(this._registroAtualDocumento.CodigoDocumento);
                        MessageBox.Show("Documento Excluído!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Carregar a lista de documentos
                        this.CarregarDocumentos(this._codigoPessoaAtual);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show($"Ocorreu o seguinte erro: {Ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonAdicionarDocumento_Click(object sender, EventArgs e)
        {
            using var _formDocumento = new FormEditarDocumentosPessoa(this._codigoPessoaAtual);

            try
            {
                _formDocumento.ShowDialog();

                //Carregar a lista de documentos
                this.CarregarDocumentos(this._codigoPessoaAtual);
            }
            finally
            {
                _formDocumento.Close();
            }
        }

        private void buttonAlterarDocumento_Click(object sender, EventArgs e)
        {
            if (this._registroAtualDocumento == null)
                MessageBox.Show("Você deve primeiro selecionar um Documento no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                using var _formDocumento = new FormEditarDocumentosPessoa(this._codigoPessoaAtual, this._registroAtualDocumento.CodigoDocumento);

                try
                {
                    _formDocumento.ShowDialog();

                    //Carregar a lista de documentos
                    this.CarregarDocumentos(this._codigoPessoaAtual);
                }
                finally
                {
                    _formDocumento.Close();
                }
            }
        }

        private void buttonAlterarRenda_Click(object sender, EventArgs e)
        {
            if (this._registroAtualRenda == null)
                MessageBox.Show("Você deve primeiro selecionar uma Renda no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                using var _formRenda = new FormEditarRendasPessoa(this._codigoPessoaAtual, this._registroAtualRenda.CodRenda);

                try
                {
                    _formRenda.ShowDialog();

                    //Carregar a lista de rendas
                    this.CarregarRendas(this._codigoPessoaAtual);
                }
                finally
                {
                    _formRenda.Close();
                }
            }
        }

        private void buttonAdicionarRenda_Click(object sender, EventArgs e)
        {
            using var _formRenda = new FormEditarRendasPessoa(this._codigoPessoaAtual);

            try
            {
                _formRenda.ShowDialog();

                //Carregar a lista de rendas
                this.CarregarRendas(this._codigoPessoaAtual);
            }
            finally
            {
                _formRenda.Close();
            }
        }

        private void dataGridViewAreaInteresseProfissional_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGridAreaInteresseProfissional(e.RowIndex);
        }

        private void dataGridViewAreaInteresseProfissional_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGridAreaInteresseProfissional(e.RowIndex);
        }

        private void buttonExcluirAreaInteresseProfissional_Click(object sender, EventArgs e)
        {
            if (this._registroAtualAreInteresseProfissional == null)
                MessageBox.Show("Você deve primeiro selecionar uma Área de Interesse Profissional no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (MessageBox.Show("Confirma a Exclusão?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        this._areaInteresseProfissionalDal.Excluir(this._registroAtualAreInteresseProfissional.codAreaInteresseProfissional);
                        MessageBox.Show("Área de Interesse Profissional Excluída!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Carregar a lista de Áreas de Interesse Profissional
                        this.CarregarAreasInteresseProfissional(this._codigoPessoaAtual);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show($"Ocorreu o seguinte erro: {Ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonAlterarAreaInteresseProfissional_Click(object sender, EventArgs e)
        {
            if (this._registroAtualAreInteresseProfissional == null)
                MessageBox.Show("Você deve primeiro selecionar uma Área de Interesse Profissional no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                using var _formDocumento = new FormEditarAreaInteresseProfissional(this._codigoPessoaAtual, this._registroAtualAreInteresseProfissional.codAreaInteresseProfissional);

                try
                {
                    _formDocumento.ShowDialog();

                    //Carregar a lista de áreas de interesse profissional
                    this.CarregarAreasInteresseProfissional(this._codigoPessoaAtual);
                }
                finally
                {
                    _formDocumento.Close();
                }
            }
        }

        private void buttonAdicionarAreaInteresseProfissional_Click(object sender, EventArgs e)
        {
            using var _formDocumento = new FormEditarAreaInteresseProfissional(this._codigoPessoaAtual);

            try
            {
                _formDocumento.ShowDialog();

                //Carregar a lista de áreas de interesse profissional
                this.CarregarAreasInteresseProfissional(this._codigoPessoaAtual);
            }
            finally
            {
                _formDocumento.Close();
            }
        }

        private void dataGridViewAtividadesDesenvolvidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGridAtividadeDesenvolvida(e.RowIndex);
        }

        private void dataGridViewAtividadesDesenvolvidas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelecionarRegistroGridAtividadeDesenvolvida(e.RowIndex);
        }

        private void buttonExcluirAtividadesDesenvolvidas_Click(object sender, EventArgs e)
        {
            if (this._registroAtualAtividadeDesenvolvida == null)
                MessageBox.Show("Você deve primeiro selecionar uma Atividade Desenvolvida no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (MessageBox.Show("Confirma a Exclusão?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        this._atividadeDesenvolvidaDal.Excluir(this._registroAtualAtividadeDesenvolvida.codAtividadeDesenvolvida);
                        MessageBox.Show("Atividade Desenvolvida Excluída!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Carregar a lista de Atividades desenvolvidas
                        this.CarregarAtividadesDesenvolvidas(this._codigoPessoaAtual);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show($"Ocorreu o seguinte erro: {Ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonAlterarAtividadesDesenvolvidas_Click(object sender, EventArgs e)
        {
            if (this._registroAtualAtividadeDesenvolvida == null)
                MessageBox.Show("Você deve primeiro selecionar uma Atividade Desenvolvida no grid!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                using var _formDocumento = new FormEditarAtividadeDesenvolvida(this._codigoPessoaAtual, this._registroAtualAtividadeDesenvolvida.codAtividadeDesenvolvida);

                try
                {
                    _formDocumento.ShowDialog();

                    //Carregar a lista de atividades desenvolvidas
                    this.CarregarAtividadesDesenvolvidas(this._codigoPessoaAtual);
                }
                finally
                {
                    _formDocumento.Close();
                }
            }
        }

        private void buttonAdicionarAtividadesDesenvolvidas_Click(object sender, EventArgs e)
        {
            using var _formDocumento = new FormEditarAtividadeDesenvolvida(this._codigoPessoaAtual);

            try
            {
                _formDocumento.ShowDialog();

                //Carregar a lista de atividades desenvolvidas
                this.CarregarAtividadesDesenvolvidas(this._codigoPessoaAtual);
            }
            finally
            {
                _formDocumento.Close();
            }
        }
    }
}