using Microsoft.Extensions.DependencyInjection;
using ProjetoControleCestas.Modelo;

namespace ProjetoControleCestas
{
    public static class SessaoSistema
    {
        public static UsuarioModel UsuarioCorrente { get; set; }
        public static ServiceCollection Services { get; set; }
    }
}