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
                        Tarih = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Tutar = c.Double(nullable: false),
                        KullaniciId_KullaniciId = c.Int(),
                        MusteriId_MusteriId = c.Int(),
                    })
                .PrimaryKey(t => t.FaturaId)
                .ForeignKey("dbo.Kullanıcılar", t => t.KullaniciId_KullaniciId)
                .ForeignKey("dbo.Musterilers", t => t.MusteriId_MusteriId)
                .Index(t => t.KullaniciId_KullaniciId)
                .Index(t => t.MusteriId_MusteriId);
            
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
                "dbo.Musterilers",
                c => new
                    {
                        MusteriId = c.Int(nullable: false, identity: true),
                        MusteriAdi = c.String(),
                        MusteriSoyadi = c.String(),
                        Telefon = c.String(),
                        Borc = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MusteriId);
            
            CreateTable(
                "dbo.Fatura_Detay",
                c => new
                    {
                        FaturaDetayID = c.Int(nullable: false, identity: true),
                        miktar = c.Int(nullable: false),
                        FaturaId_FaturaId = c.Int(),
                        UrunlerId_UrunID = c.Int(),
                    })
                .PrimaryKey(t => t.FaturaDetayID)
                .ForeignKey("dbo.Faturas", t => t.FaturaId_FaturaId)
                .ForeignKey("dbo.Urunlers", t => t.UrunlerId_UrunID)
                .Index(t => t.FaturaId_FaturaId)
                .Index(t => t.UrunlerId_UrunID);
            
            CreateTable(
                "dbo.Urunlers",
                c => new
                    {
                        UrunID = c.Int(nullable: false, identity: true),
                        Barkod = c.String(),
                        UrunAdi = c.String(),
                        AlisFiyati = c.Double(nullable: false),
                        SatisFiyati = c.Double(nullable: false),
                        Stok = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UrunID);
            
            CreateTable(
                "dbo.Firma_Odeme",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Odeme = c.Double(nullable: false),
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
                "dbo.Islem_Detay",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Miktar = c.Int(nullable: false),
                        IslemId_IslemId = c.Int(),
                        UrunID_UrunID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Islemlers", t => t.IslemId_IslemId)
                .ForeignKey("dbo.Urunlers", t => t.UrunID_UrunID)
                .Index(t => t.IslemId_IslemId)
                .Index(t => t.UrunID_UrunID);
            
            CreateTable(
                "dbo.Islemlers",
                c => new
                    {
                        IslemId = c.Int(nullable: false, identity: true),
                        tarih = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Tutar = c.Double(nullable: false),
                        OdemeYontemi = c.String(),
                        KullanıcıId_KullaniciId = c.Int(),
                    })
                .PrimaryKey(t => t.IslemId)
                .ForeignKey("dbo.Kullanıcılar", t => t.KullanıcıId_KullaniciId)
                .Index(t => t.KullanıcıId_KullaniciId);
            
            CreateTable(
                "dbo.Musteri_Odeme",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Odeme = c.Double(nullable: false),
                        MusteriId_MusteriId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Musterilers", t => t.MusteriId_MusteriId)
                .Index(t => t.MusteriId_MusteriId);
            
            CreateTable(
                "dbo.Stok_Giris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tarih = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        tutar = c.Int(nullable: false),
                        FirmaId_FirmaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Firmalars", t => t.FirmaId_FirmaId)
                .Index(t => t.FirmaId_FirmaId);
            
            CreateTable(
                "dbo.Stok_Giris_Detay",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        sayi = c.Int(nullable: false),
                        GirisId_Id = c.Int(),
                        UrunId_UrunID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stok_Giris", t => t.GirisId_Id)
                .ForeignKey("dbo.Urunlers", t => t.UrunId_UrunID)
                .Index(t => t.GirisId_Id)
                .Index(t => t.UrunId_UrunID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stok_Giris_Detay", "UrunId_UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Stok_Giris_Detay", "GirisId_Id", "dbo.Stok_Giris");
            DropForeignKey("dbo.Stok_Giris", "FirmaId_FirmaId", "dbo.Firmalars");
            DropForeignKey("dbo.Musteri_Odeme", "MusteriId_MusteriId", "dbo.Musterilers");
            DropForeignKey("dbo.Islem_Detay", "UrunID_UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Islem_Detay", "IslemId_IslemId", "dbo.Islemlers");
            DropForeignKey("dbo.Islemlers", "KullanıcıId_KullaniciId", "dbo.Kullanıcılar");
            DropForeignKey("dbo.Firma_Odeme", "FirmaId_FirmaId", "dbo.Firmalars");
            DropForeignKey("dbo.Fatura_Detay", "UrunlerId_UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Fatura_Detay", "FaturaId_FaturaId", "dbo.Faturas");
            DropForeignKey("dbo.Faturas", "MusteriId_MusteriId", "dbo.Musterilers");
            DropForeignKey("dbo.Faturas", "KullaniciId_KullaniciId", "dbo.Kullanıcılar");
            DropIndex("dbo.Stok_Giris_Detay", new[] { "UrunId_UrunID" });
            DropIndex("dbo.Stok_Giris_Detay", new[] { "GirisId_Id" });
            DropIndex("dbo.Stok_Giris", new[] { "FirmaId_FirmaId" });
            DropIndex("dbo.Musteri_Odeme", new[] { "MusteriId_MusteriId" });
            DropIndex("dbo.Islemlers", new[] { "KullanıcıId_KullaniciId" });
            DropIndex("dbo.Islem_Detay", new[] { "UrunID_UrunID" });
            DropIndex("dbo.Islem_Detay", new[] { "IslemId_IslemId" });
            DropIndex("dbo.Firma_Odeme", new[] { "FirmaId_FirmaId" });
            DropIndex("dbo.Fatura_Detay", new[] { "UrunlerId_UrunID" });
            DropIndex("dbo.Fatura_Detay", new[] { "FaturaId_FaturaId" });
            DropIndex("dbo.Faturas", new[] { "MusteriId_MusteriId" });
            DropIndex("dbo.Faturas", new[] { "KullaniciId_KullaniciId" });
            DropTable("dbo.Stok_Giris_Detay");
            DropTable("dbo.Stok_Giris");
            DropTable("dbo.Musteri_Odeme");
            DropTable("dbo.Islemlers");
            DropTable("dbo.Islem_Detay");
            DropTable("dbo.Firmalars");
            DropTable("dbo.Firma_Odeme");
            DropTable("dbo.Urunlers");
            DropTable("dbo.Fatura_Detay");
            DropTable("dbo.Musterilers");
            DropTable("dbo.Kullanıcılar");
            DropTable("dbo.Faturas");
        }
    }
}
