using Dapper.Contrib.Extensions;

namespace ProjetoControleCestas.Modelo
{
    [Table("tbProblemaSaude")]
    public class ProblemaSaudeModel: EntidadeBaseModel
    {
        [Key]
        public int CodProblemaSaude { get; set; }
        public int CodPessoa { get; set; }
        public string ProblemaSaude { get; set; }
        public string Medicamento { get; set; }
        public string Local { get; set; }
        public string Periodicidade { get; set; }
    }
}