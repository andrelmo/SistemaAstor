using Dapper.Contrib.Extensions;
using System;

namespace ProjetoControleCestas.Modelo
{
    [Table("tbVisita")]
    public class VisitaModel: EntidadeBaseModel
    {
        [Key]
        public int CodigoVisita { get; set; }
        public int CodFamilia { get; set; }
        public int CodVoluntario { get; set; }
        public string Voluntario { get; set; }
        public DateTime DataVisita { get; set; }
        public string Alimentacao { get; set; }
        public string ReligiaoPredominante { get; set; }
        public string AguaTratada { get; set; }
        public string EsgotoSanitario { get; set; }
        public string EnergiaEletrica { get; set; }
        public string ServicosPublicos { get; set; }
        public string Moradia { get; set; }
        public string HigieneLimpeza { get; set; }
        public string RelacaoFamiliar { get; set; }
        public string Confinamento { get; set; }
        public string Observacoes { get; set; }
    }
}