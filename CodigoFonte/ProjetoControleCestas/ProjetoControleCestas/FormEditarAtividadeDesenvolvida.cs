using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using System;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormEditarAtividadeDesenvolvida : Form
    {
        private readonly IAtividadeDesenvolvidaDal _atividadeDesenvolvidaDal;
        private readonly ServiceProvider _serviceProvider;
        private AtividadeDesenvolvidaModel _atividadeDesenvolvidaEdicao;
        private bool _desabilitarControles;
        private bool _alterandoRegistro;
        private int _codigoAtividadeDesenvolvidaAtual;
        private int _codigoPessoaAtual;

        public FormEditarAtividadeDesenvolvida(int codigoPessoa, int codigoAtividadeDesenvolvida = -1)
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._atividadeDesenvolvidaDal = this._serviceProvider.GetService<IAtividadeDesenvolvidaDal>();
            this._desabilitarControles = false;
            this._codigoAtividadeDesenvolvidaAtual = codigoAtividadeDesenvolvida;
            this._codigoPessoaAtual = codigoPessoa;

            if (codigoAtividadeDesenvolvida != -1)
            {
                this._alterandoRegistro = true;
                this.CarregarAtividadeDesenvolvida(codigoAtividadeDesenvolvida);
            }
            else
            {
                this._alterandoRegistro = false;
                this.LimparControles();
            }
        }

        private void CarregarAtividadeDesenvolvida(int codigoAtividadeDesenvolvida)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Buscar a atividade desenvolvida que irá ser editada
                this._atividadeDesenvolvidaEdicao = this._atividadeDesenvolvidaDal.Buscar(codigoAtividadeDesenvolvida);

                //Verificar se a atividade desenvolvida não foi encontrada
                if (this._atividadeDesenvolvidaEdicao == null)
                {
                    MessageBox.Show("A Atividade Desenvolvida que você quer editar não foi encontrada!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.textBoxAtividadeDesenvolvida.Text = this._atividadeDesenvolvidaEdicao.Atividade;
            this._desabilitarControles = false;
        }

        private void LimparControles()
        {
            this.textBoxAtividadeDesenvolvida.Text = string.Empty;
        }

        private void HabilitarControles()
        {
            var _habilitarControle = !this._desabilitarControles;

            this.textBoxAtividadeDesenvolvida.Enabled = _habilitarControle;
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
                            var _AtividadeDesenvolvidaCriado = this._atividadeDesenvolvidaDal.Adicionar(this.CriarAtividadeDesenvolvidaModel());

                            MessageBox.Show("Atividade Desenvolvida Adicionada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            //Realizar a alteração do registro
                            var _atividadeDesenvolvidaAlterado = this._atividadeDesenvolvidaDal.Atualizar(this.CriarAtividadeDesenvolvidaModelAlteracao());

                            MessageBox.Show("Atividade Desenvolvida Alterada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool VerificarInformacoesObrigatorias()
        {
            if (string.IsNullOrEmpty(this.textBoxAtividadeDesenvolvida.Text))
            {
                MessageBox.Show("Você deve informar a Atividade Desenvolvida!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            return (true);
        }

        private AtividadeDesenvolvidaModel CriarAtividadeDesenvolvidaModelAlteracao()
        {
            var _atividadeDesenvolvida = this.CriarAtividadeDesenvolvidaModel();

            _atividadeDesenvolvida.codAtividadeDesenvolvida = this._codigoAtividadeDesenvolvidaAtual;

            return (_atividadeDesenvolvida);
        }

        private AtividadeDesenvolvidaModel CriarAtividadeDesenvolvidaModel()
        {
            return (new AtividadeDesenvolvidaModel()
            {
                CodPessoas = this._codigoPessoaAtual,
                Atividade = this.textBoxAtividadeDesenvolvida.Text
            });
        }
    }
}