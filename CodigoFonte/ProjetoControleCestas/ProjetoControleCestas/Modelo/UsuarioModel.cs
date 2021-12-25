using Dapper.Contrib.Extensions;
using ProjetoControleCestas.Enums;
using System;

namespace ProjetoControleCestas.Modelo
{
    [Table("tbUsuario")]
    public class UsuarioModel
    {
        [Key]
        public int CodigoUsuario { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public string Status { get; set; }
        public DateTime DataCriacao { get; set; }

        public UsuarioModel()
        {
            this.DataCriacao = DateTime.Now;
        }
    }
}