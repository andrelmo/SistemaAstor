using Dapper;
using MySql.Data.MySqlClient;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Dto;
using ProjetoControleCestas.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ProjetoControleCestas.Dados.Implementation
{
    public class ListaAreaInteresseProfissionalDal: BaseDal, IListaAreaInteresseProfissionalDal
    {
        private readonly IAreaInteresseProfissionalDal _areaInteresseProfissinalDal;

        public ListaAreaInteresseProfissionalDal(IAreaInteresseProfissionalDal areaInteresseProfissionalDal)
        {
            this._areaInteresseProfissinalDal = areaInteresseProfissionalDal;
        }

        public List<ListaAreaInteresseProfissionalModel> BuscarTodos()
        {
            //Busca a lista de todas as areas de interesse profissinal
            var _cmdListar = @"select *
                               from tbListaAreaInteresseProfissional
                               order by codAreaInteresseProfissional";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.Query<ListaAreaInteresseProfissionalModel>(_cmdListar, commandTimeout: TimeoutPadrao, commandType: CommandType.Text).ToList());
            }
            finally
            {
                _conexao.Close();
            }
        }

        public ListaAreaInteresseProfissionalModel Buscar(int codAreaInteresseProfissional)
        {
            //Buscar uma área de interesse profissional específica
            var _cmdBuscar = @"select *
                               from tbListaAreaInteresseProfissional
                               where
                                    codAreaInteresseProfissional = @codAreaInteresseProfissional";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QuerySingleOrDefault<ListaAreaInteresseProfissionalModel>(_cmdBuscar,
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

        public ResultadoExcluirListaAreaInteresseProfissionalDto Excluir(int codAreaInteresseProfissional)
        {
            //Verificar se esse tipo de benefício está associado a algum benefício em específico
            var _listaBeneficios = this._areaInteresseProfissinalDal.BuscarPorListaAreaInteressProfissional(codAreaInteresseProfissional);

            if (_listaBeneficios.Any())
                return (new ResultadoExcluirListaAreaInteresseProfissionalDto()
                {
                    IsErro = true,
                    IsExcluido = false,
                    MensagemErro = "Essa Lista de Área de Interesse Profissinal não pode ser Excluído porque ele está associada a uma Área de Interesse Profissional!"
                });

            //Excluir o tipo do benefício
            var _cmdExcluir = @"delete from tbListaAreaInteresseProfissional
                                where
                                    codAreaInteresseProfissional = @codAreaInteresseProfissional";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdExcluir, new { codAreaInteresseProfissional }, null, this.TimeoutPadrao, CommandType.Text);

                return (new ResultadoExcluirListaAreaInteresseProfissionalDto()
                {
                    IsErro = false,
                    IsExcluido = true,
                    MensagemErro = string.Empty
                });
            }
            finally
            {
                _conexao.Close();
            }
        }

        public ListaAreaInteresseProfissionalModel Atualizar(ListaAreaInteresseProfissionalModel listaAreaInteresseProfissional)
        {
            var DataModificacao = DateTime.Now;

            //Atualiza a lista de área de interesse profissinal
            var _cmdAtualizar = @"update tbListaAreaInteresseProfissional
                                  set areaInteresse = @areaInteresse,
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
                                     listaAreaInteresseProfissional.AreaInteresse,
                                     SessaoSistema.UsuarioCorrente.CodigoUsuario,
                                     DataModificacao,
                                     listaAreaInteresseProfissional.CodAreaInteresseProfissional
                                 },
                                 null,
                                 this.TimeoutPadrao,
                                 CommandType.Text);

                return (listaAreaInteresseProfissional);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public ListaAreaInteresseProfissionalModel Adicionar(ListaAreaInteresseProfissionalModel listaAreaInteresseProfissional)
        {
            var DataCriacao = DateTime.Now;

            //Adciona um novo tipo de benefício
            var _cmdInserir = @"insert into tbListaAreaInteresseProfissional(areaInteresse,codusuariocriacao,datacriacao) values (@AreaInteresse,@CodigoUsuario,@DataCriacao)";
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
                                                      listaAreaInteresseProfissional.AreaInteresse,
                                                      SessaoSistema.UsuarioCorrente.CodigoUsuario,
                                                      DataCriacao
                                                  },
                                                  _transacao,
                                                  this.TimeoutPadrao,
                                                  CommandType.Text);

                    listaAreaInteresseProfissional.CodAreaInteresseProfissional = _transacao.Connection.ExecuteScalar<int>(_cmdNovoId, null,
                        _transacao, this.TimeoutPadrao, CommandType.Text);
                    _transacao.Commit();

                    return (listaAreaInteresseProfissional);
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