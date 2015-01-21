using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteEntityFramework.Models;

namespace TesteEntityFramework.Controllers
{
    public class AlunoController : Controller
    {
        TesteEntityContext db = new TesteEntityContext();
        public ActionResult Index()
        {
            List<Aluno> alunos = db.Alunos.ToList();
            return View(alunos);
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int id)
        {
            Aluno a = db.Alunos.Find(id);
            if (a == null)
            {
                return HttpNotFound();
            }
            
            return View(a);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            Aluno a = new Aluno();
            ViewBag.Telefones = db.TelefonesAluno.Where(telefone => false);
            return View(a);
        }

        // POST: Aluno/Create
        [HttpPost]
        public ActionResult Create(Aluno aluno, FormCollection form)
        {
            try
            {
                db.Alunos.Add(aluno);
                PegaTelefones(aluno, form);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(aluno);
            }
        }

        // GET: Aluno/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Aluno a = db.Alunos.Find(id);
            if (a == null)
            {
                return HttpNotFound();
            }
            ViewBag.Telefones = db.TelefonesAluno.Where(telefone => telefone.AlunoID == id);
            return View(a);
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        public ActionResult Edit(Aluno aluno, FormCollection form)
        {
            try
            {
                db.Entry(aluno).State = System.Data.Entity.EntityState.Modified;
                foreach (var t in db.TelefonesAluno.Where(telefone => telefone.AlunoID == aluno.AlunoID))
                {
                    db.TelefonesAluno.Remove(t);
                }
                PegaTelefones(aluno, form);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(aluno);
            }
        }

        private static void PegaTelefones(Aluno aluno, FormCollection form)
        {
            if (form["telefone"] != null)
            {
                string[] telefones = form["telefone"].ToString().Split(',');
                if (telefones.Length > 0)
                {
                    foreach (var t in telefones)
                    {
                        if (t.Trim() != String.Empty)
                        {
                            aluno.Telefones.Add(new TelefoneAluno() { AlunoID = aluno.AlunoID, Numero = t });
                        }
                    }
                }
            }
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int id)
        {
            Aluno a = db.Alunos.Find(id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }

        // POST: Aluno/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Aluno a = db.Alunos.Find(id);
                if (a == null)
                {
                    return HttpNotFound();
                }

                db.Alunos.Remove(a);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

      
    }
}
