namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecolumnFaturadbo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Faturas", "Tutar", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Faturas", "Tutar", c => c.Int(nullable: false));
        }
    }
}
