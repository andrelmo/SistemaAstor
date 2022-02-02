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
    public class PessoasDal: BaseDal, IPessoasDal
    {
        private readonly IDeficienciaDal _deficienciaDal;
        private readonly IProblemaSaudeDal _problemsaSaudeDal;
        private readonly IBeneficioDal _beneficioDal;
        private readonly IDocumentosDal _documentosDal;
        private readonly IRendaDal _rendaDal;

        public PessoasDal(IDeficienciaDal deficienciaDal, IProblemaSaudeDal problemaSaudeDal,
            IBeneficioDal beneficioDal, IDocumentosDal documentosDal, IRendaDal rendaDal)
        {
            this._deficienciaDal = deficienciaDal;
            this._problemsaSaudeDal = problemaSaudeDal;
            this._beneficioDal = beneficioDal;
            this._documentosDal = documentosDal;
            this._rendaDal = rendaDal;
        }

        public void Excluir(int codPessoas)
        {
            //Excluir uma pessoa específica
            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Open();

                using var _transacao = _conexao.BeginTransaction();
                
                try
                {
                    //Excluir todos os problemas de saude
                    this._problemsaSaudeDal.ExcluirTodos(codPessoas, _transacao);

                    //Excluir todas as deficiências
                    this._deficienciaDal.ExcluirTodos(codPessoas, _transacao);

                    //Excluir todos os benefícios
                    this._beneficioDal.ExcluirTodos(codPessoas, _transacao);

                    //Excluir todos os documentos
                    this._documentosDal.ExcluirTodos(codPessoas, _transacao);

                    //Excluir todas as rendas
                    this._rendaDal.ExcluirTodos(codPessoas, _transacao);

                    //Excluir a pessoa 
                    var _cmdExcluir = @"delete from tbPessoas
                                        where
                                            codPessoas = @codPessoas";

                    _transacao.Connection.Execute(_cmdExcluir,
                                                  new
                                                  {
                                                      codPessoas
                                                  },
                                                  _transacao,
                                                  this.TimeoutPadrao,
                                                  CommandType.Text);

                    _transacao.Commit();
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

        public List<PessoasModel> BuscarTodos(int codFamilia)
        {
            //Busca todas as pessoas associada a uma família
            var _cmdBuscarTodos = @"select *
                                    from tbPessoas
                                    where
                                        codFamilia = @codFamilia
                                    order by codPessoas";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.Query<PessoasModel>(_cmdBuscarTodos, 
                                                     new 
                                                     {
                                                         codFamilia
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

        public PessoasModel Buscar(int codPessoas)
        {
            //Busca uma pessoa específica
            var _cmdBuscar = @"select *
                               from tbPessoas
                               where
                                    codPessoas = @codPessoas";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QuerySingleOrDefault<PessoasModel>(_cmdBuscar, 
                                                                    new 
                                                                    {
                                                                        codPessoas
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

        public PessoasModel Atualizar(PessoasModel pessoa)
        {
            var DataModificacao = DateTime.Now;

            //Atualizar as informações de uma família
            var _cmdAtualizar = @"update tbPessoas
                                  set nome = @Nome,
                                      identidade = @Identidade,
                                      cpf = @Cpf,
                                      situacaoCivil = @SituacaoCivil,
                                      nomeMae = @NomeMae,
                                      nomePai = @NomePai,
                                      naturalidade = @Naturalidade,
                                      atividadeDesenvolvida = @AtividadeDesenvolvida,
                                      areaInteresseProfissional = @AreaInteresseProfissional,
                                      deficiencia = @Deficiencia,
                                      idoso = @Idoso,
                                      sexo = @Sexo,
                                      Escolaridade = @Escolaridade,
                                      Parentesco = @Parentesco,
                                      CodFamilia = @CodFamilia,
                                      VinculoFamiliar = @VinculoFamiliar,
                                      ProblemaSaude = @ProblemaSaude,
                                      IsResponsavelFamilia = @IsResponsavelFamilia,
                                      codusuariomodificacao = @CodigoUsuario,
                                      datamodificacao = @DataModificacao
                                 where
                                     codPessoas = @CodPessoas";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdAtualizar, 
                                 new 
                                 {
                                     pessoa.Nome,
                                     pessoa.Identidade,
                                     pessoa.Cpf,
                                     pessoa.SituacaoCivil,
                                     pessoa.NomeMae,
                                     pessoa.NomePai,
                                     pessoa.Naturalidade,
                                     pessoa.AtividadeDesenvolvida,
                                     pessoa.AreaInteresseProfissional,
                                     pessoa.Deficiencia,
                                     pessoa.Idoso,
                                     pessoa.Sexo,
                                     pessoa.Escolaridade,
                                     pessoa.Parentesco,
                                     pessoa.CodFamilia,
                                     pessoa.VinculoFamiliar,
                                     pessoa.ProblemaSaude,
                                     pessoa.CodPessoas,
                                     pessoa.IsResponsavelFamilia,
                                     SessaoSistema.UsuarioCorrente.CodigoUsuario,
                                     DataModificacao
                                 },
                                 null,
                                 this.TimeoutPadrao,
                                 CommandType.Text);

                return (pessoa);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public  PessoasModel Adicionar(PessoasModel pessoa)
        {
            var DataCriacao = DateTime.Now;

            //Adicona uma nova pessoa
            var _cmdInserir = @"insert into tbPessoas(nome,identidade,cpf,situacaoCivil,nomeMae,nomePai,naturalidade,
                                                      atividadeDesenvolvida,areaInteresseProfissional,deficiencia,
                                                      idoso,sexo,escolaridade,parentesco,codFamilia,vinculoFamiliar,
                                                      problemaSaude,IsResponsavelFamilia,codusuariocriacao,datacriacao) 
                                values (@Nome,@Identidade,@Cpf,@SituacaoCivil,@NomeMae,@NomePai,@Naturalidade,
                                        @AtividadeDesenvolvida,@AreaInteresseProfissional,@Deficiencia,
                                        @Idoso,@Sexo,@Escolaridade,@Parentesco,@CodFamilia,@VinculoFamiliar,
                                        @ProblemaSaude,@IsResponsavelFamilia,@CodigoUsuario,@DataCriacao)";
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
                                                      pessoa.Nome,
                                                      pessoa.Identidade,
                                                      pessoa.Cpf,
                                                      pessoa.SituacaoCivil,
                                                      pessoa.NomeMae,
                                                      pessoa.NomePai,
                                                      pessoa.Naturalidade,
                                                      pessoa.AtividadeDesenvolvida,
                                                      pessoa.AreaInteresseProfissional,
                                                      pessoa.Deficiencia,
                                                      pessoa.Idoso,
                                                      pessoa.Sexo,
                                                      pessoa.Escolaridade,
                                                      pessoa.Parentesco,
                                                      pessoa.CodFamilia,
                                                      pessoa.VinculoFamiliar,
                                                      pessoa.ProblemaSaude,
                                                      pessoa.IsResponsavelFamilia,
                                                      SessaoSistema.UsuarioCorrente.CodigoUsuario,
                                                      DataCriacao
                                                  },
                                                  _transacao,
                                                  this.TimeoutPadrao,
                                                  CommandType.Text);

                    pessoa.CodPessoas = _transacao.Connection.ExecuteScalar<int>(_cmdNovoId, null, _transacao,
                           this.TimeoutPadrao, CommandType.Text);

                    _transacao.Commit();

                    return (pessoa);
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