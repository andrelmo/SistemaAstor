using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using System;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormEditarAreaInteresseProfissional : Form
    {
        private readonly IAreaInteresseProfissionalDal _areaInteresseProfissionalDal;
        private readonly IListaAreaInteresseProfissionalDal _listaAreaInteresseProfissionalDal;
        private readonly ServiceProvider _serviceProvider;
        private AreaInteresseProfissionalModel _areaInteresseProfissionaEdicao;
        private bool _desabilitarControles;
        private bool _alterandoRegistro;
        private int _codigoAreaInteresseProfissionalAtual;
        private int _codigoPessoaAtual;

        public FormEditarAreaInteresseProfissional(int codigoPessoa, int codigoAreaInteresseProfissional = -1)
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._areaInteresseProfissionalDal = this._serviceProvider.GetService<IAreaInteresseProfissionalDal>();
            this._listaAreaInteresseProfissionalDal = this._serviceProvider.GetService<IListaAreaInteresseProfissionalDal>();
            this._desabilitarControles = false;
            this._codigoAreaInteresseProfissionalAtual = codigoAreaInteresseProfissional;
            this._codigoPessoaAtual = codigoPessoa;

            this.CarregarListaAreaInteresseProfissional();

            if (codigoAreaInteresseProfissional != -1)
            {
                this._alterandoRegistro = true;
                this.CarregarAreaInteresseProfissional(codigoAreaInteresseProfissional);
            }
            else
            {
                this._alterandoRegistro = false;
                this.LimparControles();
            }
        }

        private void CarregarListaAreaInteresseProfissional()
        {
            this.comboBoxListaAreaInteresseProfissional.ValueMember = "CodAreaInteresseProfissional";
            this.comboBoxListaAreaInteresseProfissional.DisplayMember = "AreaInteresse";
            this.comboBoxListaAreaInteresseProfissional.DataSource = this._listaAreaInteresseProfissionalDal.BuscarTodos();
        }

        private void CarregarAreaInteresseProfissional(int codigoAreaInteresseProfissionals)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Buscar a área de interesse profissional que irá ser editada
                this._areaInteresseProfissionaEdicao = this._areaInteresseProfissionalDal.Buscar(codigoAreaInteresseProfissionals);

                //Verificar se a área de interesse profissional não foi encontrada
                if (this._areaInteresseProfissionaEdicao == null)
                {
                    MessageBox.Show("A Área de Interesse Profissional que você quer editar não foi encontrada!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.comboBoxListaAreaInteresseProfissional.SelectedValue = this._areaInteresseProfissionaEdicao.CodListaAreaInteresseProfissional;
            this._desabilitarControles = false;
        }

        private void LimparControles()
        {
            this.comboBoxListaAreaInteresseProfissional.SelectedIndex = -1;
        }

        private void HabilitarControles()
        {
            var _habilitarControle = !this._desabilitarControles;

            this.comboBoxListaAreaInteresseProfissional.Enabled = _habilitarControle;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
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
                            //Realizar a inserção do registro
                            var _deficienciaCriado = this._areaInteresseProfissionalDal.Adicionar(this.CriarAreaInteresseProfissionalModel());

                            MessageBox.Show("Área de Interesse Profissional Adicionada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            //Realizar a alteração do registro
                            var _deficienciaAlterado = this._areaInteresseProfissionalDal.Atualizar(this.CriarAreaInteresseProfissionalAlteracao());

                            MessageBox.Show("Área de Interesse Profissional Alterada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private AreaInteresseProfissionalModel CriarAreaInteresseProfissionalAlteracao()
        {
            var _areaInteresse = this.CriarAreaInteresseProfissionalModel();

            _areaInteresse.codAreaInteresseProfissional = this._codigoAreaInteresseProfissionalAtual;

            return (_areaInteresse);
        }

        private AreaInteresseProfissionalModel CriarAreaInteresseProfissionalModel()
        {
            return (new AreaInteresseProfissionalModel()
            {
                CodPessoas = this._codigoPessoaAtual,
                CodListaAreaInteresseProfissional = (int)this.comboBoxListaAreaInteresseProfissional.SelectedValue
            }); ;
        }

        private bool VerificarInformacoesObrigatorias()
        {
            if (this.comboBoxListaAreaInteresseProfissional.SelectedIndex == -1)
            {
                MessageBox.Show("Você deve informar a Área de Interesse Profissional!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            return (true);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}