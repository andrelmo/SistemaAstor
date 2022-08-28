using ProjetoControleCestas.Modelo;
using System.Collections.Generic;
using System.Data;

namespace ProjetoControleCestas.Dados.Interface
{
    public interface IAtividadeDesenvolvidaDal
    {
        void ExcluirTodos(int codPessoas, IDbTransaction transacao);
        List<AtividadeDesenvolvidaModel> BuscarTodos(int codPessoas);
        AtividadeDesenvolvidaModel Buscar(int codAtividadeDesenvolvida);
        void Excluir(int codAtividadeDesenvolvida);
        AtividadeDesenvolvidaModel Atualizar(AtividadeDesenvolvidaModel atividadeDesenvolvida);
        AtividadeDesenvolvidaModel Adicionar(AtividadeDesenvolvidaModel atividadeDesenvolvida);
        List<ListaAtividadeDesenvolvidaModel> BuscarPorListaAtividadeDesenvolvida(int codListaAtividadeDesenvolvida);
    }
}