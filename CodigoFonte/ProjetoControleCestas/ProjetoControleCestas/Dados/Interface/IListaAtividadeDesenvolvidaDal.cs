using ProjetoControleCestas.Dto;
using ProjetoControleCestas.Modelo;
using System.Collections.Generic;

namespace ProjetoControleCestas.Dados.Interface
{
    public interface IListaAtividadeDesenvolvidaDal
    {
        ListaAtividadeDesenvolvidaModel Adicionar(ListaAtividadeDesenvolvidaModel listaAtividadeDesenvolvida);
        ListaAtividadeDesenvolvidaModel Atualizar(ListaAtividadeDesenvolvidaModel listaAtividadeDesenvolvida);
        ResultadoExcluirListaAtividadeDesenvolvidaDto Excluir(int codAtividadeDesenvolvida);
        ListaAtividadeDesenvolvidaModel Buscar(int codAtividadeDesenvolvida);
        List<ListaAtividadeDesenvolvidaModel> BuscarTodos();
    }
}