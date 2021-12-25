using ProjetoControleCestas.Modelo;
using System.Collections.Generic;
using System.Data;

namespace ProjetoControleCestas.Dados.Interface
{
    public interface IDeficienciaDal
    {
        void ExcluirTodos(int codPessoa, IDbTransaction transacao);
        DeficienciaModel Adicionar(DeficienciaModel deficiencia);
        DeficienciaModel Atualizar(DeficienciaModel deficiencia);
        DeficienciaModel Buscar(int codDeficiencia);
        void Excluir(int codDeficiencia);
        List<DeficienciaModel> BuscarTodos(int codPessoa);
    }
}