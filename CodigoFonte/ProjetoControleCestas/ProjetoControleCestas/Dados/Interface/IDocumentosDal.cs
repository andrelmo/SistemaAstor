using ProjetoControleCestas.Modelo;
using System.Collections.Generic;
using System.Data;

namespace ProjetoControleCestas.Dados.Interface
{
    public interface IDocumentosDal
    {
        void ExcluirTodos(int codPessoas, IDbTransaction transacao);
        DocumentosModel Adicionar(DocumentosModel documento);
        DocumentosModel Atualizar(DocumentosModel documento);
        void Excluir(int codigoDocumento);
        DocumentosModel Buscar(int codigoDocumento);
        List<DocumentosModel> BuscarTodos(int codPessoas);
    }
}