using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using System;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormEditarBeneficiosPessoa : Form
    {
        private readonly IBeneficioDal _beneficioDal;
        private readonly ITipoBeneficioDAl _tipoBeneficioDal;
        private readonly ServiceProvider _serviceProvider;
        private BeneficioModel _beneficioEdicao;
        private bool _desabilitarControles;
        private bool _alterandoRegistro;
        private int _codigoBeneficioAtual;
        private int _codigoPessoaAtual;

        public FormEditarBeneficiosPessoa(int codigoPessoa, int codigoBeneficio = -1)
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._beneficioDal = this._serviceProvider.GetService<IBeneficioDal>();
            this._tipoBeneficioDal = this._serviceProvider.GetService<ITipoBeneficioDAl>();
            this._desabilitarControles = false;
            this._codigoBeneficioAtual = codigoBeneficio;
            this._codigoPessoaAtual = codigoPessoa;
            this.CarregarTipoBeneficio();

            if (codigoBeneficio != -1)
            {
                this._alterandoRegistro = true;
                this.CarregarBeneficio(codigoBeneficio);
            }
            else
            {
                this._alterandoRegistro = false;
                this.LimparControles();
            }
        }

        private void CarregarTipoBeneficio()
        {
            var _listaTipoBeneficios = this._tipoBeneficioDal.BuscarTodos();

            this.comboBoxTipoBeneficio.DataSource = _listaTipoBeneficios;
        }

        private void CarregarBeneficio(int codigoBeneficio)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Buscar o benefício que irá ser editado
                this._beneficioEdicao = this._beneficioDal.Buscar(codigoBeneficio);

                //Verificar se o benefício não foi encontrado
                if (this._beneficioEdicao == null)
                {
                    MessageBox.Show("O Benefício que você quer editar não foi encontrado!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.comboBoxTipoBeneficio.SelectedValue = this._beneficioEdicao.CodTipoBeneficio;
            this.textBoxValorBeneficio.Text = this._beneficioEdicao.ValorBeneficio.ToString();
            this._desabilitarControles = false;
        }

        private void LimparControles()
        {
            this.textBoxValorBeneficio.Text = string.Empty;
            this.comboBoxTipoBeneficio.SelectedIndex = -1;
        }

        private void HabilitarControles()
        {
            var _habilitarControle = !this._desabilitarControles;

            this.textBoxValorBeneficio.Enabled = _habilitarControle;
            this.comboBoxTipoBeneficio.Enabled = _habilitarControle;
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
                            //Realizar a inserção do registro
                            var _beneficioCriado = this._beneficioDal.Adicionar(this.CriarBeneficioModel());

                            MessageBox.Show("Benefício Adicionado!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            //Realizar a alteração do registro
                            var _beneficioAlterado = this._beneficioDal.Atualizar(this.CriarBeneficioModelAlteracao());

                            MessageBox.Show("Benefício Alterado!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private BeneficioModel CriarBeneficioModelAlteracao()
        {
            var _beneficio = this.CriarBeneficioModel();

            _beneficio.CodBeneficio = this._codigoBeneficioAtual;


            return (_beneficio);
        }

        private BeneficioModel CriarBeneficioModel()
        {
            return (new BeneficioModel()
            {
                CodPessoa = this._codigoPessoaAtual,
                ValorBeneficio = Convert.ToDecimal(this.textBoxValorBeneficio.Text),
                CodTipoBeneficio = Convert.ToInt32(this.comboBoxTipoBeneficio.SelectedValue)
            });
        }

        private bool VerificarInformacoesObrigatorias()
        {
            if (string.IsNullOrEmpty(this.textBoxValorBeneficio.Text))
            {
                MessageBox.Show("Você deve informar o valor do benefício!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            if (this.comboBoxTipoBeneficio.SelectedIndex == -1)
            {
                MessageBox.Show("Você deve informar o tipo do benefício!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }


            return (true);
        }

        private void buttonCancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void textBoxValorBeneficio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            } else
            {
                e.Handled = false;
            }
        }
    }
}