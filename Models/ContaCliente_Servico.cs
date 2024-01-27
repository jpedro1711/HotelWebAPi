using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Hotel
{
    public class ContaCliente_Servico
    {
        [Key, ForeignKey("ContaCliente"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContaClienteCodigo {get; set;}
    
        [Key, ForeignKey("Servico"), DatabaseGenerated(DatabaseGeneratedOption.None)]        
        public int ServicoCodigo {get; set;}   
                            
        [Key]
        public DateTime DataHoraServico {get; set;}                    
        
        [ForeignKey("Funcionario"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FuncionarioCodigo {get; set;}    

        public ContaCliente? ContaCliente {get; set;}
        public Servico? Servico {get; set;} 
        public Funcionario? Funcionario {get; set;}
    }
}