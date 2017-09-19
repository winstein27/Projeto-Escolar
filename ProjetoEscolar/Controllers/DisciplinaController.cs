using Model.Models;
using ProjetoEscolar.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProjetoEscolar.Controllers
{
    public class DisciplinaController : Controller
    {
        private DisciplinaService disciplinaService = new DisciplinaService();
        private ProfessorService professorService = new ProfessorService();

        // GET: Disciplina
        public ActionResult Index()
        {
            return View(disciplinaService.ObterDisciplinasOrdenadasPorNome());
        }

        // GET: Disciplina/Details/5
        public ActionResult Details(long? id)
        {
            return ObterViewDisciplinaPorId(id);
        }

        // GET: Disciplina/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Disciplina/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                disciplinaService.GravarDisciplina(disciplina);
                return RedirectToAction("Index");
            }
            return View(disciplina);
        }

        // GET: Disciplina/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Disciplina disciplina = disciplinaService.ObterDisciplinaPorId((long)id);
            if (disciplina == null)
                return HttpNotFound();

            return View(PreparaDisciplinaEditModel(disciplina));
        }

        // POST: Disciplina/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DisciplinaSaveModel disciplinaModel)
        {
            if (ModelState.IsValid)
            {
                Disciplina disciplina = AtualizaDisciplina(disciplinaModel);
                disciplinaService.GravarDisciplina(disciplina);
                return RedirectToAction("Index");
            }
            return View(disciplinaModel);
        }

        // GET: Disciplina/Delete/5
        public ActionResult Delete(long? id)
        {
            return ObterViewDisciplinaPorId(id);
        }

        // POST: Disciplina/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                disciplinaService.RemoverDisciplinaPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ActionResult ObterViewDisciplinaPorId(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Disciplina disciplina = disciplinaService.ObterDisciplinaPorId((long)id);
            if (disciplina == null)
                return HttpNotFound();

            return View(disciplina);
        }

        private DisciplinaEditModel PreparaDisciplinaEditModel(Disciplina disciplina)
        {
            IList<Disciplina> disciplinasNaoPreRequisitos =
                disciplinaService.ObterDisciplinasOrdenadasPorNome().ToList();
            disciplinasNaoPreRequisitos.Remove(disciplina);

            IList<Professor> professoresNaoHabilitados =
                professorService.ObterProfessoresOrdenadosPorNome().ToList();

            return new DisciplinaEditModel()
            {
                Disciplina = disciplina,
                DisciplinasNaoPreRequisitos = disciplinasNaoPreRequisitos.
                    Except(disciplina.PreRequisitos),
                ProfessoresNaoHabilitados = professoresNaoHabilitados.
                    Except(disciplina.ProfessoresHabilitados)
            };
        }

        private Disciplina AtualizaDisciplina(DisciplinaSaveModel disciplinaModel)
        {
            Disciplina disciplina = disciplinaService.ObterDisciplinaPorId(
                    (long)disciplinaModel.Disciplina.Id);
            disciplina.Nome = disciplinaModel.Disciplina.Nome;

            foreach (string id in disciplinaModel.IdsDisciplinasParaAdicionar
                ?? new string[] { })
            {
                Disciplina preRequisito = disciplinaService.
                    ObterDisciplinaPorId(Convert.ToInt64(id));
                disciplina.PreRequisitos.Add(preRequisito);
            }

            foreach (string id in disciplinaModel.IdsDisciplinasParaRemover
                ?? new string[] { })
            {
                Disciplina naoPreRequisito = disciplinaService.
                    ObterDisciplinaPorId(Convert.ToInt64(id));
                disciplina.PreRequisitos.Remove(naoPreRequisito);
            }

            foreach (string id in disciplinaModel.IdsProfessoresParaAdicionar
                ?? new string[] { })
            {
                Professor professorHabilitado = professorService.
                    ObterProfessorPorId(Convert.ToInt64(id));
                disciplina.ProfessoresHabilitados.Add(professorHabilitado);
            }

            foreach (string id in disciplinaModel.IdsProfessoresParaRemover
                ?? new string[] { })
            {
                Professor professor = professorService.
                    ObterProfessorPorId(Convert.ToInt64(id));
                disciplina.ProfessoresHabilitados.Remove(professor);
            }

            return disciplina;
        }
    }
}
