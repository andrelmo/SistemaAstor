using Dapper.Contrib.Extensions;

namespace ProjetoControleCestas.Modelo
{
    [Table("tbTipoBeneficios")]
    public class TipoBeneficioModel: EntidadeBaseModel
    {
        [Key]
        public int CodTipoBeneficio { get; set; }
        public string Beneficio { get; set; }
    }
}