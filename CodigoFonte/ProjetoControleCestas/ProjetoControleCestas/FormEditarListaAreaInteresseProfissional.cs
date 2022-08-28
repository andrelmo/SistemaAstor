using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using System;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormEditarListaAreaInteresseProfissional : Form
    {
        private readonly IListaAreaInteresseProfissionalDal _listaAreaInteresseProfissionalDal;
        private readonly ServiceProvider _serviceProvider;
        private ListaAreaInteresseProfissionalModel _listaAreaInteresseProfissionalEdicao;
        private bool _desabilitarControles;
        private bool _alterandoRegistro;
        private int _codigoListaAreaInteresseAtual;

        public FormEditarListaAreaInteresseProfissional(int codigoListaAreaInteresseProfissional = -1)
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._listaAreaInteresseProfissionalDal = this._serviceProvider.GetService<IListaAreaInteresseProfissionalDal>();
            this._desabilitarControles = false;
            this._codigoListaAreaInteresseAtual = codigoListaAreaInteresseProfissional;

            if (codigoListaAreaInteresseProfissional != -1)
            {
                this._alterandoRegistro = true;
                this.CarregarListaAreaInteresseProfissional(codigoListaAreaInteresseProfissional);
            }
            else
            {
                this._alterandoRegistro = false;
                this.LimparControles();
            }
        }

        private void CarregarListaAreaInteresseProfissional(int codigoUsuario)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Buscar a lista de área de interesse profissinal que irá ser editada
                this._listaAreaInteresseProfissionalEdicao = this._listaAreaInteresseProfissionalDal.Buscar(codigoUsuario);

                //Verificar se a lista de área de interessse profissional não foi encontrado
                if (this._listaAreaInteresseProfissionalEdicao == null)
                {
                    MessageBox.Show("A Lista de Área de Interesse Profissional não foi encontrado!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.textBoxAreaInteresse.Text = this._listaAreaInteresseProfissionalEdicao.AreaInteresse;
            this._desabilitarControles = false;
        }

        private void LimparControles()
        {
            this.textBoxAreaInteresse.Text = string.Empty;
        }

        private void HabilitarControles()
        {
            var _habilitarControle = !this._desabilitarControles;

            this.textBoxAreaInteresse.Enabled = _habilitarControle;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
                            var _listaCriado = this._listaAreaInteresseProfissionalDal.Adicionar(this.CriarListaAreaInteresseProfissionalModel());

                            MessageBox.Show("Lista de Área de Interessse Profissional Adicionada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            //Realizar a alteração do registro
                            var _listaAlterada = this._listaAreaInteresseProfissionalDal.Atualizar(this.CriarListaAreaInteresseProfisionalModelAlteracao());

                            MessageBox.Show("Lista de Área de Interesse Profissinal Alterada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private ListaAreaInteresseProfissionalModel CriarListaAreaInteresseProfisionalModelAlteracao()
        {
            var _usuario = this.CriarListaAreaInteresseProfissionalModel();

            _usuario.CodAreaInteresseProfissional = this._listaAreaInteresseProfissionalEdicao.CodAreaInteresseProfissional;

            return (_usuario);
        }

        private ListaAreaInteresseProfissionalModel CriarListaAreaInteresseProfissionalModel()
        {
            return (new ListaAreaInteresseProfissionalModel()
            {
                AreaInteresse = this.textBoxAreaInteresse.Text
            });
        }

        private bool VerificarInformacoesObrigatorias()
        {
            if (string.IsNullOrEmpty(this.textBoxAreaInteresse.Text))
            {
                MessageBox.Show("Você deve informar a Área de Interesse Profissional!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            return (true);
        }
    }
}