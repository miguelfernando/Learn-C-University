using appSchool.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appSchool.Models
{
    [Table("Responsavel")]
    public class Responsavel
    {
        [Key]
        public int IDResponsavel {get;set;}
        public string Nome {get;set;}
        public string Email {get;set;}
        public string Senha {get;set;}
        public EnumTipoResponsavel TipoResponsavel {get;set;}
        public string Telefone {get;set;}
    }
}