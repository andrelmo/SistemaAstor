using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormEditarDeficienciasPessoa : Form
    {
        private readonly IDeficienciaDal _deficienciaDal;
        private readonly ServiceProvider _serviceProvider;
        private DeficienciaModel _deficienciaEdicao;
        private bool _desabilitarControles;
        private bool _alterandoRegistro;
        private int _codigoDeficienciaAtual;
        private int _codigoPessoaAtual;

        public FormEditarDeficienciasPessoa(int codigoPessoa, int codigoDeficiencia = -1)
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._deficienciaDal = this._serviceProvider.GetService<IDeficienciaDal>();
            this._desabilitarControles = false;
            this._codigoDeficienciaAtual = codigoDeficiencia;
            this._codigoPessoaAtual = codigoPessoa;

            if (codigoDeficiencia != -1)
            {
                this._alterandoRegistro = true;
                this.CarregarDeficiencia(codigoDeficiencia);
            }
            else
            {
                this._alterandoRegistro = false;
                this.LimparControles();
            }
        }

        private void CarregarDeficiencia(int codigoDeficiencia)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Buscar a deficiência que irá ser editada
                this._deficienciaEdicao = this._deficienciaDal.Buscar(codigoDeficiencia);

                //Verificar se a deficiência não foi encontrada
                if (this._deficienciaEdicao == null)
                {
                    MessageBox.Show("A Deficiência que você quer editar não foi encontrada!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.textBoxDeficiencia.Text = this._deficienciaEdicao.Deficiencia;
            this._desabilitarControles = false;
        }

        private void LimparControles()
        {
            this.textBoxDeficiencia.Text = string.Empty;
        }

        private void HabilitarControles()
        {
            var _habilitarControle = !this._desabilitarControles;

            this.textBoxDeficiencia.Enabled = _habilitarControle;
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
                            var _deficienciaCriado = this._deficienciaDal.Adicionar(this.CriarDeficienciaModel());

                            MessageBox.Show("Deficiência Adicionada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            //Realizar a alteração do registro
                            var _deficienciaAlterado = this._deficienciaDal.Atualizar(this.CriarDeficienciaModelAlteracao());

                            MessageBox.Show("Deficiência Alterada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private DeficienciaModel CriarDeficienciaModelAlteracao()
        {
            var _deficiencia = this.CriarDeficienciaModel();

            _deficiencia.CodDeficiencia = this._codigoDeficienciaAtual;

            return (_deficiencia);
        }

        private DeficienciaModel CriarDeficienciaModel()
        {
            return (new DeficienciaModel()
            {
                CodPessoa = this._codigoPessoaAtual,
                Deficiencia = this.textBoxDeficiencia.Text
            });
        }

        private bool VerificarInformacoesObrigatorias()
        {
            if (string.IsNullOrEmpty(this.textBoxDeficiencia.Text))
            {
                MessageBox.Show("Você deve informar a deficiência!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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