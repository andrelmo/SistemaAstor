using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Enums;
using ProjetoControleCestas.Modelo;
using System;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormEditarMoradia : Form
    {
        private readonly IMoradiaDal _moradiaDal;
        private readonly ServiceProvider _serviceProvider;
        private MoradiaModel _moradiaEdicao;
        private bool _desabilitarControles;
        private bool _alterandoRegistro;
        private int _codigoMoradiaoAtual;
        private int _codigoFamiliaAtual;

        public FormEditarMoradia(int codigoFamilia, int codigoMoradia = -1)
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._moradiaDal = this._serviceProvider.GetService<IMoradiaDal>();
            this._desabilitarControles = false;
            this._codigoMoradiaoAtual = codigoMoradia;
            this._codigoFamiliaAtual = codigoFamilia;

            if (codigoMoradia != -1)
            {
                this._alterandoRegistro = true;
                this.CarregarMoradia(codigoMoradia);
            }
            else
            {
                this._alterandoRegistro = false;
                this.LimparControles();
            }
        }

        private void CarregarMoradia(int codigoMoradia)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Buscar a moradia que irá ser editada
                this._moradiaEdicao = this._moradiaDal.Buscar(codigoMoradia);

                //Verificar se a moradia não foi encontrado
                if (this._moradiaEdicao == null)
                {
                    MessageBox.Show("A Moradia que você quer editar não foi encontrada!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.textBoxNumeroComodos.Text = this._moradiaEdicao.NumeroComodos.ToString();
            this.textBoxNumeroQuartos.Text = this._moradiaEdicao.NumeroQuartos.ToString();

            if (this._moradiaEdicao.CondicaoMoradia == CondicaoMoradia.Alugada)
                this.radioButtonCondicaoMoradiaAlugada.Checked = true;
            else if (this._moradiaEdicao.CondicaoMoradia == CondicaoMoradia.Cedida)
                this.radioButtonCondicaoMoradiaCedida.Checked = true;
            else
                this.radioButtonCondicaoMoradiaPropria.Checked = true;

            if (this._moradiaEdicao.Banheiro == Banheiro.Coletivo)
                this.radioButtonBanheiroColetivo.Checked = true;
            else if (this._moradiaEdicao.Banheiro == Banheiro.NaoPossui)
                this.radioButtonBanheiroNaoPossui.Checked = true;
            else
                this.radioButtonBanheiroProprio.Checked = true;
        }

        private void LimparControles()
        {
            this.textBoxNumeroComodos.Text = string.Empty;
            this.textBoxNumeroQuartos.Text = string.Empty;
            this.radioButtonCondicaoMoradiaPropria.Checked = true;
            this.radioButtonBanheiroProprio.Checked = true;
        }

        private void HabilitarControles()
        {
            var _habilitarControle = !this._desabilitarControles;

            this.textBoxNumeroComodos.Enabled = _habilitarControle;
            this.textBoxNumeroQuartos.Enabled = _habilitarControle;
            this.groupBoxTipoCondicaoMoradia.Enabled = _habilitarControle;
            this.groupBoxBanheiro.Enabled = _habilitarControle;
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
                            var _moradiaCriada = this._moradiaDal.Adicionar(this.CriarMoradiaModel());

                            MessageBox.Show("Moradia Adicionada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            //Realizar a alteração do registro
                            var _moradiaAlterada = this._moradiaDal.Atualizar(this.CriarMoradiaModelAlteracao());

                            MessageBox.Show("Moradia Alterada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private MoradiaModel CriarMoradiaModelAlteracao()
        {
            var _moradia = this.CriarMoradiaModel();

            _moradia.CodCaracteristicasMoradia = this._codigoMoradiaoAtual;
            _moradia.CodFamilia = this._codigoFamiliaAtual;

            return (_moradia);
        }

        private MoradiaModel CriarMoradiaModel()
        {
            return (new MoradiaModel()
            {
                CodFamilia = this._codigoFamiliaAtual,
                NumeroComodos = Convert.ToByte(this.textBoxNumeroComodos.Text),
                NumeroQuartos = Convert.ToByte(this.textBoxNumeroQuartos.Text),
                Banheiro = this.GetBanheiro(),
                CondicaoMoradia = this.GetCondicaoMoradia()
            });
        }

        private CondicaoMoradia GetCondicaoMoradia()
        {
            if (this.radioButtonCondicaoMoradiaAlugada.Checked)
                return (CondicaoMoradia.Alugada);
            else if (this.radioButtonCondicaoMoradiaCedida.Checked)
                return (CondicaoMoradia.Cedida);
            else
                return (CondicaoMoradia.Propria);
        }

        private Banheiro GetBanheiro()
        {
            if (this.radioButtonBanheiroColetivo.Checked)
                return (Banheiro.Coletivo);
            else if (this.radioButtonBanheiroNaoPossui.Checked)
                return (Banheiro.NaoPossui);
            else
                return (Banheiro.Proprio);
        }

        private bool VerificarInformacoesObrigatorias()
        {
            if (string.IsNullOrEmpty(this.textBoxNumeroComodos.Text))
            {
                MessageBox.Show("Você deve informar o número de cômodos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            if (string.IsNullOrEmpty(this.textBoxNumeroQuartos.Text))
            {
                MessageBox.Show("Você deve informar o número de quartos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            return (true);
        }

        private void buttonCancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void textBoxNumeroComodos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void textBoxNumeroQuartos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
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