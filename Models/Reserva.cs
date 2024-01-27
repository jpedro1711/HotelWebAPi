using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Hotel
{
    public class Reserva
    {   
        [Key, ForeignKey("Filial"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FilialCodigo {get; set;}

        [Key]
        public int ReservaCodigo {get; set;}         

        [ForeignKey("Quarto"), DatabaseGenerated(DatabaseGeneratedOption.None)]  
        public int QuartoCodigo {get; set;}  
        
        [ForeignKey("Cliente"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClienteCodigo {get; set;}
        
        [ForeignKey("NotaFiscal"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NotaFiscalCodigo {get; set;}
        
        [DataType(DataType.Date)]
        public DateTime DataInicio {get; set;}

        [DataType(DataType.Date)]
        public DateTime DataFim {get; set;}                   

        public bool? Cancelada {get; set;}                   

        public bool? CobrancaDiaria {get; set;}
        
        public decimal? ValorTotal {get; set;}          

        public Filial? Filial {get; set;}
        public Quarto? Quarto {get; set;} 
        public Cliente? Cliente {get; set;}
        public NotaFiscal? NotaFiscal {get; set;}
        
    }
}