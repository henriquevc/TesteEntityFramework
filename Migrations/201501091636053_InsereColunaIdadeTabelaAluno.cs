namespace TesteEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsereColunaIdadeTabelaAluno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "Idade", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aluno", "Idade");
        }
    }
}
