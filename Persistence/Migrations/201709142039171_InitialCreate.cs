namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Matricula = c.Long(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100),
                        DataNascimento = c.DateTime(nullable: false),
                        RG = c.String(nullable: false, maxLength: 10),
                        CPF = c.String(nullable: false, maxLength: 11),
                        Endereco = c.String(nullable: false, maxLength: 100),
                        Telefone = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Professor",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Matricula = c.Long(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100),
                        DataNascimento = c.DateTime(nullable: false),
                        RG = c.String(nullable: false, maxLength: 10),
                        CPF = c.String(nullable: false, maxLength: 11),
                        Endereco = c.String(nullable: false, maxLength: 100),
                        Telefone = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Professor");
            DropTable("dbo.Aluno");
        }
    }
}
