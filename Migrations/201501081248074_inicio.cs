namespace TesteEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        AlunoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Endereco_EnderecoID = c.Int(),
                    })
                .PrimaryKey(t => t.AlunoID)
                .ForeignKey("dbo.Endereco", t => t.Endereco_EnderecoID)
                .Index(t => t.Endereco_EnderecoID);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        EnderecoID = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(),
                        Numero = c.Int(nullable: false),
                        CEP = c.String(),
                    })
                .PrimaryKey(t => t.EnderecoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aluno", "Endereco_EnderecoID", "dbo.Endereco");
            DropIndex("dbo.Aluno", new[] { "Endereco_EnderecoID" });
            DropTable("dbo.Endereco");
            DropTable("dbo.Aluno");
        }
    }
}
