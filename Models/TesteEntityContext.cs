using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TesteEntityFramework.Models
{
    public class TesteEntityContext : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Turma> Turmas { get; set; }

        public DbSet<Professor> Professores { get; set; }

        public DbSet<TelefoneAluno> TelefonesAluno { get; set; }


        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
        }
    }


}