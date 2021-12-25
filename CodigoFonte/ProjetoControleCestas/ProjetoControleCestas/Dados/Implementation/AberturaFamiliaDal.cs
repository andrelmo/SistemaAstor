using Dapper;
using MySql.Data.MySqlClient;
using ProjetoControleCestas.Constantes;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Modelo;
using System;
using System.Data;

namespace ProjetoControleCestas.Dados.Implementation
{
    public class AberturaFamiliaDal : BaseDal, IAberturaFamiliaDal
    {
        public AberturaFamiliaModel Adicionar(AberturaFamiliaModel aberturaFamilia, IDbTransaction transacao)
        {
            //Adiciona uma nova abertura de família
            var _cmdInserir = @"insert into tbAberturaFamilia (codFamilia,dataAbertura,dataFechamento,status,observacao,codVoluntario,tipoCesta,CorCesta) 
                                                       values (@CodFamilia,@DataAbertura,@DataFechamento,@Status,@Observacao,@CodVoluntario,@TipoCesta,@CorCesta)";

            var _cmdNovoId = "select last_insert_id();";

            transacao.Connection.Execute(_cmdInserir,
                                          new
                                          {
                                              aberturaFamilia.CodFamilia,
                                              aberturaFamilia.DataAbertura,
                                              aberturaFamilia.DataFechamento,
                                              aberturaFamilia.Status,
                                              aberturaFamilia.Observacao,
                                              aberturaFamilia.CodVoluntario,
                                              aberturaFamilia.TipoCesta,
                                              aberturaFamilia.CorCesta
                                          },
                                          transacao,
                                          this.TimeoutPadrao,
                                          CommandType.Text);

            aberturaFamilia.CodigoAberturaFamilia = transacao.Connection.ExecuteScalar<int>(_cmdNovoId, null, transacao, this.TimeoutPadrao, CommandType.Text);

            return (aberturaFamilia);
        }

        public void Ativar(int codigoAberturaFamilia)
        {
            //Ativar o status da família para ativo
            var novoStatus = ConstantesGlobais.STATUS_ABERTURA_FAMILIA_ATIVO;
            var _cmdAtivar = @"update tbAberturaFamilia
                               set status = @novoStatus
                               where
                                   codigoAberturaFamilia = @codigoAberturaFamilia";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdAtivar, new { novoStatus, codigoAberturaFamilia }, null, this.TimeoutPadrao, CommandType.Text);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public IDbConnection CriarConexao()
        {
            var _conexao = new MySqlConnection(this.GetConnecitonString());

            _conexao.Open();

            return (_conexao);
        }

        public AberturaFamiliaModel Atualizar(AberturaFamiliaModel aberturaFamilia, IDbTransaction transacao)
        {
            //Atualizar as informações da família
            var _cmdAtualizar = @"update tbAberturaFamilia
                                  set codFamilia = @CodFamilia,
                                      dataAbertura = @DataAbertura,
                                      dataFechamento = @DataFechamento,
                                      status = @Status,
                                      observacao = @Observacao,
                                      codVoluntario = @CodVoluntario,
                                      tipoCesta = @TipoCesta,
                                      CorCesta = @CorCesta
                                  where
                                      codigoAberturaFamilia = @CodigoAberturaFamilia";
            transacao.Connection.Execute(_cmdAtualizar,
                             new
                             {
                                 aberturaFamilia.CodFamilia,
                                 aberturaFamilia.DataAbertura,
                                 aberturaFamilia.DataFechamento,
                                 aberturaFamilia.Status,
                                 aberturaFamilia.Observacao,
                                 aberturaFamilia.CodVoluntario,
                                 aberturaFamilia.TipoCesta,
                                 aberturaFamilia.CorCesta,
                                 aberturaFamilia.CodigoAberturaFamilia
                             },
                             transacao,
                             this.TimeoutPadrao,
                             CommandType.Text);

            return (aberturaFamilia);
        }

        public AberturaFamiliaModel BuscarPorCodigoFamilia(int codFamilia)
        {
            //Buscar o registro específico de uma abertura de família
            var _cmdBuscar = @"select *
                               from tbAberturaFamilia
                               where
                                   codFamilia = @codFamilia";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QuerySingleOrDefault<AberturaFamiliaModel>(_cmdBuscar, new { codFamilia }, null, this.TimeoutPadrao, CommandType.Text));
            }
            finally
            {
                _conexao.Close();
            }
        }

        public AberturaFamiliaModel Buscar(int codigoAberturaFamilia)
        {
            //Buscar o registro específico de uma abertura de família
            var _cmdBuscar = @"select *
                               from tbAberturaFamilia
                               where
                                   codigoAberturaFamilia = @codigoAberturaFamilia";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QuerySingleOrDefault<AberturaFamiliaModel>(_cmdBuscar, new { codigoAberturaFamilia }, null, this.TimeoutPadrao, CommandType.Text));
            }
            finally
            {
                _conexao.Close();
            }
        }

        public void Cancelar(int codigoAberturaFamilia)
        {
            //Cancelar um registro de abertura de família
            var novoStatus = ConstantesGlobais.STATUS_ABERTURA_FAMILIA_CANCELADO;
            var _cmdCancelar = @"update tbAberturaFamilia
                                 set status = @novoStatus
                                 where
                                     codigoAberturaFamilia = @codigoAberturaFamilia";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdCancelar,
                                 new
                                 {
                                     novoStatus,
                                     codigoAberturaFamilia
                                 },
                                 null, this.TimeoutPadrao, CommandType.Text);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public void Inativar(int codigoAberturaFamilia)
        {
            //Inativar um registro de abertura de família específico
            var novoStatus = ConstantesGlobais.STATUS_ABERTURA_FAMILIA_INATIVO;
            var _cmdInativar = @"update tbAberturaFamilia
                                 set status = @novoStatus
                                 where
                                     codigoAberturaFamilia = @codigoAberturaFamilia";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdInativar,
                                 new
                                 {
                                     novoStatus,
                                     codigoAberturaFamilia
                                 },
                                 null,
                                 this.TimeoutPadrao,
                                 CommandType.Text);
            }
            finally
            {
                _conexao.Clone();
            }
        }

        public bool TemAberturaFamilia(int codFamilia)
        {
            //Verificar se existe registro de abertura de família associado ao código da família
            var _cmdVerificar = @"select count(*)
                                  from tbAberturaFamilia
                                  where
                                       codFamilia = @codFamilia";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.ExecuteScalar<int>(_cmdVerificar, new { codFamilia }, null, this.TimeoutPadrao, CommandType.Text) >= 1);
            }
            finally
            {
                _conexao.Close();
            }
        }
    }
}