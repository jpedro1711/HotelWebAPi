using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Hotel
{
    public class Quarto
    {   
        [Key]
        public int QuartoCodigo {get; set;}

        [ForeignKey("Filial"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FilialCodigo {get; set;}        
        
        public int Numero {get; set;}                

        [ForeignKey("TipoQuarto"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TipoQuartoCodigo {get; set;}      
        
        public int? CapacidadeMax {get; set;} 

        public bool? CapacidadeOpc {get; set;}                

        public Filial? Filial {get; set;}
        public TipoQuarto? TipoQuarto {get; set;} 

        public ICollection<Reserva>? Reservas{get; set;}
    }
}