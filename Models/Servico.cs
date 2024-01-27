using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Hotel
{
    public class Servico
    {   
        [Key]
        public int ServicoCodigo {get; set;}

        [StringLength(100)]
        public int? Descricao {get; set;}            

        public decimal? Valor {get; set;}

        [ForeignKey("Filial"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FilialCodigo {get; set;}
        public Filial? Filial {get; set;}

        public ICollection<ContaCliente_Servico>? ContaClienteServicos {get; set;}
    }
}