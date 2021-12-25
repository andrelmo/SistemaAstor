using ProjetoControleCestas.Modelo;
using System.Data;

namespace ProjetoControleCestas.Dados.Interface
{
    public interface IAberturaFamiliaDal
    {
        IDbConnection CriarConexao();
        AberturaFamiliaModel Adicionar(AberturaFamiliaModel aberturaFamilia, IDbTransaction transacao);
        AberturaFamiliaModel Atualizar(AberturaFamiliaModel aberturaFamilia, IDbTransaction transacao);
        void Ativar(int codigoAberturaFamilia);
        void Inativar(int codigoAberturaFamilia);
        void Cancelar(int codigoAberturaFamilia);
        AberturaFamiliaModel Buscar(int codigoAberturaFamilia);
        AberturaFamiliaModel BuscarPorCodigoFamilia(int codFamilia);
        bool TemAberturaFamilia(int codFamilia);
    }
}