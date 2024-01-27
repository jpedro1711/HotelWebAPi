using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Hotel
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioCodigo {get; set;} 

        [StringLength(50)]        
        public string? Nome {get; set;}    

        [ForeignKey("TipoFuncionario"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TipoFuncionarioCodigo {get; set;}        
        
        [ForeignKey("Filial"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FilialCodigo {get; set;}        

        public TipoFuncionario? TipoFuncionario {get; set;}
        public Filial? Filial {get; set;}

        public ICollection<ContaCliente_Consumo>? ContaClienteConsumos{get; set;}
        public ICollection<ContaCliente_Servico>? ContaClienteServicos{get; set;}
    }

}