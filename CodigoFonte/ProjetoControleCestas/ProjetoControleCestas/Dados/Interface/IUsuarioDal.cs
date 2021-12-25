using ProjetoControleCestas.Dto;
using ProjetoControleCestas.Enums;
using ProjetoControleCestas.Modelo;
using System.Collections.Generic;

namespace ProjetoControleCestas.Dados.Interface
{
    public interface IUsuarioDal
    {
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        void Inativar(int codigoUsuario);
        void Ativar(int codigoUsuario);
        List<UsuarioModel> BuscarTodos();
        List<UsuarioModel> BuscarTodos(TipoUsuario tipoUsuario);
        UsuarioModel Buscar(int codigoUsuario);
        UsuarioModel Buscar(string login, int codigoUsuario);
        ResultadoVerificarLoginDto VerificarLogin(string login, string senha);
        UsuarioModel Buscar(string login);
    }
}