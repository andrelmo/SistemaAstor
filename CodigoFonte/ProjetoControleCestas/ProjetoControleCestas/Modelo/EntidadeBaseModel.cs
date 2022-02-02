using System;

namespace ProjetoControleCestas.Modelo
{
    public abstract class EntidadeBaseModel
    {
        public int? CodUsuarioCriacao { get; set; }
        public DateTime? DataCriacao { get; set; }
        public int? CodUsuarioModificacao { get; set; }
        public DateTime? DataModificacao { get; set; }
    }
}