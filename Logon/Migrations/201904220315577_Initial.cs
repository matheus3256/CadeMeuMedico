namespace Logon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Cidade = c.String(nullable: false, maxLength: 50),
                        EstadoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Estados", t => t.EstadoID, cascadeDelete: true)
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.Estados",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Estado = c.String(nullable: false, maxLength: 50),
                        Sigla = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Especialidades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Especialidade = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        CRM = c.String(nullable: false, maxLength: 100),
                        Endereco = c.String(nullable: false, maxLength: 100),
                        Bairro = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        WebSiteBlog = c.String(nullable: false, maxLength: 100),
                        EspecialidadeID = c.Int(nullable: false),
                        CidadeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cidades", t => t.CidadeID, cascadeDelete: true)
                .ForeignKey("dbo.Especialidades", t => t.EspecialidadeID, cascadeDelete: true)
                .Index(t => t.EspecialidadeID)
                .Index(t => t.CidadeID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Login = c.String(nullable: false, maxLength: 50),
                        Senha = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicos", "EspecialidadeID", "dbo.Especialidades");
            DropForeignKey("dbo.Medicos", "CidadeID", "dbo.Cidades");
            DropForeignKey("dbo.Cidades", "EstadoID", "dbo.Estados");
            DropIndex("dbo.Medicos", new[] { "CidadeID" });
            DropIndex("dbo.Medicos", new[] { "EspecialidadeID" });
            DropIndex("dbo.Cidades", new[] { "EstadoID" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Medicos");
            DropTable("dbo.Especialidades");
            DropTable("dbo.Estados");
            DropTable("dbo.Cidades");
        }
    }
}
