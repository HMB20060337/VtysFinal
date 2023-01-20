namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class barkodekle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Urunlers", "Barkod", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Urunlers", "Barkod");
        }
    }
}
