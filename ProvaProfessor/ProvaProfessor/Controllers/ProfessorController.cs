using ProvaProfessor.Context;
using ProvaProfessor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProvaProfessor.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly Contexto db = new Contexto();
        // GET: Aluno
        public ActionResult Index()
        {
            return View(db.Professores.ToList());
        }

        #region Create - GET
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(ProfessorModel prof)
        {
            if (ModelState.IsValid)
            {
                db.Professores.Add(prof);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(prof);
        }
        #endregion

        #region Details 
        [HttpGet]
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorModel prof = db.Professores.Where(a => a.Id == id).FirstOrDefault();
            if (prof == null)
            {
                return HttpNotFound();
            }
            return View(prof);
        }
        #endregion

        #region Edit - GET
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorModel prof = db.Professores.Where(a => a.Id == id).FirstOrDefault();
            if (prof == null)
            {
                return HttpNotFound();
            }
            return View(prof);
        }
        #endregion

        #region Edit - POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfessorModel prof)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prof).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(prof);
        }
        #endregion

        #region Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorModel prof = db.Professores.Find(id);
            if (prof == null)
            {
                return HttpNotFound();
            }
            return View(prof);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfessorModel aluno = db.Professores.Find(id);
            db.Professores.Remove(aluno);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}