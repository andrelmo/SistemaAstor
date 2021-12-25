using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Implementation;
using ProjetoControleCestas.Dados.Interface;
using System;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormLogin : Form
    {
        private readonly IUsuarioDal _usuarioDal;
        private readonly ServiceProvider _serviceProvider;

        public FormLogin()
        {
            InitializeComponent();

            SessaoSistema.Services = new ServiceCollection();
            SessaoSistema.Services.AddTransient<IUsuarioDal,UsuarioDal>();
            SessaoSistema.Services.AddTransient<IAberturaFamiliaDal, AberturaFamiliaDal>();
            SessaoSistema.Services.AddTransient<IBeneficioDal, BeneficioDal>();
            SessaoSistema.Services.AddTransient<IDeficienciaDal, DeficienciaDal>();
            SessaoSistema.Services.AddTransient<IDocumentosDal, DocumentosDal>();
            SessaoSistema.Services.AddTransient<IFaltasDal, FaltasDal>();
            SessaoSistema.Services.AddTransient<IFamiliaDal, FamiliaDal>();
            SessaoSistema.Services.AddTransient<IMoradiaDal, MoradiaDal>();
            SessaoSistema.Services.AddTransient<IPessoasDal, PessoasDal>();
            SessaoSistema.Services.AddTransient<IProblemaSaudeDal, ProblemaSaudeDal>();
            SessaoSistema.Services.AddTransient<IRendaDal, RendaDal>();
            SessaoSistema.Services.AddTransient<ITipoBeneficioDAl, TipoBeneficioDAl>();
            SessaoSistema.Services.AddTransient<IVisitaDal, VisitaDAl>();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._usuarioDal = this._serviceProvider.GetService<IUsuarioDal>();
        }

        private void buttonLogar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBoxLogin.Text))
            {
                MessageBox.Show("Você deve informar o Login!","Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(this.textBoxSenha.Text))
            {
                MessageBox.Show("Você deve informar a Senha!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                //Verificar se o login é válido
                var _resultadoLogin = this._usuarioDal.VerificarLogin(this.textBoxLogin.Text, this.textBoxSenha.Text);

                if (_resultadoLogin.IsErro)
                    MessageBox.Show(_resultadoLogin.MensagemErro,"Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (!_resultadoLogin.IsAutenticado)
                        MessageBox.Show("Login ou Senha Incorretos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                        //Busca o usuário que acabou de fazer o login
                        var _usuarioModel = this._usuarioDal.Buscar(this.textBoxLogin.Text);

                        if (_usuarioModel == null)
                            MessageBox.Show($"Ocorreu um problema no Sistema.Não foi encontrado nenhum registro de Usuário para o Login: {this.textBoxLogin.Text}!", 
                                "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            SessaoSistema.UsuarioCorrente = _usuarioModel;

                            this.Hide();
                            var _formPrincipal = new FormPrincipal();

                            _formPrincipal.Show();
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show($"Ocorreu o seguinte erro ao tentar fazer o Login.Erro: {Ex.Message}","Erro!", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}