using ProjetoControleCestas.Dto;
using ProjetoControleCestas.Modelo;
using System.Collections.Generic;

namespace ProjetoControleCestas.Dados.Interface
{
    public interface IListaAreaInteresseProfissionalDal
    {
        ListaAreaInteresseProfissionalModel Adicionar(ListaAreaInteresseProfissionalModel listaAreaInteresseProfissional);
        ListaAreaInteresseProfissionalModel Atualizar(ListaAreaInteresseProfissionalModel listaAreaInteresseProfissional);
        ResultadoExcluirListaAreaInteresseProfissionalDto Excluir(int codAreaInteresseProfissional);
        ListaAreaInteresseProfissionalModel Buscar(int codAreaInteresseProfissional);
        List<ListaAreaInteresseProfissionalModel> BuscarTodos();
    }
}