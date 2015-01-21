namespace TesteEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoEntidadeTElefoneAluno : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TelefoneAluno",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        AlunoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Aluno", t => t.AlunoID, cascadeDelete: true)
                .Index(t => t.AlunoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TelefoneAluno", "AlunoID", "dbo.Aluno");
            DropIndex("dbo.TelefoneAluno", new[] { "AlunoID" });
            DropTable("dbo.TelefoneAluno");
        }
    }
}
