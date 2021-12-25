using ProjetoControleCestas.Modelo;
using System.Collections.Generic;
using System.Data;

namespace ProjetoControleCestas.Dados.Interface
{
    public interface IProblemaSaudeDal
    {
        void ExcluirTodos(int codPessoa,IDbTransaction transacao);
        List<ProblemaSaudeModel> BuscarTodos(int codPessoa);
        ProblemaSaudeModel Buscar(int codProblemaSaude);
        void Excluir(int codProblemaSaude);
        ProblemaSaudeModel Atualizar(ProblemaSaudeModel problema);
        ProblemaSaudeModel Adicionar(ProblemaSaudeModel problema);
    }
}