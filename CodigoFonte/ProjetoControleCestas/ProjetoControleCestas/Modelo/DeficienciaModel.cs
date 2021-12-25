using Dapper.Contrib.Extensions;

namespace ProjetoControleCestas.Modelo
{
    [Table("tbDeficiencia")]
    public class DeficienciaModel
    {
        [Key]
        public int CodDeficiencia { get; set; }
        public int CodPessoa { get; set; }
        public string Deficiencia { get; set; }
    }
}