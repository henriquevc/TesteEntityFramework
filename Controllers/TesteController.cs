using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteEntityFramework.Models;

namespace TesteEntityFramework.Controllers
{
    public class TesteController : Controller
    {
        TesteEntityContext db = new TesteEntityContext();
        // GET: Teste
        public string Incluir()
        {
            
            
                Aluno a1 = new Aluno()
                {
                    Nome = "Henrique",
                    Endereco = new Endereco{
                        Logradouro = "Rua Bertioga",
                        CEP = "79080-690",
                        Numero = 336
                    }
                };
                Aluno a2 = new Aluno()
                {
                    Nome = "Claudio",
                    Endereco = new Endereco
                    {
                        Logradouro = "Rua Ouvidor Peleja",
                        CEP = "04128-001",
                        Numero = 585
                    }
                };

                Professor p1 = new Professor()
                {
                    Nome = "Girafales",
                    Endereco = new Endereco
                    {
                        Logradouro = "Rua Ouvidor",
                        CEP = "04128-001",
                        Numero = 585
                    }
                };

                Turma t1 = new Turma()
                {
                    Vagas = 10,
                    Professor = p1
                };

                t1.Alunos.Add(a1);
                t1.Alunos.Add(a2);

                db.Turmas.Add(t1);
                db.SaveChanges();

            
            return "Inserção de turma realizada com sucesso!";
        }

        public ActionResult Index()
        {
                var alunos = db.Alunos.ToList();

                return View(alunos);
            
        }
    }
}