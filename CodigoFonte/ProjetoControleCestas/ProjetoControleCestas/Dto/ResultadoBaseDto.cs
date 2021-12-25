namespace ProjetoControleCestas.Dto
{
    public abstract class ResultadoBaseDto
    {
        public bool IsErro { get; set; }
        public string MensagemErro { get; set; }
    }
}