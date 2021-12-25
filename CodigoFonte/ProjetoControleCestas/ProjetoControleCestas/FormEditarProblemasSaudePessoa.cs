using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormEditarProblemasSaudePessoa : Form
    {
        private readonly IProblemaSaudeDal _problemaSaudeDal;
        private readonly ServiceProvider _serviceProvider;
        private ProblemaSaudeModel _problemaSaudeEdicao;
        private bool _desabilitarControles;
        private bool _alterandoRegistro;
        private int _codigoProblemaSaudeAtual;
        private int _codigoPessoaAtual;

        public FormEditarProblemasSaudePessoa(int codigoPessoa, int codigoProblemaSaude = -1)
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._problemaSaudeDal = this._serviceProvider.GetService<IProblemaSaudeDal>();
            this._desabilitarControles = false;
            this._codigoProblemaSaudeAtual = codigoProblemaSaude;
            this._codigoPessoaAtual = codigoPessoa;

            if (codigoProblemaSaude != -1)
            {
                this._alterandoRegistro = true;
                this.CarregarProblemaSaude(codigoProblemaSaude);
            }
            else
            {
                this._alterandoRegistro = false;
                this.LimparControles();
            }
        }

        private void CarregarProblemaSaude(int codigoProblemaSaude)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Buscar o problema de saúde que irá ser editada
                this._problemaSaudeEdicao = this._problemaSaudeDal.Buscar(codigoProblemaSaude);

                //Verificar se o problema de saúde não foi encontrado
                if (this._problemaSaudeEdicao == null)
                {
                    MessageBox.Show("O Problema de Saúde que você quer editar não foi encontrado!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.textBoxProblema.Text = this._problemaSaudeEdicao.ProblemaSaude;
            this.textBoxMedicamento.Text = this._problemaSaudeEdicao.Medicamento;
            this.textBoxLocal.Text = this._problemaSaudeEdicao.Local;
            this.textBoxPeriodicidade.Text = this._problemaSaudeEdicao.Periodicidade;
            this._desabilitarControles = false;
        }

        private void LimparControles()
        {
            this.textBoxProblema.Text = string.Empty;
            this.textBoxMedicamento.Text = string.Empty;
            this.textBoxLocal.Text = string.Empty;
            this.textBoxPeriodicidade.Text = string.Empty;
        }

        private void HabilitarControles()
        {
            var _habilitarControle = !this._desabilitarControles;

            this.textBoxProblema.Enabled = _habilitarControle;
            this.textBoxMedicamento.Enabled = _habilitarControle;
            this.textBoxLocal.Enabled = _habilitarControle;
            this.textBoxPeriodicidade.Enabled = _habilitarControle;
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
                            var _problemaCriado = this._problemaSaudeDal.Adicionar(this.CriarProblemaSaudeModel());

                            MessageBox.Show("Problema de Saúde Adicionado!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            //Realizar a alteração do registro
                            var _problemaAlterado = this._problemaSaudeDal.Atualizar(this.CriarProblemaSaudeModelAlteracao());

                            MessageBox.Show("Problema de Saúde Alterado!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private ProblemaSaudeModel CriarProblemaSaudeModelAlteracao()
        {
            var _problema = this.CriarProblemaSaudeModel();

            _problema.CodProblemaSaude = this._codigoProblemaSaudeAtual;

            return (_problema);
        }

        private ProblemaSaudeModel CriarProblemaSaudeModel()
        {
            return (new ProblemaSaudeModel()
            {
                CodPessoa = this._codigoPessoaAtual,
                Local = this.textBoxLocal.Text,
                Medicamento = this.textBoxMedicamento.Text,
                Periodicidade = this.textBoxPeriodicidade.Text,
                ProblemaSaude = this.textBoxProblema.Text
            });
        }

        private bool VerificarInformacoesObrigatorias()
        {
            if (string.IsNullOrEmpty(this.textBoxProblema.Text))
            {
                MessageBox.Show("Você deve informar o problema!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            if (string.IsNullOrEmpty(this.textBoxMedicamento.Text))
            {
                MessageBox.Show("Você deve informar o medicamento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            if (string.IsNullOrEmpty(this.textBoxLocal.Text))
            {
                MessageBox.Show("Você deve informar o local!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            if (string.IsNullOrEmpty(this.textBoxPeriodicidade.Text))
            {
                MessageBox.Show("Você deve informar a periodicidade!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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