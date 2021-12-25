using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Enums;
using ProjetoControleCestas.Modelo;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormEditarUsuario : Form
    {
        private readonly IUsuarioDal _usuarioDal;
        private readonly ServiceProvider _serviceProvider;
        private UsuarioModel _usuarioEdicao;
        private bool _desabilitarControles;
        private bool _usuarioSistema;
        private bool _alterandoRegistro;
        private int _codigoUsuarioAtual;

        public FormEditarUsuario(int codigoUsuario = -1)
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._usuarioDal = this._serviceProvider.GetService<IUsuarioDal>();
            this._desabilitarControles = false;
            this._usuarioSistema = false;
            this._codigoUsuarioAtual = codigoUsuario;

            if (codigoUsuario != -1)
            {
                this._alterandoRegistro = true;
                this.CarregarUsuario(codigoUsuario);
            }
            else
            {
                this._alterandoRegistro = false;
                this.LimparControles();
            }
        }

        private void CarregarUsuario(int codigoUsuario)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Buscar o usuário que irá ser editado
                this._usuarioEdicao = this._usuarioDal.Buscar(codigoUsuario);

                //Verificar se o usuário não foi encontrado
                if (this._usuarioEdicao == null)
                {
                    MessageBox.Show("O Usuário que você quer editar não foi encontrado!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.textBoxNome.Text = this._usuarioEdicao.Nome;
            this.textBoxEndereco.Text = this._usuarioEdicao.Endereco;
            this.textBoxBairro.Text = this._usuarioEdicao.Bairro;
            this.textBoxCidade.Text = this._usuarioEdicao.Cidade;

            var _posicao = this.comboBoxEstado.FindString(this._usuarioEdicao.Estado);

            if (_posicao != -1)
                this.comboBoxEstado.SelectedIndex = _posicao;
            else
                this.comboBoxEstado.SelectedIndex = -1;

            this.textBoxCep.Text = this._usuarioEdicao.Cep;
            this.textBoxTelefone.Text = this._usuarioEdicao.Telefone;
            this.textBoxEmail.Text = this._usuarioEdicao.Email;
            this.textBoxLogin.Text = this._usuarioEdicao.Login;
            this.textBoxSenha.Text = this._usuarioEdicao.Senha;

            this.Text = "Editar Usuario";
            this._usuarioSistema = false;

            if (this._usuarioEdicao.TipoUsuario == Enums.TipoUsuario.Colaborador)
            {
                this.radioButtonTipoUsuarioColaborador.Checked = true;
                this._desabilitarControles = false;
            }
            else if (this._usuarioEdicao.TipoUsuario == Enums.TipoUsuario.Voluntario)
            {
                this.radioButtonTipoUsuarioVoluntario.Checked = true;
                this._desabilitarControles = false;
            }
            else
            {
                this.Text += " (Sistema)";
                this._desabilitarControles = true;
                this._usuarioSistema = true;
                this.radioButtonTipoUsuarioSistema.Checked = true;
            }

            if (this._usuarioEdicao.Status == Constantes.ConstantesGlobais.STATUS_ATIVO)
                this.radioButtonStatusAtivo.Checked = true;
            else
                this.radioButtonStatusInativo.Checked = true;
        }

        private void LimparControles()
        {
            this.textBoxNome.Text = string.Empty;
            this.textBoxEndereco.Text = string.Empty;
            this.textBoxBairro.Text = string.Empty;
            this.textBoxCidade.Text = string.Empty;
            this.comboBoxEstado.SelectedIndex = -1;
            this.textBoxCep.Text = string.Empty;
            this.textBoxTelefone.Text = string.Empty;
            this.textBoxEmail.Text = string.Empty;
            this.textBoxLogin.Text = string.Empty;
            this.textBoxSenha.Text = string.Empty;
            this.radioButtonTipoUsuarioColaborador.Checked = true;
            this.radioButtonStatusAtivo.Checked = true;
        }

        private void HabilitarControles()
        {
            var _habilitarControle = !this._desabilitarControles;

            this.textBoxNome.Enabled = _habilitarControle;
            this.textBoxEndereco.Enabled = _habilitarControle;
            this.textBoxBairro.Enabled = _habilitarControle;
            this.textBoxCidade.Enabled = _habilitarControle;
            this.comboBoxEstado.Enabled = _habilitarControle;
            this.textBoxCep.Enabled = _habilitarControle;
            this.textBoxTelefone.Enabled = _habilitarControle;
            this.textBoxEmail.Enabled = _habilitarControle;
            this.groupBoxTipoUsuario.Enabled = _habilitarControle;
            this.groupBoxStatus.Enabled = _habilitarControle;
            this.textBoxLogin.Enabled = _habilitarControle;
            this.textBoxSenha.Enabled = _habilitarControle;
        }

        private void buttonSalvar_Click(object sender, System.EventArgs e)
        {
            //Verifica se o registro atual não é de um Usuário de Sistema
            if (!this._usuarioSistema)
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
                                //Verificar se o login já existe
                                if (this._usuarioDal.Buscar(this.textBoxLogin.Text) != null)
                                    MessageBox.Show("O Login informado já está em uso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                else
                                {
                                    //Realizar a inserção do registro
                                    var _usuarioCriado = this._usuarioDal.Adicionar(this.CriarUsuarioModel());

                                    MessageBox.Show("Usuário Adicionado!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                            else
                            {
                                //Verifica se o login informado já existe para outro usuário diferente do usuário que está sendo alterado
                                if (this._usuarioDal.Buscar(this.textBoxLogin.Text, this._codigoUsuarioAtual) != null)
                                    MessageBox.Show("O Login informado já está em uso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                else
                                {
                                    //Realizar a alteração do registro
                                    var _usuarioAlterado = this._usuarioDal.Atualizar(this.CriarUsuarioModelAlteracao());

                                    MessageBox.Show("Usuário Alterado!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            else
                this.Close();
        }

        private UsuarioModel CriarUsuarioModelAlteracao()
        {
            var _usuario = this.CriarUsuarioModel();

            _usuario.CodigoUsuario = this._codigoUsuarioAtual;
            _usuario.DataCriacao = this._usuarioEdicao.DataCriacao;

            return (_usuario);
        }

        private UsuarioModel CriarUsuarioModel()
        {
            return (new UsuarioModel()
            {
                Bairro = this.textBoxBairro.Text,
                Cep = this.textBoxCep.Text,
                Cidade = this.textBoxCidade.Text,
                Email = this.textBoxEmail.Text,
                Endereco = this.textBoxEndereco.Text,
                Estado = this.comboBoxEstado.Items[this.comboBoxEstado.SelectedIndex].ToString(),
                Login = this.textBoxLogin.Text,
                Nome = this.textBoxNome.Text,
                Senha = this.textBoxSenha.Text,
                Status = this.GetValorStatus(),
                Telefone = this.textBoxTelefone.Text,
                TipoUsuario = this.GetTipoUsuario()
            });
        }

        private string GetValorStatus()
        {
            if (this.radioButtonStatusAtivo.Checked)
                return (Constantes.ConstantesGlobais.STATUS_ATIVO);

            return (Constantes.ConstantesGlobais.STATUS_INATIVO);
        }

        private TipoUsuario GetTipoUsuario()
        {
            if (this.radioButtonTipoUsuarioColaborador.Checked)
                return (TipoUsuario.Colaborador);
            else if (this.radioButtonTipoUsuarioVoluntario.Checked)
                return (TipoUsuario.Voluntario);

            return (TipoUsuario.Sistema);
        }

        private bool VerificarInformacoesObrigatorias()
        {
            if (string.IsNullOrEmpty(this.textBoxNome.Text))
            {
                MessageBox.Show("Você deve informar o nome!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            if (string.IsNullOrEmpty(this.textBoxEndereco.Text))
            {
                MessageBox.Show("Você deve informar o endereço!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            if (string.IsNullOrEmpty(this.textBoxBairro.Text))
            {
                MessageBox.Show("Você deve informar o bairro!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            if (string.IsNullOrEmpty(this.textBoxCidade.Text))
            {
                MessageBox.Show("Você deve informar a cidade!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }


            if (string.IsNullOrEmpty(this.textBoxCep.Text))
            {
                MessageBox.Show("Você deve informar o cep!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            if (this.comboBoxEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Você deve informar o estado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            if (string.IsNullOrEmpty(this.textBoxEmail.Text))
            {
                MessageBox.Show("Você deve informar o e-mail!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            if (string.IsNullOrEmpty(this.textBoxTelefone.Text))
            {
                MessageBox.Show("Você deve informar o telefone!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            if (string.IsNullOrEmpty(this.textBoxLogin.Text))
            {
                MessageBox.Show("Você deve informar o login!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            if (string.IsNullOrEmpty(this.textBoxSenha.Text))
            {
                MessageBox.Show("Você deve informar a senha!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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