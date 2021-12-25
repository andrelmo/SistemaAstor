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
    public class FaltasDal: BaseDal, IFaltasDal
    {
        public bool TemFalta(int codigoAberturaFamilia)
        {
            //Verificar se exite falta associado a abertura de família
            var _cmdVerificar = @"select count(*)
                                  from tbFaltas
                                  where
                                       codigoAberturaFamilia = @codigoAberturaFamilia";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.ExecuteScalar<int>(_cmdVerificar, new { codigoAberturaFamilia }, null, this.TimeoutPadrao, CommandType.Text) >= 1);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public List<FaltasModel> BuscarTodos(int codigoAberturaFamilia)
        {
            //Buscar todas as faltas associadas a uma abertura de família
            var _cmdBuscarTodos = @"select *
                                    from tbFaltas
                                    where
                                         codigoAberturaFamilia = @codigoAberturaFamilia
                                    order by codigoFaltas";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.Query<FaltasModel>(_cmdBuscarTodos, new { codigoAberturaFamilia}, null, true, this.TimeoutPadrao, CommandType.Text).ToList());
            }
            finally
            {
                _conexao.Close();
            }
        }

        public FaltasModel Buscar(int codigoFaltas)
        {
            //Buscar um registro de Faltas
            var _cmdBuscar = @"select *
                               from tbFaltas
                               where
                                   codigoFaltas = @codigoFaltas";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QuerySingleOrDefault<FaltasModel>(_cmdBuscar, new { codigoFaltas }, null, this.TimeoutPadrao, CommandType.Text));
            }
            finally
            {
                _conexao.Close();
            }
        }

        public void Excluir(int codigoFaltas)
        {
            //Excluir um registro de faltas
            var _cmdExcluir = @"delete from tbFaltas
                                where
                                     codigoFaltas = @codigoFaltas";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdExcluir, new { codigoFaltas }, null, this.TimeoutPadrao, CommandType.Text);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public FaltasModel Atualizar(FaltasModel faltas)
        {
            //Atualizar uma falta
            var _cmdAtualizar = @"update tbFaltas
                                  set codigoAberturaFamilia = @CodigoAberturaFamilia,
                                      dataFalta = @DataFalta,
                                      justificativa = @Justificativa
                                  where
                                       codigoFaltas = @CodigoFaltas";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdAtualizar, 
                                 new 
                                 {
                                     faltas.CodigoAberturaFamilia,
                                     faltas.DataFalta,
                                     faltas.Justificativa,
                                     faltas.CodigoFaltas
                                 }, 
                                 null, 
                                 this.TimeoutPadrao, 
                                 CommandType.Text);

                return (faltas);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public FaltasModel Adicionar(FaltasModel faltas)
        {
            //Adicionar uma nova falta ao cadastro de abertura de família
            var _cmdInserir = @"insert into tbFaltas (codigoAberturaFamilia,dataFalta,justificativa) 
                                              values (@CodigoAberturaFamilia,@DataFalta,@Justificativa)";
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
                                                      faltas.CodigoAberturaFamilia,
                                                      faltas.DataFalta,
                                                      faltas.Justificativa
                                                  }, 
                                                  _transacao, 
                                                  this.TimeoutPadrao, 
                                                  CommandType.Text);

                    faltas.CodigoFaltas = _transacao.Connection.ExecuteScalar<int>(_cmdNovoId, null, _transacao, this.TimeoutPadrao, CommandType.Text);
                    _transacao.Commit();

                    return (faltas);
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