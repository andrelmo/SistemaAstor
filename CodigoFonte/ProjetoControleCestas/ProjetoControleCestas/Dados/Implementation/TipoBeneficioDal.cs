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
    public class TipoBeneficioDAl: BaseDal, ITipoBeneficioDAl
    {
        private readonly IBeneficioDal _beneficiosDal;

        public TipoBeneficioDAl(IBeneficioDal beneficiosDal)
        {
            this._beneficiosDal = beneficiosDal;
        }

        public List<TipoBeneficioModel> BuscarTodos()
        {
            //Busca a lista de todos os tipos de benefícios
            var _cmdListar = @"select *
                               from tbTipoBeneficios
                               order by codTipoBeneficio";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.Query<TipoBeneficioModel>(_cmdListar, commandTimeout: TimeoutPadrao, commandType: CommandType.Text).ToList());
            }
            finally
            {
                _conexao.Close();
            }
        }
        
        public TipoBeneficioModel Buscar(int codTipoBeneficio)
        {
            //Buscar um tipo de benefício específico
            var _cmdBuscar = @"select *
                               from tbTipoBeneficios
                               where
                                    codTipoBeneficio = @codTipoBeneficio";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QuerySingleOrDefault<TipoBeneficioModel>(_cmdBuscar, 
                                                           new 
                                                           {
                                                               codTipoBeneficio
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

        public ResultadoExcluirTipoBeneficioDto Excluir(int codTipoBeneficio)
        {
            //Verificar se esse tipo de benefício está associado a algum benefício em específico
            var _listaBeneficios = this._beneficiosDal.BuscarBeneficiosPorTipoBeneficio(codTipoBeneficio);

            if (_listaBeneficios.Any())
                return (new ResultadoExcluirTipoBeneficioDto() 
                { 
                    IsErro = true, 
                    IsExcluido = false, 
                    MensagemErro = "O Tipo de Benefício não pode ser Excluído porque ele está associado a Benefícios!"
                });
            
            //Excluir o tipo do benefício
            var _cmdExcluir = @"delete from tbTipoBeneficios
                                where
                                    codTipoBeneficio = @codTipoBeneficio";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdExcluir, new { codTipoBeneficio }, null, this.TimeoutPadrao, CommandType.Text);

                return (new ResultadoExcluirTipoBeneficioDto() 
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

        public TipoBeneficioModel Atualizar(TipoBeneficioModel tipoBeneficio)
        {
            //Atualiza o tipo de benefício
            var _cmdAtualizar = @"update tbTipoBeneficios
                                  set beneficio = @Beneficio
                                  where
                                      codTipoBeneficio = @CodTipoBeneficio";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdAtualizar, 
                                 new 
                                 { 
                                     tipoBeneficio.Beneficio, 
                                     tipoBeneficio.CodTipoBeneficio
                                 },
                                 null, 
                                 this.TimeoutPadrao, 
                                 CommandType.Text);

                return (tipoBeneficio);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public TipoBeneficioModel Adicionar(TipoBeneficioModel tipoBeneficio)
        {
            //Adciona um novo tipo de benefício
            var _cmdInserir = @"insert into tbTipoBeneficios(beneficio) values (@Beneficio)";
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
                                                      tipoBeneficio.Beneficio
                                                  }, 
                                                  _transacao, 
                                                  this.TimeoutPadrao, 
                                                  CommandType.Text);

                    tipoBeneficio.CodTipoBeneficio = _transacao.Connection.ExecuteScalar<int>(_cmdNovoId, null,
                        _transacao, this.TimeoutPadrao, CommandType.Text);
                    _transacao.Commit();

                    return (tipoBeneficio);
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