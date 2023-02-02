namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class islemlerupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Islemlers", "OdemeYontemi", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Islemlers", "OdemeYontemi");
        }
    }
}
