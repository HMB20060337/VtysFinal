namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateallModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faturas", "KullaniciId_KullaniciId", c => c.Int());
            AddColumn("dbo.Faturas", "MusteriId_MusteriId", c => c.Int());
            AddColumn("dbo.Fatura_Detay", "FaturaId_FaturaId", c => c.Int());
            AddColumn("dbo.Fatura_Detay", "UrunlerId_UrunID", c => c.Int());
            AddColumn("dbo.Islem_Detay", "UrunID_UrunID", c => c.Int());
            AddColumn("dbo.Islemlers", "KullanıcıId_KullaniciId", c => c.Int());
            AddColumn("dbo.Stok_Giris", "FirmaId_FirmaId", c => c.Int());
            AddColumn("dbo.Stok_Giris_Detay", "GirisId_Id", c => c.Int());
            AddColumn("dbo.Stok_Giris_Detay", "UrunId_UrunID", c => c.Int());
            CreateIndex("dbo.Faturas", "KullaniciId_KullaniciId");
            CreateIndex("dbo.Faturas", "MusteriId_MusteriId");
            CreateIndex("dbo.Fatura_Detay", "FaturaId_FaturaId");
            CreateIndex("dbo.Fatura_Detay", "UrunlerId_UrunID");
            CreateIndex("dbo.Islem_Detay", "UrunID_UrunID");
            CreateIndex("dbo.Islemlers", "KullanıcıId_KullaniciId");
            CreateIndex("dbo.Stok_Giris", "FirmaId_FirmaId");
            CreateIndex("dbo.Stok_Giris_Detay", "GirisId_Id");
            CreateIndex("dbo.Stok_Giris_Detay", "UrunId_UrunID");
            AddForeignKey("dbo.Faturas", "KullaniciId_KullaniciId", "dbo.Kullanıcılar", "KullaniciId");
            AddForeignKey("dbo.Faturas", "MusteriId_MusteriId", "dbo.Musterilers", "MusteriId");
            AddForeignKey("dbo.Fatura_Detay", "FaturaId_FaturaId", "dbo.Faturas", "FaturaId");
            AddForeignKey("dbo.Fatura_Detay", "UrunlerId_UrunID", "dbo.Urunlers", "UrunID");
            AddForeignKey("dbo.Islemlers", "KullanıcıId_KullaniciId", "dbo.Kullanıcılar", "KullaniciId");
            AddForeignKey("dbo.Islem_Detay", "UrunID_UrunID", "dbo.Urunlers", "UrunID");
            AddForeignKey("dbo.Stok_Giris", "FirmaId_FirmaId", "dbo.Firmalars", "FirmaId");
            AddForeignKey("dbo.Stok_Giris_Detay", "GirisId_Id", "dbo.Stok_Giris", "Id");
            AddForeignKey("dbo.Stok_Giris_Detay", "UrunId_UrunID", "dbo.Urunlers", "UrunID");
            DropColumn("dbo.Faturas", "MusteriId");
            DropColumn("dbo.Faturas", "KullaniciId");
            DropColumn("dbo.Fatura_Detay", "FaturaID");
            DropColumn("dbo.Fatura_Detay", "UrunlerID");
            DropColumn("dbo.Islem_Detay", "UrunID");
            DropColumn("dbo.Islemlers", "KullanıcıId");
            DropColumn("dbo.Stok_Giris", "FirmaId");
            DropColumn("dbo.Stok_Giris_Detay", "GirisId");
            DropColumn("dbo.Stok_Giris_Detay", "UrunId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stok_Giris_Detay", "UrunId", c => c.Int(nullable: false));
            AddColumn("dbo.Stok_Giris_Detay", "GirisId", c => c.Int(nullable: false));
            AddColumn("dbo.Stok_Giris", "FirmaId", c => c.Int(nullable: false));
            AddColumn("dbo.Islemlers", "KullanıcıId", c => c.Int(nullable: false));
            AddColumn("dbo.Islem_Detay", "UrunID", c => c.Int(nullable: false));
            AddColumn("dbo.Fatura_Detay", "UrunlerID", c => c.Int(nullable: false));
            AddColumn("dbo.Fatura_Detay", "FaturaID", c => c.Int(nullable: false));
            AddColumn("dbo.Faturas", "KullaniciId", c => c.Int(nullable: false));
            AddColumn("dbo.Faturas", "MusteriId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Stok_Giris_Detay", "UrunId_UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Stok_Giris_Detay", "GirisId_Id", "dbo.Stok_Giris");
            DropForeignKey("dbo.Stok_Giris", "FirmaId_FirmaId", "dbo.Firmalars");
            DropForeignKey("dbo.Islem_Detay", "UrunID_UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Islemlers", "KullanıcıId_KullaniciId", "dbo.Kullanıcılar");
            DropForeignKey("dbo.Fatura_Detay", "UrunlerId_UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Fatura_Detay", "FaturaId_FaturaId", "dbo.Faturas");
            DropForeignKey("dbo.Faturas", "MusteriId_MusteriId", "dbo.Musterilers");
            DropForeignKey("dbo.Faturas", "KullaniciId_KullaniciId", "dbo.Kullanıcılar");
            DropIndex("dbo.Stok_Giris_Detay", new[] { "UrunId_UrunID" });
            DropIndex("dbo.Stok_Giris_Detay", new[] { "GirisId_Id" });
            DropIndex("dbo.Stok_Giris", new[] { "FirmaId_FirmaId" });
            DropIndex("dbo.Islemlers", new[] { "KullanıcıId_KullaniciId" });
            DropIndex("dbo.Islem_Detay", new[] { "UrunID_UrunID" });
            DropIndex("dbo.Fatura_Detay", new[] { "UrunlerId_UrunID" });
            DropIndex("dbo.Fatura_Detay", new[] { "FaturaId_FaturaId" });
            DropIndex("dbo.Faturas", new[] { "MusteriId_MusteriId" });
            DropIndex("dbo.Faturas", new[] { "KullaniciId_KullaniciId" });
            DropColumn("dbo.Stok_Giris_Detay", "UrunId_UrunID");
            DropColumn("dbo.Stok_Giris_Detay", "GirisId_Id");
            DropColumn("dbo.Stok_Giris", "FirmaId_FirmaId");
            DropColumn("dbo.Islemlers", "KullanıcıId_KullaniciId");
            DropColumn("dbo.Islem_Detay", "UrunID_UrunID");
            DropColumn("dbo.Fatura_Detay", "UrunlerId_UrunID");
            DropColumn("dbo.Fatura_Detay", "FaturaId_FaturaId");
            DropColumn("dbo.Faturas", "MusteriId_MusteriId");
            DropColumn("dbo.Faturas", "KullaniciId_KullaniciId");
        }
    }
}
