namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMusterilerAndUrunler : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Musterilers", "Telefon", c => c.String());
            AlterColumn("dbo.Urunlers", "Barkod", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Urunlers", "Barkod", c => c.Int(nullable: false));
            DropColumn("dbo.Musterilers", "Telefon");
        }
    }
}
