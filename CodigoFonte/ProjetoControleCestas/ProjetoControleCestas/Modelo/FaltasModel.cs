using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoControleCestas.Modelo
{
    [Table("tbFaltas")]
    public class FaltasModel: EntidadeBaseModel
    {
        [Key]
        public int CodigoFaltas { get; set; }
        public int CodigoAberturaFamilia { get; set; }
        public DateTime DataFalta { get; set; }
        public string Justificativa { get; set; }
    }
}