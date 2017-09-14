using Model.Models;
using Service.Services;
using System.Net;
using System.Web.Mvc;

namespace ProjetoEscolar.Controllers
{
    public class ProfessorController : Controller
    {
        private ProfessorService professorService = new ProfessorService();

        // GET: Professor
        public ActionResult Index()
        {
            return View(professorService.ObterProfessoresOrdenadosPorNome());
        }

        // GET: Professor/Details/5
        public ActionResult Details(long? id)
        {
            return ObterViewProfessorPorId(id);
        }

        // GET: Professor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Professor professor)
        {
            return GravarProfessor(professor);
        }

        // GET: Professor/Edit/5
        public ActionResult Edit(long? id)
        {
            return ObterViewProfessorPorId(id);
        }

        // POST: Professor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Professor professor)
        {
            return GravarProfessor(professor);
        }

        // GET: Professor/Delete/5
        public ActionResult Delete(long? id)
        {
            return ObterViewProfessorPorId(id);
        }

        // POST: Professor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                professorService.RemoverProfessorPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ActionResult GravarProfessor(Professor professor)
        {
            try
            {
                professorService.GravarProfessor(professor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(professor);
            }
        }

        private ActionResult ObterViewProfessorPorId(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Professor professor = professorService.ObterProfessorPorId((long) id);
            if (professor == null)
                return HttpNotFound();
            return View(professor);
        }
    }
}
