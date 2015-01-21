namespace TesteEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteraAlunoNomeRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Aluno", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Aluno", "Nome", c => c.String());
        }
    }
}
