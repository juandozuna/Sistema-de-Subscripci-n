namespace MVCSuscriptionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        PrimerNombre = c.String(name: "Primer Nombre", nullable: false, maxLength: 50, unicode: false),
                        SegundoNombre = c.String(name: "Segundo Nombre", maxLength: 50, unicode: false),
                        Primer_Apellido = c.String(nullable: false, maxLength: 50, unicode: false),
                        Fecha_de_nacimiento = c.DateTime(nullable: false, storeType: "date"),
                        NumeroTelefonico = c.String(name: "Numero Telefonico", maxLength: 50, unicode: false),
                        email = c.String(name: "e-mail", nullable: false, maxLength: 100, unicode: false),
                        MetododePago = c.String(name: "Metodo de Pago", nullable: false, maxLength: 50, unicode: false),
                        NumeroTarjeta = c.Int(),
                        CVC_o_CVV = c.Int(),
                        Fecha_de_expiracion = c.DateTime(storeType: "date"),
                        ImagenID = c.Int(),
                    })
                .PrimaryKey(t => t.ClientID)
                .ForeignKey("dbo.Images", t => t.ImagenID)
                .Index(t => t.ImagenID);
            
            CreateTable(
                "dbo.ClienteSuscripcion",
                c => new
                    {
                        ClienteSuscripcionId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        SubscripcionId = c.Int(nullable: false),
                        Cliente_ClientID = c.Int(),
                    })
                .PrimaryKey(t => t.ClienteSuscripcionId)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClientID)
                .ForeignKey("dbo.Subscripcions", t => t.SubscripcionId, cascadeDelete: true)
                .Index(t => t.SubscripcionId)
                .Index(t => t.Cliente_ClientID);
            
            CreateTable(
                "dbo.Subscripcions",
                c => new
                    {
                        SubscripcionID = c.Int(nullable: false, identity: true),
                        PlanID = c.Int(nullable: false),
                        Fecha_creacion = c.DateTime(nullable: false, storeType: "date"),
                        Active = c.Boolean(nullable: false),
                        ImageID = c.Int(),
                    })
                .PrimaryKey(t => t.SubscripcionID)
                .ForeignKey("dbo.Plan", t => t.PlanID)
                .ForeignKey("dbo.Images", t => t.ImageID)
                .Index(t => t.PlanID)
                .Index(t => t.ImageID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        imagesID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, unicode: false),
                        ImageData = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.imagesID);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        PlanID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100, unicode: false),
                        Precio = c.Double(nullable: false),
                        ImagenID = c.Int(),
                    })
                .PrimaryKey(t => t.PlanID)
                .ForeignKey("dbo.Images", t => t.ImagenID)
                .Index(t => t.ImagenID);
            
            CreateTable(
                "dbo.ServicioEnPlan",
                c => new
                    {
                        ServicioEnPlanID = c.Int(nullable: false, identity: true),
                        ServicioID = c.Int(nullable: false),
                        PlanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServicioEnPlanID)
                .ForeignKey("dbo.Servicio", t => t.ServicioID)
                .ForeignKey("dbo.Plan", t => t.PlanID)
                .Index(t => t.ServicioID)
                .Index(t => t.PlanID);
            
            CreateTable(
                "dbo.Servicio",
                c => new
                    {
                        ServicioID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100, unicode: false),
                        Precio = c.Double(nullable: false),
                        ImagenID = c.Int(),
                    })
                .PrimaryKey(t => t.ServicioID)
                .ForeignKey("dbo.Images", t => t.ImagenID)
                .Index(t => t.ImagenID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscripcions", "ImageID", "dbo.Images");
            DropForeignKey("dbo.Servicio", "ImagenID", "dbo.Images");
            DropForeignKey("dbo.Plan", "ImagenID", "dbo.Images");
            DropForeignKey("dbo.Subscripcions", "PlanID", "dbo.Plan");
            DropForeignKey("dbo.ServicioEnPlan", "PlanID", "dbo.Plan");
            DropForeignKey("dbo.ServicioEnPlan", "ServicioID", "dbo.Servicio");
            DropForeignKey("dbo.Clientes", "ImagenID", "dbo.Images");
            DropForeignKey("dbo.ClienteSuscripcion", "SubscripcionId", "dbo.Subscripcions");
            DropForeignKey("dbo.ClienteSuscripcion", "Cliente_ClientID", "dbo.Clientes");
            DropIndex("dbo.Servicio", new[] { "ImagenID" });
            DropIndex("dbo.ServicioEnPlan", new[] { "PlanID" });
            DropIndex("dbo.ServicioEnPlan", new[] { "ServicioID" });
            DropIndex("dbo.Plan", new[] { "ImagenID" });
            DropIndex("dbo.Subscripcions", new[] { "ImageID" });
            DropIndex("dbo.Subscripcions", new[] { "PlanID" });
            DropIndex("dbo.ClienteSuscripcion", new[] { "Cliente_ClientID" });
            DropIndex("dbo.ClienteSuscripcion", new[] { "SubscripcionId" });
            DropIndex("dbo.Clientes", new[] { "ImagenID" });
            DropTable("dbo.Servicio");
            DropTable("dbo.ServicioEnPlan");
            DropTable("dbo.Plan");
            DropTable("dbo.Images");
            DropTable("dbo.Subscripcions");
            DropTable("dbo.ClienteSuscripcion");
            DropTable("dbo.Clientes");
        }
    }
}
