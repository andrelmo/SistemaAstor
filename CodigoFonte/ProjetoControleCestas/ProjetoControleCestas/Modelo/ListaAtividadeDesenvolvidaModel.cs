using Dapper.Contrib.Extensions;

namespace ProjetoControleCestas.Modelo
{
    [Table("tblistaatividadedesenvolvida")]
    public class ListaAtividadeDesenvolvidaModel
    {
        [Key]
        public int CodAtividadeDesenvolvida { get; set; }
        public string Atividade { get; set; }
    }
}