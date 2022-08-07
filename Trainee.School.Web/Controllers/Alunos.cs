using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Trainee.School.Domain.Contratos;
using Trainee.School.Domain.Entidades;
using Trainee.School.Web.Models;
namespace Trainee.School.Web.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IRepositoryBase<Aluno> _repositoryAluno;

        public AlunosController(IRepositoryBase<Aluno> repositoryAluno)
        {
            _repositoryAluno = repositoryAluno;
        }

        //Get Alunos
        public IActionResult Index()
        {
            var Alunos = _repositoryAluno.GetAll().Select(s => new AlunoViewModel { IdAluno = s.IdAluno, Nome = s.Nome, Matricula = s.Matricula, Email = s.Email });

            return View(Alunos);
        }

    }
}
