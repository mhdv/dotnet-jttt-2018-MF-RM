namespace WpfApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JTTTdbs", "URL", c => c.String());
            AddColumn("dbo.JTTTdbs", "text", c => c.String());
            AddColumn("dbo.JTTTdbs", "mail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JTTTdbs", "mail");
            DropColumn("dbo.JTTTdbs", "text");
            DropColumn("dbo.JTTTdbs", "URL");
        }
    }
}
