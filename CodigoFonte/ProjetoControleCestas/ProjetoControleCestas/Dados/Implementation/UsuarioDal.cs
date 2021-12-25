using Dapper;
using MySqlConnector;
using ProjetoControleCestas.Dados.Interface;
using ProjetoControleCestas.Dto;
using ProjetoControleCestas.Enums;
using ProjetoControleCestas.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ProjetoControleCestas.Dados.Implementation
{
    public class UsuarioDal: BaseDal, IUsuarioDal
    {
        public ResultadoVerificarLoginDto VerificarLogin(string login, string senha)
        {
            //Procura um usuaário por login e senha
            var _cmdVerificarLogin = @"select *
                                       from tbUsuario
                                       where
                                           login = @login and
                                           senha = @senha";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                var _usuario = _conexao.QueryFirstOrDefault<UsuarioModel>(_cmdVerificarLogin,
                    new
                    {
                        login,
                        senha
                    },
                    commandTimeout: TimeoutPadrao, 
                    commandType: CommandType.Text);

                //Verifica se o usuário não foi encontrado
                if (_usuario == null)
                    return (new ResultadoVerificarLoginDto(){ IsAutenticado = false, IsErro = true, MensagemErro = "Login ou Senha incorretos!" });

                //Verifica se o usuário está inativo
                if (_usuario.Status == Constantes.ConstantesGlobais.USUARIO_INATIVO)
                    return (new ResultadoVerificarLoginDto() { IsAutenticado = false, IsErro = true, MensagemErro = "O Login está inativo!"});

                return (new ResultadoVerificarLoginDto() { IsAutenticado = true, IsErro = false, MensagemErro = "" });
            }
            finally
            {
                _conexao.Close();
            }
        }

        public UsuarioModel Buscar(string login, int codigoUsuario)
        {
            //Buscar um registro de usuário específico pelo login que esteja associado um usuário diferente do usuário informado
            var _cmdBuscar = @"select *
                               from tbUsuario
                               where
                                    login = @login and
                                    codigoUsuario <> @codigoUsuario";
            
            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QuerySingleOrDefault<UsuarioModel>(_cmdBuscar, new { login, codigoUsuario }, null, this.TimeoutPadrao, CommandType.Text));
            }
            finally
            {
                _conexao.Close();
            }
        }

        public UsuarioModel Buscar(string login)
        {
            //Buscar um registro de usuário específico pelo login
            var _cmdBuscar = @"select *
                               from tbUsuario
                               where
                                    login = @login";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QuerySingleOrDefault<UsuarioModel>(_cmdBuscar, new { login }, null, this.TimeoutPadrao, CommandType.Text));
            }
            finally
            {
                _conexao.Close();
            }
        }

        public UsuarioModel Buscar(int codigoUsuario)
        {
            //Busca um usuário pelo código do usuário
            var _cmdBuscarPorId = @"select *
                                    from tbUsuario
                                    where
                                        codigoUsuario = @codigoUsuario";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.QueryFirstOrDefault<UsuarioModel>(_cmdBuscarPorId, new { codigoUsuario}, commandTimeout: TimeoutPadrao,commandType: CommandType.Text));
            }
            finally
            {
                _conexao.Close();
            }
        }

        public List<UsuarioModel> BuscarTodos(TipoUsuario tipoUsuario)
        {
            //Busca todos os usuários do tipo solicitado
            var _cmdListarTodos = @"select *
                                    from tbUsuario
                                    where
                                         TipoUsuario = @tipoUsuario
                                    order by nome";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.Query<UsuarioModel>(_cmdListarTodos, new { tipoUsuario }, commandTimeout: TimeoutPadrao, commandType: CommandType.Text).ToList());
            }
            finally
            {
                _conexao.Close();
            }
        }

        public List<UsuarioModel> BuscarTodos()
        {
            //Busca todos os usuários
            var _cmdListarTodos = @"select *
                                    from tbUsuario
                                    order by nome";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                return (_conexao.Query<UsuarioModel>(_cmdListarTodos, commandTimeout: TimeoutPadrao, commandType: CommandType.Text).ToList());
            }
            finally
            {
                _conexao.Close();
            }
        }

        public void Ativar(int codigoUsuario)
        {
            //Ativa o usuário informado
            var status = Constantes.ConstantesGlobais.USUARIO_ATIVO;
            var _cmdAtivar = @"update tbUsuario
                               set status = @status
                               where
                                   codigoUsuario = @CodigoUsuario";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdAtivar, 
                                 new 
                                 {
                                 status,
                                 codigoUsuario
                                 }, null, this.TimeoutPadrao, CommandType.Text);
            }
            finally
            {
                _conexao.Close();
            }
        }

        public void Inativar(int codigoUsuario)
        {
            //Inativa o usuário informado
            var status = Constantes.ConstantesGlobais.USUARIO_INATIVO;
            var _cmdInativar = @"update tbUsuario
                                 set status = @status
                                 where
                                      codigoUsuario = @CodigoUsuario";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdInativar, new
                {
                    status,
                    codigoUsuario
                },null,this.TimeoutPadrao, CommandType.Text);
            } 
            finally
            {
                _conexao.Close();
            }
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            //Atualizar as informações do usuário
            var _cmdAtualizar = @"update tbUsuario
                                  set nome = @Nome,
                                      endereco = @Endereco,
                                      bairro = @Bairro,
                                      cidade = @Cidade,
                                      cep = @Cep,
                                      estado = @Estado,
                                      email = @Email,
                                      telefone = @Telefone,
                                      login = @Login,
                                      senha = @Senha,
                                      tipoUsuario = @TipoUsuario,
                                      status = @Status
                                 where
                                      codigoUsuario = @CodigoUsuario";

            using var _conexao = new MySqlConnection(this.GetConnecitonString());

            try
            {
                _conexao.Execute(_cmdAtualizar,
                                 new
                                 {
                                     usuario.Nome,
                                     usuario.Endereco,
                                     usuario.Bairro,
                                     usuario.Cidade,
                                     usuario.Cep,
                                     usuario.Estado,
                                     usuario.Email,
                                     usuario.Telefone,
                                     usuario.Login,
                                     usuario.Senha,
                                     usuario.TipoUsuario,
                                     usuario.Status,
                                     usuario.CodigoUsuario
                                 },
                                 null,
                                 this.TimeoutPadrao,
                                 CommandType.Text);

                return (usuario);
            }
            finally
            {
                _conexao.Clone();
            }
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            //Adicionar um usuário
            var _cmdInserir = @"insert into tbUsuario (nome,endereco,bairro,cidade,cep,estado,email,telefone,login,
                                                       senha,tipoUsuario,status,dataCriacao) 
                                values (@Nome,@Endereco,@Bairro,@Cidade,@Cep,@Estado,@Email,@Telefone,@Login,
                                        @Senha,@TipoUsuario,@Status,@DataCriacao)";
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
                                                     usuario.Nome,
                                                     usuario.Endereco,
                                                     usuario.Bairro,
                                                     usuario.Cidade,
                                                     usuario.Cep,
                                                     usuario.Estado,
                                                     usuario.Email,
                                                     usuario.Telefone,
                                                     usuario.Login,
                                                     usuario.Senha,
                                                     usuario.TipoUsuario,
                                                     usuario.Status,
                                                     usuario.DataCriacao
                                                 },
                                                 _transacao,
                                                 this.TimeoutPadrao,
                                                 CommandType.Text);

                    usuario.CodigoUsuario = _transacao.Connection.ExecuteScalar<int>(_cmdNovoId, null, _transacao,
                        this.TimeoutPadrao, CommandType.Text);
                    _transacao.Commit();

                    return (usuario);
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