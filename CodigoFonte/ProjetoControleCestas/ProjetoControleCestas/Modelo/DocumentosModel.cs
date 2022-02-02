using Dapper.Contrib.Extensions;

namespace ProjetoControleCestas.Modelo
{
    [Table("tbDocumentos")]
    public class DocumentosModel: EntidadeBaseModel
    {
        [Key]
        public int CodigoDocumento { get; set; }
        public int CodPessoas { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
    }
}