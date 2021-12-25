using ProjetoControleCestas.Modelo;
using System.Collections.Generic;

namespace ProjetoControleCestas.Dados.Interface
{
    public interface IMoradiaDal
    {
        List<MoradiaModel> BuscarTodos(int codFamilia);
        MoradiaModel Buscar(int codCaracteristicasMoradia);
        MoradiaModel Adicionar(MoradiaModel moradia);
        MoradiaModel Atualizar(MoradiaModel moradia);
        void Excluir(int codCaracteristicasMoradia);
    }
}