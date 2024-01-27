using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Hotel
{
    public class Telefone
    {
        [Key]
        public int TelefoneCodigo {get; set;}        

        [ForeignKey("Cliente"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClienteCodigo {get; set;} 
             
        [StringLength(20)]
        public string? Numero {get; set;}        

        public Cliente? Cliente {get; set;}  
    }
}