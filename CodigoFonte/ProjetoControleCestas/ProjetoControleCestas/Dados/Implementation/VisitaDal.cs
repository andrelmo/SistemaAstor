using Dapper;
using MySql.Data.MySqlClient;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ProjetoControleCestas.Dados.Implementation
{
    public class VisitaDAl : BaseDal, IVisitaDal
    {
        public List<VisitaModel> BuscarTodos(int codFamilia)
        {
            //Buscar todas as visitas associadas a uma família
            var _cmdBuscar = @"select *,
                                      u.nome Voluntario
                               from tbVisita v
                               inner join tbUsuario u
                               on v.codVoluntario = u.codigoUsuario
                               where
                                    codFamilia = @codFamilia
                               order by codigoVisita";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.Query<VisitaModel>(_cmdBuscar, 
                                                    new { codFamilia },
                                                    null,
                                                    true,
                                                    this.TimeoutPadrao,
                                                    CommandType.Text).ToList());
            }
            finally
            {
                _conexao.Close();
            }
        }

        public VisitaModel Buscar(int codigoVisita)
        {
            //Buscar uma determinada visita
            var _cmdBuscar = @"select *,
                                      u.nome Voluntario
                               from tbVisita v
                               inner join tbUsuario u
                               on v.codVoluntario = u.codigoUsuario
                               where
                                    codigoVisita = @codigoVisita";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QuerySingleOrDefault<VisitaModel>(_cmdBuscar, 
                                                                  new { codigoVisita },
                                                                  null,
                                                                  this.TimeoutPadrao,
                                                                  CommandType.Text));
            }
            finally
            {
                _conexao.Close();
            }
        }

        public void Excluir(int codigoVisita)
        {
            //Excluir uma determinada visita
            var _cmdExcluir = @"delete from tbVisita
                                where
                                    codigoVisita = @codigoVisita";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdExcluir, new { codigoVisita }, null, this.TimeoutPadrao, CommandType.Text);
            }
            finally
            {
                _conexao.Close();                
            }
        }

        public void ExcluirTodos(int codFamilia, IDbTransaction transacao)
        { 
            //Excluir todas as visita relacionadas a uma familia
            var _cmdExcluir = @"delete from tbVisita 
                                where
                                    codFamilia = @codFamilia";
            transacao.Connection.Execute(_cmdExcluir, new { codFamilia }, transacao, this.TimeoutPadrao, CommandType.Text);
        }

        public VisitaModel Atualizar(VisitaModel visita)
        {
            var DataModificacao = DateTime.Now;

            //Atualizar as informações de uma visita
            var _cmdAtualizar = @"update tbVisita
                                  set codFamilia = @CodFamilia,
                                      codVoluntario = @CodVoluntario,
                                      dataVisita = @DataVisita,
                                      alimentacao = @Alimentacao,
                                      religiaoPredominante = @ReligiaoPredominante,
                                      aguaTratada = @AguaTratada,
                                      esgotoSanitario = @EsgotoSanitario,
                                      energiaEletrica = @EnergiaEletrica,
                                      servicosPublicos = @ServicosPublicos,
                                      moradia = @Moradia,
                                      higieneLimpeza = @HigieneLimpeza,
                                      relacaoFamiliar = @RelacaoFamiliar,
                                      confinamento = @Confinamento,
                                      observacoes = @Observacoes,
                                      codusuariomodificacao = @CodigoUsuario,
                                      datamodificacao = @DataModificacao
                                 where
                                      codigoVisita = @CodigoVisita";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());
            var DataVisita = visita.DataVisita.ToString(Constantes.ConstantesGlobais.FROMATAR_DATA_HORA_MYSQL);

            try
            {
                _conexao.Execute(_cmdAtualizar,
                                 new
                                 {
                                     visita.CodFamilia,
                                     visita.CodVoluntario,
                                     DataVisita,
                                     visita.Alimentacao,
                                     visita.ReligiaoPredominante,
                                     visita.AguaTratada,
                                     visita.EsgotoSanitario,
                                     visita.EnergiaEletrica,
                                     visita.ServicosPublicos,
                                     visita.Moradia,
                                     visita.HigieneLimpeza,
                                     visita.RelacaoFamiliar,
                                     visita.Confinamento,
                                     visita.Observacoes,
                                     SessaoSistema.UsuarioCorrente.CodigoUsuario,
                                     DataModificacao,
                                     visita.CodigoVisita
                                 },
                                 null,
                                 this.TimeoutPadrao,
                                 CommandType.Text);
                return (visita);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public VisitaModel Adicionar(VisitaModel visita)
        {
            var DataCriacao = DateTime.Now;

            //Adiciona uma nova visita
            var _cmdInserir = @"insert into tbVisita (codFamilia,codVoluntario,dataVisita,alimentacao,
                                                      religiaoPredominante,aguaTratada,esgotoSanitario,
                                                      energiaEletrica,servicosPublicos,moradia,
                                                      higieneLimpeza,relacaoFamiliar,confinamento,observacoes,codusuariocriacao,datacriacao) 
                                values (@CodFamilia,@CodVoluntario,@DataVisita,@Alimentacao,
                                        @ReligiaoPredominante,@AguaTratada,@EsgotoSanitario,
                                        @EnergiaEletrica,@ServicosPublicos,@Moradia,
                                        @HigieneLimpeza,@RelacaoFamiliar,@Confinamento,@Observacoes,@CodigoUsuario,@DataCriacao)";
            var _cmdNovoId = "select last_insert_id();";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Open();

                using var _transacao = _conexao.BeginTransaction();

                try
                {
                    _transacao.Connection.Execute(_cmdInserir,
                                                  new
                                                  {
                                                      visita.CodFamilia,
                                                      visita.CodVoluntario,
                                                      visita.DataVisita,
                                                      visita.Alimentacao,
                                                      visita.ReligiaoPredominante,
                                                      visita.AguaTratada,
                                                      visita.EsgotoSanitario,
                                                      visita.EnergiaEletrica,
                                                      visita.ServicosPublicos,
                                                      visita.Moradia,
                                                      visita.HigieneLimpeza,
                                                      visita.RelacaoFamiliar,
                                                      visita.Confinamento,
                                                      visita.Observacoes,
                                                      SessaoSistema.UsuarioCorrente.CodigoUsuario,
                                                      DataCriacao
                                                  },
                                                  _transacao,
                                                  this.TimeoutPadrao,
                                                  CommandType.Text);

                    visita.CodigoVisita = _transacao.Connection.ExecuteScalar<int>(
                        _cmdNovoId, null, _transacao, this.TimeoutPadrao, CommandType.Text);

                    _transacao.Commit();

                    return (visita);
                }
                catch (Exception)
                {
                    _transacao.Rollback();
                    throw;
                }
            }
            finally
            {
                _conexao.Close();
            }
        }
    }
}