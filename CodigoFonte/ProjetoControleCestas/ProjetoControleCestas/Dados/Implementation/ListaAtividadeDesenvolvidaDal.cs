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
    public class ListaAtividadeDesenvolvidaDal: BaseDal, IListaAtividadeDesenvolvidaDal
    {
        private readonly IAreaInteresseProfissionalDal _atividadeDesenvolvidaDal;

        public ListaAtividadeDesenvolvidaDal(IAreaInteresseProfissionalDal atividadeDesenvolvidaDal)
        {
            this._atividadeDesenvolvidaDal = atividadeDesenvolvidaDal;
        }

        public List<ListaAtividadeDesenvolvidaModel> BuscarTodos()
        {
            //Busca a lista de todas as atividades desenvolvidas
            var _cmdListar = @"select *
                               from tbListaAtividadeDesenvolvida
                               order by codAtividadeDesenvolvida";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.Query<ListaAtividadeDesenvolvidaModel>(_cmdListar, commandTimeout: TimeoutPadrao, commandType: CommandType.Text).ToList());
            }
            finally
            {
                _conexao.Close();
            }
        }

        public ListaAtividadeDesenvolvidaModel Buscar(int codAtividadeDesenvolvida)
        {
            //Buscar uma atividade desenvolvida específica
            var _cmdBuscar = @"select *
                               from tbListaAtividadeDesenvolvida
                               where
                                    codAtividadeDesenvolvida = @codAtividadeDesenvolvida";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QuerySingleOrDefault<ListaAtividadeDesenvolvidaModel>(_cmdBuscar,
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

        public ResultadoExcluirListaAtividadeDesenvolvidaDto Excluir(int codAtividadeDesenvolvida)
        {
            //Verificar se essa lista de atividade desenvolvida está associado a alguma atividade desenvolvida
            var _listaBeneficios = this._atividadeDesenvolvidaDal.BuscarPorListaAreaInteressProfissional(codAtividadeDesenvolvida);

            if (_listaBeneficios.Any())
                return (new ResultadoExcluirListaAtividadeDesenvolvidaDto()
                {
                    IsErro = true,
                    IsExcluido = false,
                    MensagemErro = "Essa Lista de Atividade Desenvolvida não pode ser Excluído porque ele está associada a uma Atividade Desenvolvida!"
                });

            //Excluir o tipo do benefício
            var _cmdExcluir = @"delete from tblistaatividadedesenvolvida
                                where
                                    codAtividadeDesenvolvida = @codAtividadeDesenvolvida";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdExcluir, new { codAtividadeDesenvolvida }, null, this.TimeoutPadrao, CommandType.Text);

                return (new ResultadoExcluirListaAtividadeDesenvolvidaDto()
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

        public ListaAtividadeDesenvolvidaModel Atualizar(ListaAtividadeDesenvolvidaModel listaAtividadeDesenvolvida)
        {
            var DataModificacao = DateTime.Now;

            //Atualiza a lista de atividade desenvolvida
            var _cmdAtualizar = @"update tblistaatividadedesenvolvida
                                  set atividade = @Atividade,
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
                                     listaAtividadeDesenvolvida.Atividade,
                                     SessaoSistema.UsuarioCorrente.CodigoUsuario,
                                     DataModificacao,
                                     listaAtividadeDesenvolvida.CodAtividadeDesenvolvida
                                 },
                                 null,
                                 this.TimeoutPadrao,
                                 CommandType.Text);

                return (listaAtividadeDesenvolvida);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public ListaAtividadeDesenvolvidaModel Adicionar(ListaAtividadeDesenvolvidaModel listaAtividadeDesenvolvida)
        {
            var DataCriacao = DateTime.Now;

            //Adciona uma nova lista de atividade desenvolvida
            var _cmdInserir = @"insert into tblistaatividadedesenvolvida(atividade,codusuariocriacao,datacriacao) values (@Atividade,@CodigoUsuario,@DataCriacao)";
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
                                                      listaAtividadeDesenvolvida.Atividade,
                                                      SessaoSistema.UsuarioCorrente.CodigoUsuario,
                                                      DataCriacao
                                                  },
                                                  _transacao,
                                                  this.TimeoutPadrao,
                                                  CommandType.Text);

                    listaAtividadeDesenvolvida.CodAtividadeDesenvolvida = _transacao.Connection.ExecuteScalar<int>(_cmdNovoId, null,
                        _transacao, this.TimeoutPadrao, CommandType.Text);
                    _transacao.Commit();

                    return (listaAtividadeDesenvolvida);
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