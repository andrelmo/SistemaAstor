using Dapper.Contrib.Extensions;
using System;

namespace ProjetoControleCestas.Modelo
{
    [Table("tbAberturaFamilia")]
    public class AberturaFamiliaModel
    {
        [Key]
        public int CodigoAberturaFamilia { get; set; }
        public int CodFamilia { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public string Status { get; set; }
        public string Observacao { get; set; }
        public int CodVoluntario { get; set; }
        public string TipoCesta { get; set; }
        public string CorCesta { get; set; }
    }
}