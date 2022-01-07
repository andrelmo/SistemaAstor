using Dapper.Contrib.Extensions;
using ProjetoControleCestas.Enums;

namespace ProjetoControleCestas.Modelo
{
    [Table("tbPessoas")]
    public class PessoasModel
    {
        [Key]
        public int CodPessoas { get; set; }
        public string Nome { get; set; }
        public string Identidade { get; set; }
        public string Cpf { get; set; }
        public SituacaoCivil SituacaoCivil { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public string Naturalidade { get; set; }
        public string AtividadeDesenvolvida { get; set;}
        public string AreaInteresseProfissional { get; set; }
        public string Deficiencia { get; set; }
        public byte Idoso { get; set; }
        public string Sexo { get; set; }
        public string Escolaridade { get; set; }
        public string Parentesco { get; set; }
        public int CodFamilia { get; set; }
        public VinculoFamiliar VinculoFamiliar { get; set; }
        public string ProblemaSaude { get; set; }
        public bool IsResponsavelFamilia { get; set; }
    }
}