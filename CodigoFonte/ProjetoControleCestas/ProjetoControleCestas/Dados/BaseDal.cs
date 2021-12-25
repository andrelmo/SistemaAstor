using System.Configuration;

namespace ProjetoControleCestas.Dados
{
    public abstract class BaseDal
    {
        private const int TIMEOUT_PADRAO = 3000;

        protected int TimeoutPadrao
        {
            get => TIMEOUT_PADRAO;
        }

        public string GetConnecitonString()
        {
            return (ConfigurationManager.ConnectionStrings["ConexaoSistemaCestas"].ConnectionString);
        }
    }
}