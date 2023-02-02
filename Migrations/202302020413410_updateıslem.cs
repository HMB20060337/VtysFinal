namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateıslem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Islem_Detay", "IslemId_IslemId", c => c.Int());
            CreateIndex("dbo.Islem_Detay", "IslemId_IslemId");
            AddForeignKey("dbo.Islem_Detay", "IslemId_IslemId", "dbo.Islemlers", "IslemId");
            DropColumn("dbo.Islem_Detay", "IslemID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Islem_Detay", "IslemID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Islem_Detay", "IslemId_IslemId", "dbo.Islemlers");
            DropIndex("dbo.Islem_Detay", new[] { "IslemId_IslemId" });
            DropColumn("dbo.Islem_Detay", "IslemId_IslemId");
        }
    }
}
