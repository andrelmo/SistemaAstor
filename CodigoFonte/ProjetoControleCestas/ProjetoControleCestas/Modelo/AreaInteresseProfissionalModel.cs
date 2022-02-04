using Dapper.Contrib.Extensions;

namespace ProjetoControleCestas.Modelo
{
    [Table("tbAreaInteresseProfissional")]
    public class AreaInteresseProfissionalModel : EntidadeBaseModel
    {
        [Key]
        public int codAreaInteresseProfissional { get; set; }
        public string AreaInteresse { get; set; }
        public int CodPessoas { get; set; }
    }
}