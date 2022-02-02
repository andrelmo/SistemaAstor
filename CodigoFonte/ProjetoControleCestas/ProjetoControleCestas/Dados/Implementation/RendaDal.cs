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
    public class RendaDal : BaseDal, IRendaDal
    {
        public void ExcluirTodos(int codPessoas, IDbTransaction transacao)
        {
            //Excluir todos os registros de rendas associados a pessoa
            var _cmdExcluir = @"delete from tbRenda
                                where
                                    codPessoas = @codPessoas";

            transacao.Connection.Execute(_cmdExcluir, new { codPessoas }, transacao, this.TimeoutPadrao, CommandType.Text);
        }

        public bool TemRenda(int codPessoas)
        {
            //Verificar se a pessoa tem renda registrada
            var _cmdVerificar = @"select count(*)
                                  from tbRenda
                                  where
                                       codPessoas = @codPessoas";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.ExecuteScalar<int>(_cmdVerificar, new { codPessoas }, null, this.TimeoutPadrao, CommandType.Text) >= 1);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public List<RendaModel> BuscarTodos(int codPessoas)
        {
            //Buscar Todas as rendas associadas a uma pessoa específica
            var _cmdBuscarTodos = @"select *
                                    from tbRenda
                                    where
                                         codPessoas = @codPessoas
                                    order by codRenda";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.Query<RendaModel>(_cmdBuscarTodos, new { codPessoas }, null, true, this.TimeoutPadrao, CommandType.Text).ToList());
            }
            finally
            {
                _conexao.Close();
            }
        }

        public RendaModel Buscar(int codRenda)
        {
            //Buscar um registro de renda específico
            var _cmdBuscar = @"select *
                               from tbRenda
                               where
                                    codRenda = @codRenda";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QuerySingleOrDefault<RendaModel>(_cmdBuscar, new { codRenda }, null, this.TimeoutPadrao, CommandType.Text));
            }
            finally
            {
                _conexao.Close();
            }
        }

        public void Excluir(int codRenda)
        {
            //Excluir uma renda
            var _cmdExcluir = @"delete from tbRenda
                                where
                                    codRenda = @codRenda";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdExcluir, new { codRenda }, null, this.TimeoutPadrao, CommandType.Text);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public RendaModel Atualizar(RendaModel renda)
        {
            var DataModificacao = DateTime.Now;

            //Atualizar as informações de renda
            var _cmdAtualizar = @"update tbRenda 
                                  set codPessoas = @CodPessoas,
                                      renda = @Renda,
                                      valorRenda = @ValorRenda,
                                      codusuariomodificacao = @CodigoUsuario,
                                      datamodificacao = @DataModificacao
                                  where
                                       codRenda = @CodRenda";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdAtualizar,
                                 new
                                 {
                                     renda.CodPessoas,
                                     renda.Renda,
                                     renda.ValorRenda,
                                     SessaoSistema.UsuarioCorrente.CodigoUsuario,
                                     DataModificacao,
                                     renda.CodRenda
                                 },
                                 null,
                                 this.TimeoutPadrao,
                                 CommandType.Text);

                return (renda);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public RendaModel Adicionar(RendaModel renda)
        {
            var DataCriacao = DateTime.Now;

            //Adicionar uma nova renda
            var _cmdInserir = @"insert into tbRenda(codPessoas,renda,valorRenda,codusuariocriacao,datacriacao) values (@CodPessoas,@Renda,@ValorRenda,@CodigoUsuario,@DataCriacao)";
            var _cmdNovoId = "select last_insert_id();";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Open();

                var _transacao = _conexao.BeginTransaction();

                try
                {
                    _transacao.Connection.Execute(_cmdInserir,
                                                  new
                                                  {
                                                      renda.CodPessoas,
                                                      renda.Renda,
                                                      renda.ValorRenda,
                                                      SessaoSistema.UsuarioCorrente.CodigoUsuario,
                                                      DataCriacao
                                                  },
                                                  _transacao,
                                                  this.TimeoutPadrao,
                                                  CommandType.Text);
                    renda.CodRenda = _transacao.Connection.ExecuteScalar<int>(_cmdNovoId, null, _transacao, this.TimeoutPadrao, CommandType.Text);
                    _transacao.Commit();

                    return (renda);
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