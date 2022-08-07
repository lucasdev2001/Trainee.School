using System.ComponentModel.DataAnnotations;

namespace Trainee.School.Web.Models
{
    public class AlunoViewModel
    {
        [Key]
        public int IdAluno { get; set; }
        public string Nome{ get; set; }
        public string Email { get; set; }
        public string Matricula { get; set; }
    }
}
