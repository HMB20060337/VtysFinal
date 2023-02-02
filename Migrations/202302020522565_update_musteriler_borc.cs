namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_musteriler_borc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Musterilers", "Borc", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Musterilers", "Borc", c => c.Int(nullable: false));
        }
    }
}
