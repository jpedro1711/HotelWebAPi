using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Hotel
{
    public class Endereco
    {
        [Key]
        public int EnderecoCodigo {get; set;}

        [StringLength(100)]
        public string? Rua {get; set;} 

        [StringLength(10)]
        public string? Numero {get; set;}

        [StringLength(30)]
        public string? Complemento{get; set;}

        [StringLength(100)]
        public string? Bairro {get; set;}

        [StringLength(100)]
        public string? Cidade {get; set;}

        [StringLength(50)]
        public string? Estado {get; set;}

        [StringLength(100)]
        public string? Pais {get; set;}       

        public ICollection<Cliente>? Clientes { get; set; } 
        public ICollection<Filial>? Filiais { get; set; }
    }
}