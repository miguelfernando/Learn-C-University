using appSchool.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appSchool.Models
{
    [Table("Aluno")]
    public class Aluno
    {
        [Key]
        public int ID { get; set; }
        public int RGA { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
	    public EnumStatusAluno StatusAluno { get; set; }
	    public string Foto { get; set; }
        public EnumSexo Sexo { get; set; }

        
    }
}