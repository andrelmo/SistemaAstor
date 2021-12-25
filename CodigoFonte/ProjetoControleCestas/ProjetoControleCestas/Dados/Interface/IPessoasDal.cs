using ProjetoControleCestas.Modelo;
using System.Collections.Generic;

namespace ProjetoControleCestas.Dados.Interface
{
    public interface IPessoasDal
    {
        void Excluir(int codPessoas);
        PessoasModel Adicionar(PessoasModel pessoa);
        PessoasModel Atualizar(PessoasModel pessoa);
        PessoasModel Buscar(int codPessoas);
        List<PessoasModel> BuscarTodos(int codFamilia);
    }
}