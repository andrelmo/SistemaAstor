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
    public class AtividadeDesenvolvidaDal: BaseDal, IAtividadeDesenvolvidaDal
    {
        public void ExcluirTodos(int codPessoas, IDbTransaction transacao)
        {
            //Excluir todas as atividades desenvolvidas relacionadas a uma pessoa
            var _cmdExcluir = @"delete from tbAtividadeDesenvolvida
                                where
                                    codPessoas = @codPessoas";

            transacao.Connection.Execute(_cmdExcluir, new { codPessoas }, transacao, this.TimeoutPadrao, CommandType.Text);
        }

        public List<AtividadeDesenvolvidaModel> BuscarTodos(int codPessoas)
        {
            //Busca a lista de atividades desenvolvidas associados a uma pessoa
            var _cmdBuscar = @"select *
                               from tbAtividadeDesenvolvida
                               where
                                   codPessoas = @codPessoas
                               order by codAtividadeDesenvolvida";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.Query<AtividadeDesenvolvidaModel>(_cmdBuscar,
                                                           new
                                                           {
                                                               codPessoas
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

        public AtividadeDesenvolvidaModel Buscar(int codAtividadeDesenvolvida)
        {
            //Busca uma atividade desenvolvida específica
            var _cmdBuscar = @"select *
                               from tbAtividadeDesenvolvida
                               where
                                    codAtividadeDesenvolvida = @codAtividadeDesenvolvida";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QuerySingleOrDefault<AtividadeDesenvolvidaModel>(_cmdBuscar,
                                                                          new
                                                                          {
                                                                              codAtividadeDesenvolvida
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

        public void Excluir(int codAtividadeDesenvolvida)
        {
            //Excluir uma atividade desenvolvida específica
            var _cmdExcluir = @"delete from tbAtividadeDesenvolvida
                                where
                                    codAtividadeDesenvolvida = @codAtividadeDesenvolvida";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdExcluir, new { codAtividadeDesenvolvida }, null, this.TimeoutPadrao, CommandType.Text);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public AtividadeDesenvolvidaModel Atualizar(AtividadeDesenvolvidaModel atividadeDesenvolvida)
        {
            var DataModificacao = DateTime.Now;

            //Atualizar as informações da atividade desenvolvida
            var _cmdAtualizar = @"update tbAtividadeDesenvolvida
                                  set codPessoas = @CodPessoas,
                                      atividade = @Atividade,
                                      codusuariomodificacao = @CodigoUsuario,
                                      datamodificacao = @DataModificacao
                                  where
                                        codAtividadeDesenvolvida = @CodAtividadeDesenvolvida";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdAtualizar,
                                 new
                                 {
                                     atividadeDesenvolvida.CodPessoas,
                                     atividadeDesenvolvida.Atividade,
                                     SessaoSistema.UsuarioCorrente.CodigoUsuario,
                                     DataModificacao,
                                     atividadeDesenvolvida.codAtividadeDesenvolvida
                                 },
                                 null,
                                 this.TimeoutPadrao,
                                 CommandType.Text);

                return (atividadeDesenvolvida);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public AtividadeDesenvolvidaModel Adicionar(AtividadeDesenvolvidaModel atividadeDesenvolvida)
        {
            var DataCriacao = DateTime.Now;

            //Adicionar uma atividade desenvolvida a pessoa
            var _cmdInserir = @"insert into tbAtividadeDesenvolvida(codPessoas,atividade,codusuariocriacao,datacriacao) 
                                values (@CodPessoas,@Atividade,@CodigoUsuario,@DataCriacao)";
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
                                                      atividadeDesenvolvida.CodPessoas,
                                                      atividadeDesenvolvida.Atividade,
                                                      SessaoSistema.UsuarioCorrente.CodigoUsuario,
                                                      DataCriacao
                                                  },
                                                  _transacao,
                                                  this.TimeoutPadrao,
                                                  CommandType.Text);
                    atividadeDesenvolvida.codAtividadeDesenvolvida = _transacao.Connection.ExecuteScalar<int>(
                        _cmdNovoId, null, _transacao, this.TimeoutPadrao, CommandType.Text);
                    _transacao.Commit();

                    return (atividadeDesenvolvida);
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