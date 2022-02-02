using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using ProjetoControleCestas.Utils;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormEditarDocumentosPessoa : Form
    {
        private const string TIPO_DOCUMENTO_CPF = @"CPF";
        private const string MASCARA_TIPO_DOCUMENTO_CPF = @"000.00.00.00/00";
        private const int NUMERO_MAXIMO_CARACTERES_NUMERO_DOCUMENTO = 20;

        private readonly IDocumentosDal _documentosDal;
        private readonly ServiceProvider _serviceProvider;
        private DocumentosModel _documentoEdicao;
        private bool _desabilitarControles;
        private bool _alterandoRegistro;
        private int _codigoDocumentoAtual;
        private int _codigoPessoaAtual;

        public FormEditarDocumentosPessoa(int codigoPessoa, int codigoDocumento = -1)
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._documentosDal = this._serviceProvider.GetService<IDocumentosDal>();
            this._desabilitarControles = false;
            this._codigoDocumentoAtual = codigoDocumento;
            this._codigoPessoaAtual = codigoPessoa;

            if (codigoDocumento != -1)
            {
                this._alterandoRegistro = true;
                this.CarregarDocumento(codigoDocumento);
            }
            else
            {
                this._alterandoRegistro = false;
                this.LimparControles();
            }
        }

        private void CarregarDocumento(int codigoDocumento)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Buscar o documento que irá ser editado
                this._documentoEdicao = this._documentosDal.Buscar(codigoDocumento);

                //Verificar se o documento não foi encontrado
                if (this._documentoEdicao == null)
                {
                    MessageBox.Show("O Documento que você quer editar não foi encontrado!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.textBoxNumeroDocumento.Text = this._documentoEdicao.NumeroDocumento;

            var _posicao = this.comboBoxTipoDocumento.FindString(this._documentoEdicao.TipoDocumento);

            if (_posicao != -1)
                this.comboBoxTipoDocumento.SelectedIndex = _posicao;
            else
                this.comboBoxTipoDocumento.SelectedIndex = -1;
        }

        private void LimparControles()
        {
            this.textBoxNumeroDocumento.Text = string.Empty;
            this.comboBoxTipoDocumento.SelectedIndex = -1;
        }

        private void HabilitarControles()
        {
            var _habilitarControle = !this._desabilitarControles;

            this.comboBoxTipoDocumento.Enabled = _habilitarControle;
            this.textBoxNumeroDocumento.Enabled = _habilitarControle;
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
                        //Verificar se o tamanho do campo de número do documento foi excedido
                        if (this.textBoxNumeroDocumento.Text.Length > NUMERO_MAXIMO_CARACTERES_NUMERO_DOCUMENTO)
                        {
                            MessageBox.Show("Você pode digitar no máximo 20 caracteres!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            return;
                        }

                        //Verificar se foi selecionado o tipo de documento "CPF"
                        if (this.comboBoxTipoDocumento.Items[this.comboBoxTipoDocumento.SelectedIndex].ToString() == TIPO_DOCUMENTO_CPF)
                        {
                            if (!ValidaCPF.IsCpf(this.textBoxNumeroDocumento.Text))
                            {
                                MessageBox.Show("O número do CPF informado não é válido!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                return;
                            }
                        }

                        //Verificar se está sendo feita uma inserção
                        if (!this._alterandoRegistro)
                        {
                            //Realizar a inserção do registro
                            var _documentoCriado = this._documentosDal.Adicionar(this.CriarDocumentosModel());

                            MessageBox.Show("Documento Adicionado!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            //Realizar a alteração do registro
                            var _documentoAlterado = this._documentosDal.Atualizar(this.CriarDocumentosModelAlteracao());

                            MessageBox.Show("Documento Alterado!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private DocumentosModel CriarDocumentosModelAlteracao()
        {
            var _documento = this.CriarDocumentosModel();

            _documento.CodigoDocumento = this._codigoDocumentoAtual;

            return (_documento);
        }

        private DocumentosModel CriarDocumentosModel()
        {
            return (new DocumentosModel()
            {
                CodPessoas = this._codigoPessoaAtual,
                NumeroDocumento = this.textBoxNumeroDocumento.Text,
                TipoDocumento = this.comboBoxTipoDocumento.Items[this.comboBoxTipoDocumento.SelectedIndex].ToString()
            });
        }

        private bool VerificarInformacoesObrigatorias()
        {
            if (this.comboBoxTipoDocumento.SelectedIndex == -1)
            {
                MessageBox.Show("Você deve informar o tipo do documento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            if (string.IsNullOrEmpty(this.textBoxNumeroDocumento.Text))
            {
                MessageBox.Show("Você deve informar o número do documento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            return (true);
        }

        private void buttonCancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void comboBoxTipoDocumento_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.comboBoxTipoDocumento.Items[this.comboBoxTipoDocumento.SelectedIndex].ToString() == TIPO_DOCUMENTO_CPF)
                this.textBoxNumeroDocumento.Mask = MASCARA_TIPO_DOCUMENTO_CPF;
            else
                this.textBoxNumeroDocumento.Mask = string.Empty;
        }
    }
}