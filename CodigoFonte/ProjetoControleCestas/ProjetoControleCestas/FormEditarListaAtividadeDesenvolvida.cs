using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using System;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormEditarListaAtividadeDesenvolvida : Form
    {
        private readonly IListaAtividadeDesenvolvidaDal _listaAtividadeDesenvolvidaDal;
        private readonly ServiceProvider _serviceProvider;
        private ListaAtividadeDesenvolvidaModel _listaAtividadeDesenvolvidaEdicao;
        private bool _desabilitarControles;
        private bool _alterandoRegistro;
        private int _codigoListaAtividadeDesenvolvidaAtual;

        public FormEditarListaAtividadeDesenvolvida(int codigoListaAtividadeDesenvolvida = -1)
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._listaAtividadeDesenvolvidaDal = this._serviceProvider.GetService<IListaAtividadeDesenvolvidaDal>();
            this._desabilitarControles = false;
            this._codigoListaAtividadeDesenvolvidaAtual = codigoListaAtividadeDesenvolvida;

            if (codigoListaAtividadeDesenvolvida != -1)
            {
                this._alterandoRegistro = true;
                this.CarregarListaAtividadeDesenvolvida(codigoListaAtividadeDesenvolvida);
            }
            else
            {
                this._alterandoRegistro = false;
                this.LimparControles();
            }
        }

        private void CarregarListaAtividadeDesenvolvida(int codigoUsuario)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Buscar a lista de atividade desenvolvida que irá ser editada
                this._listaAtividadeDesenvolvidaEdicao = this._listaAtividadeDesenvolvidaDal.Buscar(codigoUsuario);

                //Verificar se a lista de atividade desenvolvida não foi encontrado
                if (this._listaAtividadeDesenvolvidaEdicao == null)
                {
                    MessageBox.Show("A Lista de Atividade Desenvolvida não foi encontrada!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.textBoxAtividadeDesenvolvida.Text = this._listaAtividadeDesenvolvidaEdicao.Atividade;
            this._desabilitarControles = false;
        }

        private void HabilitarControles()
        {
            var _habilitarControle = !this._desabilitarControles;

            this.textBoxAtividadeDesenvolvida.Enabled = _habilitarControle;
        }

        private void LimparControles()
        {
            this.textBoxAtividadeDesenvolvida.Text = string.Empty;
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
                            var _listaCriado = this._listaAtividadeDesenvolvidaDal.Adicionar(this.CriarListaAtividadeDesenvolvidaModel());

                            MessageBox.Show("Lista de Atividade Desenvolvida Adicionada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            //Realizar a alteração do registro
                            var _listaAlterada = this._listaAtividadeDesenvolvidaDal.Atualizar(this.CriarListaAtividadeDesenvolvidaModelAlteracao());

                            MessageBox.Show("Lista de Atividade Desenvolvida Alterada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private ListaAtividadeDesenvolvidaModel CriarListaAtividadeDesenvolvidaModelAlteracao()
        {
            var _usuario = this.CriarListaAtividadeDesenvolvidaModel();

            _usuario.CodAtividadeDesenvolvida = this._listaAtividadeDesenvolvidaEdicao.CodAtividadeDesenvolvida;

            return (_usuario);
        }

        private ListaAtividadeDesenvolvidaModel CriarListaAtividadeDesenvolvidaModel()
        {
            return (new ListaAtividadeDesenvolvidaModel()
            {
                 Atividade = this.textBoxAtividadeDesenvolvida.Text
            });
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

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}