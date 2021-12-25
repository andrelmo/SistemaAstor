using ProjetoControleCestas.Modelo;
using System.Collections.Generic;

namespace ProjetoControleCestas.Dados.Interface
{
    public interface IFaltasDal
    {
        bool TemFalta(int codigoAberturaFamilia);
        List<FaltasModel> BuscarTodos(int codigoAberturaFamilia);
        FaltasModel Buscar(int codigoFaltas);
        void Excluir(int codigoFaltas);
        FaltasModel Atualizar(FaltasModel faltas);
        FaltasModel Adicionar(FaltasModel faltas);
    }
}