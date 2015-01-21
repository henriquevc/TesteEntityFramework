using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteEntityFramework.Models
{
    public class Aluno
    {
        public int AlunoID { get ; set ; }
        [Required(ErrorMessage="O nome deve ser preenchido")]
        public string Nome { get ; set ; }
        public virtual Endereco Endereco { get ; set ; }
        [Range(7,100, ErrorMessage="Idade não permitida")]
        public int? Idade { get; set; }

        public ICollection<TelefoneAluno> Telefones { get; set; }

        public Aluno()
        {
            Telefones = new List<TelefoneAluno>();
        }

    }
}