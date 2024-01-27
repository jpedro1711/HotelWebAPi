using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Hotel
{
    public class Email
    {
        [Key]
        public int EmailCodigo {get; set;}

        [ForeignKey("Cliente"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClienteCodigo {get; set;}
        
        [StringLength(100)]
        public string? EnderecoEmail {get; set;}        

        public Cliente? Cliente {get; set;}         
    }
}