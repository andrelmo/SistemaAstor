using ProjetoControleCestas.Modelo;
using System.Collections.Generic;
using System.Data;

namespace ProjetoControleCestas.Dados.Interface
{
    public interface IAreaInteresseProfissionalDal
    {
        void ExcluirTodos(int codPessoa, IDbTransaction transacao);
        List<AreaInteresseProfissionalModel> BuscarTodos(int codPessoa);
        AreaInteresseProfissionalModel Buscar(int codAreaInteresseProfissional);
        void Excluir(int codAreaInteresseProfissional);
        AreaInteresseProfissionalModel Atualizar(AreaInteresseProfissionalModel areaInteresseProfissional);
        AreaInteresseProfissionalModel Adicionar(AreaInteresseProfissionalModel areaInteresseProfissional);
        List<AreaInteresseProfissionalModel> BuscarPorListaAreaInteressProfissional(int codListaAreaInteresseProfissional);
    }
}