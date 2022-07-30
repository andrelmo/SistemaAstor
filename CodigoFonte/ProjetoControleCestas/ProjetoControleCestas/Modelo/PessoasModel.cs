using Dapper.Contrib.Extensions;
using ProjetoControleCestas.Enums;
using System;

namespace ProjetoControleCestas.Modelo
{
    [Table("tbPessoas")]
    public class PessoasModel: EntidadeBaseModel
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
        public string Deficiencia { get; set; }
        public byte Idoso { get; set; }
        public string Sexo { get; set; }
        public string Escolaridade { get; set; }
        public string Parentesco { get; set; }
        public int CodFamilia { get; set; }
        public VinculoFamiliar VinculoFamiliar { get; set; }
        public string ProblemaSaude { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Celular { get; set; }
        public string Residencial { get; set; }
        public string Recado { get; set; }
        public string Trabalho { get; set; }
        public string Outro { get; set; }
    }
}