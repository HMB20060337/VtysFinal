namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class general_update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faturas", "MusteriId_MusteriId", c => c.Int());
            AddColumn("dbo.Fatura_Detay", "UrunlerId_UrunID", c => c.Int());
            AddColumn("dbo.Stok_Giris", "FirmaId_FirmaId", c => c.Int());
            AddColumn("dbo.Stok_Giris_Detay", "UrunId_UrunID", c => c.Int());
            CreateIndex("dbo.Faturas", "MusteriId_MusteriId");
            CreateIndex("dbo.Fatura_Detay", "UrunlerId_UrunID");
            CreateIndex("dbo.Stok_Giris", "FirmaId_FirmaId");
            CreateIndex("dbo.Stok_Giris_Detay", "UrunId_UrunID");
            AddForeignKey("dbo.Faturas", "MusteriId_MusteriId", "dbo.Musterilers", "MusteriId");
            AddForeignKey("dbo.Fatura_Detay", "UrunlerId_UrunID", "dbo.Urunlers", "UrunID");
            AddForeignKey("dbo.Stok_Giris", "FirmaId_FirmaId", "dbo.Firmalars", "FirmaId");
            AddForeignKey("dbo.Stok_Giris_Detay", "UrunId_UrunID", "dbo.Urunlers", "UrunID");
            DropColumn("dbo.Faturas", "MusteriId");
            DropColumn("dbo.Fatura_Detay", "UrunlerId");
            DropColumn("dbo.Stok_Giris", "FirmaId");
            DropColumn("dbo.Stok_Giris_Detay", "UrunId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stok_Giris_Detay", "UrunId", c => c.Int(nullable: false));
            AddColumn("dbo.Stok_Giris", "FirmaId", c => c.Int(nullable: false));
            AddColumn("dbo.Fatura_Detay", "UrunlerId", c => c.Int(nullable: false));
            AddColumn("dbo.Faturas", "MusteriId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Stok_Giris_Detay", "UrunId_UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Stok_Giris", "FirmaId_FirmaId", "dbo.Firmalars");
            DropForeignKey("dbo.Fatura_Detay", "UrunlerId_UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Faturas", "MusteriId_MusteriId", "dbo.Musterilers");
            DropIndex("dbo.Stok_Giris_Detay", new[] { "UrunId_UrunID" });
            DropIndex("dbo.Stok_Giris", new[] { "FirmaId_FirmaId" });
            DropIndex("dbo.Fatura_Detay", new[] { "UrunlerId_UrunID" });
            DropIndex("dbo.Faturas", new[] { "MusteriId_MusteriId" });
            DropColumn("dbo.Stok_Giris_Detay", "UrunId_UrunID");
            DropColumn("dbo.Stok_Giris", "FirmaId_FirmaId");
            DropColumn("dbo.Fatura_Detay", "UrunlerId_UrunID");
            DropColumn("dbo.Faturas", "MusteriId_MusteriId");
        }
    }
}
