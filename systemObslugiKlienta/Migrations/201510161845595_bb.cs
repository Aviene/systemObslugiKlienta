namespace systemObslugiKlienta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CompanyName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CompanyName");
        }
    }
}
