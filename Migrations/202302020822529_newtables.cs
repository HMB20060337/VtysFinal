namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Firma_Odeme",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        Odeme = c.Double(nullable: false),
                        FirmaId_FirmaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Firmalars", t => t.FirmaId_FirmaId)
                .Index(t => t.FirmaId_FirmaId);
            
            CreateTable(
                "dbo.Musteri_Odeme",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        Odeme = c.Double(nullable: false),
                        MusteriId_MusteriId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Musterilers", t => t.MusteriId_MusteriId)
                .Index(t => t.MusteriId_MusteriId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Musteri_Odeme", "MusteriId_MusteriId", "dbo.Musterilers");
            DropForeignKey("dbo.Firma_Odeme", "FirmaId_FirmaId", "dbo.Firmalars");
            DropIndex("dbo.Musteri_Odeme", new[] { "MusteriId_MusteriId" });
            DropIndex("dbo.Firma_Odeme", new[] { "FirmaId_FirmaId" });
            DropTable("dbo.Musteri_Odeme");
            DropTable("dbo.Firma_Odeme");
        }
    }
}
