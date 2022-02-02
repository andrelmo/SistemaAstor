using Dapper.Contrib.Extensions;
using ProjetoControleCestas.Enums;

namespace ProjetoControleCestas.Modelo
{
    [Table("tbMoradia")]
    public class MoradiaModel: EntidadeBaseModel
    {
        [Key]
        public int CodCaracteristicasMoradia { get; set; }
        public int CodFamilia { get; set; }

        private CondicaoMoradia _condicaoMoradia;
        public CondicaoMoradia CondicaoMoradia 
        { 
            get
            {
                return (this._condicaoMoradia);
            }
            set
            {
                this._condicaoMoradia = value;

                if (this._condicaoMoradia == CondicaoMoradia.Alugada)
                    this.DescricaoCondicaoMoradia = Constantes.ConstantesGlobais.TIPO_CONDICAO_MORADIA_ALUGADA;
                else if (this._condicaoMoradia == CondicaoMoradia.Cedida)
                    this.DescricaoCondicaoMoradia = Constantes.ConstantesGlobais.TIPO_CONDICAO_MORADIA_CEDIDA;
                else
                    this.DescricaoCondicaoMoradia = Constantes.ConstantesGlobais.TIPO_CONDICAO_MORADIA_PROPRIA;
            }
        }

        public byte NumeroComodos { get; set; }
        public byte NumeroQuartos { get; set; }

        private Banheiro _banheiro;
        public Banheiro Banheiro 
        { 
            get
            {
                return (this._banheiro);
            }
            set
            {
                this._banheiro = value;

                if (this._banheiro == Banheiro.Coletivo)
                    this.DescricaoBanheiro = Constantes.ConstantesGlobais.TIPO_BANHEIRO_COLETIVO;
                else if (this._banheiro == Banheiro.NaoPossui)
                    this.DescricaoBanheiro = Constantes.ConstantesGlobais.TIPO_BANHEIRO_NAO_POSSUI;
                else
                    this.DescricaoBanheiro = Constantes.ConstantesGlobais.TIPO_BANHEIRO_PROPRIO;
            }
        }

        public string DescricaoBanheiro { get; private set; }

        public string DescricaoCondicaoMoradia { get; private set; }
    }
}