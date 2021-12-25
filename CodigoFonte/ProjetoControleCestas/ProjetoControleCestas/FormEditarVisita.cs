using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using System;
using System.Windows.Forms;

namespace ProjetoControleCestas
{
    public partial class FormEditarVisita : Form
    {
        private readonly IVisitaDal _visitaDal;
        private readonly IUsuarioDal _usuarioDal;
        private readonly ServiceProvider _serviceProvider;
        private VisitaModel _visitaEdicao;
        private bool _desabilitarControles;
        private bool _alterandoRegistro;
        private int _codigoVisitaAtual;
        private int _codigoFamiliaAtual;

        public FormEditarVisita(int codigoFamilia, int codigoVisita = -1)
        {
            InitializeComponent();

            this._serviceProvider = SessaoSistema.Services.BuildServiceProvider();
            this._visitaDal = this._serviceProvider.GetService<IVisitaDal>();
            this._usuarioDal = this._serviceProvider.GetService<IUsuarioDal>();
            this._desabilitarControles = false;
            this._codigoVisitaAtual = codigoVisita;
            this._codigoFamiliaAtual = codigoFamilia;
            this.CarregarListaVoluntarios();

            if (codigoVisita != -1)
            {
                this._alterandoRegistro = true;
                this.CarregarVisita(codigoVisita);
            }
            else
            {
                this._alterandoRegistro = false;
                this.LimparControles();
                this.dateTimePickerDataVisita.Value = DateTime.Today;
            }
        }

        private void CarregarListaVoluntarios()
        {
            var _listaUsuarios = this._usuarioDal.BuscarTodos(Enums.TipoUsuario.Voluntario);

            this.comboBoxVoluntario.DataSource = _listaUsuarios;
        }

        private void CarregarVisita(int codigoVisita)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Buscar a visita que irá ser editada
                this._visitaEdicao = this._visitaDal.Buscar(codigoVisita);

                //Verificar se a visita não foi encontrado
                if (this._visitaEdicao == null)
                {
                    MessageBox.Show("A Visita que você quer editar não foi encontrada!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.comboBoxVoluntario.SelectedValue = this._visitaEdicao.CodVoluntario;
            this.dateTimePickerDataVisita.Value = this._visitaEdicao.DataVisita;
            this.textBoxAlimentacao.Text = this._visitaEdicao.Alimentacao;
            this.textBoxReligiaoPredominante.Text = this._visitaEdicao.ReligiaoPredominante;
            this.textBoxAguaTratada.Text = this._visitaEdicao.AguaTratada;
            this.textBoxEsgotoSanitario.Text = this._visitaEdicao.EsgotoSanitario;
            this.textBoxEnergiaEletrica.Text = this._visitaEdicao.EnergiaEletrica;
            this.textBoxServicosPublicos.Text = this._visitaEdicao.ServicosPublicos;
            this.textBoxMoradia.Text = this._visitaEdicao.Moradia;
            this.textBoxHigieneLimpeza.Text = this._visitaEdicao.HigieneLimpeza;
            this.textBoxRelacaoFamiliar.Text = this._visitaEdicao.RelacaoFamiliar;
            this.textBoxConfinamento.Text = this._visitaEdicao.Confinamento;
            this.textBoxObservacoes.Text = this._visitaEdicao.Observacoes;
        }

        private void LimparControles()
        {
            this.comboBoxVoluntario.SelectedIndex = -1;
            this.dateTimePickerDataVisita.Value = DateTime.Today;
            this.textBoxAlimentacao.Text = string.Empty;
            this.textBoxReligiaoPredominante.Text = string.Empty;
            this.textBoxAguaTratada.Text = string.Empty;
            this.textBoxEsgotoSanitario.Text = string.Empty;
            this.textBoxEnergiaEletrica.Text = string.Empty;
            this.textBoxServicosPublicos.Text = string.Empty;
            this.textBoxMoradia.Text = string.Empty;
            this.textBoxHigieneLimpeza.Text = string.Empty;
            this.textBoxRelacaoFamiliar.Text = string.Empty;
            this.textBoxConfinamento.Text = string.Empty;
            this.textBoxObservacoes.Text = string.Empty;
        }

        private void HabilitarControles()
        {
            var _habilitarControle = !this._desabilitarControles;

            this.comboBoxVoluntario.Enabled = _habilitarControle;
            this.dateTimePickerDataVisita.Enabled = _habilitarControle;
            this.textBoxAlimentacao.Enabled = _habilitarControle;
            this.textBoxReligiaoPredominante.Enabled = _habilitarControle;
            this.textBoxAguaTratada.Enabled = _habilitarControle;
            this.textBoxEsgotoSanitario.Enabled = _habilitarControle;
            this.textBoxEnergiaEletrica.Enabled = _habilitarControle;
            this.textBoxServicosPublicos.Enabled = _habilitarControle;
            this.textBoxMoradia.Enabled = _habilitarControle;
            this.textBoxHigieneLimpeza.Enabled = _habilitarControle;
            this.textBoxRelacaoFamiliar.Enabled = _habilitarControle;
            this.textBoxConfinamento.Enabled = _habilitarControle;
            this.textBoxObservacoes.Enabled = _habilitarControle;
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
                            var _visitaCriada = this._visitaDal.Adicionar(this.CriarVisitaModel());

                            MessageBox.Show("Visita Adicionada!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            //Realizar a alteração do registro
                            var _visitaAlterado = this._visitaDal.Atualizar(this.CriarVisitaModelAlteracao());

                            MessageBox.Show("Visita Alterado!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private VisitaModel CriarVisitaModelAlteracao()
        {
            var _visita = this.CriarVisitaModel();

            _visita.CodigoVisita = this._codigoVisitaAtual;
            _visita.CodFamilia = this._codigoFamiliaAtual;

            return (_visita);
        }

        private VisitaModel CriarVisitaModel()
        {
            return (new VisitaModel()
            {
                AguaTratada = this.textBoxAguaTratada.Text,
                Alimentacao = this.textBoxAlimentacao.Text,
                CodFamilia = this._codigoFamiliaAtual,
                CodVoluntario = Convert.ToInt32(this.comboBoxVoluntario.SelectedValue),
                Confinamento = this.textBoxConfinamento.Text,
                DataVisita = dateTimePickerDataVisita.Value,
                EnergiaEletrica = this.textBoxEnergiaEletrica.Text,
                EsgotoSanitario = this.textBoxEsgotoSanitario.Text,
                HigieneLimpeza = this.textBoxHigieneLimpeza.Text,
                Moradia = this.textBoxMoradia.Text,
                Observacoes = this.textBoxObservacoes.Text,
                RelacaoFamiliar = this.textBoxRelacaoFamiliar.Text,
                ReligiaoPredominante = this.textBoxReligiaoPredominante.Text,
                ServicosPublicos = this.textBoxServicosPublicos.Text
            });
        }

        private bool VerificarInformacoesObrigatorias()
        {
            if (this.comboBoxVoluntario.SelectedIndex == -1)
            {
                MessageBox.Show("Você deve informar o voluntário!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return (false);
            }

            if (string.IsNullOrEmpty(this.textBoxAlimentacao.Text))
            {
                MessageBox.Show("Você deve informar a alimentação!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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