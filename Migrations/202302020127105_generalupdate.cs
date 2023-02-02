namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class generalupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Fatura_Detay", "Fatura_FaturaId", "dbo.Faturas");
            DropForeignKey("dbo.Fatura_Detay", "Urunler_UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Islem_Detay", "Islemler_IslemId", "dbo.Islemlers");
            DropForeignKey("dbo.Faturas", "KullaniciId_KullaniciId", "dbo.Kullanıcılar");
            DropForeignKey("dbo.Islemlers", "KullanıcıId_KullaniciId", "dbo.Kullanıcılar");
            DropForeignKey("dbo.Islem_Detay", "Urunler_UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Stok_Giris", "FirmaId_FirmaId", "dbo.Firmalars");
            DropForeignKey("dbo.Stok_Giris_Detay", "girisId_Id", "dbo.Stok_Giris");
            DropForeignKey("dbo.Stok_Giris_Detay", "urunler_UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Faturas", "MusteriId_MusteriId", "dbo.Musterilers");
            DropIndex("dbo.Faturas", new[] { "KullaniciId_KullaniciId" });
            DropIndex("dbo.Faturas", new[] { "MusteriId_MusteriId" });
            DropIndex("dbo.Fatura_Detay", new[] { "Fatura_FaturaId" });
            DropIndex("dbo.Fatura_Detay", new[] { "Urunler_UrunID" });
            DropIndex("dbo.Islem_Detay", new[] { "Islemler_IslemId" });
            DropIndex("dbo.Islem_Detay", new[] { "Urunler_UrunID" });
            DropIndex("dbo.Islemlers", new[] { "KullanıcıId_KullaniciId" });
            DropIndex("dbo.Stok_Giris_Detay", new[] { "girisId_Id" });
            DropIndex("dbo.Stok_Giris_Detay", new[] { "urunler_UrunID" });
            DropIndex("dbo.Stok_Giris", new[] { "FirmaId_FirmaId" });
            AddColumn("dbo.Faturas", "MusteriId", c => c.Int(nullable: false));
            AddColumn("dbo.Faturas", "KullaniciId", c => c.Int(nullable: false));
            AddColumn("dbo.Fatura_Detay", "FaturaID", c => c.Int(nullable: false));
            AddColumn("dbo.Fatura_Detay", "UrunlerID", c => c.Int(nullable: false));
            AddColumn("dbo.Islem_Detay", "IslemID", c => c.Int(nullable: false));
            AddColumn("dbo.Islem_Detay", "UrunID", c => c.Int(nullable: false));
            AddColumn("dbo.Islemlers", "KullanıcıId", c => c.Int(nullable: false));
            AddColumn("dbo.Stok_Giris_Detay", "GirisId", c => c.Int(nullable: false));
            AddColumn("dbo.Stok_Giris_Detay", "UrunId", c => c.Int(nullable: false));
            AddColumn("dbo.Stok_Giris", "FirmaId", c => c.Int(nullable: false));
            DropColumn("dbo.Faturas", "KullaniciId_KullaniciId");
            DropColumn("dbo.Faturas", "MusteriId_MusteriId");
            DropColumn("dbo.Fatura_Detay", "Fatura_FaturaId");
            DropColumn("dbo.Fatura_Detay", "Urunler_UrunID");
            DropColumn("dbo.Islem_Detay", "Islemler_IslemId");
            DropColumn("dbo.Islem_Detay", "Urunler_UrunID");
            DropColumn("dbo.Islemlers", "KullanıcıId_KullaniciId");
            DropColumn("dbo.Stok_Giris_Detay", "girisId_Id");
            DropColumn("dbo.Stok_Giris_Detay", "urunler_UrunID");
            DropColumn("dbo.Stok_Giris", "FirmaId_FirmaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stok_Giris", "FirmaId_FirmaId", c => c.Int());
            AddColumn("dbo.Stok_Giris_Detay", "urunler_UrunID", c => c.Int());
            AddColumn("dbo.Stok_Giris_Detay", "girisId_Id", c => c.Int());
            AddColumn("dbo.Islemlers", "KullanıcıId_KullaniciId", c => c.Int());
            AddColumn("dbo.Islem_Detay", "Urunler_UrunID", c => c.Int());
            AddColumn("dbo.Islem_Detay", "Islemler_IslemId", c => c.Int());
            AddColumn("dbo.Fatura_Detay", "Urunler_UrunID", c => c.Int());
            AddColumn("dbo.Fatura_Detay", "Fatura_FaturaId", c => c.Int());
            AddColumn("dbo.Faturas", "MusteriId_MusteriId", c => c.Int());
            AddColumn("dbo.Faturas", "KullaniciId_KullaniciId", c => c.Int());
            DropColumn("dbo.Stok_Giris", "FirmaId");
            DropColumn("dbo.Stok_Giris_Detay", "UrunId");
            DropColumn("dbo.Stok_Giris_Detay", "GirisId");
            DropColumn("dbo.Islemlers", "KullanıcıId");
            DropColumn("dbo.Islem_Detay", "UrunID");
            DropColumn("dbo.Islem_Detay", "IslemID");
            DropColumn("dbo.Fatura_Detay", "UrunlerID");
            DropColumn("dbo.Fatura_Detay", "FaturaID");
            DropColumn("dbo.Faturas", "KullaniciId");
            DropColumn("dbo.Faturas", "MusteriId");
            CreateIndex("dbo.Stok_Giris", "FirmaId_FirmaId");
            CreateIndex("dbo.Stok_Giris_Detay", "urunler_UrunID");
            CreateIndex("dbo.Stok_Giris_Detay", "girisId_Id");
            CreateIndex("dbo.Islemlers", "KullanıcıId_KullaniciId");
            CreateIndex("dbo.Islem_Detay", "Urunler_UrunID");
            CreateIndex("dbo.Islem_Detay", "Islemler_IslemId");
            CreateIndex("dbo.Fatura_Detay", "Urunler_UrunID");
            CreateIndex("dbo.Fatura_Detay", "Fatura_FaturaId");
            CreateIndex("dbo.Faturas", "MusteriId_MusteriId");
            CreateIndex("dbo.Faturas", "KullaniciId_KullaniciId");
            AddForeignKey("dbo.Faturas", "MusteriId_MusteriId", "dbo.Musterilers", "MusteriId");
            AddForeignKey("dbo.Stok_Giris_Detay", "urunler_UrunID", "dbo.Urunlers", "UrunID");
            AddForeignKey("dbo.Stok_Giris_Detay", "girisId_Id", "dbo.Stok_Giris", "Id");
            AddForeignKey("dbo.Stok_Giris", "FirmaId_FirmaId", "dbo.Firmalars", "FirmaId");
            AddForeignKey("dbo.Islem_Detay", "Urunler_UrunID", "dbo.Urunlers", "UrunID");
            AddForeignKey("dbo.Islemlers", "KullanıcıId_KullaniciId", "dbo.Kullanıcılar", "KullaniciId");
            AddForeignKey("dbo.Faturas", "KullaniciId_KullaniciId", "dbo.Kullanıcılar", "KullaniciId");
            AddForeignKey("dbo.Islem_Detay", "Islemler_IslemId", "dbo.Islemlers", "IslemId");
            AddForeignKey("dbo.Fatura_Detay", "Urunler_UrunID", "dbo.Urunlers", "UrunID");
            AddForeignKey("dbo.Fatura_Detay", "Fatura_FaturaId", "dbo.Faturas", "FaturaId");
        }
    }
}
