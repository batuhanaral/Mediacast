namespace HaberAtolyesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Habers", "Ozet", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Habers", "Ozet");
        }
    }
}
