using Dapper.Contrib.Extensions;

namespace ProjetoControleCestas.Modelo
{
    [Table("tbListaAreaInteresseProfissional")]
    public class ListaAreaInteresseProfissionalModel
    {
        [Key]
        public int CodAreaInteresseProfissional { get; set; }
        public string AreaInteresse { get; set; }
    }
}