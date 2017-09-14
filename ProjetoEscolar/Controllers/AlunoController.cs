using Model.Models;
using Service.Services;
using System.Net;
using System.Web.Mvc;

namespace ProjetoEscolar.Controllers
{
    public class AlunoController : Controller
    {
        private AlunoService alunoService = new AlunoService();

        // GET: Aluno
        public ActionResult Index()
        {
            return View(alunoService.ObterAlunosOrdenadosPorNome());
        }

        // GET: Aluno/Details/5
        public ActionResult Details(long? id)
        {
            return ObterViewAlunoPorId(id);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aluno aluno)
        {
            return GravarAluno(aluno);
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(long? id)
        {
            return ObterViewAlunoPorId(id);
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aluno aluno)
        {
            return GravarAluno(aluno);
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(long? id)
        {
            return ObterViewAlunoPorId(id);
        }

        // POST: Aluno/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                alunoService.RemoverAlunoPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ActionResult GravarAluno(Aluno aluno)
        {
            try
            {
                alunoService.GravarAluno(aluno);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(aluno);
            }
        }

        private ActionResult ObterViewAlunoPorId(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Aluno aluno = alunoService.ObterAlunoPorId((long)id);
            if (aluno == null)
                return new HttpNotFoundResult();

            return View(aluno);
        }
    }
}
