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
    public class BeneficioDal : BaseDal, IBeneficioDal
    {
        public void ExcluirTodos(int codPessoa, IDbTransaction transacao)
        {
            //Excluir todos os benefícios associados a uma determinada pessoa
            var _cmdExcluir = @"delete from tbBeneficio
                                where
                                     codPessoa = @codPessoa";

            transacao.Connection.Execute(_cmdExcluir, new { codPessoa }, transacao, this.TimeoutPadrao, CommandType.Text);
        }

        public List<BeneficioModel> BuscarBeneficiosPorTipoBeneficio(int codTipoBeneficio)
        {
            //Buscar todos os benefícios associados a um tipo de benefício em específico
            var _cmdBuscar = @"select b.*,
                                      tb.beneficio Beneficio
                               from tbBeneficio b
                               inner join tbTipoBeneficios tb
                                 on b.codTipoBeneficio = tb.codTipoBeneficio
                               where
                                    b.codTipoBeneficio = @codTipoBeneficio
                               order by b.codBeneficio";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.Query<BeneficioModel>(_cmdBuscar, new { codTipoBeneficio }, null, true, this.TimeoutPadrao, CommandType.Text).ToList());
            }
            finally
            {
                _conexao.Close();
            }
        }

        public List<BeneficioModel> BuscarBeneficios(int codPessoa)
        {
            //Busca todos os benefícios associados a uma pessoa
            var _cmdLista = @"select b.*,
                                     tb.beneficio Beneficio
                              from tbBeneficio b
                              inner join tbTipoBeneficios tb
                              on b.codTipoBeneficio = tb.codTipoBeneficio
                              where 
                                  b.codPessoa = @codPessoa";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.Query<BeneficioModel>(_cmdLista, new { codPessoa }, null, true, this.TimeoutPadrao, CommandType.Text).ToList());
            }
            finally
            {
                _conexao.Close();
            }
        }

        public BeneficioModel Buscar(int codBeneficio)
        {
            //Busca um benefício específico
            var _cmdBuscar = @"select b.*,
                                      tb.beneficio Beneficio
                               from tbBeneficio b
                               inner join tbTipoBeneficios tb
                               on b.codTipoBeneficio = tb.codTipoBeneficio
                               where
                                    b.codBeneficio = @codBeneficio";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QuerySingleOrDefault<BeneficioModel>(_cmdBuscar,
                                                                      new
                                                                      {
                                                                          codBeneficio
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

        public void Excluir(int codBeneficio)
        {
            //Excluir um benefício específico
            var _cmdExcluir = @"delete from tbBeneficio
                                where
                                    codBeneficio = @codBeneficio";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdExcluir, new { codBeneficio }, null, this.TimeoutPadrao, CommandType.Text);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public BeneficioModel Atualizar(BeneficioModel beneficio)
        {
            //Atualizar o beneficio
            var _cmdAtualizar = @"update tbBeneficio
                                  set codPessoa = @CodPessoa,
                                      codTipoBeneficio = @CodTipoBeneficio,
                                      valorBeneficio = @ValorBeneficio
                                  where
                                       codBeneficio = @CodBeneficio";

            var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdAtualizar,
                                 new
                                 {
                                     beneficio.CodPessoa,
                                     beneficio.CodTipoBeneficio,
                                     beneficio.ValorBeneficio,
                                     beneficio.CodBeneficio
                                 },
                                 null,
                                 this.TimeoutPadrao,
                                 CommandType.Text);

                return (beneficio);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public BeneficioModel Adicionar(BeneficioModel beneficio)
        {
            //Adicona um novo Beneficio
            var _cmdInserir = @"insert into tbBeneficio (codPessoa,codTipoBeneficio,valorBeneficio)
                                            values (@CodPessoa, @CodTipoBeneficio,@ValorBeneficio)";

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
                                         beneficio.CodPessoa,
                                         beneficio.CodTipoBeneficio,
                                         beneficio.ValorBeneficio
                                     },
                                     _transacao,
                                     this.TimeoutPadrao,
                                     CommandType.Text);

                    beneficio.CodBeneficio = _transacao.Connection.ExecuteScalar<int>(_cmdNovoId,
                        null, _transacao, this.TimeoutPadrao, CommandType.Text);
                    _transacao.Commit();

                    return (beneficio);
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