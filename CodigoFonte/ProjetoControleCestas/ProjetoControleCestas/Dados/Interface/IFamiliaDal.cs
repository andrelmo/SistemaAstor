using ProjetoControleCestas.Dto;
using ProjetoControleCestas.Modelo;
using System.Collections.Generic;
using System.Data;

namespace ProjetoControleCestas.Dados.Interface
{
    public interface IFamiliaDal
    {
        ResultadoExcluirFamiliaDto Excluir(int codFamilia);
        List<FamiliaModel> BuscarTodos();
        FamiliaModel Buscar(int codFamilia);
        FamiliaModel Adicionar(FamiliaModel familia, IDbTransaction transacao);
        FamiliaModel Atualizar(FamiliaModel familia, IDbTransaction transacao);
        decimal GetTotalRendas(int codFamilia);
        decimal GetTotalBeneficiosRecebidos(int codFamilia);
        IDbConnection CriarConexao();
        List<FamiliaModel> PesquisarPorCpfResponsavel(string cpf);
        List<FamiliaModel> PesquisarPorNomeResponsavel(string nomeResponsavel);
    }
}