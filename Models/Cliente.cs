using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Hotel
{
    public class Cliente
    {
        [Key]
        public int ClienteCodigo {get; set;}
        
        [StringLength(100)]
        public string? Nome {get; set;}   

        [StringLength(100)]
        public string? Nacionalidade {get; set;} 

        [ForeignKey("Endereco"), DatabaseGenerated(DatabaseGeneratedOption.None)]                        
        public int EnderecoCodigo {get; set;}
        public Endereco? Endereco {get; set;}

        public ICollection<Email>? Emails {get; set;}

        public ICollection<Telefone>? Telefones {get; set;}
        public ICollection<Reserva>? Reservas {get; set;}
    }
}