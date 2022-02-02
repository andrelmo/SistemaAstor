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
    public class DocumentosDal : BaseDal, IDocumentosDal
    {
        public void ExcluirTodos(int codPessoas, IDbTransaction transacao)
        {
            //Excluir todos os documentos associados a uma pessoa
            var _cmdExcluir = @"delete from tbDocumentos
                                where
                                    codPessoas = @codPessoas";

            transacao.Connection.Execute(_cmdExcluir, new { codPessoas }, transacao, this.TimeoutPadrao, CommandType.Text);
        }

        public List<DocumentosModel> BuscarTodos(int codPessoas)
        {
            //Buscar todos os documentos de uma pessoa específica
            var _cmdListar = @"select *
                               from tbDocumentos
                               where
                                   codPessoas = @codPessoas
                               order by codigoDocumento";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.Query<DocumentosModel>(_cmdListar,
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

        public DocumentosModel Buscar(int codigoDocumento)
        {
            //Busca um documento específico
            var _cmdBuscar = @"select *
                               from tbDocumentos
                               where
                                   codigoDocumento = @codigoDocumento";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QuerySingleOrDefault<DocumentosModel>(_cmdBuscar,
                                                                       new
                                                                       {
                                                                           codigoDocumento
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

        public void Excluir(int codigoDocumento)
        {
            //Excluir um documento específico
            var _cmdExcluir = @"delete from tbDocumentos
                                where
                                    codigoDocumento = @codigoDocumento";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdExcluir,
                                 new
                                 {
                                     codigoDocumento
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

        public DocumentosModel Atualizar(DocumentosModel documento)
        {
            var DataModificacao = DateTime.Now;

            //Atualizar o documento
            var _cmdAtualizar = @"update tbDocumentos
                                  set codPessoas = @CodPessoas,
                                      tipodocumento = @TipoDocumento,
                                      numeroDocumento = @NumeroDocumento,
                                      codusuariomodificacao = @CodigoUsuario,
                                      datamodificacao = @DataModificacao
                                  where
                                      codigoDocumento = @CodigoDocumento";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdAtualizar,
                                 new
                                 {
                                     documento.CodPessoas,
                                     documento.TipoDocumento,
                                     documento.NumeroDocumento,
                                     SessaoSistema.UsuarioCorrente.CodigoUsuario,
                                     DataModificacao,
                                     documento.CodigoDocumento
                                 },
                                 null,
                                 this.TimeoutPadrao,
                                 CommandType.Text);

                return (documento);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public DocumentosModel Adicionar(DocumentosModel documento)
        {
            var DataCriacao = DateTime.Now;

            //Adicionar um novo documento
            var _cmdInserir = @"insert into tbDocumentos (codPessoas,tipodocumento,numeroDocumento,codusuariocriacao,datacriacao) 
                                values (@CodPessoas,@TipoDocumento,@NumeroDocumento,@CodigoUsuario,@DataCriacao)";
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
                                                      documento.CodPessoas,
                                                      documento.TipoDocumento,
                                                      documento.NumeroDocumento,
                                                      SessaoSistema.UsuarioCorrente.CodigoUsuario,
                                                      DataCriacao
                                                  },
                                                  _transacao,
                                                  this.TimeoutPadrao,
                                                  CommandType.Text);

                    documento.CodigoDocumento = _transacao.Connection.ExecuteScalar<int>(
                        _cmdNovoId, null, _transacao, this.TimeoutPadrao, CommandType.Text);
                    _transacao.Commit();

                    return (documento);
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