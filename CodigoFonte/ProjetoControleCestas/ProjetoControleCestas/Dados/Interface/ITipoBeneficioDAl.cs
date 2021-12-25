using ProjetoControleCestas.Dto;
using ProjetoControleCestas.Modelo;
using System.Collections.Generic;

namespace ProjetoControleCestas.Dados.Interface
{
    public interface ITipoBeneficioDAl
    {
        TipoBeneficioModel Adicionar(TipoBeneficioModel tipoBeneficio);
        TipoBeneficioModel Atualizar(TipoBeneficioModel tipoBeneficio);
        ResultadoExcluirTipoBeneficioDto Excluir(int codTipoBeneficio);
        TipoBeneficioModel Buscar(int codTipoBeneficio);
        List<TipoBeneficioModel> BuscarTodos();
    }
}