namespace RH.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidato",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tecnologia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vaga",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        DataPublicacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TecnologiaVaga",
                c => new
                    {
                        VagaId = c.Int(nullable: false),
                        TecnologiaId = c.Int(nullable: false),
                        Peso = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.VagaId, t.TecnologiaId })
                .ForeignKey("dbo.Tecnologia", t => t.TecnologiaId, cascadeDelete: true)
                .ForeignKey("dbo.Vaga", t => t.VagaId, cascadeDelete: true)
                .Index(t => t.VagaId)
                .Index(t => t.TecnologiaId);
            
            CreateTable(
                "dbo.Entrevista",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        observacoes = c.String(),
                        VagaId = c.Int(nullable: false),
                        CandidatoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidato", t => t.CandidatoId, cascadeDelete: true)
                .ForeignKey("dbo.Vaga", t => t.VagaId, cascadeDelete: true)
                .Index(t => t.VagaId)
                .Index(t => t.CandidatoId);
            
            CreateTable(
                "dbo.TecnologiaCandidato",
                c => new
                    {
                        Tecnologia_Id = c.Int(nullable: false),
                        Candidato_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tecnologia_Id, t.Candidato_Id })
                .ForeignKey("dbo.Tecnologia", t => t.Tecnologia_Id, cascadeDelete: true)
                .ForeignKey("dbo.Candidato", t => t.Candidato_Id, cascadeDelete: true)
                .Index(t => t.Tecnologia_Id)
                .Index(t => t.Candidato_Id);
            
            CreateTable(
                "dbo.VagaCandidato",
                c => new
                    {
                        Vaga_Id = c.Int(nullable: false),
                        Candidato_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vaga_Id, t.Candidato_Id })
                .ForeignKey("dbo.Vaga", t => t.Vaga_Id, cascadeDelete: true)
                .ForeignKey("dbo.Candidato", t => t.Candidato_Id, cascadeDelete: true)
                .Index(t => t.Vaga_Id)
                .Index(t => t.Candidato_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entrevista", "VagaId", "dbo.Vaga");
            DropForeignKey("dbo.Entrevista", "CandidatoId", "dbo.Candidato");
            DropForeignKey("dbo.TecnologiaVaga", "VagaId", "dbo.Vaga");
            DropForeignKey("dbo.TecnologiaVaga", "TecnologiaId", "dbo.Tecnologia");
            DropForeignKey("dbo.VagaCandidato", "Candidato_Id", "dbo.Candidato");
            DropForeignKey("dbo.VagaCandidato", "Vaga_Id", "dbo.Vaga");
            DropForeignKey("dbo.TecnologiaCandidato", "Candidato_Id", "dbo.Candidato");
            DropForeignKey("dbo.TecnologiaCandidato", "Tecnologia_Id", "dbo.Tecnologia");
            DropIndex("dbo.VagaCandidato", new[] { "Candidato_Id" });
            DropIndex("dbo.VagaCandidato", new[] { "Vaga_Id" });
            DropIndex("dbo.TecnologiaCandidato", new[] { "Candidato_Id" });
            DropIndex("dbo.TecnologiaCandidato", new[] { "Tecnologia_Id" });
            DropIndex("dbo.Entrevista", new[] { "CandidatoId" });
            DropIndex("dbo.Entrevista", new[] { "VagaId" });
            DropIndex("dbo.TecnologiaVaga", new[] { "TecnologiaId" });
            DropIndex("dbo.TecnologiaVaga", new[] { "VagaId" });
            DropTable("dbo.VagaCandidato");
            DropTable("dbo.TecnologiaCandidato");
            DropTable("dbo.Entrevista");
            DropTable("dbo.TecnologiaVaga");
            DropTable("dbo.Vaga");
            DropTable("dbo.Tecnologia");
            DropTable("dbo.Candidato");
        }
    }
}
