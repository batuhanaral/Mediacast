namespace HaberAtolyesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Habers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        Konu = c.String(),
                        Fotograf = c.String(),
                        Create_Time = c.DateTime(nullable: false),
                        Update_Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Habers");
        }
    }
}
