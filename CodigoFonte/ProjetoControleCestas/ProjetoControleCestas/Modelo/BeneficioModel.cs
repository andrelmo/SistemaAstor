using Dapper.Contrib.Extensions;

namespace ProjetoControleCestas.Modelo
{
    [Table("tbBeneficio")]
    public class BeneficioModel: EntidadeBaseModel
    {
        [Key]
        public int CodBeneficio { get; set; }
        public int CodPessoa { get; set; }
        public int CodTipoBeneficio { get; set; }
        public string Beneficio { get; set; }
        public decimal ValorBeneficio { get; set; }
    }
}