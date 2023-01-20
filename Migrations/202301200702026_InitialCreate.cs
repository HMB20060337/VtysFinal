namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faturas",
                c => new
                    {
                        FaturaId = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        MusteriId_MusteriId = c.Int(),
                    })
                .PrimaryKey(t => t.FaturaId)
                .ForeignKey("dbo.Musterilers", t => t.MusteriId_MusteriId)
                .Index(t => t.MusteriId_MusteriId);
            
            CreateTable(
                "dbo.Fatura_Detay",
                c => new
                    {
                        FaturaDetayID = c.Int(nullable: false, identity: true),
                        Fatura_FaturaId = c.Int(),
                        Urunler_UrunID = c.Int(),
                    })
                .PrimaryKey(t => t.FaturaDetayID)
                .ForeignKey("dbo.Faturas", t => t.Fatura_FaturaId)
                .ForeignKey("dbo.Urunlers", t => t.Urunler_UrunID)
                .Index(t => t.Fatura_FaturaId)
                .Index(t => t.Urunler_UrunID);
            
            CreateTable(
                "dbo.Urunlers",
                c => new
                    {
                        UrunID = c.Int(nullable: false, identity: true),
                        UrunAdi = c.String(),
                        AlisFiyati = c.Double(nullable: false),
                        SatisFiyati = c.Double(nullable: false),
                        Stok = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UrunID);
            
            CreateTable(
                "dbo.Islem_Detay",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Islemler_IslemId = c.Int(),
                        Urunler_UrunID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Islemlers", t => t.Islemler_IslemId)
                .ForeignKey("dbo.Urunlers", t => t.Urunler_UrunID)
                .Index(t => t.Islemler_IslemId)
                .Index(t => t.Urunler_UrunID);
            
            CreateTable(
                "dbo.Islemlers",
                c => new
                    {
                        IslemId = c.Int(nullable: false, identity: true),
                        tarih = c.DateTime(nullable: false),
                        KullanıcıId_KullaniciId = c.Int(),
                    })
                .PrimaryKey(t => t.IslemId)
                .ForeignKey("dbo.Kullanıcılar", t => t.KullanıcıId_KullaniciId)
                .Index(t => t.KullanıcıId_KullaniciId);
            
            CreateTable(
                "dbo.Kullanıcılar",
                c => new
                    {
                        KullaniciId = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(),
                        pass = c.String(),
                    })
                .PrimaryKey(t => t.KullaniciId);
            
            CreateTable(
                "dbo.Stok_Giris_Detay",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        sayi = c.Int(nullable: false),
                        girisId_Id = c.Int(),
                        urunler_UrunID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stok_Giris", t => t.girisId_Id)
                .ForeignKey("dbo.Urunlers", t => t.urunler_UrunID)
                .Index(t => t.girisId_Id)
                .Index(t => t.urunler_UrunID);
            
            CreateTable(
                "dbo.Stok_Giris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tarih = c.DateTime(nullable: false),
                        tutar = c.Int(nullable: false),
                        FirmaId_FirmaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Firmalars", t => t.FirmaId_FirmaId)
                .Index(t => t.FirmaId_FirmaId);
            
            CreateTable(
                "dbo.Firmalars",
                c => new
                    {
                        FirmaId = c.Int(nullable: false, identity: true),
                        FirmaAdi = c.String(),
                        Borc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FirmaId);
            
            CreateTable(
                "dbo.Musterilers",
                c => new
                    {
                        MusteriId = c.Int(nullable: false, identity: true),
                        MusteriAdi = c.String(),
                        MusteriSoyadi = c.String(),
                        Borc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MusteriId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Faturas", "MusteriId_MusteriId", "dbo.Musterilers");
            DropForeignKey("dbo.Stok_Giris_Detay", "urunler_UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Stok_Giris_Detay", "girisId_Id", "dbo.Stok_Giris");
            DropForeignKey("dbo.Stok_Giris", "FirmaId_FirmaId", "dbo.Firmalars");
            DropForeignKey("dbo.Islem_Detay", "Urunler_UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Islemlers", "KullanıcıId_KullaniciId", "dbo.Kullanıcılar");
            DropForeignKey("dbo.Islem_Detay", "Islemler_IslemId", "dbo.Islemlers");
            DropForeignKey("dbo.Fatura_Detay", "Urunler_UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Fatura_Detay", "Fatura_FaturaId", "dbo.Faturas");
            DropIndex("dbo.Stok_Giris", new[] { "FirmaId_FirmaId" });
            DropIndex("dbo.Stok_Giris_Detay", new[] { "urunler_UrunID" });
            DropIndex("dbo.Stok_Giris_Detay", new[] { "girisId_Id" });
            DropIndex("dbo.Islemlers", new[] { "KullanıcıId_KullaniciId" });
            DropIndex("dbo.Islem_Detay", new[] { "Urunler_UrunID" });
            DropIndex("dbo.Islem_Detay", new[] { "Islemler_IslemId" });
            DropIndex("dbo.Fatura_Detay", new[] { "Urunler_UrunID" });
            DropIndex("dbo.Fatura_Detay", new[] { "Fatura_FaturaId" });
            DropIndex("dbo.Faturas", new[] { "MusteriId_MusteriId" });
            DropTable("dbo.Musterilers");
            DropTable("dbo.Firmalars");
            DropTable("dbo.Stok_Giris");
            DropTable("dbo.Stok_Giris_Detay");
            DropTable("dbo.Kullanıcılar");
            DropTable("dbo.Islemlers");
            DropTable("dbo.Islem_Detay");
            DropTable("dbo.Urunlers");
            DropTable("dbo.Fatura_Detay");
            DropTable("dbo.Faturas");
        }
    }
}
