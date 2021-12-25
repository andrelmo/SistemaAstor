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
    public class DeficienciaDal : BaseDal, IDeficienciaDal
    {
        public void ExcluirTodos(int codPessoa, IDbTransaction transacao)
        {
            //Excluir todas as deficiêncas de uma pessoa em específico
            var _cmdExcluir = @"delete from tbDeficiencia
                                where
                                   codPessoa = @codPessoa";

            transacao.Connection.Execute(_cmdExcluir,new {codPessoa}, transacao,this.TimeoutPadrao,CommandType.Text);
        }

        public List<DeficienciaModel> BuscarTodos(int codPessoa)
        {
            //Busca a lista de todas as deficiências de uma pessoa em específico
            var _cmdBuscar = @"select *
                               from tbDeficiencia
                               where
                                    codPessoa = @codPessoa
                               order by codDeficiencia";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.Query<DeficienciaModel>(_cmdBuscar,
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

        public void Excluir(int codDeficiencia)
        {
            //Excluir uma deficiência
            var _cmdExcluir = @"delete from tbDeficiencia
                                where
                                    codDeficiencia = @codDeficiencia";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdExcluir,
                                 new
                                 {
                                     codDeficiencia
                                 },
                                 null,
                                 this.TimeoutPadrao,
                                 CommandType.Text);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public DeficienciaModel Buscar(int codDeficiencia)
        {
            //Busca uma deficiência
            var _cmdBuscar = @"select *
                               from tbDeficiencia
                               where
                                   codDeficiencia = @codDeficiencia";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QuerySingleOrDefault<DeficienciaModel>(_cmdBuscar,
                                                                        new
                                                                        {
                                                                            codDeficiencia
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

        public DeficienciaModel Atualizar(DeficienciaModel deficiencia)
        {
            //Atualizar uma deficiência associada a uma pessoa
            var _cmdAtualizar = @"update tbDeficiencia
                                  set codPessoa = @CodPessoa,
                                      deficiencia = @Deficiencia
                                  where
                                        codDeficiencia = @CodDeficiencia";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdAtualizar,
                                 new
                                 {
                                     deficiencia.CodPessoa,
                                     deficiencia.Deficiencia,
                                     deficiencia.CodDeficiencia
                                 },
                                 null,
                                 this.TimeoutPadrao,
                                 CommandType.Text);

                return (deficiencia);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public DeficienciaModel Adicionar(DeficienciaModel deficiencia)
        {
            //Adiciona uma nova deficieência
            var _cmdInserir = @"insert into tbDeficiencia(codPessoa,deficiencia) values (@CodPessoa,@Deficiencia)";
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
                                                      deficiencia.CodPessoa,
                                                      deficiencia.Deficiencia
                                                  },
                                                  _transacao,
                                                  this.TimeoutPadrao,
                                                  CommandType.Text);
                    deficiencia.CodDeficiencia = _transacao.Connection.ExecuteScalar<int>(
                        _cmdNovoId, null, _transacao, this.TimeoutPadrao, CommandType.Text);
                    _transacao.Commit();

                    return (deficiencia);
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