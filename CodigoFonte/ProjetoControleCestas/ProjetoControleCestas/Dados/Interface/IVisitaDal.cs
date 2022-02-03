using ProjetoControleCestas.Modelo;
using System.Collections.Generic;
using System.Data;

namespace ProjetoControleCestas.Dados.Interface
{
    public interface IVisitaDal
    {
        VisitaModel Adicionar(VisitaModel visita);
        VisitaModel Atualizar(VisitaModel visita);
        void Excluir(int codigoVisita);
        void ExcluirTodos(int codFamilia, IDbTransaction transacao);
        VisitaModel Buscar(int codigoVisita);
        List<VisitaModel> BuscarTodos(int codFamilia);
        bool VerificarExiste(int codigoVisita);
    }
}