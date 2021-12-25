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
    public class MoradiaDal: BaseDal, IMoradiaDal
    {
        public List<MoradiaModel> BuscarTodos(int codFamilia)
        {
            //Buscar todas as moradias de uma família específica
            var _cmdBuscar = @"select *
                               from tbMoradia
                               where
                                    codFamilia = @codFamilia
                               order by codCaracteristicasMoradia";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.Query<MoradiaModel>(_cmdBuscar, 
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

        public MoradiaModel Buscar(int codCaracteristicasMoradia)
        {
            //Buscar uma moradia específica
            var _cmdBuscar = @"select *
                               from tbMoradia
                               where
                                   codCaracteristicasMoradia = @codCaracteristicasMoradia";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QuerySingleOrDefault<MoradiaModel>(_cmdBuscar, 
                                                                    new 
                                                                    {
                                                                        codCaracteristicasMoradia
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

        public void Excluir(int codCaracteristicasMoradia)
        {
            //Excluir uma determinada moradia
            var _cmdExcluir = @"delete from tbMoradia
                                where
                                    codCaracteristicasMoradia = @codCaracteristicasMoradia";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());
            
            try
            {
                _conexao.Execute(_cmdExcluir, 
                                 new 
                                 { 
                                     codCaracteristicasMoradia 
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

        public MoradiaModel Atualizar(MoradiaModel moradia)
        {
            //Atualizar as informações de uma moradia
            var _cmdAtualizar = @"update tbMoradia
                                  set codFamilia = @CodFamilia,
                                      condicaoMoradia = @CondicaoMoradia,
                                      numeroComodos = @NumeroComodos,
                                      numeroQuartos = @NumeroQuartos,
                                      banheiro = @Banheiro
                                  where
                                       codCaracteristicasMoradia = @CodCaracteristicasMoradia";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdAtualizar, 
                                 new 
                                 {
                                    moradia.CodFamilia,
                                    moradia.CondicaoMoradia,
                                    moradia.NumeroComodos,
                                    moradia.NumeroQuartos,
                                    moradia.Banheiro,
                                    moradia.CodCaracteristicasMoradia
                                 }, 
                                 null, 
                                 this.TimeoutPadrao, 
                                 CommandType.Text);

                return (moradia);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public MoradiaModel Adicionar(MoradiaModel moradia)
        {
            //Adiciona uma nova moradia
            var _cmdInserir = @"insert into tbMoradia(codFamilia,condicaoMoradia,numeroComodos,numeroQuartos,banheiro) 
                                values (@CodFamilia,@CondicaoMoradia,@NumeroComodos,@NumeroQuartos,@Banheiro)";
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
                                                      moradia.CodFamilia,
                                                      moradia.CondicaoMoradia,
                                                      moradia.NumeroComodos,
                                                      moradia.NumeroQuartos,
                                                      moradia.Banheiro
                                                  },
                                                  _transacao,
                                                  this.TimeoutPadrao,
                                                  CommandType.Text);
                    moradia.CodCaracteristicasMoradia = _transacao.Connection.ExecuteScalar<int>(
                        _cmdNovoId,
                        null,
                        _transacao,
                        this.TimeoutPadrao,
                        CommandType.Text);
                    _transacao.Commit();

                    return (moradia);
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