using Dapper.Contrib.Extensions;

namespace ProjetoControleCestas.Modelo
{
    [Table("tbFamilia")]
    public class FamiliaModel: EntidadeBaseModel
    {
        [Key]
        public int CodFamilia { get; set; }
        public string TipoLogradouro { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Municipio { get; set; }
        public string Referencia { get; set; }
        public string Onibus { get; set; }
        public bool IsResponsavelFamilia { get; set; }
        public string CpfResponsavel { get; set; }
        public string NomeResponsavel { get; set; }
    }
}