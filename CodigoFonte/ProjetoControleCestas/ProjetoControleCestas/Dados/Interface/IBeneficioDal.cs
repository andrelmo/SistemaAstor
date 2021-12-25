using ProjetoControleCestas.Modelo;
using System.Collections.Generic;
using System.Data;

namespace ProjetoControleCestas.Dados.Interface
{
    public interface IBeneficioDal
    {
        void ExcluirTodos(int codPessoa, IDbTransaction transacao);
        List<BeneficioModel> BuscarBeneficiosPorTipoBeneficio(int codTipoBeneficio);
        List<BeneficioModel> BuscarBeneficios(int codPessoa);
        BeneficioModel Buscar(int codBeneficio);
        void Excluir(int codBeneficio);
        BeneficioModel Atualizar(BeneficioModel beneficio);
        BeneficioModel Adicionar(BeneficioModel beneficio);
    }
}