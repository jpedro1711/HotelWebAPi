using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Hotel
{
    public class TipoPagamento
    {   
        [Key]
        public int TipoPagamentoCodigo {get; set;}
        
        [StringLength(50)]        
        public string? Descricao {get; set;}     

        public ICollection<NotaFiscal>? NotasFiscais {get; set;}   
    }
}