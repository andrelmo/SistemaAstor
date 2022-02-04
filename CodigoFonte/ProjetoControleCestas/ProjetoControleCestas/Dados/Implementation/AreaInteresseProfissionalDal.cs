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
    public class AreaInteresseProfissionalDal : BaseDal, IAreaInteresseProfissionalDal
    {
        public void ExcluirTodos(int codPessoas, IDbTransaction transacao)
        {
            //Excluir todas as áreas de interesse profissionais relacionadas a uma pessoa
            var _cmdExcluir = @"delete from tbAreaInteresseProfissional
                                where
                                    codPessoas = @codPessoas";

            transacao.Connection.Execute(_cmdExcluir, new { codPessoas }, transacao, this.TimeoutPadrao, CommandType.Text);
        }

        public List<AreaInteresseProfissionalModel> BuscarTodos(int codPessoas)
        {
            //Busca a lista de áreas de interesse profissionais associados a uma pessoa
            var _cmdBuscar = @"select *
                               from tbAreaInteresseProfissional
                               where
                                   codPessoas = @codPessoas
                               order by codAreaInteresseProfissional";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.Query<AreaInteresseProfissionalModel>(_cmdBuscar,
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

        public AreaInteresseProfissionalModel Buscar(int codAreaInteresseProfissional)
        {
            //Busca uma área de interesse profissional específica
            var _cmdBuscar = @"select *
                               from tbAreaInteresseProfissional
                               where
                                    codAreaInteresseProfissional = @codAreaInteresseProfissional";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QuerySingleOrDefault<AreaInteresseProfissionalModel>(_cmdBuscar,
                                                                          new
                                                                          {
                                                                              codAreaInteresseProfissional
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

        public void Excluir(int codAreaInteresseProfissional)
        {
            //Excluir uma área de interesse profissional específica
            var _cmdExcluir = @"delete from tbAreaInteresseProfissional
                                where
                                    codAreaInteresseProfissional = @codAreaInteresseProfissional";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdExcluir, new { codAreaInteresseProfissional }, null, this.TimeoutPadrao, CommandType.Text);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public AreaInteresseProfissionalModel Atualizar(AreaInteresseProfissionalModel areaInteresseProfissional)
        {
            var DataModificacao = DateTime.Now;

            //Atualizar as informações da área de interesse profissional
            var _cmdAtualizar = @"update tbAreaInteresseProfissional
                                  set codPessoas = @CodPessoas,
                                      areaInteresse = @AreaInteresse,
                                      codusuariomodificacao = @CodigoUsuario,
                                      datamodificacao = @DataModificacao
                                  where
                                        codAreaInteresseProfissional = @CodAreaInteresseProfissional";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdAtualizar,
                                 new
                                 {
                                     areaInteresseProfissional.CodPessoas,
                                     areaInteresseProfissional.AreaInteresse,
                                     SessaoSistema.UsuarioCorrente.CodigoUsuario,
                                     DataModificacao,
                                     areaInteresseProfissional.codAreaInteresseProfissional
                                 },
                                 null,
                                 this.TimeoutPadrao,
                                 CommandType.Text);

                return (areaInteresseProfissional);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public AreaInteresseProfissionalModel Adicionar(AreaInteresseProfissionalModel areaInteresseProfissional)
        {
            var DataCriacao = DateTime.Now;

            //Adicionar uma área de interesse profissional a pessoa
            var _cmdInserir = @"insert into tbAreaInteresseProfissional(codPessoas,areaInteresse,codusuariocriacao,datacriacao) 
                                values (@CodPessoas,@AreaInteresse,@CodigoUsuario,@DataCriacao)";
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
                                                      areaInteresseProfissional.CodPessoas,
                                                      areaInteresseProfissional.AreaInteresse,
                                                      SessaoSistema.UsuarioCorrente.CodigoUsuario,
                                                      DataCriacao
                                                  },
                                                  _transacao,
                                                  this.TimeoutPadrao,
                                                  CommandType.Text);
                    areaInteresseProfissional.codAreaInteresseProfissional = _transacao.Connection.ExecuteScalar<int>(
                        _cmdNovoId, null, _transacao, this.TimeoutPadrao, CommandType.Text);
                    _transacao.Commit();

                    return (areaInteresseProfissional);
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