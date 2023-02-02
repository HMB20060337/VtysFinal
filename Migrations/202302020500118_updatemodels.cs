namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Faturas", "MusteriId_MusteriId", "dbo.Musterilers");
            DropForeignKey("dbo.Fatura_Detay", "UrunlerId_UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Islem_Detay", "UrunID_UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Stok_Giris", "FirmaId_FirmaId", "dbo.Firmalars");
            DropForeignKey("dbo.Stok_Giris_Detay", "UrunId_UrunID", "dbo.Urunlers");
            DropIndex("dbo.Faturas", new[] { "MusteriId_MusteriId" });
            DropIndex("dbo.Fatura_Detay", new[] { "UrunlerId_UrunID" });
            DropIndex("dbo.Islem_Detay", new[] { "UrunID_UrunID" });
            DropIndex("dbo.Stok_Giris", new[] { "FirmaId_FirmaId" });
            DropIndex("dbo.Stok_Giris_Detay", new[] { "UrunId_UrunID" });
            AddColumn("dbo.Faturas", "MusteriId", c => c.Int(nullable: false));
            AddColumn("dbo.Fatura_Detay", "UrunlerId", c => c.Int(nullable: false));
            AddColumn("dbo.Islem_Detay", "UrunID", c => c.Int(nullable: false));
            AddColumn("dbo.Stok_Giris", "FirmaId", c => c.Int(nullable: false));
            AddColumn("dbo.Stok_Giris_Detay", "UrunId", c => c.Int(nullable: false));
            DropColumn("dbo.Faturas", "MusteriId_MusteriId");
            DropColumn("dbo.Fatura_Detay", "UrunlerId_UrunID");
            DropColumn("dbo.Islem_Detay", "UrunID_UrunID");
            DropColumn("dbo.Stok_Giris", "FirmaId_FirmaId");
            DropColumn("dbo.Stok_Giris_Detay", "UrunId_UrunID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stok_Giris_Detay", "UrunId_UrunID", c => c.Int());
            AddColumn("dbo.Stok_Giris", "FirmaId_FirmaId", c => c.Int());
            AddColumn("dbo.Islem_Detay", "UrunID_UrunID", c => c.Int());
            AddColumn("dbo.Fatura_Detay", "UrunlerId_UrunID", c => c.Int());
            AddColumn("dbo.Faturas", "MusteriId_MusteriId", c => c.Int());
            DropColumn("dbo.Stok_Giris_Detay", "UrunId");
            DropColumn("dbo.Stok_Giris", "FirmaId");
            DropColumn("dbo.Islem_Detay", "UrunID");
            DropColumn("dbo.Fatura_Detay", "UrunlerId");
            DropColumn("dbo.Faturas", "MusteriId");
            CreateIndex("dbo.Stok_Giris_Detay", "UrunId_UrunID");
            CreateIndex("dbo.Stok_Giris", "FirmaId_FirmaId");
            CreateIndex("dbo.Islem_Detay", "UrunID_UrunID");
            CreateIndex("dbo.Fatura_Detay", "UrunlerId_UrunID");
            CreateIndex("dbo.Faturas", "MusteriId_MusteriId");
            AddForeignKey("dbo.Stok_Giris_Detay", "UrunId_UrunID", "dbo.Urunlers", "UrunID");
            AddForeignKey("dbo.Stok_Giris", "FirmaId_FirmaId", "dbo.Firmalars", "FirmaId");
            AddForeignKey("dbo.Islem_Detay", "UrunID_UrunID", "dbo.Urunlers", "UrunID");
            AddForeignKey("dbo.Fatura_Detay", "UrunlerId_UrunID", "dbo.Urunlers", "UrunID");
            AddForeignKey("dbo.Faturas", "MusteriId_MusteriId", "dbo.Musterilers", "MusteriId");
        }
    }
}
