using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Hotel
{
    public class TipoQuarto
    {
        [Key]
        public int TipoQuartoCodigo {get; set;}

        [StringLength(50)]
        public string? Descricao {get; set;}

        public decimal? Valor {get; set;} 

        [ForeignKey("Filial"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FilialCodigo {get; set;}                
        public Filial? Filial {get; set;}

        public ICollection<Quarto>? Quartos {get; set;}
    }

}