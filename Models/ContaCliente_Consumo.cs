using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DB_Hotel
{
    public class ContaCliente_Consumo
    {
        [Key, ForeignKey("ContaCliente"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        
        public int ContaClienteCodigo {get; set;}
        
        [Key, ForeignKey("Consumo"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ConsumoCodigo {get; set;}   
          
        [Key]         
        public DateTime DataHoraConsumo {get; set;}

        public bool? ServicoQuarto {get; set;}
        
        [ForeignKey("Funcionario"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FuncionarioCodigo {get; set;}

        public ContaCliente? ContaCliente {get; set;}
        public Consumo? Consumo {get; set;} 
        public Funcionario? Funcionario {get; set;}       
        
    }
}