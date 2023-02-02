namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateIslemDetay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Islem_Detay", "UrunID_UrunID", c => c.Int());
            CreateIndex("dbo.Islem_Detay", "UrunID_UrunID");
            AddForeignKey("dbo.Islem_Detay", "UrunID_UrunID", "dbo.Urunlers", "UrunID");
            DropColumn("dbo.Islem_Detay", "UrunID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Islem_Detay", "UrunID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Islem_Detay", "UrunID_UrunID", "dbo.Urunlers");
            DropIndex("dbo.Islem_Detay", new[] { "UrunID_UrunID" });
            DropColumn("dbo.Islem_Detay", "UrunID_UrunID");
        }
    }
}
