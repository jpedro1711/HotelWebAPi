using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Hotel
{
    public class ContaCliente
    {
        [Key]
        public int ContaClienteCodigo {get; set;}   

        [ForeignKey("Cliente"), DatabaseGenerated(DatabaseGeneratedOption.None)]     
        public int ClienteCodigo {get; set;}    
        public Cliente? Cliente {get; set;}

        public ICollection<ContaCliente_Consumo>? ContaClienteConsumos {get; set;}
        public ICollection<ContaCliente_Servico>? ContaClienteServicos {get; set;}
    }
}