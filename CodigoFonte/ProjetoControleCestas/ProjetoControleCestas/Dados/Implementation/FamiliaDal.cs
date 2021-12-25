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
    public class FamiliaDal : BaseDal, IFamiliaDal
    {
        private readonly IMoradiaDal _moradiaDal;
        private readonly IPessoasDal _pessoaDal;
        private readonly IVisitaDal _visitaDal;
        private readonly IAberturaFamiliaDal _aberturaFamiliaDal;
        private readonly IFaltasDal _faltasDal;

        public FamiliaDal(IMoradiaDal moradiaDal, IPessoasDal pessoaDal, IVisitaDal visitaDal, IAberturaFamiliaDal aberturaFamiliaDal, IFaltasDal faltasDal)
        {
            this._moradiaDal = moradiaDal;
            this._pessoaDal = pessoaDal;
            this._visitaDal = visitaDal;
            this._aberturaFamiliaDal = aberturaFamiliaDal;
            this._faltasDal = faltasDal;
        }

        public decimal GetTotalRendas(int codFamilia)
        {
            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                //Calcular o valor de todas as rendas recebidas por todas as pessoas que compoêm a família
                var _cmdTotalRendas = @"select sum(r.valorRenda) as TotalRendas 
                                        from tbPessoas p
                                        inner join tbRenda r
                                        on p.codPessoas = r.codPessoas
                                        where
                                             p.codFamilia = @codFamilia";

                return (_conexao.ExecuteScalar<decimal>(_cmdTotalRendas, new { codFamilia }, null, this.TimeoutPadrao, CommandType.Text));
            }
            finally
            {
                _conexao.Close();
            }
        }

        public decimal GetTotalBeneficiosRecebidos(int codFamilia)
        {
            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                //Calcular o valor total de todos os benefícios recebidos pela família
                var _cmdTotalBeneficios = @"select sum(b.valorBeneficio) as TotalBeneficios
                                        from tbPessoas p
                                        inner join tbBeneficio b
                                        on p.codPessoas = b.codPessoa
                                        where
                                             p.codFamilia = @codFamilia";

                return (_conexao.ExecuteScalar<decimal>(_cmdTotalBeneficios, new { codFamilia }, null, this.TimeoutPadrao, CommandType.Text));
            }
            finally
            {
                _conexao.Close();
            }
        }

        public ResultadoExcluirFamiliaDto Excluir(int codFamilia)
        {
            //Verifica se a família tem moradias registradas
            if (this._moradiaDal.BuscarTodos(codFamilia).Any())
                return (new ResultadoExcluirFamiliaDto()
                {
                    IsErro = true,
                    IsExcluido = false,
                    MensagemErro = "A família não pode ser excluída porque tem moradias registradas.Exclua primeiro as moradias!"
                });

            //Verifica se a família tem pessoas registradas
            if (this._pessoaDal.BuscarTodos(codFamilia).Any())
                return (new ResultadoExcluirFamiliaDto()
                {
                    IsErro = true,
                    IsExcluido = false,
                    MensagemErro = "A família não pode ser excluída porque tem pessoas registradas.Exclua primeiro as pessoas!"
                });

            //Verifica se a família tem visitas registradas
            if (this._visitaDal.BuscarTodos(codFamilia).Any())
                return (new ResultadoExcluirFamiliaDto()
                {
                    IsErro = true,
                    IsExcluido = false,
                    MensagemErro = "A família não pode ser excluída porque tem visitas registradas.Exclua primeiro as visitas!"
                });

            //Verifica se a família tem abertura de família
            if (this._aberturaFamiliaDal.TemAberturaFamilia(codFamilia))
            {
                return (new ResultadoExcluirFamiliaDto()
                {
                    IsErro = true,
                    IsExcluido = false,
                    MensagemErro = "A família não pode ser excluída porque tem Abertura de Família!"
                });
            }


            //Excluir o registro da família
            var _cmdExcluir = @"delete from tbFamilia
                                where
                                     codFamilia = @codFamilia";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdExcluir, new { codFamilia }, null, this.TimeoutPadrao, CommandType.Text);

                return (new ResultadoExcluirFamiliaDto() { IsErro = false, IsExcluido = true, MensagemErro = string.Empty });
            }
            catch (Exception Ex)
            {
                return (new ResultadoExcluirFamiliaDto()
                {
                    IsErro = true,
                    IsExcluido = false,
                    MensagemErro = $"Ocorreu o seguinte erro ao Excluir a Família.Erro: {Ex.Message}"
                });
            }
            finally
            {
                _conexao.Close();
            }
        }

        public List<FamiliaModel> BuscarTodos()
        {
            //Buscar todas as famílias
            var _cmdBuscar = @"select *
                               from tbFamilia
                               order by codFamilia";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.Query<FamiliaModel>(_cmdBuscar,
                                                    commandTimeout: this.TimeoutPadrao,
                                                    commandType: CommandType.Text).ToList());
            }
            finally
            {
                _conexao.Close();
            }
        }

        public FamiliaModel Buscar(int codFamilia)
        {
            //Buscar uma família em específico
            var _cmdBuscar = @"select *
                               from tbFamilia
                               where
                                   codFamilia = @codFamilia";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QueryFirstOrDefault<FamiliaModel>(_cmdBuscar,
                                                                   new
                                                                   {
                                                                       codFamilia
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

        public FamiliaModel Atualizar(FamiliaModel familia, IDbTransaction transacao)
        {
            //Atualiza uma familia
            var _cmdAtualizar = @"update tbFamilia
                                  set tipoLogradouro = @TipoLogradouro,
                                      logradouro = @Logradouro,
                                      numero = @Numero,
                                      complemento = @Complemento,
                                      bairro = @Bairro,
                                      cep = @Cep,
                                      municipio = @Municipio,
                                      referencia = @Referencia,
                                      onibus = @Onibus
                                  where
                                        codFamilia = @CodFamilia";

            transacao.Connection.Execute(_cmdAtualizar,
                             new
                             {
                                 familia.TipoLogradouro,
                                 familia.Logradouro,
                                 familia.Numero,
                                 familia.Complemento,
                                 familia.Bairro,
                                 familia.Cep,
                                 familia.Municipio,
                                 familia.Referencia,
                                 familia.Onibus,
                                 familia.CodFamilia
                             },
                             transacao,
                             this.TimeoutPadrao,
                             CommandType.Text);

            return (familia);
        }

        public IDbConnection CriarConexao()
        {
            var _conexao = new MySqlConnection(this.GetConnecitonString());

            _conexao.Open();

            return (_conexao);
        }

        public FamiliaModel Adicionar(FamiliaModel familia, IDbTransaction transacao)
        {
            //Adiciona uma nova familia            
            var _cmdInserir = @"insert into tbFamilia (tipoLogradouro,logradouro,numero,complemento,
                                                       bairro,cep,municipio,referencia,onibus) 
                                values (@TipoLogradouro,@Logradouro,@Numero,@Complemento,@Bairro,@Cep,
                                        @Municipio,@Referencia,@Onibus)";
            var _cmdNovoId = "select last_insert_id();";

            transacao.Connection.Execute(_cmdInserir,
                                          new
                                          {
                                              familia.TipoLogradouro,
                                              familia.Logradouro,
                                              familia.Numero,
                                              familia.Complemento,
                                              familia.Bairro,
                                              familia.Cep,
                                              familia.Municipio,
                                              familia.Referencia,
                                              familia.Onibus
                                          },
                                          transacao,
                                          this.TimeoutPadrao,
                                          CommandType.Text);
            familia.CodFamilia = transacao.Connection.ExecuteScalar<int>(_cmdNovoId,
                                                                          null,
                                                                          transacao,
                                                                          this.TimeoutPadrao,
                                                                          CommandType.Text);

            return (familia);
        }
    }
}