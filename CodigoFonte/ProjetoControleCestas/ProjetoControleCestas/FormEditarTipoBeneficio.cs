using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormEditarTipoBeneficio : Form
    {
        private readonly ITipoBeneficioDAl _tipoBeneficioDal;
        private readonly ServiceProvider _serviceProvider;
        private TipoBeneficioModel _tipoBeneficioEdicao;
        private bool _desabilitarControles;
        private bool _alterandoRegistro;
        private int _codigoTipoBeneficioAtual;

        public FormEditarTipoBeneficio(int codigoTipoBeneficio = -1)
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._tipoBeneficioDal = this._serviceProvider.GetService<ITipoBeneficioDAl>();
            this._desabilitarControles = false;
            this._codigoTipoBeneficioAtual = codigoTipoBeneficio;

            if (codigoTipoBeneficio != -1)
            {
                this._alterandoRegistro = true;
                this.CarregarTipoBeneficio(codigoTipoBeneficio);
            }
            else
            {
                this._alterandoRegistro = false;
                this.LimparControles();
            }
        }

        private void CarregarTipoBeneficio(int codigoUsuario)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Buscar o tipo de benefício que irá ser editado
                this._tipoBeneficioEdicao = this._tipoBeneficioDal.Buscar(codigoUsuario);

                //Verificar se o tipo de benefício não foi encontrado
                if (this._tipoBeneficioEdicao == null)
                {
                    MessageBox.Show("O Tipo de Benefício que você quer editar não foi encontrado!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.textBoxBeneficio.Text = this._tipoBeneficioEdicao.Beneficio;
            this._desabilitarControles = false;
        }

        private void LimparControles()
        {
            this.textBoxBeneficio.Text = string.Empty;
        }

        private void HabilitarControles()
        {
            var _habilitarControle = !this._desabilitarControles;

            this.textBoxBeneficio.Enabled = _habilitarControle;
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
                            var _tipoBeneficioCriado = this._tipoBeneficioDal.Adicionar(this.CriarTipoBeneficioModel());

                            MessageBox.Show("Tipo de Benefício Adicionado!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            //Realizar a alteração do registro
                            var _tipoBeneficioAlterado = this._tipoBeneficioDal.Atualizar(this.CriarTipoBeneficioModelAlteracao());

                            MessageBox.Show("Tipo de Benefício Alterado!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private TipoBeneficioModel CriarTipoBeneficioModelAlteracao()
        {
            var _usuario = this.CriarTipoBeneficioModel();

            _usuario.CodTipoBeneficio = this._tipoBeneficioEdicao.CodTipoBeneficio;

            return (_usuario);
        }

        private TipoBeneficioModel CriarTipoBeneficioModel()
        {
            return (new TipoBeneficioModel()
            {
                Beneficio = this.textBoxBeneficio.Text
            });
        }

        private bool VerificarInformacoesObrigatorias()
        {
            if (string.IsNullOrEmpty(this.textBoxBeneficio.Text))
            {
                MessageBox.Show("Você deve informar o benefício!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            return (true);
        }

        private void buttonCancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}