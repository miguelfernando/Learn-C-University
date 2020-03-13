namespace appSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RGA = c.Int(nullable: false),
                        Nome = c.String(),
                        Email = c.String(),
                        Senha = c.String(),
                        StatusAluno = c.Int(nullable: false),
                        Foto = c.String(),
                        Sexo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Alunos");
        }
    }
}
