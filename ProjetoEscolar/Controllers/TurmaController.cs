using Model.Models;
using Service.Services;
using System.Net;
using System.Web.Mvc;

namespace ProjetoEscolar.Controllers
{
    public class TurmaController : Controller
    {
        private TurmaService turmaService = new TurmaService();
        private DisciplinaService disciplinaService = new DisciplinaService();

        // GET: Turma
        public ActionResult Index()
        {
            return View(turmaService.ObterTurmasOrdenadasPorDisciplina());
        }

        // GET: Turma/Details/5
        public ActionResult Details(long? id)
        {
            return ObterViewPorId(id, false);
        }

        // GET: Turma/AtribuirProfessor/5
        public ActionResult AtribuirProfessor(long? id)
        {
            return ObterViewPorId(id, true);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtribuirProfessor(long id, long professorId)
        {
            Turma turma = turmaService.ObterTurmaPorId(id);
            turma.ProfessorId = professorId;
            turmaService.GravarTurma(turma);
            
            return RedirectToAction("Index");
        }

        // GET: Turma/Create
        public ActionResult Create()
        {
            PopulaViewBag();
            return View();
        }

        // POST: Turma/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Turma turma)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    turmaService.GravarTurma(turma);
                    return RedirectToAction("Index");
                }

                PopulaViewBag();
                return View(turma);
            }
            catch
            {
                PopulaViewBag();
                return View(turma);
            }
        }

        // GET: Turma/Edit/5
        public ActionResult Edit(long? id)
        {
            return ObterViewPorId(id, true);
        }

        // POST: Turma/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Turma turmaAlterada)
        {
            try
            {
                Turma turma = turmaService.ObterTurmaPorId(
                    (long) turmaAlterada.Id);
                turma.DisciplinaId = turmaAlterada.DisciplinaId;
                turma.Vagas = turmaAlterada.Vagas;
                turma.Turno = turmaAlterada.Turno;
                turma.ProfessorId = null;
                turma.Professor = null;
                
                turmaService.GravarTurma(turma);
                return RedirectToAction("Index");
            }
            catch
            {
                PopulaViewBag();
                return View(turmaAlterada);
            }
        }

        // GET: Turma/Delete/5
        public ActionResult Delete(long? id)
        {
            return ObterViewPorId(id, false);
        }

        // POST: Turma/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Turma turma = turmaService.RemoverTurmaPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void PopulaViewBag(Turma turma = null)
        {
            if (turma == null)
                ViewBag.DisciplinaId = new SelectList(
                    disciplinaService.ObterDisciplinasOrdenadasPorNome(),
                    "Id", "Nome");
            else
            {
                ViewBag.DisciplinaId = new SelectList(
                    disciplinaService.ObterDisciplinasOrdenadasPorNome(),
                    "Id", "Nome", turma.DisciplinaId);
                ViewBag.ProfessorId = new SelectList(
                    turma.Disciplina.ProfessoresHabilitados, "Id", "Nome");
            }
                
        }

        private ActionResult ObterViewPorId(long? id, bool popularViewBag)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Turma turma = turmaService.ObterTurmaPorId((long)id);
            if (turma == null)
                return HttpNotFound();
            if (popularViewBag)
                PopulaViewBag(turma);

            return View(turma);
        }
    }
}
