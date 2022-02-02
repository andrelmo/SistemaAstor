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
    public class ProblemaSaudeDal: BaseDal, IProblemaSaudeDal
    {
        public void ExcluirTodos(int codPessoa, IDbTransaction transacao)
        {
            //Excluir todos os problemas de saúde relacionados a uma pessoa
            var _cmdExcluir = @"delete from tbProblemaSaude
                                where
                                    codPessoa = @codPessoa";

            transacao.Connection.Execute(_cmdExcluir, new { codPessoa }, transacao, this.TimeoutPadrao, CommandType.Text);
        }

        public List<ProblemaSaudeModel> BuscarTodos(int codPessoa)
        {
            //Busca a lista de problemas associados a uma pessoa
            var _cmdBuscar = @"select *
                               from tbProblemaSaude
                               where
                                   codPessoa = @codPessoa
                               order by codProblemaSaude";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.Query<ProblemaSaudeModel>(_cmdBuscar, 
                                                           new 
                                                           {
                                                               codPessoa
                                                           },
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

        public ProblemaSaudeModel Buscar(int codProblemaSaude)
        {
            //Busca um problema de saúde específico
            var _cmdBuscar = @"select *
                               from tbProblemaSaude
                               where
                                    codProblemaSaude = @codProblemaSaude";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QuerySingleOrDefault<ProblemaSaudeModel>(_cmdBuscar, 
                                                                          new 
                                                                          {
                                                                              codProblemaSaude
                                                                          },
                                                                          null,
                                                                          this.TimeoutPadrao,
                                                                          CommandType.Text));
            }
            finally
            {
                _conexao.Close();
            }
        }

        public void Excluir(int codProblemaSaude)
        {
            //Excluir um problema de saúde específico
            var _cmdExcluir = @"delete from tbProblemaSaude
                                where
                                    codProblemaSaude = @codProblemaSaude";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdExcluir, new { codProblemaSaude }, null, this.TimeoutPadrao, CommandType.Text);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public ProblemaSaudeModel Atualizar(ProblemaSaudeModel problema)
        {
            var DataModificacao = DateTime.Now;

            //Atualizar as informações de saúde da pessoa
            var _cmdAtualizar = @"update tbProblemaSaude
                                  set codPessoa = @CodPessoa,
                                      problemaSaude = @ProblemaSaude,
                                      medicamento = @Medicamento,
                                      local = @Local,
                                      periodicidade = @Periodicidade,
                                      codusuariomodificacao = @CodigoUsuario,
                                      datamodificacao = @DataModificacao
                                  where
                                        codProblemaSaude = @CodProblemaSaude";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());
            
            try
            {
                _conexao.Execute(_cmdAtualizar,
                                 new
                                 {
                                     problema.CodPessoa,
                                     problema.ProblemaSaude,
                                     problema.Medicamento,
                                     problema.Local,
                                     problema.Periodicidade,
                                     SessaoSistema.UsuarioCorrente.CodigoUsuario,
                                     DataModificacao,
                                     problema.CodProblemaSaude
                                 },
                                 null,
                                 this.TimeoutPadrao,
                                 CommandType.Text);

                return (problema);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public ProblemaSaudeModel Adicionar(ProblemaSaudeModel problema)
        {
            var DataCriacao = DateTime.Now;

            //Adicionar um problema de saúde a pessoa
            var _cmdInserir = @"insert into tbProblemaSaude(codPessoa,problemaSaude,medicamento,
                                local,periodicidade,codusuariocriacao,datacriacao) 
                                values (@CodPessoa,@ProblemaSaude,@Medicamento,@Local,@Periodicidade,@CodigoUsuario,@DataCriacao)";
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
                                                      problema.CodPessoa,
                                                      problema.ProblemaSaude,
                                                      problema.Medicamento,
                                                      problema.Local,
                                                      problema.Periodicidade,
                                                      SessaoSistema.UsuarioCorrente.CodigoUsuario,
                                                      DataCriacao
                                                  },
                                                  _transacao, 
                                                  this.TimeoutPadrao, 
                                                  CommandType.Text);
                    problema.CodProblemaSaude = _transacao.Connection.ExecuteScalar<int>(
                        _cmdNovoId, null, _transacao, this.TimeoutPadrao, CommandType.Text);
                    _transacao.Commit();

                    return (problema);
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