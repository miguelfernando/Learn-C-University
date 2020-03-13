namespace appSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aluno : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Alunos", newName: "Aluno");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Aluno", newName: "Alunos");
        }
    }
}
