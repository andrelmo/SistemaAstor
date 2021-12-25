using ProjetoControleCestas.Modelo;
using System.Collections.Generic;
using System.Data;

namespace ProjetoControleCestas.Dados.Interface
{
    public interface IRendaDal
    {
        bool TemRenda(int codPessoas);
        List<RendaModel> BuscarTodos(int codPessoas);
        RendaModel Buscar(int codRenda);
        void Excluir(int codRenda);
        RendaModel Atualizar(RendaModel renda);
        RendaModel Adicionar(RendaModel renda);
        void ExcluirTodos(int codPessoas, IDbTransaction transacao);
    }
}