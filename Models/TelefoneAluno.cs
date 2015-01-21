using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteEntityFramework.Models
{
    public class TelefoneAluno
    {
        public int ID { get; set; }

        public string Numero { get; set; }

        public int AlunoID { get; set; }

        public virtual Aluno Aluno { get; set; }

    }
}