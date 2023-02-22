namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firmalar_borc_datatype_changed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Firmalars", "Borc", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Firmalars", "Borc", c => c.Int(nullable: false));
        }
    }
}
