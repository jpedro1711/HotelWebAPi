using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_Hotel
{
    public class TipoFuncionario
    {
        [Key]
        public int TipoFuncionarioCodigo {get; set;}

        [StringLength(50)]        
        public string? Descricao {get; set;}   

        public ICollection<Funcionario>? Funcionarios {get; set;}
    }
}