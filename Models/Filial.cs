using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Hotel
{
    public class Filial
    {
        [Key]
        public int FilialCodigo {get; set;}

        [StringLength(50)]
        public string? Nome {get; set;}  
              
        public int? QtdEstrelas {get; set;}

        [ForeignKey("Endereco"), DatabaseGenerated(DatabaseGeneratedOption.None)]                        
        public int EnderecoCodigo {get; set;}
        public Endereco? Endereco {get; set;}

        public ICollection<TipoQuarto>? TiposQuartos { get; set; }
        public ICollection<Consumo>? Consumos { get; set; }
        public ICollection<Servico>? Servicos { get; set; }
        public ICollection<Reserva>? Reservas { get; set; }
    }
}
