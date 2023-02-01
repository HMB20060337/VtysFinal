namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ıslem_detay_ıslem_add_columns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Islem_Detay", "Miktar", c => c.Int(nullable: false));
            AddColumn("dbo.Islemlers", "Tutar", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Islemlers", "Tutar");
            DropColumn("dbo.Islem_Detay", "Miktar");
        }
    }
}
