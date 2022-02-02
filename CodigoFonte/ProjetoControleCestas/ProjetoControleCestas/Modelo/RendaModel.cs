using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoControleCestas.Modelo
{
    [Table("tbRenda")]
    public class RendaModel: EntidadeBaseModel
    {
        [Key]
        public int CodRenda { get; set; }
        public int CodPessoas { get; set; }
        public string Renda { get; set; }
        public decimal ValorRenda { get; set; }
    }
}