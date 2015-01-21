namespace TesteEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criacaoClasseTurmaProfessor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Professor",
                c => new
                    {
                        ProfessorID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Endereco_EnderecoID = c.Int(),
                    })
                .PrimaryKey(t => t.ProfessorID)
                .ForeignKey("dbo.Endereco", t => t.Endereco_EnderecoID)
                .Index(t => t.Endereco_EnderecoID);
            
            CreateTable(
                "dbo.Turma",
                c => new
                    {
                        TurmaID = c.Int(nullable: false, identity: true),
                        Vagas = c.Int(nullable: false),
                        Professor_ProfessorID = c.Int(),
                    })
                .PrimaryKey(t => t.TurmaID)
                .ForeignKey("dbo.Professor", t => t.Professor_ProfessorID)
                .Index(t => t.Professor_ProfessorID);
            
            AddColumn("dbo.Aluno", "Turma_TurmaID", c => c.Int());
            CreateIndex("dbo.Aluno", "Turma_TurmaID");
            AddForeignKey("dbo.Aluno", "Turma_TurmaID", "dbo.Turma", "TurmaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Turma", "Professor_ProfessorID", "dbo.Professor");
            DropForeignKey("dbo.Aluno", "Turma_TurmaID", "dbo.Turma");
            DropForeignKey("dbo.Professor", "Endereco_EnderecoID", "dbo.Endereco");
            DropIndex("dbo.Turma", new[] { "Professor_ProfessorID" });
            DropIndex("dbo.Professor", new[] { "Endereco_EnderecoID" });
            DropIndex("dbo.Aluno", new[] { "Turma_TurmaID" });
            DropColumn("dbo.Aluno", "Turma_TurmaID");
            DropTable("dbo.Turma");
            DropTable("dbo.Professor");
        }
    }
}
