using Dapper.Contrib.Extensions;

namespace ProjetoControleCestas.Modelo
{
    [Table("tbAtividadeDesenvolvida")]
    public class AtividadeDesenvolvidaModel: EntidadeBaseModel
    {
        [Key]
        public int codAtividadeDesenvolvida { get; set; }
        public string Atividade { get; set; }
        public int CodPessoas { get; set; }
    }
}