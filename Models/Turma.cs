using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteEntityFramework.Models
{
    public class Turma
    {

        public int TurmaID { get; set; }
        public int Vagas { get; set; }
        public Professor Professor { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }

        public Turma()
        {
            Alunos = new List<Aluno>();
        }

    }
}