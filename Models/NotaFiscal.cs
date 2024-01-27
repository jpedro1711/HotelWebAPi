using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace DB_Hotel
{
    public class NotaFiscal
    {
        [Key]
        public int NotaFiscalCodigo {get; set;}        

        [StringLength(35)]        
        public string? Numero {get; set;}

        [DataType(DataType.Date)] 
        public DateTime? Data {get; set;}                

        [ForeignKey("TipoPagamento"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TipoPagamentoCodigo {get; set;}
        public TipoPagamento? TipoPagamento {get; set;}

        public ICollection<Reserva>? Reservas {get; set;}
        
    }
}