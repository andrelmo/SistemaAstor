using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using System;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormEditarRendasPessoa : Form
    {
        private readonly IRendaDal _rendaDal;
        private readonly ServiceProvider _serviceProvider;
        private RendaModel _rendaEdicao;
        private bool _desabilitarControles;
        private bool _alterandoRegistro;
        private int _codigoRendaAtual;
        private int _codigoPessoaAtual;

        public FormEditarRendasPessoa(int codigoPessoa, int codigoRenda = -1)
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._rendaDal = this._serviceProvider.GetService<IRendaDal>();
            this._desabilitarControles = false;
            this._codigoRendaAtual = codigoRenda;
            this._codigoPessoaAtual = codigoPessoa;

            if (codigoRenda != -1)
            {
                this._alterandoRegistro = true;
                this.CarregarRenda(codigoRenda);
            }
            else
            {
                this._alterandoRegistro = false;
                this.LimparControles();
            }
        }

        private void CarregarRenda(int codigoRenda)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Buscar a renda que irá ser editado
                this._rendaEdicao = this._rendaDal.Buscar(codigoRenda);

                //Verificar se a renda não foi encontrada
                if (this._rendaEdicao == null)
                {
                    MessageBox.Show("A Renda que você quer editar não foi encontrada!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.textBoxValorRenda.Text = this._rendaEdicao.ValorRenda.ToString();
            this._desabilitarControles = false;

            if (this._rendaEdicao.Renda == Constantes.ConstantesGlobais.RENDA_FORMAL)
                this.radioButtonTipoRendaFormal.Checked = true;
            else
                this.radioButtonTipoRendaInformal.Checked = true;
        }

        private void LimparControles()
        {
            this.textBoxValorRenda.Text = string.Empty;
            this.radioButtonTipoRendaFormal.Checked = true;
        }

        private void HabilitarControles()
        {
            var _habilitarControle = !this._desabilitarControles;

            this.textBoxValorRenda.Enabled = _habilitarControle;
            this.groupBoxTipoRenda.Enabled = _habilitarControle;
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
                            var _rendaCriado = this._rendaDal.Adicionar(this.CriarRendaModel());

                            MessageBox.Show("Renda Adicionada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            //Realizar a alteração do registro
                            var _rendaAlterado = this._rendaDal.Atualizar(this.CriarRendaModelAlteracao());

                            MessageBox.Show("Renda Alterada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private RendaModel CriarRendaModelAlteracao()
        {
            var _renda = this.CriarRendaModel();

            _renda.CodRenda = this._codigoRendaAtual;

            return (_renda);
        }

        private RendaModel CriarRendaModel()
        {
            return (new RendaModel()
            {
                CodPessoas = this._codigoPessoaAtual,
                Renda = this.GetValorRenda(),
                ValorRenda = Convert.ToDecimal(this.textBoxValorRenda.Text)
            });
        }

        private string GetValorRenda()
        {
            if (this.radioButtonTipoRendaFormal.Checked)
                return (Constantes.ConstantesGlobais.RENDA_FORMAL);

            return (Constantes.ConstantesGlobais.RENDA_INFORMAL);
        }

        private bool VerificarInformacoesObrigatorias()
        {
            if (string.IsNullOrEmpty(this.textBoxValorRenda.Text))
            {
                MessageBox.Show("Você deve informar o valor da renda!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            return (true);
        }

        private void buttonCancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void textBoxValorRenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}