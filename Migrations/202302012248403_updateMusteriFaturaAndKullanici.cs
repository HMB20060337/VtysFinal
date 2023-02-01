namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMusteriFaturaAndKullanici : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faturas", "Tutar", c => c.Int(nullable: false));
            AddColumn("dbo.Faturas", "KullaniciId_KullaniciId", c => c.Int());
            AddColumn("dbo.Fatura_Detay", "miktar", c => c.Int(nullable: false));
            CreateIndex("dbo.Faturas", "KullaniciId_KullaniciId");
            AddForeignKey("dbo.Faturas", "KullaniciId_KullaniciId", "dbo.Kullanıcılar", "KullaniciId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Faturas", "KullaniciId_KullaniciId", "dbo.Kullanıcılar");
            DropIndex("dbo.Faturas", new[] { "KullaniciId_KullaniciId" });
            DropColumn("dbo.Fatura_Detay", "miktar");
            DropColumn("dbo.Faturas", "KullaniciId_KullaniciId");
            DropColumn("dbo.Faturas", "Tutar");
        }
    }
}
